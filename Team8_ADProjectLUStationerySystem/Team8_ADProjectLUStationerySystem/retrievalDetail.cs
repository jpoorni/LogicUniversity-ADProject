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
    
    public partial class retrievalDetail
    {
        public int retrievalId { get; set; }
        public string itemCode { get; set; }
        public string departmentId { get; set; }
        public Nullable<int> needQuantity { get; set; }
        public Nullable<int> actualQuantity { get; set; }
        public string bin { get; set; }
        public Nullable<int> employeeId { get; set; }
    
        public virtual catelogueItem catelogueItem { get; set; }
        public virtual department department { get; set; }
        public virtual employee employee { get; set; }
        public virtual retrieval retrieval { get; set; }
    }
}
