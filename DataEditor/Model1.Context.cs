﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MasterSET2008Entities : DbContext
    {
        public MasterSET2008Entities()
            : base("name=MasterSET2008Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ffo> ffoes { get; set; }
        public virtual DbSet<ffoa> ffoas { get; set; }
        public virtual DbSet<fkh> fkhs { get; set; }
        public virtual DbSet<fkha> fkhas { get; set; }
        public virtual DbSet<mfo> mfoes { get; set; }
        public virtual DbSet<mkh> mkhs { get; set; }
        public virtual DbSet<pfa> pfas { get; set; }
        public virtual DbSet<vw_Buy> vw_Buy { get; set; }
        public virtual DbSet<vw_BuyList> vw_BuyList { get; set; }
        public virtual DbSet<vw_Ccustomer> vw_Ccustomer { get; set; }
        public virtual DbSet<vw_Company> vw_Company { get; set; }
        public virtual DbSet<vw_customer> vw_customer { get; set; }
        public virtual DbSet<vw_Product> vw_Product { get; set; }
        public virtual DbSet<vw_Store> vw_Store { get; set; }
        public virtual DbSet<wv_Sale> wv_Sale { get; set; }
        public virtual DbSet<wv_SaleList> wv_SaleList { get; set; }
    }
}
