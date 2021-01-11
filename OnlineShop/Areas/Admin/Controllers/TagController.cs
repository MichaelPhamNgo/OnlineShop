using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        // GET: Admin/Tag
        public ActionResult Index(string keyword, string sort = "decs", int pageSize = 10, int page = 1)
        {
            //ViewBag.KeyWord = keyword;
            //if (sort.Equals("asc"))
            //{
            //    sort = "decs";
            //}
            //else
            //{
            //    sort = "asc";
            //}
            //ViewBag.Sort = sort;
            //ViewBag.Page = page;
            //ViewBag.PageSize = pageSize;

            //var dao = new TagDao();
            //var model = dao.listAllPaging(searchString, sortByType, sorting, searchPageSize, searchPage);
            //var totalRows = dao.totalRows(searchString);
            //if (totalRows == 0)
            //{
            //    ViewBag.SearchRolePageDisplay = 0;
            //}
            //else
            //{
            //    ViewBag.SearchRolePageDisplay = (searchPage - 1) * searchPageSize + 1;
            //}

            //var pageRange = searchPage * searchPageSize;
            //if (totalRows > (pageRange))
            //    ViewBag.SearchTagPageSizeDisplay = pageRange;
            //else
            //    ViewBag.SearchTagPageSizeDisplay = totalRows;
            //ViewBag.TotalTagDisplay = totalRows;

            //return View(model);
            return View();
        }        
    }
}
