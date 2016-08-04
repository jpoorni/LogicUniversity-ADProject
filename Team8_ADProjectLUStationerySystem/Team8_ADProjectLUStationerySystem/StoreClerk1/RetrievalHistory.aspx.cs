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
    public partial class RetrievalHistory : System.Web.UI.Page
    {
        ItemBLL itb = new ItemBLL();
        EmployeeBLL eb = new EmployeeBLL();
        Retrieval r = new Retrieval();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                LoadItemList();
                LoadDepartmentList();


            }

        }

        protected void LoadItemList()
        {
            List<catelogueItem> ct = itb.getAllItem();
            ddlItem.DataSource = ct;
            ddlItem.DataTextField = "itemDescription";
            ddlItem.DataValueField = "itemCode";
            ddlItem.DataBind();
            ddlItem.Items.Insert(0, new ListItem("Any", "0"));

        }

        protected void LoadDepartmentList()
        {
            List<department> dp = eb.getAlldepartment();
            ddlDep.DataSource = dp;
            ddlDep.DataTextField = "departmentName";
            ddlDep.DataValueField = "departmentCode";
            ddlDep.DataBind();
            ddlDep.Items.Insert(0,new ListItem("Any","0"));
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<retrievalDetail> rd = r.getHistory(ddlItem.SelectedValue, ddlDep.SelectedValue);
            if (rd.Count == 0)
            {
                Label1.Visible = true;
                GridView1.Visible = false;
            }
            else
            {
                Label1.Visible = false;
                GridView1.Visible = true;
                GridView1.DataSource = rd;
                GridView1.DataBind();
            }
            
        }
        protected void lbView_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd = (HiddenField)lb.FindControl("HiddenField1");
            int rid = Convert.ToInt32(hd.Value);
            Session["retrievalId"] = rid;
            Response.Redirect("RetrievalForm.aspx");

        }
}
}