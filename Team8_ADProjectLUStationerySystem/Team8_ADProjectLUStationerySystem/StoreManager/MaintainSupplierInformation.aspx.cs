using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.StoreManager
{
    public partial class MaintainSupplierInformation : System.Web.UI.Page
    {
        SupplierBLL sp = new SupplierBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                LoadGridView();
            }

        }

        protected void LoadGridView()
        {
            SupplierGridView.DataSource = sp.getAllSupplier();
            SupplierGridView.DataBind();
            loadTender();
        }


        string first = "First";
        string second = "Second";
        string third = "Third";
        string none = "BackUp";

        protected void loadTender()
        {
            for (int i = 0; i < SupplierGridView.Rows.Count; i++)
            {
                HiddenField hd = (HiddenField)SupplierGridView.Rows[i].Cells[7].FindControl("HiddenField1");
                DropDownList ddl = (DropDownList)SupplierGridView.Rows[i].Cells[7].FindControl("ddlRank");
                ddl.SelectedValue = hd.Value;
                if (hd.Value == "1")
                {
                    ddl.SelectedItem.Text = first;
                }
                else if (hd.Value == "2")
                {
                    ddl.SelectedItem.Text = second;
                }
                else if (hd.Value == "3")
                {
                    ddl.SelectedItem.Text = third;
                }
                else
                {
                    ddl.SelectedItem.Text = none;
                }
            }
        }


        protected void AdjustStationeryGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DropDownList ddl = (DropDownList)e.Row.FindControl("ddlRank");
            //    HiddenField hd = (HiddenField)e.Row.FindControl("HiddenField1");
            //    ddl.SelectedValue = hd.Value;
            //    if (hd.Value == "1")
            //    {
            //        ddl.SelectedItem.Text = first;
            //    }
            //    else if (hd.Value == "2")
            //    {
            //        ddl.SelectedItem.Text = second;
            //    }
            //    else if (hd.Value == "3")
            //    {
            //        ddl.SelectedItem.Text = third;
            //    }
            //    else
            //    {
            //        ddl.SelectedItem.Text = none;
            //    }
                

            //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<supplier> spl = sp.getAllSupplier();

            for (int i = 0; i < SupplierGridView.Rows.Count; i++)
            {
                DropDownList ddl = (DropDownList)SupplierGridView.Rows[i].Cells[7].FindControl("ddlRank");
                string rank = ddl.SelectedValue;
                spl[i].supplierRank = Convert.ToInt32(rank);
            }
            int flag = 0;
            List<int> rankV = new List<int>();
            foreach (supplier s in spl)
            {

                if (s.supplierRank.HasValue)
                {
                    if (rankV.Contains(s.supplierRank.Value) == true)
                    {
                        flag = 1;
                        break;
                    }
                    else
                    {
                        rankV.Add(s.supplierRank.Value);
                    }

                }

            }

            if (flag != 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "uns();", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Rank can't be same!');</script>");
                //LoadGridView();
            }
            else
            {
                sp.changeRank(spl);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "s();", true);

            }

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }
    }
}