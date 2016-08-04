
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;
using Team8_ADProjectLUStationerySystem.Report;

namespace Team8_ADProjectLUStationerySystem.StoreSupervisor
{
    public partial class AdjustmentForm : System.Web.UI.Page
    {
        AdjustInventoryBLL a = new AdjustInventoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            string adjid = (string)Session["adjid"];
            LoadGridView(adjid);
        }
        protected void LoadGridView(string adjid)
        {
            List<adjustmentDetail> adjd = a.getAdjustmentDetailsbyID(adjid);
            AdjustmentGridView.DataSource = adjd;
            AdjustmentGridView.DataBind();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {

            AdjustmentGridView.Visible = false;
            AdjustmentReport.Visible = true;
            string adjid = (string)Session["adjid"];
            int id = Convert.ToInt32(adjid);
            AdjustmentListReport rpt = new AdjustmentListReport();
            DataSet.AdjustmentListDS ds = new DataSet.AdjustmentListDS();
            DataSet.AdjustmentListDSTableAdapters.AdjustmentListSPTableAdapter rd = new DataSet.AdjustmentListDSTableAdapters.AdjustmentListSPTableAdapter();
            rd.Fill(ds.AdjustmentListSP, id);
            rpt.SetDataSource(ds);
            this.AdjustmentReport.ReportSource = rpt;
            this.AdjustmentReport.DataBind();


        }
    }
}