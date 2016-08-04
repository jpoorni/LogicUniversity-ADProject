using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Models
{
    public class DisbursementModel
    {
        private int disbursementId;

        public int DisbursementId
        {
            get { return disbursementId; }
            set { disbursementId = value; }
        }
        private string departmentName;

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }
        private DateTime collectionDate;

        public DateTime CollectionDate
        {
            get { return collectionDate; }
            set { collectionDate = value; }
        }
    }
}