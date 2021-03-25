using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataEditor.Models
{
    public class crmList
    {
        public IPagedList<crm> list { get; set; }
    }
}