using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class DisbursementView

    {
        public int? disbursementID;
        public string itemCode;
        public string itemDescription;
        public int? reqQuantity;
        public string departmentCode;
        public string departmentName;
        public int? totalDisburseIdNo;
        public int? employeeId;
        public string employeeName;
        public DateTime? collectionDate;
        public int?  collectionPointId;
        public string collectionPointName;

        public DisbursementView(int? disbursementID, string itemCode, string itemDescription, int? reqQuantity)
        {
            this.disbursementID = disbursementID;
            this.itemCode = itemCode;
            this.itemDescription = itemDescription;
            this.reqQuantity = reqQuantity;
        }

        public DisbursementView()
        {
            // TODO: Complete member initialization
        }

        public DisbursementView(string departmentCode,string departmentName,int? totalDisburseIdNo)
        {
            this.departmentCode = departmentCode;
            this.departmentName = departmentName;
            this.totalDisburseIdNo = totalDisburseIdNo;
        }

        public DisbursementView(int? disbursementID, string departmentCode, string departmentName, string employeeName, DateTime collectionDate)
        {
            this.disbursementID = disbursementID;
            this.departmentCode = departmentCode;
            this.departmentName = departmentName;
            this.employeeName = employeeName;
            this.collectionDate = collectionDate;
        }

        public DisbursementView(string departmentName,int? employeeId,string employeeName, int? collectionPointId,string collectionPointName,DateTime collectionDate)
        {
            this.departmentName = departmentName;
            this.employeeId = employeeId;
            this.employeeName = employeeName;
            this.collectionPointId = collectionPointId;
            this.collectionPointName = collectionPointName;
            this.collectionDate = collectionDate;
        }
        public int DisbursementID { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int ReqQuantity { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int TotalDisburseIdNo { get; set; }

        public int EmployeeId { get; set; }
        public int CollectionPointId { get; set; }
        public string CollectionPointName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CollectionDate { get; set; }

    }
}