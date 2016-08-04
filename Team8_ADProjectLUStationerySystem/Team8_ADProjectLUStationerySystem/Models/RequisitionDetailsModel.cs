using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Models
{
    public class RequisitionDetailsModel

    {
        private string itemDescription;

        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

       
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        private string uom;

        public string Uom
        {
            get { return uom; }
            set { uom = value; }
        }
    }
}