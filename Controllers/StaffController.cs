﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Business;

namespace Login.Controllers
{
    public class StaffController : Controller
    {
        private readonly business _business;
        public StaffController()
        {
            _business = new business(new DB_Entities());
        }

        // GET: Staff
        public ActionResult Index()
        {
            var staff = _business.GetStaff();
            return View(staff);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _business.AddStaff(staff);
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        public ActionResult Edit(int id)
        {
            var staff = _business.GetStaffById(id);
            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _business.UpdateStaff(staff);
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        public ActionResult Delete(int id)
        {
            _business.DeleteStaff(id);
            return RedirectToAction("Index");
        }
    }
}