using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Register(String username)
        {
            if (Request.IsAuthenticated)
            {
                if (username != null)
                {
                    ViewBag.userAdd = "User " + username + " has been added";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}