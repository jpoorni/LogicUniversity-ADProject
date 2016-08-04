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
    public partial class OutstandingRequisitionDetails : System.Web.UI.Page
    {
        Retrieval retrieval = new Retrieval();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            List<int> requisitionId = (List<int>)Session["thisQuisition"];
            List<requisitionDetail> rd = retrieval.getOutstanding(requisitionId);
            
            if (rd.Count != 0)
            {
                LoadGridView(rd);
            }
            else
            {
                Label1.Visible = true;
            }
            

        }

        protected void LoadGridView(List<requisitionDetail> rd)
        {
            OutstandingRequisitionDetailsGridView.DataSource = rd;
            OutstandingRequisitionDetailsGridView.DataBind();


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            retrieval.generateSC();
            int id = retrieval.generateNormal(1);
            Session["thisQuisition"] = null;
            Session["retrievalId"] = id;

            Response.Redirect("RetrievalForm.aspx");

        }
}
}