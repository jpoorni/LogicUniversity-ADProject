using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;
using Team8_ADProjectLUStationerySystem.DataSet;
using CrystalDecisions.CrystalReports;
using Team8_ADProjectLUStationerySystem.Report;

namespace Team8_ADProjectLUStationerySystem.StoreManager
{
    public partial class RetrievalForm : System.Web.UI.Page
    {
        Retrieval r = new Retrieval();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            RetrievalGridView.Visible = true;
            RetrievalListReport.Visible = false;
            int id = (int)Session["retrievalId"];
            //int id = 10005;
            List<retrievalDetail> rdr = r.getOneRetrieval(id);
            List<retrievalDetail> rd = r.getId(rdr);
            this.RetrievalGridView.DataSource = rd;
            this.RetrievalGridView.DataBind();
        }
        protected void RetrievalGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rid = 10005;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hd = (HiddenField)e.Row.FindControl("HiddenField1");
                string id = hd.Value;
                List<retrievalDetail> rdr = r.getOneRetrieval(rid);
                List<retrievalDetail> rd = r.getId(rdr);
                List<retrievalDetail> rdetail = rdr.Where(x =>
                    x.itemCode == id).ToList();


                GridView gv = (GridView)e.Row.FindControl("DepartmentGridView");
                gv.DataSource = rdetail;
                gv.DataBind();

            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            RetrievalGridView.Visible = false;
            RetrievalListReport.Visible = true;
            int id = (int)Session["retrievalId"];
            //int id = 10005;
            RetrievalListRep rpt = new RetrievalListRep();
            DataSet.RetrievalListDS ds = new RetrievalListDS();
            DataSet.RetrievalListDSTableAdapters.RetrievalListSPTableAdapter rd = new DataSet.RetrievalListDSTableAdapters.RetrievalListSPTableAdapter();
            rd.Fill(ds.RetrievalListSP, id);
            rpt.SetDataSource(ds);
            this.RetrievalListReport.ReportSource = rpt;
            this.RetrievalListReport.DataBind();

        }

    }
}