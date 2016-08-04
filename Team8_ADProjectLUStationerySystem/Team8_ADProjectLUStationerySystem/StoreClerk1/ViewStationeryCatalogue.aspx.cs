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
    public partial class ViewStationeryCatalogue : System.Web.UI.Page
    {
        CategoryBLL categorylogic = new CategoryBLL();
        ItemBLL itemlogic = new ItemBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                LoadCategoryList();
                LoadItemList();
               

            }

        }

        protected void LoadItemList()
        {
            if (CategoryDropDown.SelectedItem.Text != "Any")
            {
                ItemNameDropDown.DataSource = itemlogic.getAllItemNameByCategory(CategoryDropDown.SelectedItem.Text); 
                ItemNameDropDown.DataValueField = "itemCode";
                ItemNameDropDown.DataTextField = "itemDescription";
                ItemNameDropDown.DataBind();
                
            }
            else
            {
                ItemNameDropDown.DataSource = itemlogic.getAllItem();
                ItemNameDropDown.DataValueField = "itemCode";
                ItemNameDropDown.DataTextField = "itemDescription";
                ItemNameDropDown.DataBind();
                ItemNameDropDown.Items.Insert(0, new ListItem("Any", "0"));
            }
        }
        protected void CategoryDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemList();
        }

        protected void LoadGridView()
        {
            CatalogueGridview.DataSource = itemlogic.getAllItem();
            CatalogueGridview.DataBind();
        }

            protected void LoadCategoryList()
        { 
            CategoryDropDown.DataSource = categorylogic.getAllCategory();
            CategoryDropDown.DataValueField = "categoryId";
            CategoryDropDown.DataTextField = "categoryName";
            CategoryDropDown.DataBind();
            CategoryDropDown.Items.Insert(0, new ListItem("Any", "0"));
            
        }

            protected void LoadGridViewByCategoryList()
            {
                CatalogueGridview.DataSource = itemlogic.itemListbyCat(CategoryDropDown.SelectedItem.Text);
                CatalogueGridview.DataBind();
            }

         protected void LoadGridViewByItemName()
            {

                CatalogueGridview.DataSource = itemlogic.itemListByItemName(ItemNameDropDown.SelectedItem.Text);
                CatalogueGridview.DataBind();
       
        }

          
     
      
            protected void SearchBtn_Click(object sender, EventArgs e)
            {
                if (CategoryDropDown.SelectedItem.Text == "Any" && ItemNameDropDown.SelectedItem.Text == "Any")
                {
                    LoadGridView();
                }
                else if (ItemNameDropDown.SelectedItem.Text == " "  && CategoryDropDown.SelectedItem.Text != "Any")
                {
                    LoadGridViewByCategoryList();

                }
                else if (ItemNameDropDown.SelectedItem.Text != " "  &&  CategoryDropDown.SelectedItem.Text != " ")
                {
                    
                    LoadGridViewByItemName();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts","<script>alert('Error. Please try again.');</script>");
                }
             
            }


            protected void ItemNameDropDown_SelectedIndexChanged(object sender, EventArgs e)
            {

            }
}
}