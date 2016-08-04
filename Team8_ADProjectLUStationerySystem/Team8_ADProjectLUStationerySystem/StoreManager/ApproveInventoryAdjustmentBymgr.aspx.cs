using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.StoreManager
{
    public partial class ApproveInventoryAdjustmentBymgr : System.Web.UI.Page
    {
        AdjustInventoryBLL adglogic = new AdjustInventoryBLL();
        List<adjustment> adjCart; List<adjustment> adj; int userid; UserBLL userlogic = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["UserID"] != null)
            {
                userid = Convert.ToInt32(Session["UserID"]);
                if (userlogic.GetUserByID(userid).roleId != 11002)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }


            if (!IsPostBack)
            {
                LoadAllAdjustment();

            }



            gdvAdjustment.Visible = true;
            adjCart = Session["Adj"] != null ? (List<adjustment>)Session["Adj"] : null;
            if (adjCart == null)
            {
                List<adjustmentDetail> newcart = new List<adjustmentDetail>();
                Session["Adj"] = newcart;

            }
            else
            {
                Session["Adj"] = adjCart;
            }

        }

        protected void LoadAllAdjustment()
        {
            String userid = Session["UserID"].ToString();
            Session["Adj"] = adglogic.LoadAllAdjust(userid);
            List<adjustment> adj = new List<adjustment>();
             adj = adglogic.LoadAllAdjust(userid);
            if(adj.Count == 0)
            {
                btnApproveAll.Visible = false;
                btnRejectAll.Visible = false;
                gdvAdjustment.DataSource = adj;//adglogic.LoadAllAdjust(userid);
                gdvAdjustment.DataBind();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + "No Adjustment List to approve!" + "');", true);
            }
            else 
            {

                gdvAdjustment.DataSource = adj;//adglogic.LoadAllAdjust(userid);
                gdvAdjustment.DataBind();


            }
            

        }

        protected List<adjustmentDetail> callAdjustDetails(String id)
        {

            List<adjustmentDetail> detaillist = new List<adjustmentDetail>();
            detaillist = adglogic.getAdjustmentDetailsbyID(id);

            return detaillist;
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            
            int adjid = Convert.ToInt32(hdfid.Value);

            adglogic.ApproveAdjustmentByone(adjid);           
            gdvAdjustment.DataBind();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + "Completed!" + "');", true);
            
        }


        protected void btnReject_Click(object sender, EventArgs e)
        {
            
            int adjid = Convert.ToInt32(hdfid.Value);
            adglogic.RejectAdjustmentByOne(adjid);
            gdvAdjustment.DataBind();

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + "Completed!" + "');", true);
            
        }

        protected void btnApproveAll_Click(object sender, EventArgs e)
        {
            List<adjustment> adjlist = new List<adjustment>();
            adjlist = (List<adjustment>)Session["Adj"];
            List<int> idlist = new List<int>();
            foreach (adjustment adj in adjlist)
            {
                int id = adj.adjustmentId;

                idlist.Add(id);

            }

            adglogic.ApproveAdjustment(idlist);
            this.Page.Session.Clear();
            gdvAdjustment.DataBind();
            btnApproveAll.Visible = false;
            btnRejectAll.Visible = false;
            
        }

        public String Myrow(object adjustmentId)
        {
            /* 
                * 1. Close current cell in our example phone </TD>
                * 2. Close Current Row </TR>
                * 3. Cretae new Row with ID and class <TR id='...' style='...'>
                * 4. Create blank cell <TD></TD>
                * 5. Create new cell to contain the grid <TD>
                * 6. Finall grid will close its own row
                ************************************************************/
            return String.Format(@"</td></tr><tr id ='tr{0}' style='display:none;  padding:0px; margin:0px;'>
               <td></td><td colspan='100' style='padding:0px; margin:0px;'>", adjustmentId);
        }

        protected void gdvAdjustment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string id = gdvAdjustment.DataKeys[e.Row.RowIndex].Value.ToString();
                var adjdetails = (GridView)e.Row.FindControl("gdvAdjustmentDetails");


                var orders = callAdjustDetails(id);
                adjdetails.DataSource = orders;
                adjdetails.DataBind();
            }
        }

        protected void btnRejectAll_Click(object sender, EventArgs e)
        {

            List<adjustment> adjlist = new List<adjustment>();
            adjlist = (List<adjustment>)Session["Adj"];
            List<int> idlist = new List<int>();
            foreach (adjustment adj in adjlist)
            {
                int id = adj.adjustmentId;

                idlist.Add(id);

            }


            adglogic.RejectAdjustment(idlist);

            Session.Remove("Adj");
            
            gdvAdjustment.DataBind();
            btnApproveAll.Visible = false;
            btnRejectAll.Visible = false;
        }

        protected void gdvAdjustment_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            int ee = Convert.ToInt32(e.CommandArgument);  


           String userid = Session["UserID"].ToString();
            List<adjustment> adj = adglogic.LoadAllAdjust(userid);
            int id = Convert.ToInt32(gdvAdjustment.Rows[ee].Cells[1].Text);
            if(ee < adj.Count )
            {             

                if (e.CommandName == "ApproveComm")
                {


                    adglogic.ApproveAdjustmentByone(id);
                    LoadAllAdjustment();

                   
            

                }
                else if (e.CommandName == "RejectComm")
                {

                    adglogic.RejectAdjustmentByOne(id);
                    LoadAllAdjustment();

                

                }
            }

           
           
        }

      
       
    }
}