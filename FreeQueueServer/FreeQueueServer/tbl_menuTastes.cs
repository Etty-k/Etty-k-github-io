//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FreeQueueServer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_menuTastes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_menuTastes()
        {
            this.tbl_purchasesTastes = new HashSet<tbl_purchasesTastes>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Product { get; set; }
        public string Taste { get; set; }
        public Nullable<bool> TasteStatus { get; set; }
        public string TasteImage { get; set; }
    
        public virtual tbl_storesMenu tbl_storesMenu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_purchasesTastes> tbl_purchasesTastes { get; set; }
    }
}
