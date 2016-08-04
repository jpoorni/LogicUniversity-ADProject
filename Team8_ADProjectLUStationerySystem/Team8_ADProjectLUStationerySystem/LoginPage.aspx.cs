using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team8_ADProjectLUStationerySystem.BusinessLogic;

namespace Team8_ADProjectLUStationerySystem
{
    public partial class LoginPage : System.Web.UI.Page
    {
        LoginBLL loginlogic = new LoginBLL();
        UserBLL userlogic = new UserBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != null && txtPassword.Text != null)
            {
                string url = loginlogic.login(txtUserName.Text, txtPassword.Text.Trim());
                if (url != "errorPage.aspx")
                {
                    Session["UserID"] = userlogic.CheckUser(txtUserName.Text);
                }
                Response.Redirect(url);
            }
        }
    }
}