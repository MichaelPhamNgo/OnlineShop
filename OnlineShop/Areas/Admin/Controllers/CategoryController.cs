using Models.Dao;
using Models.EF;
using OnlineShop.Common;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {        
        public ActionResult Index(string searchName, string searchMetaTitle,
                                    string searchDateFrom, string searchDateTo, 
                                        string searchCreator, string searchStatus, 
                                            int page = 1, int pageSize = 10)
        {
            ViewBag.DeleteCategorySuccessMessage = TempData["DeleteCategorySuccessMessage"] as string;
            ViewBag.DeleteCategoryErrorMessage = TempData["DeleteCategoryErrorMessage"] as string;
            ViewBag.SearchName = searchName;
            ViewBag.SearchMetaTitle = searchMetaTitle;
            ViewBag.SearchDateFrom = searchDateFrom;
            ViewBag.SearchDateTo = searchDateTo;
            ViewBag.SearchCreator = searchCreator;
            ViewBag.SearchStatus = searchStatus;

            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchName, searchMetaTitle, searchDateFrom, 
                                            searchDateTo, searchCreator, searchStatus,
                                                page, pageSize);
            return View(model);
        }

        [HttpPost]
        public JsonResult GetCreatorByUserName(string UserName)
        {
            using (OnlineShopDbContext db = new OnlineShopDbContext())
            {
                var username = (from user in db.Users
                             where user.UserName.StartsWith(UserName)
                             select new { label = user.UserName }).ToList();
                return Json(username);
            }
        }


        public ActionResult Detail(long? id)
        {
            var dao = new CategoryDao();
            var model = dao.GetJoinById(id);
            if(model == null)
            {
                return RedirectToAction("Index", "Category");
            }
            return View(model);
        }
                
        public ActionResult Create()
        {
            ViewBag.CreateCategorySuccessMessage = TempData["CreateCategorySuccessMessage"] as string;
            ViewBag.CreateCategoryErrorMessage = TempData["CreateCategoryErrorMessage"] as string;            
            SetViewBag();
            return View();
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.ParentId = new SelectList(dao.ListAll(), "Id", "Name", selectedId);
        }

        [HttpPost]
        public ActionResult Create(Category cat)
        {
            //Gọi lớp Models/Dao/CategoryDao.cs
            var dao = new CategoryDao();

            string catName = string.Empty;
            string catSeoTitle = string.Empty;
            string catMetaTitle = string.Empty;
            string catMetaKeywords = string.Empty;
            string catMetaDescription = string.Empty;     

            //Kiểm tra trường hợp category name bị để trống
            if (cat.Name == null)
            {
                ModelState.AddModelError("Name", "Please input category name.");
            } else
            {
                catName = cat.Name.Trim();
                if (catName.Length > 250 || catName.Length < 3) // Kiểm tra trường hợp category name chỉ có ít hơn 3 kí tự hoặc nhiều hơn 250 ký tự
                {
                    ModelState.AddModelError("Name", "The category name is 3 to 250 characters.");
                }
                else
                {
                    //Truy xuất dữ liệu category name
                    var categoryName = dao.GetByName(catName);

                    //Nếu category name đã tồn tại thì báo lỗi
                    if (categoryName != null)
                    {
                        ModelState.AddModelError("Name", "The category name exists in database.");
                    }
                }
            }

            //Loại bỏ những ký tự rỗng
            if(cat.SeoTitle != null)
            {
                catSeoTitle = cat.SeoTitle.Trim();
            }

            //Loại bỏ những ký tự rỗng
            if (cat.MetaTitle != null)
            {
                catMetaTitle = cat.MetaTitle.Trim();
            }

            //Loại bỏ những ký tự rỗng
            if (cat.MetaKeywords != null)
            {
                catMetaKeywords = cat.MetaKeywords.Trim();
            }

            //Loại bỏ những ký tự rỗng
            if (cat.MetaDescription != null)
            {
                catMetaDescription = cat.MetaDescription.Trim();
            }

            if (ModelState.IsValid)
            {
                cat.Name = catName;
                cat.SeoTitle = catSeoTitle;
                cat.MetaTitle = catMetaTitle;
                cat.MetaKeywords = catMetaKeywords;
                cat.MetaDescription = catMetaDescription;                
                //Lưu ngày giờ tạo mới một category
                cat.CreatedDate = DateTime.UtcNow;
                //Lưu lại người tạo mới một category
                cat.CreatedBy = ((UserLogin)Session[CommonConstants.USER_SESSION]).UserId;
                //Lưu ngày giờ tạo mới một category
                cat.ModifiedDate = DateTime.UtcNow;
                //Lưu lại người tạo mới một category
                cat.ModifiedBy = ((UserLogin)Session[CommonConstants.USER_SESSION]).UserId;
                //Lưu lại trạng thái của category
                cat.Status = true;
                //Lưu category vào hệ thống
                long id = dao.Insert(cat);
                //Lưu cateogry vào hệ thống thành công
                if (id > 0)
                {
                    TempData["CreateCategorySuccessMessage"] = "Create A New Category Successful";
                    return RedirectToAction("Create", "Category");
                }
                else
                {
                    TempData["CreateCategoryErrorMessage"] = "Create A New Category failed";
                    return RedirectToAction("Create", "Category");
                }               
            }
            SetViewBag();
            return View("Create");
        }        

        public ActionResult Edit(long? id)
        {
            ViewBag.EditCategorySuccessMessage = TempData["EditCategorySuccessMessage"] as string;
            ViewBag.EditCategoryErrorMessage = TempData["EditCategoryErrorMessage"] as string;

            if (id == null)
            {
                TempData["EditCategoryErrorMessage"] = "URL does not exist!";
                return RedirectToAction("Index", "Category");
            }
            else
            {
                var dao = new CategoryDao();
                var cat = dao.GetById(id);
                if (cat == null)
                {
                    TempData["EditCategoryErrorMessage"] = "Category " + id + " does not exist!";
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    SetViewBag(cat.ParentId);
                    return View(cat);
                }
            }            
        }

        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            //Gọi lớp Models/Dao/CategoryDao.cs
            var dao = new CategoryDao();

            string catName = string.Empty;
            string catSeoTitle = string.Empty;
            string catMetaTitle = string.Empty;
            string catMetaKeywords = string.Empty;
            string catMetaDescription = string.Empty;

            //Kiểm tra sự tồn tại của category id
            var checkExistCategory = dao.GetById(cat.Id);
            if (checkExistCategory == null)
            {
                ModelState.AddModelError("EditCategoryErrorMessage", "Update category failed.");
            }

            //Kiểm tra trường hợp category name bị để trống
            if (cat.Name == null)
            {
                ModelState.AddModelError("Name", "Please input category name.");
            }
            else if (cat.Name.Length > 250 || cat.Name.Length < 3) // Kiểm tra trường hợp category name chỉ có ít hơn 3 kí tự hoặc nhiều hơn 250 ký tự
            {
                ModelState.AddModelError("Name", "The category name is 3 to 250 characters.");
            }
            else
            {
                catName = cat.Name.Trim();
                //Kiểm tra trường hợp nếu lưu category name mới. Nếu đã tồi tại rồi thì thông báo
                if (!catName.Equals(checkExistCategory.Name))
                {
                    //Truy xuất dữ liệu category name
                    var categoryName = dao.GetByName(catName);

                    //Nếu category name đã tồn tại thì báo lỗi
                    if (categoryName != null)
                    {
                        ModelState.AddModelError("Name", "The category name exists in database.");
                    }
                }                
            }

            //Kiểm tra sự tồn tại của parent of category
            if(cat.ParentId != null)
            {
                //Kiểm tra sự tồn tại của category id
                var checkExistParentCategory = dao.GetById(cat.ParentId);
                if (checkExistParentCategory == null)
                {
                    ModelState.AddModelError("EditCategoryErrorMessage", "Update category failed.");
                }
            }

            if(cat.Id == cat.ParentId)
            {
                ModelState.AddModelError("EditCategoryErrorMessage", "Category and its parent have the same id.");
            }

            //Loại bỏ những ký tự rỗng
            if (cat.SeoTitle != null)
            {
                catSeoTitle = cat.SeoTitle.Trim();
            }

            //Loại bỏ những ký tự rỗng
            if (cat.MetaTitle != null)
            {
                catMetaTitle = cat.MetaTitle.Trim();
            }

            //Loại bỏ những ký tự rỗng
            if (cat.MetaKeywords != null)
            {
                catMetaKeywords = cat.MetaKeywords.Trim();
            }

            //Loại bỏ những ký tự rỗng
            if (cat.MetaDescription != null)
            {
                catMetaDescription = cat.MetaDescription.Trim();
            }

            if (ModelState.IsValid)
            {
                cat.Name = catName;
                cat.SeoTitle = catSeoTitle;
                cat.MetaTitle = catMetaTitle;
                cat.MetaKeywords = catMetaKeywords;
                cat.MetaDescription = catMetaDescription;
                //Lưu ngày giờ tạo mới một category
                cat.ModifiedDate = DateTime.UtcNow;
                //Lưu lại người tạo mới một category
                cat.ModifiedBy = ((UserLogin)Session[CommonConstants.USER_SESSION]).UserId;                
                //Lưu category vào hệ thống
                bool update = dao.Update(cat);
                //Lưu cateogry vào hệ thống thành công
                if (update)
                {
                    TempData["EditCategorySuccessMessage"] = "Update Category Successful";
                    return RedirectToAction("Edit", "Category", new RouteValueDictionary( new { id = cat.Id }));
                }
                else
                {
                    TempData["EditCategoryErrorMessage"] = "Update Category failed";
                    return RedirectToAction("Edit", "Category", new RouteValueDictionary(new { id = cat.Id }));
                }
            }
            SetViewBag(cat.ParentId);
            return View(cat);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new CategoryDao().ChangeStatus(id);
            return Json(new { status = result});
        }

        [HttpDelete]
        public ActionResult Delete(long? id)
        {            
            var dao = new CategoryDao();
            var delSuccess = dao.Delete(id);
            if (delSuccess)
            {
                TempData["DeleteCategorySuccessMessage"] = "Delete category successful";
            }
            else
            {
                TempData["DeleteCategoryErrorMessage"] = "Delete category failed";
            }
            return RedirectToAction("Index");
        }
    }
}
