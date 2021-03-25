using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataEditor.Models
{
    public class crm
    {
        public int Id { get;  set; }
        [Display(Name ="نام")]
        public string Name { get; set; }
        [Display(Name ="شماره تلفن")]
        public int Number { get; set; }
        [Display(Name ="کدملی")]
        public int NationalCode { get; set; }
    }
}