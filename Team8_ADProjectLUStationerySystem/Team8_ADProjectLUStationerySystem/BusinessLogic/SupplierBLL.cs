
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;

namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class SupplierBLL
    {
        SupplierDAO supplierDAO = new SupplierDAO(); //Supplier DAO
        public List<supplier> getAllSupplier()
        {
            return supplierDAO.getAllSupplier();
        }
        public List<supplier> getTenderSupplier()
        {
            return supplierDAO.getTenderSupplier();
        }
        public supplier getSupplierByPK(string suppliercode)
        {
            return supplierDAO.getSupplierByPK(suppliercode);
        }

        public void changeRank(List<supplier> sp)
        {
            supplierDAO.changeRank(sp);
        }
    }
}