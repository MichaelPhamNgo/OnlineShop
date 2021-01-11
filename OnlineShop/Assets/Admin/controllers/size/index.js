var sizeController = function () {
    this.initialize = function () {
        //Load data
        loadData();
        registerEvents();
    }

    function registerEvents() {
        //Init validation
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],            
            rules: {
                txtNameM: { required: true }
            }
        });

        $('#ddlShowPage').on('change', function () {
            webapp.configs.pageSize = $(this).val();
            webapp.configs.pageIndex = 1;
            loadData(true);
        });

        //Search Event
        $('#btnSearch').on('click', function () {
            loadData();
        });

        //Create Event
        $("#btnCreate").on('click', function () {
            resetFormMaintainance();
            initTreeDropDownCategory();
            $('#modal-add-edit').modal('show');
        });

        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                loadData();
            }
        });

        $('#btnSave').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = $('#hidIdM').val();
                var name = $('#txtNameM').val();   
                $.ajax({
                    type: "POST",
                    url: "/Admin/Size/Save",
                    data: {
                        Id: id,
                        Name: name                        
                    },
                    dataType: "json",
                    beforeSend: function () {
                        webapp.startLoading();
                    },
                    success: function (response) {
                        webapp.notify('Update product successful', 'success');
                        $('#modal-add-edit').modal('hide');
                        resetFormMaintainance();
                        webapp.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        webapp.notify('Has an error in save product progress', 'error');
                        webapp.stopLoading();
                    }
                });
                return false;
            }

        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "/Admin/Size/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    webapp.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    $('#modal-add-edit').modal('show');
                    webapp.stopLoading();
                },
                error: function (status) {
                    webapp.notify('Có lỗi xảy ra', 'error');
                    webapp.stopLoading();
                }
            });
        });

        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            webapp.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Size/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        webapp.startLoading();
                    },
                    success: function (response) {
                        webapp.notify('Delete successful', 'success');
                        webapp.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        webapp.notify('Has an error in delete progress', 'error');
                        webapp.stopLoading();
                    }
                });
            });
        });

    }

    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');
    }

    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: "/Admin/size/GetAll",
            type: 'GET',
            dataType: 'json',            
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name                        
                    });
                });
            }
        });
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            data: {
                keyword: $('#txtKeyword').val(),
                page: webapp.configs.pageIndex,
                pageSize: webapp.configs.pageSize
            },
            url: '/admin/size/GetAllPaging',
            dataType: 'json',
            success: function (response) {                
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name                        
                    });
                    $('#lblTotalRecords').text(response.RowCount);
                    if (render != '') {
                        $('#tbl-content').html(render);
                    }
                    wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                });
            },
            error: function (status) {
                console.log(status);
                webapp.notify('Cannot loading data', 'error');
            }
        });
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / webapp.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'First',
            prev: 'Previous',
            next: 'Next',
            last: 'Last',
            onPageClick: function (event, p) {
                webapp.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}