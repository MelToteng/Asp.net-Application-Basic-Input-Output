//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PharmacyApplication.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DRUG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DRUG()
        {
            this.TRANSACTIONS = new HashSet<TRANSACTION>();
        }
    
        public string BR_ID { get; set; }
        public string DRUG_NAME { get; set; }
        public int UNITARY_PRICE { get; set; }
        public string BulkPrice { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
    
        public virtual STOCK STOCK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSACTION> TRANSACTIONS { get; set; }
    }
}
