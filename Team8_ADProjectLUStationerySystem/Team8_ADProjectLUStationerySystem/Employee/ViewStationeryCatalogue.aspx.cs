using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem.Employee
{
    public partial class ViewStationeryCatalogue : System.Web.UI.Page
    {
        CategoryBLL CBL = new CategoryBLL();
        ItemBLL IBL = new ItemBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if(!IsPostBack)
            {
                DropDownList1.DataSource = CBL.getAllCategory();
                DropDownList1.DataTextField = "categoryName";
                DropDownList1.DataValueField = "categoryId";
                DropDownList1.DataBind();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cateID =  Convert.ToInt32(DropDownList1.SelectedValue);
            List<catelogueItem> List = IBL.getAllItemByCategory(cateID);
            
            

            Gridview1.DataSource = List;
            Gridview1.DataBind();
           
        }
        
       
}
}