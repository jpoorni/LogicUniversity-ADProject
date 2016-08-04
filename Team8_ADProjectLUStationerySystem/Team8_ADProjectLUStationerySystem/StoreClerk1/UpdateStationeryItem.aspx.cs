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
    public partial class UpdateStationeryItem : System.Web.UI.Page
    {
        CategoryBLL cb = new CategoryBLL();
        ItemBLL ib = new ItemBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if (!IsPostBack)
            {
                LoadItem();
            }
        }

        protected void LoadItem()
        {
            string itemCode = (string)Session["itemCode"];
            catelogueItem updateItem = ib.getItem(itemCode);
            ItemNoLbl.Text = updateItem.itemCode;
            ItemCatLbl.Text = cb.getCatName((int)updateItem.categoryId);

            TextBox1.Text = updateItem.itemDescription;
            TextBox5.Text = Convert.ToString(updateItem.reorderLevel);
            TextBox6.Text = Convert.ToString(updateItem.reorderQuantity);
            TextBox7.Text = updateItem.uom;
            TextBox8.Text = Convert.ToString(updateItem.tenderPrice);
            TextBox2.Text = updateItem.bin;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string photo=Convert.ToBoolean(FileUpload1.HasFile).ToString();
            //ib.UpdateItem(ItemNoLbl.Text,TextBox2.Text, photo, TextBox1.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MaintainStationeryItem.aspx");
        }

}
}