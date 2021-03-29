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
using DataEditor.ErrorLog;
using DataEditor.data;

namespace DataEditor.Controllers
{


    public static class selectlist
    {
        public static List<vw_Product> list;

    }
    public static class query
    {
        private static crmList list ;
        private static bool succes ;
        private static string serch ;
        public static void set(crmList input,string _serch ,bool _succes)
        {
            serch = _serch;
            succes = _succes;
            list = input;
        }
        public static crmList get()
        {
           return list;
        }
        public static bool getb()
        {
            return succes;
        }
        public static string gets()
        {
            return serch;
        }

    }
    public class HomeController : Controller
    {
        public  string getpath()
        {
            string path=Server.MapPath("~/ErrorLog/ErrorLog.txt");
            return path;
        }

        public ActionResult Index()
        {
            ViewBag.Authenticated = User.Identity.IsAuthenticated;
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
                errors.LogError(ex, getpath());
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
                    errors.LogError(ex, getpath());
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
                    errors.LogError(ex, getpath());
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
            selectlist.list = null;
            selectlist.list = list;
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
        [Authorize]
        public ActionResult addCRM()
        {

            ViewBag.error = false;
            ViewBag.succes = false;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult addCRM(crm Crm)
        {
            bool f;
            if (ModelState.IsValid)
            {
                 f=crmManagment.add(Crm,getpath());
            }
            else
            {
                f = false;
            }
            
            ViewBag.error = !f;
            ViewBag.succes = f;
            return View();
        }
        [Authorize]
        public ActionResult serchCRM(int?page,string serch)
        {
            crmList list = new crmList();
            if (query.get() == null)
            {
                ViewBag.succes = false;
                ViewBag.error = false;

                if (page == null)
                {
                    ViewBag.page = 1;
                }
                else
                {
                    ViewBag.page = page;
                }
                if (!string.IsNullOrEmpty(serch))
                {
                    ViewBag.serch = serch;
                }
                
                List<crm> Lcrm = new List<crm>();
                if (string.IsNullOrEmpty(serch))
                {
                    Lcrm = crmManagment.get();
                }
                else
                {
                    Lcrm = crmManagment.get(serch);
                }
                list.list = Lcrm.ToPagedList(page ?? 1, 6);

            }
            else
            {
                list = query.get();
                ViewBag.serch = query.gets();
                ViewBag.succes = query.getb();
                ViewBag.error = !query.getb();
                query.set(null, null, false);
            }
                return View(list);
        }
        [Authorize]
        public ActionResult deletCrm(int?page,int id,string serch)
        {
            bool succes=crmManagment.delete(id,getpath());
            ViewBag.succes = succes;
            ViewBag.error = !succes;
            if (!string.IsNullOrEmpty(serch))
            {
                ViewBag.serch = serch;
            }
            crmList list = new crmList();
            List<crm> Lcrm = new List<crm>();
            if (string.IsNullOrEmpty(serch))
            {
                Lcrm = crmManagment.get();
            }
            else
            {
                Lcrm = crmManagment.get(serch);
            }
            list.list = Lcrm.ToPagedList(page ?? 1, 9);
            query.set(list,serch,succes);
            return Redirect("serchCRM");
        }
        
    }
}








