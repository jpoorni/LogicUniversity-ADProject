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
    public partial class NewRequisitionList : System.Web.UI.Page
    {
        Retrieval retrieval = new Retrieval();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                if (retrieval.getForPorcess().Count != 0)
                {
                    LoadGridView();
                }
                else
                {
                    LoadLable();


                }
                
            }
            
        }

        protected void LoadLable()
        {
            Label1.Visible = true;
            NewRequisitionGridView.Visible = false;
            CheckBox1.Visible = false;
            Process.Visible = false;
        }

        protected void LoadGridView()
        {
            Label1.Visible = false;
            NewRequisitionGridView.Visible = true;
            CheckBox1.Visible = true;
            Process.Visible = true;
            NewRequisitionGridView.DataSource = retrieval.getForPorcess();
            NewRequisitionGridView.DataBind();


        }

        protected void NewRequisitionGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("DetailsGridView");
                HiddenField hd = (HiddenField)e.Row.FindControl("HiddenField1");
                int id = Convert.ToInt32(hd.Value);
                gv.DataSource = retrieval.getDetails(id);
                gv.DataBind();

            }

        }


        protected void CheckBox1_CheckedChanged1(object sender, EventArgs e)
        {
            for(int i =0;i<=NewRequisitionGridView.Rows.Count-1;i++){
                CheckBox cb = (CheckBox)NewRequisitionGridView.Rows[i].FindControl("CheckBox2");
                if(CheckBox1.Checked==true){
                    cb.Checked=true;
                }else
                {
                    cb.Checked=false;
                }
            } 

        }

        protected void Process_Click(object sender, EventArgs e)
        {
            List<int> requisitionId = new List<int>();
            for (int i = 0; i < NewRequisitionGridView.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)NewRequisitionGridView.Rows[i].FindControl("CheckBox2");
                HiddenField hd = (HiddenField)NewRequisitionGridView.Rows[i].FindControl("HiddenField2");
                if (cb.Checked == true)
                {
                    requisitionId.Add(Convert.ToInt32(hd.Value));
                }
            }
            if (requisitionId.Count != 0)
            {
                retrieval.process(requisitionId, 0);
                Session["thisQuisition"] = requisitionId;
                Response.Redirect("OutstandingRequisitionDetails.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Please Choose at least one!');</script>");
            }
            

        }

        

        
    }
}