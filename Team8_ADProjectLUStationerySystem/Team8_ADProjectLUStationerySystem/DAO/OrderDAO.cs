using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team8_ADProjectLUStationerySystem.DAO
{
    //PO Status Definition:
    //1. pending : when storeclerk create PO
    //2. approved : when supervisor approve the PO
    //3. rejected : when supervisor reject the PO
    //4. partiallyreceived : when PO_Delivery has outstanding
    //5. completed : when PO_Delivery close 

    public class OrderDAO
    {
        logicUniversityEntities context;

        List<purchaseOrder> returnlist; Boolean isOustanding;

        public double getOrderCartTotal(List<purchaseDetail> orderCart)
        {
            double total = 0.0;
            foreach (purchaseDetail pd in orderCart)
            {
                total += (Convert.ToDouble(pd.price) * Convert.ToDouble(pd.orderedQuantity));
            }
            return total;               
        }
        public void createOrder(string suppliercode, int userid, List<purchaseDetail> orderCart)
        {
            var context = new logicUniversityEntities();
            purchaseOrder order = new purchaseOrder();
            order.supplierCode = suppliercode;
            order.purchaseDate = DateTime.Now;
            order.status = "pending";
            order.userId = userid;
            order.totalAmount = getOrderCartTotal(orderCart);

            foreach (purchaseDetail pd in orderCart)
            {
                purchaseDetail detail = new purchaseDetail();
                detail.itemCode = pd.itemCode;
                detail.orderedQuantity = pd.orderedQuantity;
                detail.price = pd.price;
                detail.amount = pd.amount;
                detail.receivedQuantity = 0;

                order.purchaseDetails.Add(detail);
            }
            context.purchaseOrders.Add(order);
            context.SaveChanges();           
        }
        public purchaseOrder getPurchaseOrderByPK(int orderid)
        {
            var context = new logicUniversityEntities();
            return context.purchaseOrders.Where(po => po.purchaseorderno == orderid).First();
        }
        public List<purchaseOrder> getPurchaseOrderListByUserId(int userid)
        {
            var context = new logicUniversityEntities();
            return context.purchaseOrders.Where(po => po.userId == userid).ToList();
        }
        public List<purchaseOrder> getPurchaseOrderListForApproval() //log in user must be supervisor to make approval
        {
            var context = new logicUniversityEntities();
            returnlist = context.purchaseOrders.Where(po => po.status == "pending").ToList();
            if (returnlist != null)
                return returnlist;
            else
                return null;
        }
        public List<purchaseDetail> getPurchaseDetailByOrderId(int orderid)
        {
            var context = new logicUniversityEntities();
            return context.purchaseDetails.Where(pd => pd.purchaseOrderno == orderid && (pd.orderedQuantity - pd.receivedQuantity) != 0).ToList();
        }

        public List<purchaseDetail> getPurchaseDetailByOrderId2(int orderid)
        {
            var context = new logicUniversityEntities();
            return context.purchaseDetails.Where(pd => pd.purchaseOrderno == orderid).ToList();
        }
        public purchaseDetail getPurchaseDetailByPK(int orderdetailId)
        {
            var context = new logicUniversityEntities();
            return context.purchaseDetails.Where(pd => pd.purchaseDetail_Id == orderdetailId).First();
        }
        public string getOrderStatus(int orderid)
        {
            var context = new logicUniversityEntities();
            var status = from po in context.purchaseOrders
                         where po.purchaseorderno == orderid
                         select (new { po.status });
            return status.ToString();
        }
        public void changePOStatus(int orderid, string status)
        {
            var ctx = new logicUniversityEntities();
            purchaseOrder po = ctx.purchaseOrders.Where(p => p.purchaseorderno == orderid).First();
            po.status = status;
           
            ctx.SaveChanges();          
        }
        public List<purchaseOrder> getPurchaseOrderListByStatus(int userid, string status)
        {
            var context = new logicUniversityEntities();
            return context.purchaseOrders.Where(po => po.userId == userid && po.status == status).ToList();
        }

        //receive purchaseOrder
        public List<purchaseOrder> getPurchaseOrderListForDelivery(int userid)
        {
            var context = new logicUniversityEntities();
            //PO Status Definition:
            //1. approved : when supervisor approve the PO

            List<purchaseOrder> list = getPurchaseOrderListByUserId(userid);
            returnlist = new List<purchaseOrder>();
            if (list != null)
            {
                foreach (purchaseOrder po in list)
                {
                    if (po.status == "approved")
                    {
                        returnlist.Add(po);
                    }
                }
                return returnlist;
            }
            else
            {
                return null;
            }
        }
        public void updatePurchaseDetail(int purchaseOrderid, List<purchaseDetail> receivedCart)
        {
            var context = new logicUniversityEntities();
            int count = receivedCart.Count;
            foreach (purchaseDetail pd in receivedCart)
            {
                context.purchaseDetails.Where(pdd => pdd.purchaseDetail_Id == pd.purchaseDetail_Id).First().receivedQuantity = pd.receivedQuantity;
            }
            context.purchaseOrders.Where(po => po.purchaseorderno == purchaseOrderid).First().status = "completed";
            context.SaveChanges();
        }
        public Boolean hasOutstanding(List<purchaseDetail> receivedCart)
        {
            var context = new logicUniversityEntities();
            List<purchaseDetail> list = receivedCart;
            foreach (purchaseDetail pd in list)
            {
                if ((pd.orderedQuantity - pd.receivedQuantity) != 0)
                {
                    isOustanding = true;
                    break;
                }
                else
                {
                    isOustanding = false;
                }
            }
            return isOustanding;
        }

        public List<purchaseOrder> getPurchaseOrderListByDateRange(int userid, DateTime startDate, DateTime endDate)
        {
            var context = new logicUniversityEntities();
            int syear = startDate.Year; int smonth = startDate.Month; int sday = startDate.Day;
            int eyear = endDate.Year; int emonth = endDate.Month; int eday = endDate.Day;

            return context.purchaseOrders.Where(po => po.userId == userid && po.purchaseDate >= new DateTime(syear, smonth, sday) && po.purchaseDate <= new DateTime(eyear, emonth, eday)).ToList();
                
        }
        public List<purchaseOrder> getPurchaseOrderListByDateRangeAndStatus(int userid, DateTime startDate, DateTime endDate, string status)
        {
            var context = new logicUniversityEntities();
            int syear = startDate.Year; int smonth = startDate.Month; int sday = startDate.Day;
            int eyear = endDate.Year; int emonth = endDate.Month; int eday = endDate.Day;

            return context.purchaseOrders.Where(po => po.userId == userid && po.purchaseDate >= new DateTime(syear, smonth, sday) && po.purchaseDate <= new DateTime(eyear, emonth, eday) && po.status == status).ToList();

        }

        public void changeStatus(int orderid, string status)
        {
            purchaseOrder po = getPurchaseOrderByPK(orderid);
            if (status == "approved")
            {
                po.status = "approved";
            }
            else
            {
                po.status = "rejected";
            }
            context.SaveChanges();
        }

        public void ChangePODetails(int podid, int receivedqty)
        {
            purchaseDetail pod = context.purchaseDetails.Where(pd => pd.purchaseDetail_Id == podid).FirstOrDefault();
            pod.receivedQuantity = receivedqty;
            context.SaveChanges();

        }

        public int? DefaultReorderQuantity(string itemcode)
        {
            return context.catelogueItems.Where(ca => ca.itemCode == itemcode).First().reorderQuantity;
        }

        public int ConfrimPOStatus(string poid)
        {
            int pid = Convert.ToInt32(poid);
            purchaseOrder po = context.purchaseOrders.Where(pod => pod.purchaseorderno == pid).FirstOrDefault();
            po.status = "completed";
            context.SaveChanges();
            return 1;
        }

        public List<int> getPOIds()
        {
            //var ids = from po in context.purchaseOrders
            //          where po.status == "approved"
            //          select po.purchaseorderno;
            //return ids.ToList();

            List<purchaseOrder> order = context.purchaseOrders.Where(x => x.status == "approved").ToList();
            List<int> poId = new List<int>();
            foreach (purchaseOrder p in order)
            {
                poId.Add(p.purchaseorderno);
            }

            return poId;
        }

        public List<Model.PoDetails> podetails(int poid)
        {
            var list = from po in context.purchaseDetails
                       from ci in context.catelogueItems
                       where po.purchaseOrderno == poid
                       where po.itemCode == ci.itemCode
                       select new Model.PoDetails
                       {
                           purchaseDetail_Id = po.purchaseDetail_Id,
                           itemdesp = ci.itemDescription,
                           orderedQuantity = po.orderedQuantity
                       };
            return list.ToList();
        }

        public int RejectPOStatus(string poid)
        {
            int pid = Convert.ToInt32(poid);
            purchaseOrder po = context.purchaseOrders.Where(pod => pod.purchaseorderno == pid).FirstOrDefault();
            po.status = "rejected";
            context.SaveChanges();
            return 1;
        }
    }
}