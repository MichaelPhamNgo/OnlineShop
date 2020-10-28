using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
            ViewBag.SearchName = searchString;
            var dao = new ContactDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(long? id)
        {
            var dao = new ContactDao();
            return View(dao.GetById(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
            return View();
        }

        /// <summary>
        /// Tạo mới một category trong database
        /// </summary>
        /// <param name="cat">dữ liệu category được submit từ browser</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Contact cont)
        {
            //Gọi lớp Models/Dao/CategoryDao.cs
            var dao = new ContactDao();

            string contDetail = string.Empty;            

            //Kiểm tra trường hợp category name bị để trống
            if (cont.Detail == null)
            {
                ModelState.AddModelError("Name", "Please input contact detail.");
            }
            else
            {
                contDetail = cont.Detail.Trim();
                if (contDetail.Length > 250 || contDetail.Length < 3) // Kiểm tra trường hợp category name chỉ có ít hơn 3 kí tự hoặc nhiều hơn 250 ký tự
                {
                    ModelState.AddModelError("Name", "The contact detail is 3 to 250 characters.");
                }
                else
                {
                    //Truy xuất dữ liệu category name
                    var contactDetail = dao.GetByDetail(contDetail);

                    //Nếu category name đã tồn tại thì báo lỗi
                    if (contactDetail != null)
                    {
                        ModelState.AddModelError("Name", "The contact detail exists in database.");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                cont.Detail = contDetail;
                //Lưu lại trạng thái của category
                cont.Status = true;
                //Lưu category vào hệ thống
                long id = dao.Insert(cont);
                //Lưu cateogry vào hệ thống thành công
                if (id > 0)
                {
                    TempData["SuccessMessage"] = "Create A New Contact Successful";
                    return RedirectToAction("Create", "Contact");
                }
                else
                {
                    TempData["ErrorMessage"] = "Create A New Contact failed";
                    return RedirectToAction("Create", "Contact");
                }
            }            
            return View("Create");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(long? id)
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;

            if (id == null)
            {
                TempData["ErrorMessage"] = "URL does not exist!";
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                var dao = new ContactDao();
                var cont = dao.GetById(id);
                if (cont == null)
                {
                    TempData["ErrorMessage"] = "Contact " + id + " does not exist!";
                    return RedirectToAction("Index", "Contact");
                }
                else
                {                    
                    return View(cont);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Contact cont)
        {
            //Gọi lớp Models/Dao/CategoryDao.cs
            var dao = new ContactDao();

            string contDetail = string.Empty;

            //Kiểm tra sự tồn tại của category id
            var checkExistContact = dao.GetById(cont.Id);
            if (checkExistContact == null)
            {
                ModelState.AddModelError("ErrorMessage", "Update contact failed.");
            }

            //Kiểm tra trường hợp category name bị để trống
            if (cont.Detail == null)
            {
                ModelState.AddModelError("Name", "Please input contact detail.");
            }
            else if (cont.Detail.Length > 250 || cont.Detail.Length < 3) // Kiểm tra trường hợp category name chỉ có ít hơn 3 kí tự hoặc nhiều hơn 250 ký tự
            {
                ModelState.AddModelError("Name", "The contact detail is 3 to 250 characters.");
            }
            else
            {
                contDetail = cont.Detail.Trim();
                //Kiểm tra trường hợp nếu lưu category name mới. Nếu đã tồi tại rồi thì thông báo
                if (!contDetail.Equals(checkExistContact.Detail))
                {
                    //Truy xuất dữ liệu category name
                    var contactDetail = dao.GetByDetail(contDetail);

                    //Nếu category name đã tồn tại thì báo lỗi
                    if (contactDetail != null)
                    {
                        ModelState.AddModelError("Name", "The contact detail exists in database.");
                    }
                }
            }            

            if (ModelState.IsValid)
            {
                cont.Detail = contDetail;                
                //Lưu category vào hệ thống
                bool update = dao.Update(cont);
                //Lưu cateogry vào hệ thống thành công
                if (update)
                {
                    TempData["SuccessMessage"] = "Update Contact Successful";
                    return RedirectToAction("Edit", "Contact", new RouteValueDictionary(new { id = cont.Id }));
                }
                else
                {
                    TempData["ErrorMessage"] = "Update Contact failed";
                    return RedirectToAction("Edit", "Contact", new RouteValueDictionary(new { id = cont.Id }));
                }
            }            
            return View(cont);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ContactDao().ChangeStatus(id);
            return Json(new { status = result });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(long? id)
        {
            var dao = new ContactDao();
            var delSuccess = dao.Delete(id);
            if (delSuccess)
            {
                TempData["SuccessMessage"] = "Delete Contact successful";
            }
            else
            {
                TempData["ErrorMessage"] = "Delete Contact failed";
            }
            return RedirectToAction("Index");
        }
    }
}
