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
    public partial class SpecialAdjustment : System.Web.UI.Page
    {
        AdjustInventoryBLL ad = new AdjustInventoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                if (Session["detail"] != null)
                {
                    AdjustmentGridView.Visible = true;
                    btnSubmit.Visible = true;
                    Label1.Visible = false;
                    AdjustmentGridView.DataSource = (List<adjustmentDetail>)Session["detail"];
                    AdjustmentGridView.DataBind();
                }
                else
                {
                    AdjustmentGridView.Visible = false;
                    btnSubmit.Visible = false;
                    Label1.Visible = true;
                }
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            List<adjustmentDetail> list = (List<adjustmentDetail>)Session["detail"];
            int uid = (int)Session["UserID"];
            for (int i = 0; i < AdjustmentGridView.Rows.Count; i++)
            {

                string reason = ((DropDownList)AdjustmentGridView.Rows[i].Cells[3].FindControl("dlReason")).SelectedValue;
                list[i].reason = reason;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Saved!');</script>");
                AdjustmentGridView.Visible = false;
                btnSubmit.Visible = false;
                Label1.Visible = true;
            }
            ad.CreateSpecialAdjustment(list, uid);
            Session["detail"] = null;

        }
    }
}