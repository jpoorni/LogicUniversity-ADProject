using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class Disbursement
    {
        private DAO.DisbursementDAO disbursementDao;
        private DAO.MailController mailController;

        public Disbursement()
        {
            disbursementDao = new DAO.DisbursementDAO();
            mailController = new DAO.MailController();
        }
        public int generateNewDisbursement(string departmentCode, int retrievalId, DateTime collectionDate)
        {
            disbursementDao.generateDisbursementList(departmentCode, retrievalId, collectionDate);
            int i = disbursementDao.generateDisbursementDetail(departmentCode, retrievalId, collectionDate);
            disbursementDao.changeRetrievalStatus(retrievalId);
            //disbursementDao.changeRequisitionStatus(departmentCode);
            mailController.canCollectionNoti(departmentCode);
            return i;
           

        }
        public void changeDisbursementQuantity(int disbursementId, string itemCode, int realReceiveQty/*, string departmentCode*/)
        {
            string departmentCode = disbursementDao.getDisbursement(disbursementId).departmentCode;
            disbursementDao.changeDisbursementDetail(disbursementId, itemCode, realReceiveQty, departmentCode);
        }
        public void confirmDisbursement(int disbursementId/*, string departmentCode*/)
        {
            string departmentCode = disbursementDao.getDisbursement(disbursementId).departmentCode;
            disbursementDao.confirmDisbursement(disbursementId);
            //new Change
            disbursementDao.changeRequsitionStatusAfterDisbursement(departmentCode, disbursementId);
            disbursementDao.changeStockCard(disbursementId);
        }
        public List<Models.disbursement> getdisbursementForMobile(string departmentId)
        {
            return disbursementDao.getDisbursementforMobile(departmentId);
        }
        public List<retrieval> getList()
        {
            return disbursementDao.getRetrievalList();
        }

        public List<department> getDepartment(int rid)
        {
            return disbursementDao.getCanGenrateDepartment(rid);
        }

        public List<disbursement> getUnConfirm()
        {
            return disbursementDao.getUnConfirm();
        }

        public List<disbursementDetail> getDisbursementDetail(int disid)
        {
            return disbursementDao.getDisbursementDetail(disid);
        }

        public List<disbursement> getByDate(DateTime from, DateTime to)
        {
            return disbursementDao.getByDate(from, to);
        }

        public List<Model.DisbursementView> ViewDisForClerk()
        {
            return disbursementDao.ViewDisForClerk();
        }
        public List<Model.DisbursementView> ViewDisbyDeptForClerk(string deptCode)
        {
            return disbursementDao.ViewDisbyDeptForClerk(deptCode);
        }

        public List<Model.DisbursementView> ViewDisWithoutItemForClerk(int disId)
        {
            return disbursementDao.ViewDisWithoutItemForClerk(disId);
        }

        public List<Model.disbursementdetails> getDisbursementDetailsListforMobile(int disbursementId)
        {
            return disbursementDao.getDisbursementDetailsListforMobile(disbursementId);
        }

        public List<int> getDisIds(string dcode)
        {
            return disbursementDao.getDisIds(dcode);
        }

        public void confirmDisbursementformob(int disbursementId, string departmentCode)
        {

            disbursementDao.confirmDisbursement(disbursementId);
            //new Change
            disbursementDao.changeRequsitionStatusAfterDisbursement(departmentCode, disbursementId);
            disbursementDao.changeStockCard(disbursementId);
        }

        public List<Model.DisbursementView> ViewDisbursementbydept(string deptCode)
        {
            return disbursementDao.ViewDisbursementbydept(deptCode);
        }

        public int getUserid(string username)
        {
            return disbursementDao.getUserid(username);

        }

        public string getItemcode(string itemDes)
        {
            return disbursementDao.getItemcode(itemDes);
        }

        public void changeDisbursementQuantityformob(int disbursementId, string itemCode, int realReceiveQty, string departmentCode)
        {

            disbursementDao.changeDisbursementDetail(disbursementId, itemCode, realReceiveQty, departmentCode);
        }

    }
}