using DataEditor.Models;
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
            seting myseting = new seting();
            myseting.password = "";
            myseting.SqlUsername = Properties.Settings.Default.SqlUsername;
            myseting.SqlPassword = Properties.Settings.Default.SqlPassword;
            myseting.urlServises = Properties.Settings.Default.urlServises;
            myseting.FiscalYear = Properties.Settings.Default.FiscalYear;
            return View(myseting);





        }
        [HttpPost]
        public ActionResult seting(seting myseting)
        {
            Properties.Settings.Default["SqlUsername"] = myseting.SqlUsername;
            Properties.Settings.Default["SqlPassword"] = myseting.SqlPassword;
            Properties.Settings.Default["FiscalYear"] = myseting.FiscalYear;
            Properties.Settings.Default["urlServises"] = myseting.urlServises;
            //  Properties.Settings.Default.SqlPassword = "sdfasf";
            Properties.Settings.Default.Save();
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