//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataEditor
{
    using System;
    using System.Collections.Generic;
    
    public partial class CRM_SMSSender
    {
        public int SHS_ID { get; set; }
        public int ID { get; set; }
        public int ID_Customer { get; set; }
        public string tar { get; set; }
        public string matn { get; set; }
        public Nullable<int> vaz { get; set; }
        public Nullable<int> shs_id_ffo { get; set; }
        public string shs_id_ffo_name { get; set; }
    
        public virtual CRM_Customer CRM_Customer { get; set; }
        public virtual SalMaly SalMaly { get; set; }
    }
}
