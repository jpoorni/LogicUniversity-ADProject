using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team8_ADProjectLUStationerySystem.StoreManager
{
    public partial class LogOutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.Remove("uid");
            Session["uid"] = null;

            Response.Redirect("~/LoginPage.aspx");
        }
    }
}