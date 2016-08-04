using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.Report;
using Team8_ADProjectLUStationerySystem.BusinessLogic;
using System.Web.Security;

namespace Team8_ADProjectLUStationerySystem.DepartmentHead
{
    public partial class RequisitionForm : System.Web.UI.Page
    {
        Requisitioin req = new Requisitioin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            int reqid = (int)Session["reqid"];
            GridView1.Visible = true;
            btnPrint.Visible = true;
            RequisitionReport.Visible = false;
            GridView1.DataSource = req.getDetails(reqid);
            GridView1.DataBind();

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            btnPrint.Visible = false;
            RequisitionReport.Visible = true;
            int reqid = (int)Session["reqid"];
            RequisitionListRep rpt = new RequisitionListRep();
            DataSet.RequisitionListDS ds = new DataSet.RequisitionListDS();
            DataSet.RequisitionListDSTableAdapters.RequisitionListSPTableAdapter rd = new DataSet.RequisitionListDSTableAdapters.RequisitionListSPTableAdapter();
            rd.Fill(ds.RequisitionListSP, reqid);
            rpt.SetDataSource(ds);
            this.RequisitionReport.ReportSource = rpt;
            this.RequisitionReport.DataBind();
        }
    }
}