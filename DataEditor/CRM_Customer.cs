
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
    
    public partial class CRM_Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CRM_Customer()
        {
            this.CRM_log = new HashSet<CRM_log>();
            this.CRM_SMSSender = new HashSet<CRM_SMSSender>();
        }
    
        public int               SHS_ID              { get; set; }
        public int               id                  { get; set; }
        public string            NAME                { get; set; }
        public string            SHO                 { get; set; }
        public string            MOBIL               { get; set; }
        public string            ADR                 { get; set; }
        public string            FAX                 { get; set; }
        public string            TOZIH               { get; set; }
        public string            cod_Eshterak        { get; set; }
        public string            CodeMelli           { get; set; }
        public Nullable<bool>    SendSMS                { get; set; }
        public string            tar_tavalod            { get; set; }
        public string            city                   { get; set; }
        public string            pas                    { get; set; }
        public string            tar_ez                 { get; set; }
        public string            mail                    { get; set; }
        public string            job                    { get; set; }
        public Nullable<int>     ID_Company              { get; set; }
        public string            CartKind                { get; set; }
        public int               Mos_id                 { get; set; }
        public bool              Lottery                { get; set; }
        public string            adder                  { get; set; }
        public string            editor                 { get; set; }
        public string            tar_s                  { get; set; }
        public string            FATHER                 { get; set; }
        public string            SCODE                  { get; set; }
        public string            HOMEPHONE              { get; set; }
        public string            NAMEL                { get; set; }
        public string            SSTNDRDCODE            { get; set; }
        public string            SODOR                  { get; set; }
        public Nullable<int>     SEX                { get; set; }
        public Nullable<int>     TAHOL                  { get; set; }
        public string            HOMECODE               { get; set; }
        public string            WORKCODE               { get; set; }
        public string            WORKADDR               { get; set; }
        public string            WORKPHONE                 { get; set; }
        public string            bincart                   { get; set; }
        public string            binEXPDATE                { get; set; }
        public string            binCVV2                   { get; set; }
        public string            tar_edit                  { get; set; }
        public string            tar_kasian_d           { get; set; }
        public string            tar_kasian_t           { get; set; }
    
        public virtual SalMaly SalMaly { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRM_log> CRM_log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CRM_SMSSender> CRM_SMSSender { get; set; }
    }
}