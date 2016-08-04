using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.StoreClerk1
{
    public partial class AdjustStationery : System.Web.UI.Page
    {
        AdjustInventoryBLL adglogic = new AdjustInventoryBLL();
        List<adjustmentDetail> adjCart; List<adjustmentDetail> updateCart; int userid; UserBLL userlogic = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorClear();


            if (Session["UserID"] != null)
            {
                userid = Convert.ToInt32(Session["UserID"]);
                if (userlogic.GetUserByID(userid).roleId != 11000)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            else
            {
                Response.Redirect("~/LoginPage.aspx");
            }
        

            if (!IsPostBack)
            {
                LoadCategoryList();

            }

            adjCart = Session["AdjCart"] != null ? (List<adjustmentDetail>)Session["AdjCart"] : null;

            if (adjCart == null)
            {
                List<adjustmentDetail> newcart = new List<adjustmentDetail>();
                Session["AdjCart"] = newcart;

            }
            else
            {
                Session["AdjCart"] = adjCart;
            }

            btnConfirmAdj.Visible = false;         
            Label8.Visible = false;
            AmtAdjustmentLbl.Visible = false;
         

        }

        protected void LoadCategoryList()
        {
            
            ddlCategory.DataSource = adglogic.getAllCategories();
            ddlCategory.DataValueField = "categoryId";
            ddlCategory.DataTextField = "categoryName";
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearlist();
        
            try
            {


                gdvCatelogueItem.DataSource = adglogic.getAllCatelogueItem(Convert.ToInt32(ddlCategory.SelectedItem.Value));
                gdvCatelogueItem.DataBind();

            }
            catch
            {
               
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + "Error!" + "');", true);
            }

        }

        //protected void callCatelogue()
        //{
            
        //    gdvCatelogueItem.DataSource = adglogic.getAllCatelogueItem(Convert.ToInt32(ddlCategory.SelectedItem.Value));
        //    gdvCatelogueItem.DataBind();
        //}

        protected void gdvCatelogueItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            clearlist();

            try
            {
                if (e.CommandName == "ChooseComm")
                {

                    int ee = Convert.ToInt32(e.CommandArgument);

                    lblItemNo.Text = gdvCatelogueItem.Rows[ee].Cells[0].Text;
                    lblItemName.Text = gdvCatelogueItem.Rows[ee].Cells[1].Text;


                }

            }

            catch(Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" +ex.Message + "');", true);
            }
                
            


        }

        protected void checkAdjustType()
        {
            if (rdbAdjustIn.Checked == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + "Please choose Adjustment Type!" + "');", true);
            }
            else if (rdbAdjustOut.Checked == false)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + "Please choose Adjustment Type!" + "');", true);
            }


        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            
            Boolean error = false;
            error = errorAddChecking();


            if (error == false)
            {
                
                try
                {

                    adjCart = Session["AdjCart"] != null ? (List<adjustmentDetail>)Session["AdjCart"] : null;
                    String AdjType = "";
                    String reason = "";
                    if (rdbAdjustIn.Checked == true)
                    {

                        AdjType = rdbAdjustIn.Text;
                    }
                    else
                    {
                        AdjType = rdbAdjustOut.Text;
                    }

                    if (rdbLost.Checked == true)
                    {

                        reason = rdbLost.Text;
                    }

                    else if (rdbFreeGift.Checked == true)
                    {
                        reason = rdbFreeGift.Text;

                    }
                    else if (rdbDamage.Checked == true)
                    {
                        reason = rdbDamage.Text;

                    }

                   

                    int qty = adglogic.checkQty(lblItemNo.Text);

                    if (Convert.ToInt32(txtQty.Text) <= 0 || Convert.ToInt32(txtQty.Text) > 1500)
                    {

                        chkrange.Text = "Value should be between 1 and 1500!";
                    }

                    else if (AdjType == "AdjustOut" && (Convert.ToInt32(txtQty.Text) > qty))
                    {

                        Label7.Text = "The quantity is Out Of Stock!";
                       

                    }

                    else
                    {
                                             
                            Label7.Text = "";
                            double amt = 0;
                            if (adjCart.Count == 0)
                            {

                                updateCart = adglogic.CreateAdjCart(lblItemNo.Text, Convert.ToInt32(txtQty.Text), AdjType, reason, adjCart);
                                List<adjustmentDetail> totalamount = updateCart;

                                foreach (adjustmentDetail ad in totalamount)
                                {
                                    AmtAdjustmentLbl.Text += ad.adjustmentAmount;
                                }

                                foreach (adjustmentDetail ad in totalamount)
                                {

                                    amt += (double)ad.adjustmentAmount;
                                    AmtAdjustmentLbl.Text = Convert.ToString(amt);
                                }

                                Session["AdjCart"] = updateCart;

                                gdvAdjustmentList.DataSource = Session["AdjCart"];
                                gdvAdjustmentList.DataBind();


                            }


                                    else
                                    {

                                        updateCart = adglogic.CreateAdjCart(lblItemNo.Text, Convert.ToInt32(txtQty.Text), AdjType, reason, adjCart);

                                        List<adjustmentDetail> totalamount = updateCart;

                                        foreach (adjustmentDetail ad in totalamount)
                                        {

                                            amt += (double)ad.adjustmentAmount;
                                            AmtAdjustmentLbl.Text = Convert.ToString(amt);
                                        }

                                        Session["AdjCart"] = updateCart;

                                        gdvAdjustmentList.DataSource = Session["AdjCart"];
                                        gdvAdjustmentList.DataBind();
                                       
                                    }


                            btnConfirmAdj.Visible = true;
                            clearlist();
                        

                    }

                }
                catch (Exception ex)
                {
                   // ScriptManager.RegisterStartupScript(Page, this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                  Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + ex.Message + "');", true);
                }

                
            }

        }

        protected void ErrorClear()
        {
            lblErrIName.Text = "";
            lblErrorMsg.Text = "";
            lblINo.Text = "";
            cv.Text = "";
            Label7.Text = "";
            chkrange.Text = "";


        }
        protected void clearlist()
        {


            lblItemNo.Text = "";
            lblItemName.Text = "";
            txtQty.Text = "";

            
        }

        protected void gdvAdjustmentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            List<adjustmentDetail> list = (List<adjustmentDetail>)Session["AdjCart"];
            
                if (e.CommandName == "RemoveComm")
                {
                  

                    int ee = Convert.ToInt32(e.CommandArgument);
                    String id = gdvAdjustmentList.Rows[ee].Cells[0].Text;
                    int rowindex = Convert.ToInt32(e.CommandArgument);
                   

                    list.Remove(list[rowindex]);
                    Session["Cart"] = list;
                    gdvAdjustmentList.DataSource = Session["Cart"];
                    gdvAdjustmentList.DataBind();

                    if (list.Count == 0)
                    {
                        btnConfirmAdj.Visible = false;
                    }
                    else
                    {
                        btnConfirmAdj.Visible = true;
                    }
                }

            
        }

        protected void btnConfirmAdj_Click(object sender, EventArgs e)
        {
            ddlCategory.AutoPostBack = false;
            List<adjustmentDetail> adjlist = new List<adjustmentDetail>();

            int userid = Convert.ToInt32(Session["UserID"]);
            adjlist = (List<adjustmentDetail>)Session["AdjCart"];

            adglogic.CreateAdjustment(adjlist, userid);
          
           
            //Page.Session.Clear();
            //clearlist();
            //MainExender.Hide();           
            //gdvAdjustmentList.DataBind();


            ScriptManager.RegisterStartupScript(Page, this.GetType(), "ErrorAlert", "alert('Successfully!');", true);
          //////Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + "Successfully Saved!" + "');", true);

            Session.Remove("AdjCart");
            Response.Redirect("AdjustmentHistory.aspx");
          
        }

        protected bool errorAddChecking()
        {
           
            Boolean ErrorBro = false;
            if (txtQty.Text == "")
            {
                lblErrorMsg.Text = "The Item Quantity Should not be Blank!";
               

                ErrorBro = true;
            }
            
            
            if (lblItemNo.Text == "")
            {
                lblINo.Text = "The Item No Should not be Blank!";
                ErrorBro = true;
            }
            else if (lblItemName.Text == "")
            {
                lblErrIName.Text = "The Item Name Should not be Blank!";
                ErrorBro = true;
            }
           
           

            return ErrorBro;
        }


        protected void gdvCatelogueItem_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gdvCatelogueItem.DataSource = adglogic.getAllCatelogueItem(Convert.ToInt32(ddlCategory.SelectedItem.Value));
            gdvCatelogueItem.DataBind();

            gdvCatelogueItem.PageIndex = e.NewPageIndex;
            gdvCatelogueItem.DataBind();
            MainExender.Show();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            MainExender.Hide();
        }

        protected void gdvAdjustmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            btnConfirmAdj.Visible = true;
            gdvAdjustmentList.DataSource = Session["AdjCart"];
            gdvAdjustmentList.DataBind();
            gdvAdjustmentList.PageIndex = e.NewPageIndex;
            gdvAdjustmentList.DataBind();
        }


        
    }
}