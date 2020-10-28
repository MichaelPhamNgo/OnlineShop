﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Content/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Content/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Content/Create
        [HttpPost]
        public ActionResult Create(Content cont)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Content/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Content/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Content cont)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Content/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Content/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
