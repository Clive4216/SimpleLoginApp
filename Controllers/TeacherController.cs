using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login.Business;

namespace Login.Controllers
{
    public class TeacherController : Controller
    {
        private readonly business _business;

        public TeacherController()
        {
            _business = new business(new DB_Entities());
        }

        public ActionResult Index()
        {
            //var teachers = _business.GetTeachers();
            //return View(teachers);
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Teacher")
            {
                return RedirectToAction("Unauthorized");
            }
            var teachers = _business.GetTeachers();
            return View(teachers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _business.AddTeacher(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public ActionResult Update(int id)
        {
            var teacher = _business.GetTeacherById(id);
            return View(teacher);
        }

        [HttpPost]
        public ActionResult Update(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _business.UpdateTeacher(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        public ActionResult Delete(int id)
        {
            _business.DeleteTeacher(id);
            return RedirectToAction("Index");
        }

        public ActionResult Unauthorized()
        {
            //return RedirectToAction("Unauthorized");
            return View();
        }

        public JsonResult GetTeachers()
        {
            var teachers = _business.GetTeachers().Select(t => new
            {
                t.name,
                t.subject_taught,
                t.email
            }).ToList();

            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _TeacherList()
        {
            var teachers = _business.GetTeachers();
            return PartialView(teachers);
        }
    }
}