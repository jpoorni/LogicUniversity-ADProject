using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.DepartmentHead
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        EmployeeBLL employee = new EmployeeBLL();
        DelegateEmployeeBLL demp = new DelegateEmployeeBLL();
        delegateEmployee de;
        Requisitioin req = new Requisitioin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            //Session["departCode"] = "COMM";
            int userid = (int)Session["UserID"];
            string departCode = req.findDeptCode(userid);
            Session["departCode"] = departCode;
            //string departCode = (string)Session["departCode"];

            if (demp.checkDelegatedEmployee(departCode) == true)
            {
                GridView1.DataSource = employee.getNormalEmployeeByDepartmentCode(departCode);
                GridView1.DataBind();
            }
            else
            {
                de = demp.getDelegatedEmployee(departCode);
                Session["deperson"] = de;
                Response.Redirect("DelegateAuthorisedPerson.aspx");
            }
        }

        protected void delegate_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hf = (HiddenField)lb.FindControl("HiddenField1");
            int eid = Convert.ToInt32(hf.Value);
            Session["eid"] = eid;
            Response.Redirect("DelegateAuthorisedPerson.aspx");
        }

    
    }
}