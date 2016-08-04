using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class Requisitiondetails
    {
        public string category;
        public string itemDescription;
        public int? qtyNeeded;
        public int? qtyAcutal;
        public string statusDescription;

        public Requisitiondetails(string itemDescription, int? qtyNeeded, int? qtyAcutal, string statusDescription)
        {
            this.itemDescription = itemDescription;
            this.qtyNeeded = qtyNeeded;
            this.statusDescription = statusDescription;
            this.qtyAcutal=qtyAcutal;
        }

        public Requisitiondetails(string category,string itemDescription, int? qtyNeeded)
        {
            this.category = category;
            this.itemDescription = itemDescription;
            this.qtyNeeded = qtyNeeded;
            
        }

        public Requisitiondetails()
        {
            // TODO: Complete member initialization
        }

        public string Category { get; set; }
        public string ItemDescription { get; set; }
        public int QtyNeeded { get; set; }
       
        public int QtyAcutal { get; set; }

        public string StatusDescription { get; set; }
    }
}