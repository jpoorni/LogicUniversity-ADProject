using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class disbursementdetail
    {
        private string itemCode;
        private int reqQuantity;
        private string itemDes;
        private string repName;
        private string repPhoto;
        private string collectionDes;
        private string collectionDate;

        public disbursementdetail(string itemCode, int reqQuantity)
        {
            this.itemCode = itemCode;
            this.reqQuantity = reqQuantity;
        }
        public disbursementdetail(string repName, string collectionDate, string repPhoto)
        {
            this.repName = repName;
            this.collectionDate = collectionDate;
            this.repPhoto = repPhoto;
        }
        public string getItemCode()
        {
            return this.itemCode;
        }
        public int getReqQuantity()
        {
            return this.reqQuantity;
        }
    }
}