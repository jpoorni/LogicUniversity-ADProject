using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.StoreClerk1
{
    public partial class ReceiveOrder : System.Web.UI.Page
    {
        //createObject of BusinessLogic
        SupplierBLL supplierlogic = new SupplierBLL();
        CategoryBLL categorylogic = new CategoryBLL();
        UserBLL userlogic = new UserBLL();
        ItemBLL itemlogic = new ItemBLL();
        OrderBLL orderlogic = new OrderBLL();
        Boolean canprocess = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            Session.Remove("OrderCart");
            if (Session["UserID"] != null)
            {
                if (userlogic.GetUserByID(Convert.ToInt32(Session["UserID"])).roleId != 11000)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }
            //try
            //{
            //    userid = Convert.ToInt32(Session["UserID"]);
            //    if (userlogic.GetUserByID(userid).roleId != 11000)
            //    {
            //        Response.Redirect("~/LoginPage.aspx");
            //    }
            //}
            //catch
            //{
            //    Response.Redirect("~/LoginPage.aspx");
            //}

            if (!IsPostBack)
            {
                RefreshAll();
            }
        }
        protected void LoadPurchaseOrderList()
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            List<purchaseOrder> list = orderlogic.GetPurchaseOrderListForDelivery(userid);
            if (list != null)
            {
                ddlPurchaseOrder.DataSource = list;
                ddlPurchaseOrder.DataValueField = "purchaseorderno";
                ddlPurchaseOrder.DataTextField = "purchaseorderno";
                ddlPurchaseOrder.DataBind();

                ddlPurchaseOrder.Items.Insert(0, new ListItem("--Select PO--", "0"));
            }
            else
            {
                ddlPurchaseOrder.Items.Insert(0, new ListItem("--NO Order--", "0"));
            }
        }
        protected void ddlPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPurchaseOrder.SelectedIndex == 0)
            {
                RefreshAll();
            }
            else
            {
                lblPOstatus.Text = orderlogic.GetPurchaseOrderByPK(Convert.ToInt32(ddlPurchaseOrder.SelectedValue)).status.ToString();
                btnReceiveDelivery.Visible = true;
                btnRejectDelivery.Visible = true;

                gvOrderDetail.DataSource = orderlogic.GetPurchaseDetailByOrderId(Convert.ToInt32(ddlPurchaseOrder.SelectedValue));
                gvOrderDetail.DataBind();
            }            
        }

        protected void RefreshAll()
        {
            LoadPurchaseOrderList();
            lblPOstatus.Text = "";
            btnReceiveDelivery.Visible = false;
            btnRejectDelivery.Visible = false;
            ClearGridView();
        }
        protected void btnReceiveDelivery_Click(object sender, EventArgs e)
        {
            List<purchaseDetail> receivedCart = new List<purchaseDetail>();
            List<purchaseDetail> tempCart = orderlogic.GetPurchaseDetailByOrderId(Convert.ToInt32(ddlPurchaseOrder.SelectedValue));

            for (int i = 0; i < tempCart.Count; i++)
            {
                TextBox txtQuantity = (TextBox)gvOrderDetail.Rows[i].Cells[0].FindControl("txtReceivedQty");
                tempCart[i].receivedQuantity = Convert.ToInt32(txtQuantity.Text);
            }

            //Now : tempCart is final receivedPO details

            foreach (purchaseDetail po in tempCart)
            {            
                if (po.orderedQuantity < po.receivedQuantity)
                {
                    canprocess = false;
                    break;
                }
                else
                {
                    receivedCart.Add(po);
                    canprocess = true;
                }
            }

            if (canprocess)
            {
                orderlogic.UpdatePurchaseDetail(Convert.ToInt32(ddlPurchaseOrder.SelectedValue), receivedCart);
                updateStockCardAndCatelogueItem(receivedCart);
                RefreshAll();
                lblStatus.Text = "Order Delivery successfully received !";                
            }
            else
            {
                lblStatus.Text = "Incorrect ! received quantity is more than ordered quantity.";
                //ClearGridView();

                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + "Incorrect Qty !" + "'); ", true);
            }                                                
        }      
        protected void btnRejectDelivery_Click(object sender, EventArgs e)
        {
            orderlogic.ChangePOStatus(Convert.ToInt32(ddlPurchaseOrder.SelectedValue), "rejected");
            RefreshAll();
            lblStatus.Text = "Order Delivery rejected !";
        }
        public void updateStockCardAndCatelogueItem(List<purchaseDetail> list)
        {
            logicUniversityEntities luSSEntity = new logicUniversityEntities();
            foreach (purchaseDetail d in list)
            {
                stockCard newtransaction = new stockCard();
                newtransaction.itemCode = d.itemCode;
                newtransaction.transactionDate = DateTime.Now;
                newtransaction.transactionType = "Supplier Order-Delivery" + " (" + d.purchaseOrder.supplier.supplierName + ")";
                newtransaction.quantity = d.receivedQuantity;
                newtransaction.balance = d.catelogueItem.quantity + d.receivedQuantity;
                luSSEntity.stockCards.Add(newtransaction);

                //update catelogueItems quantity 
                luSSEntity.catelogueItems.Where(c => c.itemCode == d.itemCode).First().quantity += d.receivedQuantity; 
            }
            luSSEntity.SaveChanges();
        }
        protected void ClearGridView()
        {
            gvOrderDetail.DataSource = null;
            gvOrderDetail.DataBind();
        }
    }
}