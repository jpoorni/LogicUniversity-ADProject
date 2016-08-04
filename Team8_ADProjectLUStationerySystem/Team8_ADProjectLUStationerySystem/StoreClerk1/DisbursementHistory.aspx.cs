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
    public partial class DisbursementHistory : System.Web.UI.Page
    {
        Disbursement db = new Disbursement();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            DateTime from = Convert.ToDateTime(DateFromTb.Text);
            DateTime to = Convert.ToDateTime(DateToTb.Text);
            if (from > to)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Wrong Date');</script>");
            }
            else
            {
                List<disbursement> list = db.getByDate(from, to);
                if (list.Count != 0)
                {
                    DisbursementGridView.DataSource = list;
                    DisbursementGridView.DataBind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('No Record!');</script>");
                }

            }
           
            
        }

        protected void lbView_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenField1");
            int disid = Convert.ToInt32(hd.Value);
            Session["disid"] = disid;
            Response.Redirect("DisbursementForm.aspx");
        }
    }
}