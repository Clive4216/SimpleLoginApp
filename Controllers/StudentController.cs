﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Business;

namespace Login.Controllers
{
    public class StudentController : Controller
    {
        private readonly business _business;

        public StudentController()
        {
            _business = new business(new DB_Entities());
        }

        public ActionResult Index()
        {
            var students = _business.GetStudents();
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _business.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Edit(int id)
        {
            var student = _business.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _business.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public ActionResult Delete(int id)
        {
            _business.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}