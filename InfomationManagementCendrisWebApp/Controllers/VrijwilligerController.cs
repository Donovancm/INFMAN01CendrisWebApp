using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfomationManagementCendrisWebApp.Controllers
{
    public class VrijwilligerController : Controller
    {
        // GET: /Vrijwilliger/
        public ActionResult Index()
        {
            ViewBag.Message = "Vrijwilliger boiiii";

            return View();
        }

        // GET: /Vrijwilliger/Dashboard
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Dashboard";

            return View();
        }
    }
}

