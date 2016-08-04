using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.DAO
{
    public class AdjustInventoryDAO
    {
        public AdjustInventoryDAO() { }



        public List<catelogueItem> getAllCatelogueItem(int id)
        {
            var ctx = new logicUniversityEntities();
            return ctx.catelogueItems.Where(c => c.categoryId == id).ToList();
        }

        public List<adjustment> getAllAdjustment()
        {
            var ctx = new logicUniversityEntities();
            var q = from d in ctx.adjustments select d;

            return q.ToList();
        }

        public int checkQty(String id)
        {

            var ctx = new logicUniversityEntities();
            catelogueItem c = ctx.catelogueItems.Where(x =>
                x.itemCode == id).First();
            return (int) c.quantity;
        }

        public adjustment getOne(int id)
        {
            var ctx = new logicUniversityEntities();
            return ctx.adjustments.Where(x =>
                x.adjustmentId == id).First();
        }

        public List<adjustment> getAllAdjustmentByAuthPerson(String id)
        {
            var ctx = new logicUniversityEntities();
            List<adjustment> adjlist = new List<adjustment>();
            String roledesc = "";
            roledesc = checkRole(id);

            if (roledesc == "supervisor")
            {

                adjlist = ctx.adjustments.Where(adj => adj.totalAmount < 250 && (adj.status == "Pending" || adj.status == "Special Pending")).ToList();
            }
            else if (roledesc == "storeManager")
            {
                adjlist = ctx.adjustments.Where(adj => adj.totalAmount >= 250 && (adj.status == "Pending" || adj.status == "Special Pending")).ToList();
            }

            return adjlist;
        }


        //just for report -->show all status
        public List<adjustment> getAllAdjustmentListByAuthPerson(String id)
        {
            var ctx = new logicUniversityEntities();
            List<adjustment> adjlist = new List<adjustment>();
            String roledesc = "";
            roledesc = checkRole(id);

            if (roledesc == "supervisor")
            {

                adjlist = ctx.adjustments.Where(adj => adj.totalAmount < 250).ToList();
            }
            else if (roledesc == "storeManager")
            {
                adjlist = ctx.adjustments.Where(adj => adj.totalAmount >= 250).ToList();
            }

            return adjlist;
        }

        public List<adjustment> getAllAdjustmentList()
        {
            var ctx = new logicUniversityEntities();
            List<adjustment> adjlist = new List<adjustment>();
            
            var q = from list in ctx.adjustments select list;
            adjlist = q.ToList();
            return adjlist;
        }



        public String checkRole(String id)
        {
            int uid = Convert.ToInt32(id);
            String roledesc = "";
            var ctx = new logicUniversityEntities();
            userDetail user = ctx.userDetails.Where(u => u.userId == uid).First();
            var r = from role in ctx.roles select role;
            List<role> rlist = r.ToList();

            foreach (role rol in rlist)
            {

                if (rol.roleId == user.roleId)
                {
                    roledesc = rol.roleDescription;
                    break;
                }

            }
            return roledesc;
        }


        public List<adjustmentDetail> getAllAdjustmentDetailsbyID(int adjid)
        {
            var ctx = new logicUniversityEntities();
            return ctx.adjustmentDetails.Where(d => d.adjustmentId == adjid).ToList();
        }
        public catelogueItem getItem(string itemcode)
        {
            var ctx = new logicUniversityEntities();
            return ctx.catelogueItems.Where(c => c.itemCode == itemcode).First();
        }
        public List<category> getAllCategories()
        {
            var ctx = new logicUniversityEntities();
            var q = from c in ctx.categories select c;
            return q.ToList();
        }

        public int createAdjustment(List<adjustmentDetail> ad, int uid)
        {
            var ctx = new logicUniversityEntities();
            List<adjustmentDetail> adlist = new List<adjustmentDetail>();
            adjustment adj = new adjustment();

            //insert Adjustment table
            adjustmentDetail adjDeail;
            int totalAmt = calculatetotalAmount(ad);
            adj.totalAmount = totalAmt;
            adj.status = "Pending";

            if (totalAmt < 250)
            {
                adj.authorizedPerson = "supervisor";
            }
            else if (totalAmt >= 250)
            {
                adj.authorizedPerson = "storeManager";
            }

            adj.employeeId = uid;
            adj.adjustDate = DateTime.Today;

            foreach (adjustmentDetail adD in ad)
            {
                //insert adjustmentDetails table
                adjDeail = new adjustmentDetail();
                adjDeail.itemCode = adD.itemCode;
                adjDeail.adjustmentQuantity = adD.adjustmentQuantity;
                adjDeail.adjustmentAmount = adD.adjustmentAmount;
                adjDeail.type = adD.type;
                adjDeail.reason = adD.reason;
                adj.adjustmentDetails.Add(adjDeail);

            }

            ctx.adjustments.Add(adj);
            ctx.SaveChanges();
            return totalAmt;
        }

        public void createSpecialAdjustment(List<adjustmentDetail> ad, int uid)
        {
            var ctx = new logicUniversityEntities();
            List<adjustmentDetail> adlist = new List<adjustmentDetail>();
            adjustment adj = new adjustment();

            //insert Adjustment table
            adjustmentDetail adjDeail;
            int totalAmt = calculatetotalAmount(ad);
            adj.totalAmount = totalAmt;
            adj.status = "Special Pending";

            if (totalAmt < 250)
            {
                adj.authorizedPerson = "supervisor";
            }
            else if (totalAmt >= 250)
            {
                adj.authorizedPerson = "storeManager";
            }

            adj.employeeId = uid;
            adj.adjustDate = DateTime.Today;

            foreach (adjustmentDetail adD in ad)
            {
                //insert adjustmentDetails table
                adjDeail = new adjustmentDetail();
                adjDeail.itemCode = adD.itemCode;
                adjDeail.adjustmentQuantity = adD.adjustmentQuantity;
                adjDeail.adjustmentAmount = adD.adjustmentAmount;
                adjDeail.type = adD.type;
                adjDeail.reason = adD.reason;
                adj.adjustmentDetails.Add(adjDeail);

            }

            ctx.adjustments.Add(adj);
            ctx.SaveChanges();
        }

        public void AddStockCard(List<adjustmentDetail> adjDetaillist)
        {
            var ctx = new logicUniversityEntities();
            stockCard sc;


            foreach (adjustmentDetail adD in adjDetaillist)
            {
                sc = new stockCard();
                sc.itemCode = adD.itemCode;
                sc.transactionDate = DateTime.Today;
                sc.transactionType = "Stock Adjustment " + "(" + adD.type + ")";
                sc.quantity = adD.adjustmentQuantity;
                sc.balance = CalculateStockCardBal(adD);
                ctx.stockCards.Add(sc);
                ctx.SaveChanges();
            }


            
        }

        public int CalculateStockCardBal(adjustmentDetail adD)
        {
            int Stockbal = 0;
            var ctx = new logicUniversityEntities();

            try
            {
                stockCard sc = ctx.stockCards.OrderByDescending(s => s.transactionId).FirstOrDefault(c => c.itemCode == adD.itemCode);
                if (adD.type == "AdjustIn")
                {

                    Stockbal = (int)(sc.balance + adD.adjustmentQuantity);

                }

                else if (adD.type == "AdjustOut")
                {
                    Stockbal = (int)(sc.balance - adD.adjustmentQuantity);

                }

            }
            catch
            {
                catelogueItem c = ctx.catelogueItems.Where(i => i.itemCode == adD.itemCode).First();

                if (adD.type == "AdjustIn")
                {

                    Stockbal = (int)(c.quantity + adD.adjustmentQuantity);

                }

                else if (adD.type == "AdjustOut")
                {
                    Stockbal = (int)(c.quantity - adD.adjustmentQuantity);

                }
            }            

            return Stockbal;
        }
        public void changeQty(List<adjustmentDetail> list)
        {

            var ctx = new logicUniversityEntities();

            foreach (adjustmentDetail adjDetail in list)
            {
                catelogueItem ct = ctx.catelogueItems.Where(i => i.itemCode == adjDetail.itemCode).First();

                if (adjDetail.type == "AdjustIn")
                {

                    int bal = (int)(ct.quantity + adjDetail.adjustmentQuantity);
                    ct.quantity = 0;
                    ct.quantity = bal;
                }

                else if (adjDetail.type == "AdjustOut")
                {
                    int bal = (int)(ct.quantity - adjDetail.adjustmentQuantity);
                    ct.quantity = 0;
                    ct.quantity = bal;
                }

                ctx.SaveChanges();
            }
        }

        public int calculatetotalAmount(List<adjustmentDetail> ad)
        {
            List<adjustmentDetail> adlist = new List<adjustmentDetail>();
            int totaltotalAmount = 0;
            adlist = ad;
            foreach (adjustmentDetail adjDetail in adlist)
            {

                totaltotalAmount += (int)adjDetail.adjustmentAmount;
            }

            return totaltotalAmount;
        }

        public List<adjustmentDetail> getAllAdjustmentDetail()
        {
            var ctx = new logicUniversityEntities();
            var q = from adjDetail in ctx.adjustmentDetails select adjDetail;
            return q.ToList();
        }

        public List<adjustment> getAdjustmentbyID(int id)
        {
            var ctx = new logicUniversityEntities();

            return ctx.adjustments.Where(adj => adj.adjustmentId == id).ToList();
        }

        public void ApproveAdjustment(int adjid)
        {
            var ctx = new logicUniversityEntities();
            adjustment adj = ctx.adjustments.Where(ad => ad.adjustmentId == adjid).First();
            adj.status = "Approved";
            ctx.SaveChanges();
        }

        public void RejectAdjustment(int adjid)
        {
            var ctx = new logicUniversityEntities();
            adjustment adj = ctx.adjustments.Where(ad => ad.adjustmentId == adjid).First();
            adj.status = "Rejected";
            ctx.SaveChanges();
        }

        public double adjustmentAmount(string iid, int qty)
        {
            logicUniversityEntities lue = new logicUniversityEntities();
            catelogueItem item = lue.catelogueItems.Where(x =>
                x.itemCode == iid).First();
            if (item.tenderPrice.HasValue)
            {
                return item.tenderPrice.Value * qty;
            }
            else
            {
                return 0;
            }
        }

        public List<adjustment> getHistory(DateTime from, DateTime to)
        {
            logicUniversityEntities lue = new logicUniversityEntities();
            return lue.adjustments.Where(x =>
                x.adjustDate >= from &&
                x.adjustDate <= to).ToList();
        }
        

        public List<adjustment> getOwnHistory(DateTime from, DateTime to,int userid)
        {
            logicUniversityEntities lue = new logicUniversityEntities();
            return lue.adjustments.Where(x =>
                x.adjustDate >= from &&
                x.adjustDate <= to &&
                x.employeeId==userid).ToList();
        }

    
    }
}