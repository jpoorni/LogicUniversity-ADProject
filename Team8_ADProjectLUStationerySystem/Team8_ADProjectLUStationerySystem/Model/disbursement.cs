using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class disbursement
    {
        private string itemCode;
        private int reqQuantity;
        private string repName;
        private string departmentPhoto;
        private string repPhoto;
        private string collectionDes;
        private string collectionDate;
        private string departmentName;
        private int disbursementId;
        private List<Model.disbursementdetails> details;

        public disbursement(string itemCode, int reqQuantity)
        {
            this.itemCode = itemCode;
            this.reqQuantity = reqQuantity;
        }
        public disbursement(int disbursementId, string repName, string collectionDate, string departmentPhoto)
        {
            this.disbursementId = disbursementId;
            this.repName = repName;
            this.collectionDate = collectionDate;
            this.departmentPhoto = departmentPhoto;
        }
        public disbursement(string departmentName, string repPhoto, string repName, string collectionDes, string collectionDate, List<Model.disbursementdetails> details)
        {
            this.departmentName = departmentName;
            this.repPhoto = repPhoto;
            this.repName = repName;
            this.collectionDes = collectionDes;
            this.collectionDate = collectionDate;
            this.details = details;

        }
        public string getItemCode()
        {
            return this.itemCode;
        }
        public int getReqQuantity()
        {
            return this.reqQuantity;
        }
        public override string ToString()
        {
            return this.collectionDes;
        }
    }
}