using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.StoreClerk1
{
    public partial class InventoryAdjustmentList : System.Web.UI.Page
    {
        AdjustInventoryBLL adglogic = new AdjustInventoryBLL(); int userid; UserBLL userlogic = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                userid = Convert.ToInt32(Session["UserID"]);
                //userlogic.GetUserByID(userid).roleId != 11001 || userlogic.GetUserByID(userid).roleId != 11002 || userlogic.GetUserByID(userid).roleId != 11000
                int roleid = Convert.ToInt32((userlogic.GetUserByID(userid).roleId));
                if (roleid == 11004)
               

              //  if (id != 11000)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            catch
            {
                Response.Redirect("~/LoginPage.aspx");
            }

            LoadAllAdjustment();
            
        }

        protected void LoadAllAdjustment()
        {
            

            gdvAdjustment.DataSource = adglogic.LoadAllAdjustList();
            gdvAdjustment.DataBind();

        }


        protected void gdvAdjustment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            pnlAdjustmentDetails.Visible = true;
           
            if (e.CommandName == "DetailsComm")
            {

                int ee = Convert.ToInt32(e.CommandArgument);
                String id = gdvAdjustment.Rows[ee].Cells[0].Text;
                AdjustmentAmtLbl.Text = gdvAdjustment.Rows[ee].Cells[2].Text;
                hdfid.Value = id;

                callAdjustDetails(id);


            }
        }

        protected void callAdjustDetails(String id)
        {

            List<adjustmentDetail> detaillist = new List<adjustmentDetail>();
            detaillist = adglogic.getAdjustmentDetailsbyID(id);

            gdvAdjustmentDetails.DataSource = detaillist;
            gdvAdjustmentDetails.DataBind();

        }

      

    }
}