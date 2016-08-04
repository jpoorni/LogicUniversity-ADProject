using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.DepartmentHead
{
    public partial class DisbursementHistory : System.Web.UI.Page
    {
        Requisitioin R = new Requisitioin();
        UserBLL UBL = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (DateFromTb.Text != "" && DateToTb.Text != "")
            {
                loadGridview();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Warning", "alert('Please Enter from and To Date!!!')", true);
            }

        }

        private void loadGridview()
        {
            int userid = (int)Session["UserID"];
            //int userid = 1004;

           // int? roleID = UBL.getRoleID(userid);

            DateTime fromdate = Convert.ToDateTime(DateFromTb.Text);
            DateTime todate = Convert.ToDateTime(DateToTb.Text);
            string deptcode = R.findDeptCode(userid);

            List<Models.DisbursementModel> list = R.deptfromtodates(deptcode, fromdate, todate);

            if (list.Count > 0)
            {
                LabelMessage.Visible = false;
                DisbursementListGridView.DataSource = list;
                DisbursementListGridView.DataBind();
            }

            else
            {
                LabelMessage.Visible = true;
                LabelMessage.Text = "No Values Found!!!!";
                //  ScriptManager.RegisterStartupScript(Page, this.GetType(), "Message", "alert('No Values!!!')", true);
            }

            //int roleID = UBL.getUserRoleByUserid(userid);

            //DateTime fromdate = Convert.ToDateTime(DateFromTb.Text);
            //DateTime todate = Convert.ToDateTime(DateFromTb.Text);

            //if (roleID == 11003)
            //{
            //    string deptcode = R.findDeptCode(userid);
            //    DisbursementListGridView.DataSource = R.deptfromtodates(deptcode, fromdate, todate);
            //    DisbursementListGridView.DataBind();
            //}
            //else
            //{
            //    DisbursementListGridView.DataSource = R.getfromtodates(userid, fromdate, todate);
            //    DisbursementListGridView.DataBind();
            //}
        }

        protected void DisbursementListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadGridview();
            DisbursementListGridView.PageIndex = e.NewPageIndex;
            DisbursementListGridView.DataBind();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Label label = (Label)lb.FindControl("Label3");
            int disid = Convert.ToInt32(label.Text);
            Session["disid"] = disid;
            Response.Redirect("DisbursementForm.aspx");

        }
        protected void DateToTb_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(DateToTb.Text) < Convert.ToDateTime(DateFromTb.Text))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "msgbox", "alert('From date cannot be greater than To date')", true);
                DateToTb.Text = "";
                DateFromTb.Text = "";
            }
        }
}
}