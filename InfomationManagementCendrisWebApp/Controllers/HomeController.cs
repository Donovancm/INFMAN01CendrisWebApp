﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfomationManagementCendrisWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Wie zijn wij";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact";

            return View();
        }

        public ActionResult AskForHelp()
        {
            ViewBag.Message = "Hulp Nodig?";

            return View();
        }
        public ActionResult Activiteiten()
        {
            ViewBag.Message = "Beschikbare Activiteiten";

            return View();
        }
    }
}