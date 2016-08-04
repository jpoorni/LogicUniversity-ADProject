using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{
    public class RetriveViewbyCategory
    {
        public int? categoryId;
        public string categoryName;
        public int? actualQuantity;

        public RetriveViewbyCategory(int? categoryId, string categoryName, int? actualQuantity)
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
            this.actualQuantity = actualQuantity;
        }

        public RetriveViewbyCategory()
        {
            // TODO: Complete member initialization
        }

        public int CategoryId { get; set; }

        public int ActualQuantity { get; set; }

        public string CategoryName { get; set; }
    }
}