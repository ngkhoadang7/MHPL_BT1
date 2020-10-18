using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Todolist
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.Request.Cookies.AllKeys.Contains("userInfo"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('Phiên làm việc hết hạn'); window.location='" +
                        Request.ApplicationPath + "Login.aspx';", true);
                return;
            }
            userName.InnerText = Request.Cookies["userInfo"]["name"];
        }

        protected void btnLogout_OnClick(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirmLogout"];
            if (confirmValue == "Yes")
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}