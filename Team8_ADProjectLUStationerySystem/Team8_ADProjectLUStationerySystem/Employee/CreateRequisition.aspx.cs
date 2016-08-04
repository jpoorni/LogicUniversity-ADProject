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
    public partial class CreateRequisition : System.Web.UI.Page
    {

        Requisitioin req = new Requisitioin();
        List<requisitionDetail> listrd;
        requisitionDetail rd;

        CategoryBLL CBL = new CategoryBLL();
        ItemBLL IBL = new ItemBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"]==null)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            if(!IsPostBack)
            {
                DropDownList1.DataSource = IBL.getAllItem(); ;
                DropDownList1.DataTextField = "itemDescription";
                DropDownList1.DataValueField = "itemCode";
                DropDownList1.DataBind();
            }

            

            //session
            listrd = Session["listrd"] != null ? (List<requisitionDetail>)Session["listrd"] : null;
            if (listrd == null)
            {
                List<requisitionDetail> newList = new List<requisitionDetail>();
                Session["listrd"] = newList;
            }
            else
            {
                Session["listrd"] = listrd;
            }
        }

        private void filedata()
        {
           
            GridView1.DataSource = Session["listrd"];
            GridView1.DataBind();
        }

        int i = 0;
        protected void Button1_Click(object sender, EventArgs e)
        {
            listrd = Session["listrd"] != null ? (List<requisitionDetail>)Session["listrd"] : null;
            //checking duplicate item
            if (listrd.Count == 0)
            {
                List<requisitionDetail> updateItem = req.addItem(i,DropDownList1.SelectedValue,DropDownList1.SelectedItem.Text, Convert.ToInt32(TextBox2.Text), 0, 0, false, listrd);
                Session["listrd"] = updateItem;
                // GridView1.DataSourceID=
                filedata();
                

            }
            else
            {
                foreach (requisitionDetail rd in listrd)
                {
                    if (rd.itemCode == DropDownList1.SelectedValue)
                    {
                        ScriptManager.RegisterStartupScript(Page, this.GetType(), "Success", "alert('Already Added.!!!')", true);
                        break;
                    }
                    else
                    {
                       

                        List<requisitionDetail> updateItem = req.addItem(i, DropDownList1.SelectedValue, DropDownList1.SelectedItem.Text, Convert.ToInt32(TextBox2.Text), 0, 0, false, listrd);
                        Session["listrd"] = updateItem;

                        filedata();
                       
                        break;
                    }
                }
            }

            TextBox2.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(listrd.Count>0)
            { 

            int userid = (int)Session["UserID"];
           // int userid = 1004;
            string deptcode = req.findDeptCode(userid);
            if(CheckBox1.Checked)
            {
            req.addrequisition(deptcode, userid, 2000, DateTime.Now, true, listrd);
            }
            else
            { 
            req.addrequisition(deptcode, userid, 2000, DateTime.Now, false, listrd);
            }

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Success", "alert('Requisition Successfull!!!')", true);

            Clear();
            Session.Remove("listrd");
            filedata();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Warning", "alert('Please Create Requisition!!!!!')", true);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex] as GridViewRow;
            Label item = (Label)row.FindControl("Label2");
            string itemCode = item.Text;
            List<requisitionDetail> list = Session["listrd"] as List<requisitionDetail>;
            var removeItem = list.First(x => x.itemDescription == itemCode);

            list.Remove(removeItem);


            filedata();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            filedata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex] as GridViewRow;
            Label item = (Label)row.FindControl("Label2");
            TextBox qty = (TextBox)row.FindControl("TextBox1");
            int Quanty = Convert.ToInt32(qty.Text);
            string itemCode = item.Text;
            List<requisitionDetail> list = Session["listrd"] as List<requisitionDetail>;
            var addItem = list.First(x => x.itemDescription == itemCode);
            addItem.qtyNeeded = Quanty;
            //  list.Add(addItem);
            GridView1.EditIndex = -1;
            filedata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            filedata();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Clear();
            Session.Remove("listrd");
            filedata();
        }

        private void Clear()
        {
            DropDownList1.SelectedIndex = 0;
            TextBox2.Text = "";
        }

        
    }
}