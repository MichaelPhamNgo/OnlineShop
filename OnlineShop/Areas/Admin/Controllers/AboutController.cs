﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        // GET: Admin/About
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/About/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/About/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/About/Create
        [HttpPost]
        public ActionResult Create(About abo)
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

        // GET: Admin/About/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/About/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, About abo)
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

        // GET: Admin/About/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/About/Delete/5
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
