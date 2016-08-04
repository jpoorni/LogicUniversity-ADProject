using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class disbursementdetails
    {
        public string itemDes;
        public int? reqQty;
        public int? receivedQuantity;

        public disbursementdetails(string itemDes, int? reqQty)
        {
            this.itemDes = itemDes;
            this.reqQty = reqQty;

        }
        public disbursementdetails(string itemDes, int? reqQty, int? receivedQuantity)
        {
            this.itemDes = itemDes;
            this.reqQty = reqQty;
            this.receivedQuantity = receivedQuantity;
        }
        public override string ToString()
        {
            return this.itemDes;
        }
    }
}