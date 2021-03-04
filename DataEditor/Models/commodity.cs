using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEditor.Models
{
    public class commodity
    {
        public int id { get; set; }
        public string name { get; set; }
        public int id_Store { get; set; }
        public string name_Store { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
    }
}