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
    public partial class StockCards : System.Web.UI.Page
    {

        //createObject of BusinessLogic
        SupplierBLL supplierlogic = new SupplierBLL();
        CategoryBLL categorylogic = new CategoryBLL();
        ItemBLL itemlogic = new ItemBLL();
        OrderBLL orderlogic = new OrderBLL();
        StockCard stocklogic = new StockCard();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                LoadCategoryList();

                StockCardImage.Visible = false;
            }

            //to be added in during integration.
            //try
            //{
            //    userid = Convert.ToInt32(Session["UserID"]);
            //}
            //catch
            //{
            //    Response.Redirect("~/LoginPage.aspx");
            //}
        }
        protected void CategoryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ItemNameDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void LoadCategoryList()
        {
            ddlCategory.DataSource = categorylogic.getAllCategory();
            ddlCategory.DataValueField = "categoryId";
            ddlCategory.DataTextField = "categoryName";
            ddlCategory.DataBind();
            

            ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                gdvCatelogueItem.DataSource = itemlogic.getAllItemByCategory(Convert.ToInt32(ddlCategory.SelectedValue));
                gdvCatelogueItem.DataBind();

            
        }


        protected void gdvCatelogueItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ChooseComm")
            {
                Label6.Visible = true;
                catelogueItem itm = itemlogic.getItem(gdvCatelogueItem.Rows[rowindex].Cells[0].Text);
                txtItemDescription.Text = itm.itemCode + "-" + itm.itemDescription;
                itemCode.Text = itm.itemCode;
                BinNoLbl.Text = itm.bin;
                StockCardImage.Visible = true;
                StockCardImage.ImageUrl = "~/images/" + itm.photos;
              

                List<string> stock = stocklogic.getItemCodeList();
               
                int flag = 0;
                
                foreach (string x in stock)
                {
                    if ((itemCode.Text).Equals(x))
                    {
                        InStock.Visible = false;
                        StockCardGridView.Visible = true;
                        StockCardGridView.DataSource = stocklogic.getStockCard(gdvCatelogueItem.Rows[rowindex].Cells[0].Text);
                        StockCardGridView.DataBind();
                        flag = 1;
                        break;
                        
                        
                    }
                }
                if (flag == 0)
                {
                    StockCardGridView.Visible = false;
                    InStock.Visible = true;
                    MakePurchaseOrderBtn.Visible = true;


                }

                
                
              
          
            }
}
       



        protected void gdvCatelogueItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }


        protected void MakePurchaseOrderBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateOrder.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
}
}