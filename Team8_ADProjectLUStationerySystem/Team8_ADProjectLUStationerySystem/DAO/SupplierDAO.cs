
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class SupplierDAO
    {
        logicUniversityEntities lue = new logicUniversityEntities();

        logicUniversityEntities context = new logicUniversityEntities(); //entityframework
        public List<supplier> getAllSupplier()
        {
            return context.suppliers.ToList();
        }
        public List<supplier> getTenderSupplier()
        {
            return context.suppliers.Where(s => s.supplierRank != 0).OrderBy(s => s.supplierRank).ToList();
        }
        public supplier getSupplierByPK(string suppliercode)
        {
            return context.suppliers.Where(s => s.supplierCode == suppliercode).First<supplier>();
        }

        public void changeRank(List<supplier> sp)
        {
            foreach (supplier s in sp)
            {
                supplier spr = lue.suppliers.Where(x =>
                    x.supplierCode == s.supplierCode).First();
                spr.supplierRank = s.supplierRank;
                lue.SaveChanges();
            }
        }
    }
}