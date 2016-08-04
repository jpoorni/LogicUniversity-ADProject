using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.StoreClerk1
{
    public partial class OrderListForStoreClerk : System.Web.UI.Page
    {
        //createObject of Business Logic
        OrderBLL orderlogic = new OrderBLL();
        UserBLL userlogic = new UserBLL();

        List<purchaseOrder> orderlist;
        DateTime startDate, endDate; string status;
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

            if (!this.IsPostBack)
            {
                LoadGridView();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Please choose Start Date and End Date')", true);
                //startDate = DateTime.Now.Date.AddDays(-1);
                //endDate = DateTime.Now.Date; 
            }
            else
            {
                startDate = Convert.ToDateTime(txtStartDate.Text);
                endDate = Convert.ToDateTime(txtEndDate.Text);
            }

            status = rdostatus.SelectedValue;
            orderlist = orderlogic.GetPurchaseOrderListByDateAndStatus(Convert.ToInt32(Session["UserID"]), startDate, endDate, status);

            if (orderlist.Count != 0)
            {
                gvOrderList.DataSource = orderlist;
                gvOrderList.DataBind();
            }
            else
            {
                gvOrderList.DataSource = "";
                gvOrderList.DataBind();
            }          
        }
        protected void LoadGridView()
        {
            gvOrderList.DataSource = orderlogic.GetPurchaseDetailByOrderId(Convert.ToInt32(Session["UserID"]));
            gvOrderList.DataBind();
        }

        //protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvOrderList.DataSource = orderlogic.GetPurchaseOrderListByDateAndStatus(Convert.ToInt32(Session["UserID"]), startDate, endDate, status);
        //    gvOrderList.DataBind();
        //    gvOrderList.PageIndex = e.NewPageIndex;
        //    gvOrderList.DataBind();

        //}
        protected void gvOrderListInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("gvOrderDetail");
                int orderid = Convert.ToInt32(e.Row.Cells[1].Text);
                gv.DataSource = orderlogic.GetPurchaseDetailByOrderId2(orderid);
                gv.DataBind();
            }
        }
        protected void gvOrderList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = Convert.ToInt32(e.CommandArgument);
            orderlist = orderlogic.GetPurchaseOrderListByUserId(Convert.ToInt32(Session["UserID"]));
            //if(rowindex < orderlist.Count)
            //{
                int orderid = Convert.ToInt32(gvOrderList.Rows[rowindex].Cells[1].Text);
                Response.Redirect("CreateOrder.aspx?orderid=" + orderid);
            //}        
        }
        
    }
}