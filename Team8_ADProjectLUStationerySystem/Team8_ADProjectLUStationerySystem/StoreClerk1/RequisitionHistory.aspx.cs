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
    public partial class RequisitionHistory : System.Web.UI.Page
    {
        Requisitioin R = new Requisitioin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                RequisitionHistoryGridView.DataSource = R.getSearch(0, 0);
                RequisitionHistoryGridView.DataBind();
                Label1.Visible = false;
                
            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridView();
        }


        protected void LoadGridView()
        {
            var r = R.getSearch(Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(DropDownList3.SelectedValue));
            if (r.Count != 0)
            {
                RequisitionHistoryGridView.Visible = true;
                RequisitionHistoryGridView.DataSource = r;
                RequisitionHistoryGridView.DataBind();
                Label1.Visible = false;
            }
            else
            {
                RequisitionHistoryGridView.Visible = false;
                Label1.Visible = true;
            }
            
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridView();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenField1");
            Session["reqid"] = Convert.ToInt32(hd.Value);
            Response.Redirect("RequisitionForm.aspx");
        }
    }
}