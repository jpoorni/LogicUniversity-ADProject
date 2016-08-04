using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class PoDetails
    {
        public int? purchaseDetail_Id;
        public string itemdesp;
        public int? orderedQuantity;

        public PoDetails(int? purchaseDetail_Id, string itemdesp, int? orderedQuantity)
        {
            this.purchaseDetail_Id = purchaseDetail_Id;
            this.itemdesp = itemdesp;
            this.orderedQuantity = orderedQuantity;
        }
        public PoDetails()
        {
            // TODO: Complete member initialization
        }
        public string Itemdesp { get; set; }
        public int? PurchaseDetail_Id { get; set; }
        public int? OrderedQuantity { get; set; }
    }
}