using DataEditor.Models;
using DataEditor.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.IO;

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
            try
            { 
                myseting.password    = "";
                myseting.SqlUsername = Properties.Settings.Default.SqlUsername;
                myseting.SqlPassword = Properties.Settings.Default.SqlPassword;
                myseting.urlServises = Properties.Settings.Default.urlServises;
                myseting.FiscalYear  = Properties.Settings.Default.FiscalYear;
                return View(myseting);

            }
            catch (Exception ex)
            {
                LogError(ex);
                return View(myseting);
            }



}
        [HttpPost]
        public ActionResult seting(seting myseting)
        {

            try
            { 
                Settings.Default["SqlUsername"] = myseting.SqlUsername;
                Settings.Default["SqlPassword"] = myseting.SqlPassword;
                Settings.Default["FiscalYear"]  = myseting.FiscalYear;
                Settings.Default["urlServises"] = myseting.urlServises;
                /*Settings.Default.urlServises = "MyUserValue";*/
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();
                myseting.error = false;
                return View(myseting);
            }          
            catch (Exception ex)
            {
                LogError(ex);
                myseting.error = true;
                return View(myseting);
            }

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
        private void LogError(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("~/ErrorLog/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

    }
}