using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team8_ADProjectLUStationerySystem.DAO;

namespace Team8_ADProjectLUStationerySystem.BusinessLogic
{
    public class OrderBLL
    {
        //createObject of BusinessLogic
        SupplierBLL supplierlogic = new SupplierBLL();
        CategoryBLL categorylogic = new CategoryBLL();
        ItemBLL itemlogic = new ItemBLL();
        UserBLL userlogic = new UserBLL();


        //createObject of DAO
        OrderDAO orderDAO = new OrderDAO();
        MailController mail = new MailController();

        purchaseDetail purDetail; catelogueItem item; List<purchaseDetail> updateCart; List<purchaseOrder> list;
        public List<purchaseDetail> AddToOrderCart(string itemcode, int orderedQty, List<purchaseDetail> orderCart)
        {
                purDetail = new purchaseDetail();

                purDetail.itemCode = itemcode;
                purDetail.itemDescription = GetItemDescription(itemcode);
                purDetail.orderedQuantity = orderedQty;
                purDetail.price = item.tenderPrice;
                purDetail.amount = (orderedQty * item.tenderPrice);
                purDetail.receivedQuantity = 0;

                orderCart.Add(purDetail);
                updateCart = orderCart;

                return updateCart;
        }

        public List<purchaseDetail> ReorderCart(List<purchaseDetail> reorderCart)
        {
            updateCart = new List<purchaseDetail>();
            foreach (purchaseDetail pd in reorderCart)
            {
                purDetail = new purchaseDetail();

                purDetail.itemCode = pd.itemCode;
                purDetail.itemDescription = GetItemDescription(pd.itemCode);
                purDetail.orderedQuantity = pd.orderedQuantity;
                purDetail.price = pd.price;
                purDetail.amount = (pd.orderedQuantity * pd.price);
                purDetail.receivedQuantity = 0;

                updateCart.Add(purDetail);                
            }
            return updateCart;            
        }

        public string GetItemDescription(string itemcode)
        {
            //to show item description in gvOrderDetail
            item = new catelogueItem();
            item = itemlogic.getItem(itemcode);
            return (item.itemDescription);
        }
        public double GetOrderCartTotal(List<purchaseDetail> orderCart)
        {
            double total = 0.0;
            if (orderCart == null)
            {
                total = 0.0;
            }
            else
            {
                total = orderDAO.getOrderCartTotal(orderCart);
            }
            
            //if (orderCart.Count != 0 || orderCart != null)
            //{
            //    total = orderDAO.getOrderCartTotal(orderCart);
            //}
            //else
            //{
            //    total = 0.0;
            //}
            return total;
        }
        public void CreateOrder(string suppliercode, int userid, List<purchaseDetail> orderCart)
        {
            orderDAO.createOrder(suppliercode, userid, orderCart);
            mail.NewOrderNoti();
        }
        public purchaseOrder GetPurchaseOrderByPK(int orderid)
        {
            return orderDAO.getPurchaseOrderByPK(orderid);
        }
        public List<purchaseOrder> GetPurchaseOrderListByUserId(int userid)
        {
            //check login user role
            //purchaseOrder list will vary based on user role
            if(userlogic.GetUserByID(userid).roleId == 11001)                       
            {
                //for supervisor
                list = orderDAO.getPurchaseOrderListForApproval();
            }
            else
            {
                //for particular storeclerk
                list = orderDAO.getPurchaseOrderListByUserId(userid);
            }
            return list;
        }
        public List<purchaseDetail> GetPurchaseDetailByOrderId(int orderid)
        {
            List<purchaseDetail> nlist = new List<purchaseDetail>();
            updateCart = orderDAO.getPurchaseDetailByOrderId(orderid);
            foreach (purchaseDetail pd in updateCart)
            {                 
                pd.receivedQuantity = pd.orderedQuantity - pd.receivedQuantity;
                nlist.Add(pd);
            }
            return nlist;
        }

        public List<purchaseDetail> GetPurchaseDetailByOrderId2(int orderid)
        {            
            return updateCart = orderDAO.getPurchaseDetailByOrderId2(orderid);
            
        }
        public void ChangePOStatus(int orderid, string status)
        {
            orderDAO.changePOStatus(orderid, status);
            mail.orderStatusNoti(orderid, status);
        }
        public List<purchaseOrder> GetPurchaseOrderListByStatus(int userid, string status)
        {
            return orderDAO.getPurchaseOrderListByStatus(userid, status);
        }
        public List<purchaseOrder> GetPurchaseOrderListForDelivery(int userid)
        {
            return orderDAO.getPurchaseOrderListForDelivery(userid);
        }
        public Boolean correctQty(int poDetailId, int receivedQty)
        {
            purchaseDetail pd = orderDAO.getPurchaseDetailByPK(poDetailId);

            if ((pd.orderedQuantity - pd.receivedQuantity) >= receivedQty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void UpdatePurchaseDetail(int purchaseOrderid, List<purchaseDetail> receivedCart)
        {
            orderDAO.updatePurchaseDetail(purchaseOrderid, receivedCart);
        }
        public List<purchaseOrder> GetPurchaseOrderListByDateAndStatus(int userid, DateTime startDate, DateTime endDate, string status)
        {
            if (status != "all")
            {
                return orderDAO.getPurchaseOrderListByDateRangeAndStatus(userid, startDate, endDate, status);
            }
            else
            {
                return orderDAO.getPurchaseOrderListByDateRange(userid, startDate, endDate);
            }
        }

        public void ChangeStatus(int orderid, string status)
        {
            orderDAO.changeStatus(orderid, status);
        }
        public void ChangePODetails(int podid, int receivedqty)
        {
            orderDAO.ChangePODetails(podid, receivedqty);
        }

        public int? DefaultReorderQuantity(string itemcode)
        {
            return orderDAO.DefaultReorderQuantity(itemcode);
        }

        public int ConfrimPOStatus(string poid)
        {
            return orderDAO.ConfrimPOStatus(poid);
        }

        public List<int> getPOIds()
        {
            return orderDAO.getPOIds();
        }

        public List<Model.PoDetails> podetails(int poid)
        {
            return orderDAO.podetails(poid);
        }

        public int RejectPOStatus(string poid)
        {
            return orderDAO.RejectPOStatus(poid);
        }

       

    }
}