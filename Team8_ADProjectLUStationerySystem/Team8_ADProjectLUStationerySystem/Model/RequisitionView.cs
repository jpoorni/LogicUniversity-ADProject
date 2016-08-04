using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class RequisitionView
    {
        public int? requisitionId;
        public DateTime requisitionDate;
        public int? totalQty;

        public int? employeeID;
        public string employeeName;
        public string statusDescription;

        public RequisitionView()
        {

        }
       
        public RequisitionView(int? requisitionId, string employeeName,DateTime requisitionDate)
        {
            this.requisitionId = requisitionId;
            this.employeeName = employeeName;
            this.requisitionDate = requisitionDate;
        }
        public RequisitionView(int? requisitionId,DateTime requisitionDate, int? totalQty)
        {
            this.requisitionId = requisitionId;
            this.requisitionDate = requisitionDate;
            this.totalQty = totalQty;
        }

        public RequisitionView(int? requisitionId, int? employeeID, string employeeName, DateTime requisitionDate,string statusDescription)
        {
            this.requisitionId = requisitionId;
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.requisitionDate = requisitionDate;
            this.statusDescription = statusDescription;
        }

        public int RequisitionId { get; set; }
        public DateTime RequisitionDate { get; set; }
        public int TotalQty { get; set; }


        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }
        public string StatusDescription { get; set; }


    }
}