using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.Employee
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

            if(!IsPostBack)
            {
                AllRequisition();
            }
        }



        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            loadalldata();
        }

        private void loadalldata()
        {
            int userid = (int)Session["UserID"];
            //int userid = 1004;
            if (DropDownList2.SelectedIndex == 0)
            {
                AllRequisition();

            }
            else
            {
                List<Models.RequisitionModel> list = R.employeeRequisitionByStatus(userid, Convert.ToInt32(DropDownList2.SelectedValue));
                if (list.Count > 0)
                {
                    DisbursementListGridView.Visible = true;
                    LabelMessage.Visible = false;
                    DisbursementListGridView.DataSource = list;
                    DisbursementListGridView.DataBind();
                }
                else
                {
                    DisbursementListGridView.Visible = false;
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "No Values Found!!!!";
                }

            }

            //2nd GView

            // int userid = (int)Session["UserID"];
            //int userid = 1004;
            if (DropDownList3.SelectedIndex == 0)
            {
                if (DropDownList2.SelectedIndex == 0)
                {
                    AllRequisition();
                }
                else
                {
                    List<Models.RequisitionModel> list = R.employeeRequisitionByStatus(userid, Convert.ToInt32(DropDownList2.SelectedValue));
                    if (list.Count > 0)
                    {
                        DisbursementListGridView.Visible = true;
                        LabelMessage.Visible = false;
                        DisbursementListGridView.DataSource = list;
                        DisbursementListGridView.DataBind();
                    }
                    else
                    {
                        DisbursementListGridView.Visible = false;
                        LabelMessage.Visible = true;
                        LabelMessage.Text = "No Values Found!!!!";
                    }
                //DisbursementListGridView.DataSource = R.employeeRequisitionByStatus(userid, Convert.ToInt32(DropDownList2.SelectedValue));
                //DisbursementListGridView.DataBind();
                }

            }
            else
            {
                if (DropDownList2.SelectedIndex == 0)
                {
                     List<Models.RequisitionModel> list = R.employeeRequisitionByMonth(userid, Convert.ToInt32(DropDownList3.SelectedValue));
                     if (list.Count > 0)
                     {
                         DisbursementListGridView.Visible = true;
                         LabelMessage.Visible = false;
                         DisbursementListGridView.DataSource = list;
                         DisbursementListGridView.DataBind();
                     }
                     else
                     {
                         DisbursementListGridView.Visible = false;
                         LabelMessage.Visible = true;
                         LabelMessage.Text = "No Values Found!!!!";
                     }
                }
                else
                {
                     List<Models.RequisitionModel> list = R.employeeRequisitionByAll(userid, Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(DropDownList3.SelectedValue));
                     if (list.Count > 0)
                     {
                         DisbursementListGridView.Visible = true;
                         LabelMessage.Visible = false;
                         DisbursementListGridView.DataSource = list;
                         DisbursementListGridView.DataBind();
                     }
                     else
                     {
                         DisbursementListGridView.Visible = false;
                         LabelMessage.Visible = true;
                         LabelMessage.Text = "No Values Found!!!!";
                     }
                }
            }
           
        }

        private void AllRequisition()
        {
            int userid = (int)Session["UserID"];
           // int userid = 1004;
            List<Models.RequisitionModel> list = R.employeeAllRequisition(userid);
            if(list.Count>0)
            {
            DisbursementListGridView.Visible = true;
            LabelMessage.Visible = false;
            DisbursementListGridView.DataSource = list;
            DisbursementListGridView.DataBind();
            }
            else
            {
                DisbursementListGridView.Visible = false;
                LabelMessage.Visible = true;
                LabelMessage.Text = "No Values Found!!!!";
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadalldata();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;

            //  LinkButton lk = (LinkButton)item.FindControl("LinkButton2");
            Label rid = (Label)row.FindControl("Label1");

            List<requisitionDetail> list = R.getDetails(Convert.ToInt32(rid.Text));

            // int userid = (int)Session["UserID"];
            int userid = 1004;
            string deptcode = R.findDeptCode(userid);

            R.addrequisition(deptcode, userid, 2000, DateTime.Now, false, list);


            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Success", "alert('Re-Order Successfull!!!')", true);

        }

        protected void DisbursementListGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadalldata();
            DisbursementListGridView.PageIndex = e.NewPageIndex;
            DisbursementListGridView.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Label l = (Label)lb.FindControl("Label1");
            int reqid = Convert.ToInt32(l.Text);
            Session["reqid"] = reqid;
            Response.Redirect("RequisitionForm.aspx");
        }
    

        
    }
}