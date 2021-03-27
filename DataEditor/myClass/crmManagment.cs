using DataEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEditor.myClass
{
    public static class crmManagment
    {
        static CRM2008 dbcrm = new CRM2008();
        public static List<crm> get()
        {
            List<crm> Lcrm = new List<crm>();
            
            foreach(var item in dbcrm.CRM_Customer)
            {

                Lcrm.Add(new crm
                {
                    Id = item.id,
                    Name = item.NAME,
                    Number = item.MOBIL,
                    NationalCode = item.CodeMelli,
                });
                
            }
            return Lcrm;
        }
        public static List<crm> get(string serch)
        {
          List<crm> Lcrm = new List<crm>();
          Lcrm= get();
          Lcrm = Lcrm.Where(x => x.Name == serch||x.NationalCode.ToString()== serch||x.Number.ToString()== serch).ToList();
          return Lcrm;
        }
        public static bool add(crm Crm)
        {
            try
            {
                Random rand = new Random();
                var x = dbcrm.CRM_Customer.ToList();
                dbcrm.CRM_Customer.Add(new CRM_Customer
                {
                    NAME = Crm.Name,
                    MOBIL = Crm.Number,
                    CodeMelli = Crm.NationalCode,
                    SHS_ID = rand.Next(),
                    CartKind = "اشتراک",
                    Lottery=false,
                    Mos_id=0
                });
                var y = dbcrm.CRM_Customer.ToList();
                dbcrm.SaveChanges();
                return true;
            }

            catch (Exception error)

            {
                return false;

            }
        }
    }
}