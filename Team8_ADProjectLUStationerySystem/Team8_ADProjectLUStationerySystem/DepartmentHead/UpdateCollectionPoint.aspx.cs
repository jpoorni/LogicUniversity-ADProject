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
    public partial class UpdateCollectionPoint : System.Web.UI.Page
    {
        CollectionPointBLL collectionPointBLL = new CollectionPointBLL();
        EmployeeBLL employeeBll = new EmployeeBLL();
        Requisitioin req = new Requisitioin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            
            //Session["departCode"]="COMM"; //Assume get from DepHead Login
            int userid = (int)Session["UserID"];
            string dCode = employeeBll.getDepartmentCode(userid);
            
            string collectionPointName=collectionPointBLL.getCurrentPointName(dCode);
            string repName = collectionPointBLL.getCurrentRepName(dCode);

            CollectionPointTb.Text = collectionPointName;
            RepTb.Text=repName;
            
            if (!IsPostBack)
            {
                //RadioButtonList1.Items.Insert
                loadCPLit();
                RepresentativeNameDropDown.DataSource = collectionPointBLL.getAllEmployeesByDepartmentCode(dCode);
                RepresentativeNameDropDown.DataTextField = "employeeName";
                RepresentativeNameDropDown.DataValueField = "employeeId";
                RepresentativeNameDropDown.DataBind();
                RepresentativeNameDropDown.Items.Insert(0, new ListItem("--Select One Person--", "0"));
            }
          

        }

        protected void loadCPLit()
        {
            ddlCP.Items.Insert(0, new ListItem("--Select aCollection Point--", "0"));
            List<collectionPoint> cp = collectionPointBLL.getAllCollectionPoints();
            for (int i = 0; i < cp.Count-1; i++)
            {
                collectionPoint cpp = cp[i];
                ddlCP.Items.Insert(i + 1, new ListItem(cpp.collectionPointName + "/" + cpp.collectionTime, cpp.collectionPointId.ToString()));
            }
        }


        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            //Session["departCode"] = "COMM"; //Assume get from DepHead Login
            //string dCode = (string)Session["departCode"];
            int userid = (int)Session["UserID"];
            string departCode = req.findDeptCode(userid);
            Session["departCode"] = departCode;
            int newCollectionPointId=Convert.ToInt32(ddlCP.SelectedValue);
            //foreach (GridViewRow r in collectionPointGridView.Rows)
            //{
            //    RadioButton  rb = (RadioButton)r.FindControl("rdBtn");
            //    if (rb.Checked)
            //    {
            //        string newCollectionPointName = r.Cells[1].Text;
            //        newCollectionPointId = collectionPointBLL.getCollectionPointIdbyCollectionPointName(newCollectionPointName);
                    
            //    }
            //}
            if (newCollectionPointId != 0)
            {
                collectionPointBLL.changeCollectionPoint(departCode, newCollectionPointId);
                if (RepresentativeNameDropDown.SelectedItem.Value != "0")
                {
                    string newRepName = RepresentativeNameDropDown.SelectedItem.Text;
                    employee emp = collectionPointBLL.getEmployeeByName(newRepName);
                    int eid = emp.employeeId;

                    collectionPointBLL.assignRepresentative(departCode, eid);
                    collectionPointBLL.changeRepUserRoleId(eid, 11005);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "cp();", true);
                    
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Please select a Person!');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Please select a Collection Point!');</script>");
            }
            
            
            
            //Response.Redirect("UpdateCollectionPoint.aspx");
          
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApproveRequisitions.aspx");
        }

     
    }
}