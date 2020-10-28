﻿using Models.Dao;
using Models.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class TagController : BaseController
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
            var dao = new TagDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(long id)
        {
            var dao = new TagDao();
            return View(dao.GetJoinById(id));
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
        public ActionResult Create(Tag tag)
        {
            //Gọi lớp Models/Dao/CategoryDao.cs
            var dao = new TagDao();

            string tagName = string.Empty;

            //Kiểm tra trường hợp category name bị để trống
            if (tag.Name == null)
            {
                ModelState.AddModelError("Name", "Please input tag name.");
            }
            else
            {
                tagName = tag.Name.Trim();
                if (tagName.Length > 250 || tagName.Length < 3) // Kiểm tra trường hợp category name chỉ có ít hơn 3 kí tự hoặc nhiều hơn 250 ký tự
                {
                    ModelState.AddModelError("Name", "The tag name is 3 to 250 characters.");
                }
                else
                {
                    //Truy xuất dữ liệu category name
                    var tagDetail = dao.GetByName(tagName);

                    //Nếu category name đã tồn tại thì báo lỗi
                    if (tagDetail != null)
                    {
                        ModelState.AddModelError("Name", "The tag name exists in database.");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                tag.Name = tagName;
                //Lưu ngày giờ tạo mới một category
                tag.CreatedDate = DateTime.UtcNow;
                //Lưu lại người tạo mới một category
                tag.CreatedBy = ((UserLogin)Session[CommonConstants.USER_SESSION]).UserId;
                //Lưu ngày giờ tạo mới một category
                tag.ModifiedDate = DateTime.UtcNow;
                //Lưu lại người tạo mới một category
                tag.ModifiedBy = ((UserLogin)Session[CommonConstants.USER_SESSION]).UserId;
                //Lưu lại trạng thái của category
                tag.Status = true;
                //Lưu category vào hệ thống
                long id = dao.Insert(tag);
                //Lưu cateogry vào hệ thống thành công
                if (id > 0)
                {
                    TempData["SuccessMessage"] = "Create A New Tag Successful";
                    return RedirectToAction("Create", "Tag");
                }
                else
                {
                    TempData["ErrorMessage"] = "Create A New Tag failed";
                    return RedirectToAction("Create", "Tag");
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
                return RedirectToAction("Index", "Tag");
            }
            else
            {
                var dao = new TagDao();
                var tag = dao.GetById(id);
                if (tag == null)
                {
                    TempData["ErrorMessage"] = "Tag " + id + " does not exist!";
                    return RedirectToAction("Index", "Tag");
                }
                else
                {                    
                    return View(tag);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cat"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            //Gọi lớp Models/Dao/CategoryDao.cs
            var dao = new TagDao();

            string tagName = string.Empty;            

            //Kiểm tra sự tồn tại của category id
            var checkExistTag = dao.GetById(tag.Id);
            if (checkExistTag == null)
            {
                ModelState.AddModelError("ErrorMessage", "Update tag failed.");
            }

            //Kiểm tra trường hợp category name bị để trống
            if (tag.Name == null)
            {
                ModelState.AddModelError("Name", "Please input tag name.");
            }
            else if (tag.Name.Length > 250 || tag.Name.Length < 3) // Kiểm tra trường hợp category name chỉ có ít hơn 3 kí tự hoặc nhiều hơn 250 ký tự
            {
                ModelState.AddModelError("Name", "The tag name is 3 to 250 characters.");
            }
            else
            {
                tagName = tag.Name.Trim();
                //Kiểm tra trường hợp nếu lưu category name mới. Nếu đã tồi tại rồi thì thông báo
                if (!tagName.Equals(checkExistTag.Name))
                {
                    //Truy xuất dữ liệu category name
                    var tagDetail = dao.GetByName(tagName);

                    //Nếu category name đã tồn tại thì báo lỗi
                    if (tagDetail != null)
                    {
                        ModelState.AddModelError("Name", "The tag name exists in database.");
                    }
                }
            }

            if (ModelState.IsValid)
            {
                tag.Name = tagName;
                //Lưu ngày giờ tạo mới một category
                tag.ModifiedDate = DateTime.UtcNow;
                //Lưu lại người tạo mới một category
                tag.ModifiedBy = ((UserLogin)Session[CommonConstants.USER_SESSION]).UserId;
                //Lưu category vào hệ thống
                bool update = dao.Update(tag);
                //Lưu cateogry vào hệ thống thành công
                if (update)
                {
                    TempData["SuccessMessage"] = "Update Category Successful";
                    return RedirectToAction("Edit", "Category", new RouteValueDictionary(new { id = tag.Id }));
                }
                else
                {
                    TempData["ErrorMessage"] = "Update Category failed";
                    return RedirectToAction("Edit", "Category", new RouteValueDictionary(new { id = tag.Id }));
                }
            }            
            return View(tag);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new TagDao().ChangeStatus(id);
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
            var dao = new TagDao();
            var delSuccess = dao.Delete(id);
            if (delSuccess)
            {
                TempData["SuccessMessage"] = "Delete tag successful";
            }
            else
            {
                TempData["ErrorMessage"] = "Delete tag failed";
            }
            return RedirectToAction("Index");
        }
    }
}
