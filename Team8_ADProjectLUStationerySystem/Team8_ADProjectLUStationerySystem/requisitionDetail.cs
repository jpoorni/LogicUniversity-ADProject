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
    
    public partial class requisitionDetail
    {
        public int requisitionId { get; set; }
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        public Nullable<int> qtyNeeded { get; set; }
        public Nullable<int> qtyActual { get; set; }
        public Nullable<int> qtyOutstaning { get; set; }
        public Nullable<bool> outstandingField { get; set; }
    
        public virtual catelogueItem catelogueItem { get; set; }
        public virtual requisition requisition { get; set; }
    }
}