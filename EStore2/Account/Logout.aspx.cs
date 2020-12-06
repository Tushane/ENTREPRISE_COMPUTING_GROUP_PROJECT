using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EStore2.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Web.UI.HtmlControls.HtmlGenericControl temp = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("logout_state");

            //if (temp != null)
            //{
            //    temp.Visible = true;
            //}

           
            //temp = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("login_state");

            //if (temp != null)
            //{
            //    temp.Visible = false;
            //}
            Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/");

        }
    }
}