using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Models
{
    public class disbursementdetails
    {
        private string itemDes;
        private int reqQty;
        public disbursementdetails(string itemDes, int reqQty)
        {
            this.itemDes = itemDes;
            this.reqQty = reqQty;
        }
        public override string ToString()
        {
            return this.itemDes;
        }
    }
}