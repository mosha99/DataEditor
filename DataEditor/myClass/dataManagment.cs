using DataEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEditor.myClass
{
    public static class dataManagment
    {
        static MasterSET2008Entities db = new MasterSET2008Entities();
        public static List<vw_Product> getall()
        {
            List<vw_Product> list = db.vw_Product.ToList();

            return list;
        }
    }
}