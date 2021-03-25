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
                    Number = Convert.ToInt32(item.MOBIL),
                    NationalCode = Convert.ToInt32(item.CodeMelli),
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
                dbcrm.CRM_Customer.Add(new CRM_Customer {
                    NAME = Crm.Name,
                    MOBIL = Crm.Number.ToString(),
                    CodeMelli = Crm.NationalCode.ToString(),
                    /*SHS_ID = 0,
                    CRM_log=1,
                    SalMaly=1,
                    CRM_SMSSender=1,*/
                    SendSMS        =false,
                    Lottery        =false,
                    SEX            =0,
                    TAHOL          =0,
                    ID_Company     =0,
                    Mos_id         =0,
                    CartKind       ="null2",
                    SHO            ="null2",
                    ADR            ="null2",
                    FAX            ="null2",
                    TOZIH          ="null2",
                    cod_Eshterak   ="null2",               
                    tar_tavalod    ="null2",
                    city           ="null2",
                    pas            ="null2",
                    tar_ez         ="null2",
                    mail           ="null2",
                    job            ="null2",
                    adder          ="null2",
                    editor         ="null2",
                    tar_s          ="null2",
                    FATHER         ="null2",
                    SCODE          ="null2",
                    HOMEPHONE      ="null2",
                    NAMEL          ="null2",
                    SSTNDRDCODE    ="null2",
                    SODOR          ="null2",
                    HOMECODE       ="null2",
                    WORKCODE       ="null2",
                    WORKADDR       ="null2",
                    WORKPHONE      ="null2",
                    bincart        ="null2",
                    binEXPDATE     ="null2",
                    binCVV2        ="null2",
                    tar_edit       ="null2",
                    tar_kasian_d   ="null2",
                    tar_kasian_t   ="null2",

                });
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