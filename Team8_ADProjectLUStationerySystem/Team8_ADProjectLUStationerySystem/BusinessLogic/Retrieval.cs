using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class Retrieval
    {
        private DAO.RetrievalDAO retrievalDAO;
        private DAO.MailController mailController;
        public Retrieval()
        {
            retrievalDAO = new DAO.RetrievalDAO();
            mailController = new DAO.MailController();
        }

        public void process(List<int> idList, int i)
        {
            retrievalDAO.processOutstandSelfcollectionRequisition(idList);
            retrievalDAO.processNormalSelfcollectionRequisition(idList);
            retrievalDAO.processOutstandingRequisition(idList);
            retrievalDAO.processNormalRequisition(idList);
            List<requisition> r = retrievalDAO.changeStatus(idList,i);
            mailController.fullfillRequisitionNoti(r);
            mailController.outstandingRequisitionNoti(r);
        }

        public int generateNormal(int i)
        {
            //retrievalDAO.generateNew(0);
            int id = retrievalDAO.generateRetrievalList();
            retrievalDAO.changeStatus(null,i);
            return id;
        }

        public void generateSC()
        {
            retrievalDAO.generateScRetrievalList();
            //retrievalDAO.changeStatus(null,1);
        }

        public void comfirmRetrievalDetails(int rid, string ic, string did, int actqty)//change retrieval & requisition detail
        {
            retrievalDetail r = new retrievalDetail();
            r.retrievalId = rid;
            r.itemCode = ic;
            r.departmentId = did;
            r.actualQuantity = actqty;

            retrievalDAO.comfirmRetrievalDetails(r);
        }

        public void ComfirmRetriavleList(int rid, int i)//change status
        {
            retrievalDAO.changeStatus(null,2);
            retrievalDAO.comfirmRetrievalList(rid, i);
        }

        
        public List<retrievalDetail> getOneRetrieval(int id)
        {
            return retrievalDAO.getOneRetrieval(id);
        }

        public List<retrievalDetail> getId(List<retrievalDetail> r)
        {
            List<retrievalDetail> i = new List<retrievalDetail>();

            foreach (retrievalDetail result in r)
            {
                int flag = 0;
                foreach (retrievalDetail record in i)
                {
                    if (result.itemCode == record.itemCode)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    i.Add(result);
                }
            }
            return i;
        }

        public List<requisition> getForPorcess()
        {
            return retrievalDAO.getForPorcess();
        }

        public List<requisitionDetail> getDetails(int id)
        {
            return retrievalDAO.getDetails(id);
        }

        public List<requisitionDetail> getOutstanding(List<int> idList)
        {
            return retrievalDAO.getOutstandingDetail(idList);
        }

        public List<retrieval> getNormalView()
        {
            return retrievalDAO.getNormalView();
        }

        public List<retrieval> getUnConfirm()
        {
            return retrievalDAO.getUnConfirm();
        }

        public string getStatus(int id)
        {
            return retrievalDAO.getStatus(id);
        }

        public List<retrievalDetail> getHistory(string itemCode, string depCode)
        {
            return retrievalDAO.getHistory(itemCode, depCode);
        }

        public List<int> getAllRetrievalId()
        {
            return retrievalDAO.getAllRetrievalId();
        }
    }
}