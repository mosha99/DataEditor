using DataEditor.data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEditor.Models
{
    public class commoditys
    {
        public IPagedList<vw_Product> commoditys_list { get; set; }
    }

}