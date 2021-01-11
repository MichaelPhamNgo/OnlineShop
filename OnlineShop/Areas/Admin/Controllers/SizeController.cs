using Models.Dao;
using Models.Entities;
using Models.ViewModels;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SizeController : Controller
    {
        // GET: Admin/Size
        public ActionResult Index()
        {
            return View();
        }

        #region AJAX API
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = new SizeDao().GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllPaging(string keyword, int page, int pageSize)
        {
            var data = new SizeDao().GetAllPaging(keyword, page, pageSize);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var data = new SizeDao().GetById(id);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(Size size)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return View("_AddEditModal",allErrors);
            }
            else
            {
                var dao = new SizeDao();
                if (size.Id == 0)
                {                    
                    return Json(new { status = dao.Add(size) > 0 ? true : false }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { status = dao.Update(size) }, JsonRequestBehavior.AllowGet);                    
                }                                
            }
        }

        [HttpPost]
        public ActionResult Delete(long Id)
        {
            if (!ModelState.IsValid)
            {
                return View("_AddEditModal", ModelState);                
            }
            else
            {
                var dao = new SizeDao();
                return Json(new { status = dao.Delete(Id) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


    }
}
