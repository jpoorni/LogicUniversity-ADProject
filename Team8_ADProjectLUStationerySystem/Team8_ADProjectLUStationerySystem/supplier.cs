//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team8_ADProjectLUStationerySystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class supplier
    {
        public supplier()
        {
            this.purchaseOrders = new HashSet<purchaseOrder>();
        }
    
        public string supplierCode { get; set; }
        public string gstRegistrationNumber { get; set; }
        public string supplierName { get; set; }
        public string contactName { get; set; }
        public Nullable<int> phoneNo { get; set; }
        public string faxNo { get; set; }
        public string address { get; set; }
        public Nullable<int> supplierRank { get; set; }
    
        public virtual ICollection<purchaseOrder> purchaseOrders { get; set; }
    }
}
