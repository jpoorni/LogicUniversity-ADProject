using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;

namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class AdjustInventoryBLL
    {



        DAO.AdjustInventoryDAO AdjDAO = new DAO.AdjustInventoryDAO();
        adjustmentDetail adj; catelogueItem item; List<adjustmentDetail> updatecart;
        MailController mail = new MailController();


        //creat Adjustment
        public void CreateAdjustment(List<adjustmentDetail> ad, int uid)
        {
            List<adjustmentDetail> list = new List<adjustmentDetail>();
            list = ad;

            int totalAmt = AdjDAO.createAdjustment(ad, uid);
            mail.newAdjustment(totalAmt);


        }

        public  int checkQty(String id)
        {
            int qty = AdjDAO.checkQty(id);

            return qty;
        }
        //creat Special Adjustment
        public void CreateSpecialAdjustment(List<adjustmentDetail> ad, int uid)
        {
            List<adjustmentDetail> list = new List<adjustmentDetail>();
            list = ad;

            AdjDAO.createSpecialAdjustment(ad, uid);


        }

        //view of all adjustments for View Adjustment page to approve or reject by AuthPerson
        public List<adjustment> LoadAllAdjust(String uid)
        {
            return AdjDAO.getAllAdjustmentByAuthPerson(uid);
        }

        public List<adjustment> LoadAllAdjustListToPrint(String uid)
        {
            return AdjDAO.getAllAdjustmentListByAuthPerson(uid);
        }

        public List<adjustment> LoadAllAdjustList()
        {
            return AdjDAO.getAllAdjustment();
        }
        //to view the AdjustmentDetails gridview after click Details button in Adjustment Gridview
        public List<adjustmentDetail> getAdjustmentDetailsbyID(String id)
        {
            int adjid = Convert.ToInt32(id);
            return AdjDAO.getAllAdjustmentDetailsbyID(adjid);
        }

        //method for keep data as Session in gridview   <for web page>
        public List<adjustmentDetail> CreateAdjCart(String itemcode, int adjQty, String type, String reason, List<adjustmentDetail> list)
        {
            adj = new adjustmentDetail();
            item = AdjDAO.getItem(itemcode);
            adj.itemCode = itemcode;
            adj.adjustmentQuantity = adjQty;
            adj.type = type;
            adj.reason = reason;
            adj.adjustmentAmount = adjQty * item.tenderPrice;

            list.Add(adj);
            updatecart = list;

            return updatecart;

        }


        public catelogueItem getItem(string itemcode)
        {
            return AdjDAO.getItem(itemcode);
        }

        public List<category> getAllCategories()
        {
            return AdjDAO.getAllCategories();
        }
        public List<catelogueItem> getAllCatelogueItem(int id)
        {
            return AdjDAO.getAllCatelogueItem(id);
        }

        public List<adjustmentDetail> getAllAdjustmentDetail()
        {
            return AdjDAO.getAllAdjustmentDetail();
        }

        public List<adjustment> getAdjustmentbyID(int id)
        {
            return AdjDAO.getAdjustmentbyID(id);
        }

        //Approved by Adjustment List
        public void ApproveAdjustment(List<int> adjidlist)
        {
            List<adjustmentDetail> adjDetaillist = new List<adjustmentDetail>();

            foreach (int id in adjidlist)
            {
                adjustment ad = AdjDAO.getOne(id);
                if (ad.status == "Pending")
                {
                    AdjDAO.ApproveAdjustment(id);
                    adjDetaillist = AdjDAO.getAllAdjustmentDetailsbyID(id);
                    AdjDAO.AddStockCard(adjDetaillist);
                    AdjDAO.changeQty(adjDetaillist);

                }
                else
                {
                    AdjDAO.ApproveAdjustment(id);
                    adjDetaillist = AdjDAO.getAllAdjustmentDetailsbyID(id);
                    AdjDAO.AddStockCard(adjDetaillist);
                }

            }

        }



        //Approved by One adjustment
        public void ApproveAdjustmentByone(int adjustmentid)
        {
            List<adjustmentDetail> adjDetaillist = new List<adjustmentDetail>();

            adjustment ad = AdjDAO.getOne(adjustmentid);
            if (ad.status == "Pending")
            {
                AdjDAO.ApproveAdjustment(adjustmentid);
                adjDetaillist = AdjDAO.getAllAdjustmentDetailsbyID(adjustmentid);             
                AdjDAO.AddStockCard(adjDetaillist);
                AdjDAO.changeQty(adjDetaillist);

            }
            else
            {
                AdjDAO.ApproveAdjustment(adjustmentid);
                adjDetaillist = AdjDAO.getAllAdjustmentDetailsbyID(adjustmentid);
                AdjDAO.AddStockCard(adjDetaillist);
            }
        }




        //Rejected by One adjustment
        public void RejectAdjustmentByOne(int adjustmentid)
        {
            AdjDAO.RejectAdjustment(adjustmentid);

        }


        //Rejected by Adjustment List
        public void RejectAdjustment(List<int> adjidlist)
        {
            List<adjustmentDetail> adjDetaillist = new List<adjustmentDetail>();

            foreach (int id in adjidlist)
            {
                AdjDAO.RejectAdjustment(id);

            }
        }

        public int calculateTotalAmt(List<adjustmentDetail> list)
        {
            return AdjDAO.calculatetotalAmount(list);
        }

        public double adjustmentAmount(string iid, int qty)
        {
            return AdjDAO.adjustmentAmount(iid, qty);
        }

        public List<adjustment> getHistory(DateTime from, DateTime to)
        {
            return AdjDAO.getHistory(from, to);
        }

        public List<adjustment> getOwnHistory(DateTime from, DateTime to,int userid)
        {
            return AdjDAO.getOwnHistory(from, to,userid);
        }

        public void ApproveAdjustmentt(int adjid)
        {
            AdjDAO.ApproveAdjustment(adjid);
        }

        public void RejectAdjustmentt(int adjid)
        {
            AdjDAO.RejectAdjustment(adjid);
        }
    }
}