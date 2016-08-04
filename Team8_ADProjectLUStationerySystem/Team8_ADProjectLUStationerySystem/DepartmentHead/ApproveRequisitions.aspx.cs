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
    public partial class ApproveRequisitions : System.Web.UI.Page
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
                bindRequisition();
            }
        }

        private void bindRequisition()
        {
            int userid = (int)Session["UserID"];
           // int userid = 1006;
            string deptcode = R.findDeptCode(userid);
            List<Models.RequisitionModel> list = R.bindRequisition(deptcode);

            if(list.Count>0)
            {
            GridView1.Visible = true;
            LabelMessage.Visible = false;
            GridView1.DataSource = list;
            GridView1.DataBind();
            }
            else
            {
                GridView1.Visible = false;
                LabelMessage.Visible = true;
                LabelMessage.Text = "No Requisitions Found!!!!";
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            detailsView.Visible = true;
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;

            Label rid = (Label)row.FindControl("Label1");
            int reqid = Convert.ToInt32(rid.Text);
            Session["ApproveID"] = reqid.ToString();



            GridView2.DataSource = R.bindRequisitionDetails(reqid);
            GridView2.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32( Session["ApproveID"]);
            R.changeStatus(id, 2001);

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Success", "alert('Approved!!!')", true);
            detailsView.Visible = false;
            bindRequisition();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Session["ApproveID"]);
            R.changeStatus(id, 2002);

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "UnSuccess", "alert('Rejected!!!')", true);
            detailsView.Visible = false;
            bindRequisition();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            detailsView.Visible = false;
        }
    }
}