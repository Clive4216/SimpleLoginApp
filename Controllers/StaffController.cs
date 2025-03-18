using System;
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
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Staff")
            {
                return RedirectToAction("Unauthorized");
            }
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

        public ActionResult Update(int id)
        {
            var staff = _business.GetStaffById(id);
            return View(staff);
        }

        [HttpPost]
        public ActionResult Update(Staff staff)
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

        public ActionResult Unauthorized()
        {
            return View();
        }

        public JsonResult GetStaff()
        {
            var staff = _business.GetStaff().Select(st => new
            {
                st.name,
                st.designation,
                st.salary
            }).ToList();

            return Json(staff, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _StaffList()
        {
            var staff = _business.GetStaff();
            return PartialView(staff);
        }
    }
}