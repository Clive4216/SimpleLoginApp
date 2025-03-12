using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class NavigationController : Controller
    {
        public class NavigationItem
        {
            public string Text { get; set; }
            public string Url { get; set; }
        }

        public JsonResult GetNavigationItems()
        {
            var userRole = Session["UserRole"]?.ToString();
            var navigationItems = new List<NavigationItem>();

            if (userRole == "Student")
            {
                navigationItems.Add(new NavigationItem { Text = "Student", Url = Url.Action("Index", "Student") });
            }
            else if (userRole == "Teacher")
            {
                navigationItems.Add(new NavigationItem { Text = "Teacher", Url = Url.Action("Index", "Teacher") });
            }
            else if (userRole == "Staff")
            {
                navigationItems.Add(new NavigationItem { Text = "Staff", Url = Url.Action("Index", "Staff") });
            }

            return Json(navigationItems, JsonRequestBehavior.AllowGet);
        }
    }
}