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
    public partial class ComfirmDisbursement : System.Web.UI.Page
    {
        Disbursement d = new Disbursement();
        AdjustInventoryBLL adj = new AdjustInventoryBLL();
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

            DropDownList1.DataSource = d.getUnConfirm();
            DropDownList1.DataTextField = "disbursementId";
            DropDownList1.DataValueField = "disbursementId";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select disbursement--", "0"));
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            

        }

        protected void LoadGridView(int disid)
        {
            this.GridView1.Visible = true;
            btnConfirm.Visible = true;
            this.GridView1.DataSource = d.getDisbursementDetail(disid);
            this.GridView1.DataBind();

        }

        protected void tbActqty_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            HiddenField hd1 = (HiddenField)lb.FindControl("HiddenField1");
            HiddenField hd2 = (HiddenField)lb.FindControl("HiddenField2");
            HiddenField hd3 = (HiddenField)lb.FindControl("HiddenField3");
            HiddenField hd4 = (HiddenField)lb.FindControl("HiddenField4");
            TextBox tb = (TextBox)lb.FindControl("tbActqty");

            int disid = Convert.ToInt32(hd1.Value);
            string iid = hd2.Value;
            int actQty = Convert.ToInt32(tb.Text);
            int reqQty= Convert.ToInt32(hd3.Value);
            int actr = Convert.ToInt32(hd4.Value);
            if (actQty < reqQty && actQty<actr)
            {
                d.changeDisbursementQuantity(disid, iid, actQty);
                adjustmentDetail ad = new adjustmentDetail();
                ad.itemCode = iid;
                ad.adjustmentQuantity = reqQty - actQty;
                ad.type = "AdjustOut";
                ad.adjustmentAmount = adj.adjustmentAmount(iid, reqQty - actQty);
                if (Session["detail"] == null)
                {
                    List<adjustmentDetail> detail = new List<adjustmentDetail>();
                    detail.Add(ad);
                    Session["detail"] = detail;

                }
                else
                {
                    List<adjustmentDetail> detail = (List<adjustmentDetail>)Session["detail"];
                    List<adjustmentDetail> a = detail.Where(x =>
                        x.itemCode == ad.itemCode).ToList();
                    if (a.Count == 0)
                    {
                        detail.Add(ad);
                    }
                    else
                    {
                        a[0].adjustmentQuantity = a[0].adjustmentQuantity + ad.adjustmentQuantity;
                        a[0].adjustmentAmount = a[0].adjustmentAmount + ad.adjustmentAmount;
                    }

                    Session["detail"] = detail;

                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Saved!');</script>");
                LoadGridView((int)Session["disid"]);
            }
            else if (actQty < reqQty && actQty>actr)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Can not large then before');</script>");
                LoadGridView((int)Session["disid"]);

            }
            else if (actQty == reqQty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('The Qty id same.');</script>");
                LoadGridView((int)Session["disid"]);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Wrong Receive Qty');</script>");
                LoadGridView((int)Session["disid"]);
            }
            

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int disid = (int)Session["disid"];
            d.confirmDisbursement(disid);
            List<adjustmentDetail> detail = (List<adjustmentDetail>)Session["detail"];
            if (detail != null)
            {
                Response.Redirect("SpecialAdjustment.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Comfirmed!');</script>");
                Response.Redirect("SpecialAdjustment.aspx");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int disid = Convert.ToInt32(DropDownList1.SelectedValue);
            if (disid != 0)
            {
                Session["disid"] = disid;
                LoadGridView(disid);

            }
            else
            {
                GridView1.Visible = false;
                btnConfirm.Visible = false;
            }
            
        }

    }
}