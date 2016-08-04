using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class ReportDAO
    {
        logicUniversityEntities context = new logicUniversityEntities();

        public List<string> getAllItemCode()
        {
            var query = context.purchaseDetails.Select(pd => pd.itemCode).Distinct();
            return query.ToList();
        }

        public dynamic getAllDepartment()
        {
            var query = from dept in context.departments
                        select (new {dept.departmentCode, dept.departmentName});
            return query.ToList();
        }

        public dynamic getDeatilByItemCode(string icode)
        {
            var query = from pd in context.purchaseDetails
                        group pd by pd.itemCode into pdg
                        select new
                        {
                            itemCode = pdg.Key,
                            receivedQuantity = pdg.Sum(x => x.receivedQuantity)
                        };
            return query.ToList();
        }
    }
}