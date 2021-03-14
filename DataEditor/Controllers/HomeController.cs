using DataEditor.Models;
using DataEditor.Properties;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Web.Security;
using DataEditor.myClass;
using System.Data.OleDb;
using System.Data;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace DataEditor.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult seting()
        {
            seting myseting = new seting();
            try
            {
                string path3 = Server.MapPath("~/App_Data/seting.txt");
                using (StreamReader JsonText = new StreamReader(path3, true))
                {

                    string Jsonstring = JsonText.ReadToEnd();
                    var serverSettings = JsonConvert.DeserializeObject<seting>(Jsonstring,
                    new JsonSerializerSettings());
                    myseting.SqlUsername = serverSettings.SqlUsername;
                    myseting.SqlPassword = serverSettings.SqlPassword;
                    myseting.urlServises = serverSettings.urlServises;
                    myseting.FiscalYear  = serverSettings.FiscalYear;                   
                    //var x5 = JsonSerializer.Deserialize<seting>(x4);

                }
                ViewBag.testconection = null;
                return View(myseting);

            }
            catch (Exception ex)
            {
                LogError(ex);
                return View(myseting);
            }



}
        [Authorize]
        [HttpPost]
        public ActionResult seting(seting myseting)
        {
            
            if (myseting.button == "save")
            {


                try
                {
                    string path3 = Server.MapPath("~/App_Data/seting.txt");
                    //FileStream file = new FileStream(path3, FileMode.Open);
                    System.IO.File.Delete(path3);
                    var s = System.IO.File.Exists(path3);
                    //System.IO.File.CreateText(path3);
                    using (StreamWriter writer = new StreamWriter(path3, true))
                    {
                        //FileStream fileStream = new FileStream(path3, FileMode.Open, FileAccess.Write);
                        writer.Write("");
                        string json = JsonConvert.SerializeObject(myseting);
                        writer.Write(json);
                        writer.Close();
                    }

                    myseting.error = false;
                    ViewBag.succes = true;
                    return View(myseting);
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    myseting.error = true;
                    ViewBag.succes = false;
                    return View(myseting);
                }
            }else if(myseting.button == "test")
            {
                try
                {
                    string path3 = Server.MapPath("~/App_Data/seting.txt");
                    using (StreamReader JsonText = new StreamReader(path3, true))
                    {

                        string Jsonstring = JsonText.ReadToEnd();
                        var serverSettings = JsonConvert.DeserializeObject<seting>(Jsonstring,new JsonSerializerSettings());    
                        bool succes = testconection(serverSettings);
                        ViewBag.testconection = "true";
                        return View(myseting);
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    ViewBag.testconection = "false";
                    return View(myseting);
                }
            }
            return View(myseting);
        }
        [Authorize]
        public ActionResult list(int? page)
        {   
            
            var x=Request;
            commoditys vlist = new commoditys();
            var list = dataManagment.getall();
            List<filtercs> storlist = new List<filtercs>();
            foreach (var item in list)
            {
                if (storlist.Where(d => d.stor_id == item.id_store).Count() == 0)
                {
                    storlist.Add(new filtercs { name = item.name_store, stor_id = item.id_store });
                }
                else
                    if (item.name_store != null || item.name_store != "")
                {
                    if (storlist.Where(d => d.stor_id == item.id_store).ToList()[0].name == null || storlist.Where(c => c.stor_id == item.id_store).ToList()[0].name == "")
                    {
                        storlist.Where(c => c.stor_id == item.id_store).ToList()[0].name = item.name_store;
                    }
                }

            }
            if (Request.QueryString["store1"] != null || Request.QueryString["example"] != null)
            {
                string store = Request.QueryString["store1"];
                string example = Request.QueryString["example"];
                ViewBag.store1 = store;
                ViewBag.example = example;
                if(store!="all") list = list.Where(s => s.id_store.ToString() == store).ToList();
                if(example == "on") list = list.Where(s => s.Amount > 0).ToList();
            }

            vlist.commoditys_list = list.ToPagedList(page ?? 1, 9);
            ViewBag.store = storlist;
            return View(vlist);
        }
        public bool testconection (seting myseting)
        {
            if (myseting.FiscalYear == 95)
            {
                throw new Exeptioncs("FiscalYear",myseting.FiscalYear.ToString());
            } 
            return false;

        }
        public ActionResult login()
        {
            login log = new login();
            log.url = Request.QueryString["ReturnUrl"];
            return View(log);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult login(login log)
        {
            string url = Request.QueryString["ReturnUrl"];
            if (log.password != "password")
            {
                ViewBag.error = "true";
                return View(log);
            }
            FormsAuthentication.SetAuthCookie("admin", true);
            return Redirect(log.url);
        }
        public ActionResult logout()
        {
            if (User.Identity.IsAuthenticated != false)
            {
                FormsAuthentication.SignOut();
            }
            return Redirect("index");
        }
        public ActionResult dbacsses()
        {

            return View();
        }
        private void LogError(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message      += Environment.NewLine;
            message      += "-----------------------------------------------------------";
            message      += Environment.NewLine;
            message      += string.Format("Message: {0}", ex.Message);
            message      += Environment.NewLine;
            message      += string.Format("StackTrace: {0}", ex.StackTrace);
            message      += Environment.NewLine;
            message      += string.Format("Source: {0}", ex.Source);
            message      += Environment.NewLine;
            message      += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message      += Environment.NewLine;
            message      += "-----------------------------------------------------------";
            message      += Environment.NewLine;
            string path   = Server.MapPath("~/ErrorLog/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }

            using (StreamReader writer = new StreamReader(path, true))
            {
                var x = writer.ToString();
            }
        }
        
    }
}