﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataEditor.data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CRM2008Entities : DbContext
    {
        public CRM2008Entities()
            : base("name=CRM2008Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CRM_Agreement> CRM_Agreement { get; set; }
        public virtual DbSet<CRM_Company> CRM_Company { get; set; }
        public virtual DbSet<CRM_Customer> CRM_Customer { get; set; }
        public virtual DbSet<CRM_Discount> CRM_Discount { get; set; }
        public virtual DbSet<CRM_log> CRM_log { get; set; }
        public virtual DbSet<CRM_Setting> CRM_Setting { get; set; }
        public virtual DbSet<CRM_SMSSender> CRM_SMSSender { get; set; }
        public virtual DbSet<db_info> db_info { get; set; }
        public virtual DbSet<karbar> karbars { get; set; }
        public virtual DbSet<SalMaly> SalMalies { get; set; }
        public virtual DbSet<SHerkat> SHerkats { get; set; }
    }
}
