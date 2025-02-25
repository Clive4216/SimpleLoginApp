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
        private const string Password = "123456789";

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (DB_Entities db = new DB_Entities())
                {
                    var obj = db.UserProfiles.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        return RedirectToAction("Dashboard");
                    }
                }
            }
            return View(objUser);
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