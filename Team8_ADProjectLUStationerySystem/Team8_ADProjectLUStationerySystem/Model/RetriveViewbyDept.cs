using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.Model
{

        public class RetriveViewbyDept
        {
            public int? retrievalId;
            public string departmentId;
            public string depetName;
            public string itemCode;
            public string itemDescription;
            public int? actualQuantity;

            public RetriveViewbyDept(int? retrievalId, string departmentId, string depetName, string itemCode, string itemDescripion, int? actualQuantity)
            {
                this.retrievalId = retrievalId;
                this.departmentId = departmentId;
                this.depetName = depetName;
                this.itemCode = itemCode;
                this.itemDescription = itemDescripion;
                this.actualQuantity = actualQuantity;
            }

            public RetriveViewbyDept()
            {
                // TODO: Complete member initialization
            }

            public string DepetName { get; set; }

            public string ItemCode { get; set; }

            public string ItemDescription { get; set; }

            public int? ActualQuantity { get; set; }

            public int? RetrievalId { get; set; }

            public string DepartmentId { get; set; }

        }
    }
