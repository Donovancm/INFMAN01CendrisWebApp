using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfomationManagementCendrisWebApp.Controllers
{
    public class AskforHelpController : Controller
    {
        // GET: AskforHelp
        public ActionResult Index()
        {
            ViewBag.Message = "Opzetten van een activiteit";
            return View();
        }
        // GET: /AskforHelp/Dashboard
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Dashboard";

            return View();
        }
    }
}
