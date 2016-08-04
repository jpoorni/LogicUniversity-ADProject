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
    public partial class OrderTrendAnalysisReport : System.Web.UI.Page
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
                LoadItem();
                Button1.Visible = false;

                //ChartQuantity.Visible = false;
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


            string itemCode = ddlItem.SelectedValue;
            int type = shownby.SelectedIndex;
            //int totalQuantity1, totalQuantity2, totalQuantity3;
            DataTable OrderTable1, OrderTable2, OrderTable3;


            if (itemCode == "0")
            {
                lblStatus.Text = "Please Select Item";
            }
            else
            {
                OrderTable1 = GetOrderData(itemCode, year1, mth1);
                OrderTable2 = GetOrderData(itemCode, year2, mth2);
                OrderTable3 = GetOrderData(itemCode, year3, mth3);

                SetUp(OrderTable1, OrderTable2, OrderTable3, itemCode, type);
            }
        }
        protected DataTable GetOrderData(string itemcode, int year, int month)
        {
            string query = string.Format("select sum(pd.receivedQuantity)as totalQuantity, sum(pd.receivedQuantity * pd.price)as totalAmount from purchaseDetail pd, purchaseOrder po where pd.purchaseOrderno = po.purchaseorderno and itemCode = '{0}' and year(po.purchaseDate) = {1} and month(po.purchaseDate) = {2} group by pd.itemCode, month(po.purchaseDate), year(po.purchaseDate)", itemcode, year, month);
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
        private void LoadChart_OrderQuantity(DataTable initialOrderDataSource)
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
        private void LoadChart_OrderPrice(DataTable initialOrderDataSource)
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
        private void SetUp(DataTable OrderTable1, DataTable OrderTable2, DataTable OrderTable3, string itemCode, int type)
        {

            DataTable QtyTable, PriceTable;

            if (type == 0) //quantity
            {
                label1.Text = "Quantity Comparison for " + " [ " + itemCode + " : " + itemlogic.getItem(itemCode).itemDescription.ToString() + " ] ";

                QtyTable = new DataTable();
                QtyTable.Columns.Add("QData", Type.GetType("System.String"));
                QtyTable.Columns.Add("Quantity", Type.GetType("System.Int32"));

                //add first row
                DataRow qrow1 = QtyTable.NewRow();
                qrow1["QData"] = itemCode + " : " + year1.ToString() + "-" + info.GetMonthName(mth1);
                if (OrderTable1 != null)
                {
                    qrow1["Quantity"] = OrderTable1.Rows[0][0];
                }
                else
                {
                    qrow1["Quantity"] = 0;
                }
                QtyTable.Rows.Add(qrow1);


                //add second row
                DataRow qrow2 = QtyTable.NewRow();
                qrow2["QData"] = itemCode + " : " + year2.ToString() + "-" + info.GetMonthName(mth2);

                if (OrderTable2 != null)
                {
                    qrow2["Quantity"] = OrderTable2.Rows[0][0];
                }
                else
                {
                    qrow2["Quantity"] = 0;
                }
                QtyTable.Rows.Add(qrow2);


                //add third row
                DataRow qrow3 = QtyTable.NewRow();
                qrow3["QData"] = itemCode + " : " + year3.ToString() + "-" + info.GetMonthName(mth3);
                if (OrderTable3 != null)
                {
                    qrow3["Quantity"] = OrderTable3.Rows[0][0];
                }
                else
                {
                    qrow3["Quantity"] = 0;
                }
                QtyTable.Rows.Add(qrow3);

                GridViewQuantity.DataSource = QtyTable;
                GridViewQuantity.DataBind();
                LoadChart_OrderQuantity(QtyTable);

                GridViewPrice.DataSource = "";
                GridViewPrice.DataBind();

                Button1.Visible = true;
                PanelQuantity.Visible = true;
                PanelPrice.Visible = false;
            }
            else //price
            {
                label1.Text = "Price Comparison for " + " [ " + itemCode + " : " + itemlogic.getItem(itemCode).itemDescription.ToString() + " ] ";

                PriceTable = new DataTable();
                PriceTable.Columns.Add("PData", Type.GetType("System.String"));
                PriceTable.Columns.Add("Price", Type.GetType("System.Double"));

                //add first row
                DataRow prow1 = PriceTable.NewRow();
                prow1["PData"] = itemCode + " : " + year1.ToString() + "-" + info.GetMonthName(mth1);

                if (OrderTable1 != null)
                {
                    prow1["Price"] = OrderTable1.Rows[0][1];
                }
                else
                {
                    prow1["Price"] = 0.0;
                }
                PriceTable.Rows.Add(prow1);


                //add second row
                DataRow prow2 = PriceTable.NewRow();
                prow2["PData"] = itemCode + " : " + year2.ToString() + "-" + info.GetMonthName(mth2);
                if (OrderTable2 != null)
                {
                    prow2["Price"] = OrderTable2.Rows[0][1];
                }
                else
                {
                    prow2["Price"] = 0.0;
                }
                PriceTable.Rows.Add(prow2);


                //add third row
                DataRow prow3 = PriceTable.NewRow();
                prow3["PData"] = itemCode + " : " + year3.ToString() + "-" + info.GetMonthName(mth3);
                if (OrderTable3 != null)
                {
                    prow3["Price"] = OrderTable3.Rows[0][1];
                }
                else
                {
                    prow3["Price"] = 0.0;
                }
                PriceTable.Rows.Add(prow3);

                GridViewPrice.DataSource = PriceTable;
                GridViewPrice.DataBind();
                LoadChart_OrderPrice(PriceTable);

                GridViewQuantity.DataSource = "";
                GridViewQuantity.DataBind();

                Button1.Visible = true;
                PanelPrice.Visible = true;
                PanelQuantity.Visible = false;

            }
        }
    }
}