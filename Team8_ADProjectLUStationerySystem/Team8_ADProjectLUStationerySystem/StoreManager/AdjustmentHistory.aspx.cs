using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.StoreManager
{
    public partial class AdjustmentHistory : System.Web.UI.Page
    {
        AdjustInventoryBLL a = new AdjustInventoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (DateFromTb.Text == "" || DateToTb.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Please choose From Date and To Date')", true);
            }
            else
            {
                DateTime from = Convert.ToDateTime(DateFromTb.Text);
                DateTime to = Convert.ToDateTime(DateToTb.Text);

                if (from > to)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Wrong Date');</script>");
                }
                else
                {
                    List<adjustment> list = a.getHistory(from, to);
                    if (list.Count != 0)
                    {
                        AdjustmentGridView.DataSource = list;
                        AdjustmentGridView.DataBind();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No Record!');</script>");
                    }
                }
            }
        }

        protected void lbView_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenField1");
            string adjid = hd.Value;
            Session["adjid"] = adjid;
            Response.Redirect("AdjustmentForm.aspx");
        }
    }
}