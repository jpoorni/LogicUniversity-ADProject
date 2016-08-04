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
    public partial class RetrievalList : System.Web.UI.Page
    {
        Retrieval r = new Retrieval();
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
            List<retrieval> retrievalList = new List<retrieval>();
            DropDownList1.DataSource = r.getUnConfirm();
            DropDownList1.DataTextField = "retrievalId";
            DropDownList1.DataValueField = "retrievalId";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--Select retrieval--", "0"));
        }


        protected void LoadNormalGridView(int id)
        {
            List<retrievalDetail> rdr = r.getOneRetrieval(id);
            List<retrievalDetail> rd = r.getId(rdr);
            UpdateGridView.Visible = false;
            RetrievalGridView.Visible = true;
            BtnSubmit.Visible = false;
            this.RetrievalGridView.DataSource = rd;
            this.RetrievalGridView.DataBind();
        }
        protected void RetrievalGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rid = Convert.ToInt32(DropDownList1.SelectedValue);
            if (rid != 0)
            {
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
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Please select!');</script>");
            }
            

        }



        protected void LoadUpdateGridView(int id)
        {
            List<retrievalDetail> rdr = r.getOneRetrieval(id);
            List<retrievalDetail> rd = r.getId(rdr);
            RetrievalGridView.Visible = false;
            UpdateGridView.Visible = true;
            this.UpdateGridView.DataSource = rd;
            this.UpdateGridView.DataBind();
            BtnSubmit.Visible = true;

        }

        protected void UpdateGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rid = Convert.ToInt32(DropDownList1.SelectedValue);
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

        protected void tbActqty_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
        }

        protected void lbSave_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            LinkButton lbr = (LinkButton)lb.FindControl("lbSave");
            HiddenField hd1 = (HiddenField)lb.FindControl("HiddenField1");
            HiddenField hd2 = (HiddenField)lb.FindControl("HiddenField2");
            HiddenField hd3 = (HiddenField)lb.FindControl("HiddenField3");
            HiddenField hd4 = (HiddenField)lb.FindControl("HiddenField4");
            HiddenField hd5 = (HiddenField)lb.FindControl("HiddenField5");
            TextBox tb = (TextBox)lb.FindControl("tbActqty");

            int rid = Convert.ToInt32(hd1.Value);
            string iid = hd2.Value;
            string did = hd3.Value;
            int reqQty = Convert.ToInt32(hd4.Value);
            int actQty = Convert.ToInt32(tb.Text);
            int hdact = Convert.ToInt32(hd5.Value);
            if (actQty < reqQty && actQty<hdact)
            {
                r.comfirmRetrievalDetails(rid, iid, did, actQty);
                adjustmentDetail ad = new adjustmentDetail();
                ad.itemCode = iid;
                ad.adjustmentQuantity = hdact-actQty;
                ad.type = "AdjustOut";
                ad.adjustmentAmount = adj.adjustmentAmount(iid, reqQty - actQty);
                if (Session["detail"] == null)
                {
                    List<adjustmentDetail> detail= new List<adjustmentDetail>();
                    detail.Add(ad);
                    Session["detail"] = detail;

                }
                else
                {
                    List<adjustmentDetail> detail = (List<adjustmentDetail>)Session["detail"];
                    List<adjustmentDetail> a = detail.Where(x =>
                        x.itemCode == ad.itemCode).ToList();
                    if (a.Count==0)
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
                //ad.reason = "";
               
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Saved!');</script>");
                //lbr.Enabled = false;
                LoadUpdateGridView((int)Session["rid"]);
            }
            else if (actQty < reqQty && actQty > hdact)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Can not large before');</script>");
                LoadUpdateGridView((int)Session["rid"]);
            }
            else if (actQty == reqQty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('The Qty id same.');</script>");
                LoadUpdateGridView((int)Session["rid"]);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Wrong Actual Qty');</script>");
                LoadUpdateGridView((int)Session["rid"]);
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            int rid = (int)Session["rid"];
            string status = r.getStatus(rid);
            if (status == "0")
            {
                r.ComfirmRetriavleList(rid, 0);
            }
            else
            {
                r.ComfirmRetriavleList(rid, 1);
            }
            List<adjustmentDetail> detail = (List<adjustmentDetail>)Session["detail"];
            if (detail != null)
            {
                Response.Redirect("SpecialAdjustment.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Comfirmed!');</script>");
                //Response.Redirect(".aspx"); zhuye
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList1.SelectedValue);
            if (id != 0)
            {
                string status = r.getStatus(id);

                if (status == "0")
                {
                    Label4.Text = "Normal Retrieval Haven't Confirm.";

                }
                else
                {
                    Label4.Text = "Self Collection Haven't Confirm.";

                }
                RadioButton1.Enabled = true;
                RadioButton2.Enabled = true;
                btnProcess.Enabled = true;
            }
            else
            {
                Label4.Text = "";
                UpdateGridView.Visible = false;
                RetrievalGridView.Visible = false;
                RadioButton1.Checked = false;
                RadioButton2.Checked = false;

            }
            
            
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            int rid = Convert.ToInt32(DropDownList1.SelectedValue);
            Session["rid"] = rid;
            if (DropDownList1.SelectedValue == "0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Please Select one Retrieval!');</script>");
            }
            else
            {
                if (RadioButton1.Checked == true)
                {
                    LoadNormalGridView(rid);
                }
                else if (RadioButton2.Checked == true)
                {
                    LoadUpdateGridView(rid);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "<script>alert('Please Select one Action!');</script>");
                }
            }
            
            
        }

        protected void lbNew_Click(object sender, EventArgs e)
        {
            r.generateSC();
            int id = r.generateNormal(1);

            Session["retrievalId"] = id;

            Response.Redirect("RetrievalForm.aspx");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            int rid = (int)Session["rid"];
            Response.Redirect("RetrievalForm.aspx");

        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }








    }
}