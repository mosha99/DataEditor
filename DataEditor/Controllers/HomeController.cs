using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataEditor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult seting()
        {
            return View();
        }

        public ActionResult list()
        {
            return View();
        }
        public ActionResult serch()
        {
            return View();
        }
        public ActionResult Ajaxserch()
        {
            return PartialView();
        }

    }
}