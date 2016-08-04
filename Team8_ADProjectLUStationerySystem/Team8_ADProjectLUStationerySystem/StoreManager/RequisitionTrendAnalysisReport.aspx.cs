using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
using System.Web.UI.DataVisualization.Charting;
using Team8_ADProjectLUStationerySystem.BusinessLogic; 

namespace Team8_ADProjectLUStationerySystem.StoreManager
{
    public partial class RequisitionTrendAnalysisReport : System.Web.UI.Page
    {
        ItemBLL itemlogic = new ItemBLL();
        ReportBLL reportlogic = new ReportBLL();

        static int year = DateTime.Now.Year + 1;
        DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
        DataTable dt;

        int mth1, mth2, mth3, year1, year2, year3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadYear();
                LoadMonth();
                LoadDepartment();
                LoadItem();
                Button2.Visible = false;

                PanelQuantity.Visible = false;
                PanelPrice.Visible = false;

            }
            lblStatus.Text = "";
        }
        private void LoadYear()
        {
            for (int i = 1; i <= 3; i++)
            {
                rdoyear1.Items.Add(new ListItem((year - i).ToString(), (year - i).ToString()));
                rdoyear1.Items.FindByValue((year - 1).ToString()).Selected = true;
                rdoyear2.Items.Add(new ListItem((year - i).ToString(), (year - i).ToString()));
                rdoyear2.Items.FindByValue((year - 1).ToString()).Selected = true;
                rdoyear3.Items.Add(new ListItem((year - i).ToString(), (year - i).ToString()));
                rdoyear3.Items.FindByValue((year - 1).ToString()).Selected = true;
            }
        }
        private void LoadMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                ddlmth1.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
                ddlmth2.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
                ddlmth3.Items.Add(new ListItem(info.GetMonthName(i), i.ToString()));
            }

            //make previous two months and current month as default
            int currentMonth = DateTime.Now.Month;
            ddlmth1.Items.Insert(0, new ListItem("-- Choose Month --", (currentMonth - 1).ToString()));
            ddlmth2.Items.Insert(0, new ListItem("-- Choose Month --", (currentMonth - 2).ToString()));
            ddlmth3.Items.Insert(0, new ListItem("-- Choose Month --", (currentMonth - 0).ToString()));
        }
        private void LoadDepartment()
        {
            ddlDepartment.DataSource = reportlogic.getAllDepartment();
            ddlDepartment.DataValueField = "departmentCode";
            ddlDepartment.DataTextField = "departmentName";
            ddlDepartment.DataBind();
        }
        private void LoadItem()
        {
            ddlItem.DataSource = itemlogic.getAllItem();
            ddlItem.DataValueField = "itemCode";
            ddlItem.DataTextField = "itemDescription";
            ddlItem.DataBind();

            ddlItem.Items.Insert(0, new ListItem("-- Select Item --", "0"));
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            year1 = Convert.ToInt32(rdoyear1.SelectedValue);
            year2 = Convert.ToInt32(rdoyear2.SelectedValue);
            year3 = Convert.ToInt32(rdoyear3.SelectedValue);

            mth1 = Convert.ToInt32(ddlmth1.SelectedValue);
            mth2 = Convert.ToInt32(ddlmth2.SelectedValue);
            mth3 = Convert.ToInt32(ddlmth3.SelectedValue);


            string deptCode = ddlDepartment.SelectedValue;
            string itemCode = ddlItem.SelectedValue;
            int type = shownby.SelectedIndex;
            DataTable RequisitionTable1, RequisitionTable2, RequisitionTable3;


            if (itemCode == "0")
            {
                lblStatus.Text = "Please Select Item";
            }
            else
            {
                RequisitionTable1 = GetRequisitionData(itemCode, deptCode, year1, mth1);
                RequisitionTable2 = GetRequisitionData(itemCode, deptCode, year2, mth2);
                RequisitionTable3 = GetRequisitionData(itemCode, deptCode, year3, mth3);

                SetUp(RequisitionTable1, RequisitionTable2, RequisitionTable3, itemCode, deptCode, type);
            }
        }
        protected DataTable GetRequisitionData(string itemcode, string deptcode, int year, int month)
        {
            string query = string.Format("select sum(rd.qtyActual)as totalQuantity, sum(rd.qtyActual * c.tenderPrice)as totalAmount from requisition r, requisitionDetails rd, catelogueItem c where r.requisitionId = rd.requisitionId and rd.itemCode = c.itemCode and rd.itemCode='{0}' and r.departmentCode = '{1}' and year(r.requisitionDate) = {2} and month(r.requisitionDate) = {3} group by r.departmentCode, rd.itemCode, year(r.requisitionDate), month(r.requisitionDate)", itemcode, deptcode, year, month);
            DataTable dt = GetData(query);
            if (dt.Rows.Count != 0)
                return dt;
            else
                return null;
        }
        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            //orderTable dt = new orderTable();
            string constr = ConfigurationManager.ConnectionStrings["constringReport"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                    }
                }
                return dt;
            }
        }
        private void LoadChart_RequisitionQuantity(DataTable initialOrderDataSource)
        {
            for (int i = 1; i < initialOrderDataSource.Columns.Count; i++)
            {
                Series series = new Series();
                foreach (DataRow dr in initialOrderDataSource.Rows)
                {
                    int y = (int)dr[i];
                    series.Points.AddXY(dr["QData"].ToString(), y);
                }
                ChartQuantity.Series.Add(series);
            }
        }
        private void LoadChart_RequisitionPrice(DataTable initialOrderDataSource)
        {
            for (int i = 1; i < initialOrderDataSource.Columns.Count; i++)
            {
                Series series = new Series();
                foreach (DataRow dr in initialOrderDataSource.Rows)
                {
                    double y = (double)dr[i];
                    series.Points.AddXY(dr["PData"].ToString(), y);
                }
                ChartPrice.Series.Add(series);
            }
        }
        private void SetUp(DataTable RequisitionTable1, DataTable RequisitionTable2, DataTable RequisitionTable3, string itemCode, string deptCode, int type)
        {
            DataTable QtyTable, PriceTable;

            if (type == 0) //quantity
            {
                lblMessage.Text = "Quantity Comparison for " + " [ " + itemCode + " : " + itemlogic.getItem(itemCode).itemDescription.ToString() + " ] ";

                QtyTable = new DataTable();
                QtyTable.Columns.Add("QData", Type.GetType("System.String"));
                QtyTable.Columns.Add("Quantity", Type.GetType("System.Int32"));

                //add first row
                DataRow qrow1 = QtyTable.NewRow();
                qrow1["QData"] = itemCode + " : " + year1.ToString() + "-" + info.GetMonthName(mth1);
                if (RequisitionTable1 != null)
                {
                    qrow1["Quantity"] = RequisitionTable1.Rows[0][0];
                }
                else
                {
                    qrow1["Quantity"] = 0;
                }
                QtyTable.Rows.Add(qrow1);


                //add second row
                DataRow qrow2 = QtyTable.NewRow();
                qrow2["QData"] = itemCode + " : " + year2.ToString() + "-" + info.GetMonthName(mth2);

                if (RequisitionTable2 != null)
                {
                    qrow2["Quantity"] = RequisitionTable2.Rows[0][0];
                }
                else
                {
                    qrow2["Quantity"] = 0;
                }
                QtyTable.Rows.Add(qrow2);


                //add third row
                DataRow qrow3 = QtyTable.NewRow();
                qrow3["QData"] = itemCode + " : " + year3.ToString() + "-" + info.GetMonthName(mth3);
                if (RequisitionTable3 != null)
                {
                    qrow3["Quantity"] = RequisitionTable3.Rows[0][0];
                }
                else
                {
                    qrow3["Quantity"] = 0;
                }
                QtyTable.Rows.Add(qrow3);

                GridViewQuantity.DataSource = QtyTable;
                GridViewQuantity.DataBind();
                LoadChart_RequisitionQuantity(QtyTable);

                GridViewPrice.DataSource = "";
                GridViewPrice.DataBind();

                Button2.Visible = true;
                PanelQuantity.Visible = true;
                PanelPrice.Visible = false;

            }
            else //price
            {
                lblMessage.Text = "Price Comparison for " + " [ " + itemCode + " : " + itemlogic.getItem(itemCode).itemDescription.ToString() + " ] ";

                PriceTable = new DataTable();
                PriceTable.Columns.Add("PData", Type.GetType("System.String"));
                PriceTable.Columns.Add("Price", Type.GetType("System.Double"));

                //add first row
                DataRow prow1 = PriceTable.NewRow();
                prow1["PData"] = itemCode + " : " + year1.ToString() + "-" + info.GetMonthName(mth1);

                if (RequisitionTable1 != null)
                {
                    prow1["Price"] = RequisitionTable1.Rows[0][1];
                }
                else
                {
                    prow1["Price"] = 0.0;
                }
                PriceTable.Rows.Add(prow1);


                //add second row
                DataRow prow2 = PriceTable.NewRow();
                prow2["PData"] = itemCode + " : " + year2.ToString() + "-" + info.GetMonthName(mth2);
                if (RequisitionTable2 != null)
                {
                    prow2["Price"] = RequisitionTable2.Rows[0][1];
                }
                else
                {
                    prow2["Price"] = 0.0;
                }
                PriceTable.Rows.Add(prow2);


                //add third row
                DataRow prow3 = PriceTable.NewRow();
                prow3["PData"] = itemCode + " : " + year3.ToString() + "-" + info.GetMonthName(mth3);
                if (RequisitionTable3 != null)
                {
                    prow3["Price"] = RequisitionTable3.Rows[0][1];
                }
                else
                {
                    prow3["Price"] = 0.0;
                }
                PriceTable.Rows.Add(prow3);

                GridViewPrice.DataSource = PriceTable;
                GridViewPrice.DataBind();
                LoadChart_RequisitionPrice(PriceTable);

                GridViewQuantity.DataSource = "";
                GridViewQuantity.DataBind();

                Button2.Visible = true;
                PanelPrice.Visible = true;
                PanelQuantity.Visible = false;

            }
        }
    }
}