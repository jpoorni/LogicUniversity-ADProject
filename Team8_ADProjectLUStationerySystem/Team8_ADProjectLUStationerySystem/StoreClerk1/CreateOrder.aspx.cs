using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.StoreClerk1
{
    public partial class CreateOrder : System.Web.UI.Page
    {
        //createObject of BusinessLogic
        SupplierBLL supplierlogic = new SupplierBLL();
        CategoryBLL categorylogic = new CategoryBLL();
        ItemBLL itemlogic = new ItemBLL();
        UserBLL userlogic = new UserBLL();
        OrderBLL orderlogic = new OrderBLL();
        ValidationBLL validation = new ValidationBLL();

        List<purchaseDetail> orderCart; //create cart for purchaseOrderDetail

        protected void Page_Load(object sender, EventArgs e)
        {
            #region LoginSecurity definition
            //prevent entering page address in browser by invalid user
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
            #endregion

            if (!IsPostBack)
            {
                Session.Remove("OrderCart");
                LoadCategoryList();
                LoadSupplierList();

                if (isReorder())
                {
                    Session["OrderCart"] = orderlogic.ReorderCart(orderlogic.GetPurchaseDetailByOrderId(Convert.ToInt32(Request.QueryString["orderid"])));
                    refreshGridView();
                    btnCreate.Visible = true;
                    btnCancel.Visible = true;
                }

                //btnCreate.Visible = false;
                //btnCancel.Visible = false;
                ////lblTotal.Visible = false;
            }

            //create cart for purchaseOrderDetail
            orderCart = Session["OrderCart"] != null ? (List<purchaseDetail>)Session["OrderCart"] : null;
            if (orderCart == null)
            {
                btnCreate.Visible = false;
                btnCancel.Visible = false;
                List<purchaseDetail> newCart = new List<purchaseDetail>();
                Session["OrderCart"] = newCart;

            }
            else
            {
                Session["OrderCart"] = orderCart;
                //lblTotal.Text = "Total Order Amount : " + orderlogic.GetOrderCartTotal((List<purchaseDetail>)Session["OrderCart"]).ToString();
            }
            CalculateTotal(orderCart);
            lblErrorMsg.Text = "";
        }

        public void CalculateTotal(List<purchaseDetail> cart)
        {
            double cartTotal = 0;
            cartTotal = orderlogic.GetOrderCartTotal(cart);
            if (cartTotal > 0)
            {
                //display total
                lblTotal.Text = String.Format("{0:c}", cartTotal);
            }
            else
            {
                LabelTotalText.Text = "";
                lblTotal.Text = "";

            }
        }
        protected Boolean isReorder()
        {
            if (Request.QueryString["orderid"] == null)
                return false;
            else
                return true;
        }
        protected void LoadSupplierList()
        {
            ddlSupplier.DataSource = supplierlogic.getTenderSupplier();
            ddlSupplier.DataValueField = "supplierCode";
            ddlSupplier.DataTextField = "supplierName";
            ddlSupplier.DataBind();

            lblAddress.Text = supplierlogic.getTenderSupplier().First().address.ToString();
        }
        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplier s = supplierlogic.getSupplierByPK(ddlSupplier.SelectedValue);
            lblAddress.Text = s.address.ToString();
        }
        protected void LoadCategoryList()
        {
            ddlCategory.DataSource = categorylogic.getAllCategory();
            ddlCategory.DataValueField = "categoryId";
            ddlCategory.DataTextField = "categoryName";
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex != 0)
            {
                gdvCatelogueItem.DataSource = itemlogic.getAllItemByCategory(Convert.ToInt32(ddlCategory.SelectedValue));
                gdvCatelogueItem.DataBind();
            }
        }
        protected void gdvCatelogueItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            clearlist();
            int rowindex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ChooseComm")
            {
                catelogueItem itm = itemlogic.getItem(gdvCatelogueItem.Rows[rowindex].Cells[0].Text);
                txtItemDescription.Text = itm.itemCode + "-" + itm.itemDescription;
                txtQty.Text = itm.reorderQuantity.ToString();
                lblUoM.Text = itm.uom;
            }
        }
        protected void gvOrderDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = Convert.ToInt32(e.CommandArgument);

            orderCart = Session["OrderCart"] != null ? (List<purchaseDetail>)Session["OrderCart"] : null;
            if (orderCart != null)
            {
                if (e.CommandName == "RemoveComm")
                {
                    itemRemoveFromOrderCart(rowindex);
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtItemDescription.Text != "")
            {
                orderCart = Session["OrderCart"] != null ? (List<purchaseDetail>)Session["OrderCart"] : null;
                string itemcode = txtItemDescription.Text.Substring(0, 4);
                //checking duplicate item
                if (orderCart.Count == 0)
                {
                    if (validation.checkOrderValue(Convert.ToInt32(txtQty.Text)))
                    {
                        List<purchaseDetail> updateCart = orderlogic.AddToOrderCart(itemcode, Convert.ToInt32(txtQty.Text), orderCart);

                        Session["OrderCart"] = updateCart;
                        refreshGridView();
                    }
                    else
                    {
                        lblErrorMsg.Text = "Order Quantity Should be between 9 and 1500";
                    }

                }
                else
                {
                    if (isDuplicate(orderCart, itemcode))
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "ErrroAlert", "alert('Item Alredy Added!');", true);
                    }
                    else
                    {
                        foreach (purchaseDetail pd in orderCart)
                        {
                            if (validation.checkOrderValue(Convert.ToInt32(txtQty.Text)))
                            {
                                List<purchaseDetail> updateCart = orderlogic.AddToOrderCart(itemcode, Convert.ToInt32(txtQty.Text), orderCart);

                                Session["OrderCart"] = updateCart;
                                refreshGridView();
                                break;
                            }
                            else
                            {
                                lblErrorMsg.Text = "Order Quantity Should be between 9 and 1500";
                            }
                        }
                    }
                }
                btnCreate.Visible = true;
                btnCancel.Visible = true;
                clearlist();
            }
            else
            {
                lblErrorMsg.Text = "Please select Stationery Item";
            }

        }

        private Boolean isDuplicate(List<purchaseDetail> cart, string itemcode)
        {
            Boolean duplicate = true;
            foreach (purchaseDetail pd in cart)
            {
                if (pd.itemCode != itemcode)
                {
                    duplicate = false;
                }
                else
                {
                    duplicate = true;
                    break;
                }
            }
            return duplicate;
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string suppliercode = ddlSupplier.SelectedValue;
            if (suppliercode == null)
            {
                lblErrorMsg.Text = "Please choose supplier";
            }
            else
            {
                int userid = Convert.ToInt32(Session["UserID"]);
                orderCart = Session["OrderCart"] != null ? (List<purchaseDetail>)Session["OrderCart"] : null;
                orderlogic.CreateOrder(suppliercode, userid, orderCart);

            }

            //show order list page.
            Session.Remove("OrderCart");
            Response.Redirect("OrderListForStoreClerk.aspx");

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("OrderCart");
            clearlist();
            refreshGridView();
            lblAddress.Text = "";
            LoadSupplierList();
            btnCreate.Visible = false;
            btnCancel.Visible = false;
        }
        protected void itemRemoveFromOrderCart(int rowindex)
        {
            orderCart.Remove(orderCart[rowindex]);
            Session["OrderCart"] = orderCart;
            refreshGridView();
            CalculateTotal(orderCart);

            if (orderCart.Count == 0)
            {
                btnCreate.Visible = false;
                btnCancel.Visible = false;
            }
        }
        protected void clearlist()
        {
            txtItemDescription.Text = "";
            txtQty.Text = "";
            lblUoM.Text = "";
            LabelTotalText.Text = "";
            lblTotal.Text = "";
        }
        protected void refreshGridView()
        {
            gvOrderDetail.DataSource = Session["OrderCart"];
            gvOrderDetail.DataBind();
        }

        protected void gvOrderDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            refreshGridView();
            gvOrderDetail.PageIndex = e.NewPageIndex;
            gvOrderDetail.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            MainExender.Hide();
        }
    }
}