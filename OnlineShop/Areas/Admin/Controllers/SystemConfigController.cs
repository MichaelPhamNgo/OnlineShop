﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SystemConfigController : BaseController
    {
        // GET: Admin/SystemConfig
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/SystemConfig/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SystemConfig/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SystemConfig/Create
        [HttpPost]
        public ActionResult Create(SystemConfig sys)
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

        // GET: Admin/SystemConfig/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/SystemConfig/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SystemConfig sys)
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

        // GET: Admin/SystemConfig/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/SystemConfig/Delete/5
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
