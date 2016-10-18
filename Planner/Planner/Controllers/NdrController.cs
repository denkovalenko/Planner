using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Domain;
using Domain.Models;
using Planner.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Helpers;

namespace Planner.Controllers
{
    [Authorize]
    public class NdrController : Controller
    {
        public NdrController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(NdrViewModel model)
        {
            if (ModelState.IsValid)
            {
                Session["message"] = null;
                return null;
            }
            Session["message"] = "Усi поля повиннi бути заповненi";
            return RedirectToAction("Index");
        }
    }
   
}