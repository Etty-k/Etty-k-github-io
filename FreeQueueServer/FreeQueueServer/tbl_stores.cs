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
    
    public partial class tbl_stores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_stores()
        {
            this.tbl_productsCategories = new HashSet<tbl_productsCategories>();
            this.tbl_purchases = new HashSet<tbl_purchases>();
            this.tbl_storesActivityTime = new HashSet<tbl_storesActivityTime>();
            this.tbl_storesMenu = new HashSet<tbl_storesMenu>();
        }
    
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string Phone { get; set; }
        public string About { get; set; }
        public string KashrutCertification { get; set; }
        public string Img { get; set; }
        public string StoreCategory { get; set; }
        public Nullable<bool> ReservedSeats { get; set; }
        public Nullable<bool> Club { get; set; }
        public Nullable<bool> Tip { get; set; }
        public Nullable<bool> StoreLoad { get; set; }
        public Nullable<int> Bank { get; set; }
        public Nullable<int> Brunch { get; set; }
        public string Account { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_productsCategories> tbl_productsCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_purchases> tbl_purchases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_storesActivityTime> tbl_storesActivityTime { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_storesMenu> tbl_storesMenu { get; set; }
    }
}
