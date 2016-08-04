using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;



namespace Team8_ADProjectLUStationerySystem.DepartmentHead
{
    public partial class DelegateAuthorisedPerson : System.Web.UI.Page
    {
       
        EmployeeBLL employee = new EmployeeBLL();
        UserBLL user = new UserBLL();
        DelegateEmployeeBLL delegateEmployees = new DelegateEmployeeBLL();
        delegateEmployee de = new delegateEmployee();
     

        int eid;
        //int delempid; //delegate emp id
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (Session["deperson"] != null)
            {
                de = (delegateEmployee)Session["deperson"];

                if(Convert.ToInt32(Session["UserID"]) == de.employeeId){
                    EndDelegationBtn.Visible = false;
                }else{
                    EndDelegationBtn.Visible = true;
                }                
                employee emp = employee.getEmployeeByEmpId((int)de.employeeId);
                EmployeeNameLb.Text = emp.employeeName;
                StartDateTb.Visible = false;
                EndDateTb.Visible = false;
                StartDateTb2.Visible = true;
                EndDateTb2.Visible = true;
                DateTime from = (DateTime)de.fromDate;
                DateTime to = (DateTime)de.toDate;
                StartDateTb2.Text = from.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                EndDateTb2.Text = to.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                ReasonDropDown.SelectedItem.Text = de.reason.ToString();
                ReasonDropDown.Enabled = false;
                AssignBtn.Visible = false;
                CancelBtn.Visible = false;

            }
            else
            {
                eid = (int)Session["eid"];
                employee emp = employee.getEmployeeByEmpId(eid);
                EmployeeNameLb.Text = emp.employeeName;
                StartDateTb.Visible = true;
                EndDateTb.Visible = true;
                StartDateTb2.Visible = false;
                EndDateTb2.Visible = false;
                ReasonDropDown.Enabled = true;
                EndDelegationBtn.Visible = false;
                AssignBtn.Visible = true;
                CancelBtn.Visible = true;
            }
        }
        protected void AssignBtn_Click(object sender, EventArgs e)
        {
            if (StartDateTb.Text == "" || EndDateTb.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorAlert", "alert('Please choose Start Date and End Date')", true);
            }
            else
            {
                DateTime start = Convert.ToDateTime(StartDateTb.Text);
                DateTime end = Convert.ToDateTime(EndDateTb.Text);
                if (start < end)
                {
                    delegateEmployee demp = new delegateEmployee();
                    demp.employeeId = eid;
                    demp.fromDate = Convert.ToDateTime(StartDateTb.Text);
                    demp.toDate = Convert.ToDateTime(EndDateTb.Text);
                    demp.reason = ReasonDropDown.SelectedValue;
                    demp.status = "Open";
                    user.changeDelegateEmployeeUserRoleId(eid, 11006);
                    delegateEmployees.startDelegatation(demp);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "dele();", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Wrong Date!');</script>");
                }
            }
            
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Delegatation successfully');</script>");
            //Response.Redirect("ApproveRequisitions.aspx");
        }

        protected void EndDelegationBtn_Click(object sender, EventArgs e)
        {

            user.changeDelegateEmployeeUserRoleId((int)de.employeeId, 11004);
            delegateEmployees.EndDelegation(de, de.delegationId);
            Session["deperson"] = null;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "undele();", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('End Delegatation successfully');</script>");
            //Response.Redirect("ApproveRequisitions.aspx");
        }
        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            if (Session["deperson"] != null)
            {
                Response.Redirect("ApproveRequisitions.aspx");
            }
            else
            {
                Response.Redirect("EmployeeList.aspx");
            }
        }
    }
}