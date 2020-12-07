using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EStore2.Backend;
using Stripe;
using Stripe.Checkout;

namespace EStore2.CART_DATA
{
    public partial class INSERT_HISTORY : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["user_id"];//getting the user_id 

            Process_Executor exec = new Process_Executor();

            if (cookie.Value != null)
            {
                string response = exec.complete_order(cookie.Value, "");

                if (response == "ORDER_COMPLETED")
                {
                    Response.Redirect("~/CART_DATA/CART_HIST");
                }
            }
       
        }
    }
}