using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;
using Team8_ADProjectLUStationerySystem.Report;

namespace Team8_ADProjectLUStationerySystem.Employee
{
    public partial class DisbursementForm : System.Web.UI.Page
    {
        Disbursement db = new Disbursement();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            int disid = (int)Session["disid"];
            //int disid = 13060;
            LoadGridView(disid);
        }
        protected void LoadGridView(int disid)
        {
            List<disbursementDetail> dbd = db.getDisbursementDetail(disid);
            DisbursementGridView.DataSource = dbd;
            DisbursementGridView.DataBind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            DisbursementGridView.Visible = false;
            DisbursementReport.Visible = true;
            int id = (int)Session["disid"];
            //int id = 13060;
            DisbursementListReport rpt = new DisbursementListReport();
            DataSet.DisbursementListDS ds = new DataSet.DisbursementListDS();
            DataSet.DisbursementListDSTableAdapters.DisbursementListSPTableAdapter rd = new DataSet.DisbursementListDSTableAdapters.DisbursementListSPTableAdapter();
            rd.Fill(ds.DisbursementListSP, id);
            rpt.SetDataSource(ds);
            this.DisbursementReport.ReportSource = rpt;
            this.DisbursementReport.DataBind();
        }
    }
}