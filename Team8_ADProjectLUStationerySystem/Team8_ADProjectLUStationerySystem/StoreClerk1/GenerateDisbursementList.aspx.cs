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
    public partial class GenerateDisbursementList : System.Web.UI.Page
    {
        Disbursement db = new Disbursement();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            { LoadList(); }

        }
        protected void LoadList()
        {
            List<department> retrievalList = new List<department>();
            DropDownList1.DataSource = db.getList();
            DropDownList1.DataTextField = "retrievalId";
            DropDownList1.DataValueField = "retrievalId";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select retrieval--", "0"));
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void LoadGridView(int rid)
        {
            GenrateDisbursementGridView.Visible = true;
            List<department> dp = db.getDepartment(rid);
            GenrateDisbursementGridView.DataSource = dp;
            GenrateDisbursementGridView.DataBind();
        }

        protected void lbNew_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            TextBox tb = (TextBox)lb.FindControl("tbDate");
            DateTime choose = Convert.ToDateTime(tb.Text);
            if (choose < DateTime.Now)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Can not choose the Date Before!');</script>");
                int rid = (int)Session["rid"];
                LoadGridView(rid);

            }
            else
            {
                HiddenField hd = (HiddenField)lb.FindControl("HiddenField1");
                string did = hd.Value;
                int rid = Convert.ToInt32(DropDownList1.SelectedValue);
                DateTime date = Convert.ToDateTime(tb.Text);

                int i = db.generateNewDisbursement(did, rid, date);
                Session["disid"] = i;

                Response.Redirect("DisbursementForm.aspx");


            }

            


        }

        protected void tbDate_TextChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rid = Convert.ToInt32(DropDownList1.SelectedValue);
            if (rid != 0)
            {
                Session["rid"] = rid;
                LoadGridView(rid);
            }
            else
            {
                GenrateDisbursementGridView.Visible = false;
            }
            
        }







    }
}