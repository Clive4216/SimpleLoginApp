using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class LoginController : Controller
    {
        private const string Username = "Clive";
        private const string Password = "123";

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (model.Username == Username && model.Password == Password)
            {
                Session["Username"] = model.Username;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Invalid Username or Password";
                return View();
            }
        }

        public ActionResult Dashboard()
        {
            if (Session["Username"] == null)
                return RedirectToAction("Index");

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}