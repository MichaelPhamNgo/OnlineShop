var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var status = $(this);
            var id = status.data('id');
            $.ajax({
                url: "/Admin/Contact/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type:"POST",                
                success: function (response) {
                    console.log(response)
                    if (response.status == true) {
                        status.text("Processing");
                    } else {
                        status.text("Blocked");
                    }
                }
            });
        });
    }
}
contact.init();