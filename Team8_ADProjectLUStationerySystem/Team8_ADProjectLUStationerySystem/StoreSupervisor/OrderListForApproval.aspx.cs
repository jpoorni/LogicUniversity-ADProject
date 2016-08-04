using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.StoreSupervisor
{
    public partial class OrderListForApproval : System.Web.UI.Page
    {
        OrderBLL orderlogic = new OrderBLL();
        UserBLL userlogic = new UserBLL();
        int userid;

        //create session for ApproveAll button

        protected void Page_Load(object sender, EventArgs e)
        {
            #region LoginSecurity definition
            //prevent entering page address in browser by invalid user
            if (Session["UserID"] != null)
            {
                if (userlogic.GetUserByID(Convert.ToInt32(Session["UserID"])).roleId != 11001)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
                else
                {
                    LoadGridView();
                } 
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }
            #endregion            
        }
        protected void LoadGridView()
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            gvOrderList.DataSource = orderlogic.GetPurchaseOrderListByUserId(userid);
            gvOrderList.DataBind();
        }
        protected void gvOrderListInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("gvOrderDetail");
                int orderid = Convert.ToInt32(e.Row.Cells[1].Text);
                gv.DataSource = orderlogic.GetPurchaseDetailByOrderId(orderid);
                gv.DataBind();
            }
        }
        protected void gvOrderList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = Convert.ToInt32(e.CommandArgument);
            int orderid = Convert.ToInt32(gvOrderList.Rows[rowindex].Cells[1].Text);

            if (e.CommandName == "Approve")
            {
                orderlogic.ChangePOStatus(orderid, "approved");
            }
            else
            {
                orderlogic.ChangePOStatus(orderid, "rejected");
            }
            LoadGridView();
        }
    }
}