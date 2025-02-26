using System;
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

        // GET: Student
        public ActionResult Index()
        {
            var students = _business.DisplayAllStudents();
            return View(students);
        }
    }
}