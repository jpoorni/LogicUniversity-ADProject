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
    
    public partial class employee
    {
        public employee()
        {
            this.adjustments = new HashSet<adjustment>();
            this.delegateEmployees = new HashSet<delegateEmployee>();
            this.disbursements = new HashSet<disbursement>();
            this.requisitions = new HashSet<requisition>();
            this.retrievalDetails = new HashSet<retrievalDetail>();
        }
    
        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string departmentCode { get; set; }
        public Nullable<int> phoneNumber { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public string photo { get; set; }
    
        public virtual ICollection<adjustment> adjustments { get; set; }
        public virtual ICollection<delegateEmployee> delegateEmployees { get; set; }
        public virtual department department { get; set; }
        public virtual ICollection<disbursement> disbursements { get; set; }
        public virtual ICollection<requisition> requisitions { get; set; }
        public virtual ICollection<retrievalDetail> retrievalDetails { get; set; }
        public virtual userDetail userDetail { get; set; }
    }
}
