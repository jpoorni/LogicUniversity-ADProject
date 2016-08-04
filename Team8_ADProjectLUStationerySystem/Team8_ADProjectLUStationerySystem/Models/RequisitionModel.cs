using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Models
{
    public class RequisitionModel
    {
        public RequisitionModel()
        {

        }
         

        private int requisitionId;

        public int RequisitionId
        {
            get { return requisitionId; }
            set { requisitionId = value; }
        }
        private DateTime requisitionDate;

        public DateTime RequisitionDate
        {
            get { return requisitionDate; }
            set { requisitionDate = value; }
        }
        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        public RequisitionModel(int requisitionId, string employeeName, DateTime requisitionDate)
        {
            requisitionId = this.requisitionId;
            employeeName = this.employeeName;
            requisitionDate = this.requisitionDate;
        }

        private string statusDescription;

        public string StatusDescription
        {
            get { return statusDescription; }
            set { statusDescription = value; }
        }

        public RequisitionModel(int requisitionId, DateTime requisitionDate, string statusDescription)
        {
            requisitionId = this.requisitionId;
            
            requisitionDate = this.requisitionDate;
            statusDescription = this.statusDescription;
        }
         
    }
}