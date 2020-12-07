using EStore2.Backend;
using EStore2.Backend.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EStore2.CART_DATA
{
    public partial class CART_HIST : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["user_id"];//getting the user_id 
            List<System.Web.UI.HtmlControls.HtmlGenericControl> element_list = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();

            if (cookie != null)//check if the cookie exists
            {

                //init the page builder
                PageElementGenerator peg = new PageElementGenerator();

                //adding each cart breakout element to the page
                Process_Executor exec = new Process_Executor();
                List<System.Web.UI.HtmlControls.HtmlGenericControl> all_prod_display = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();
                List<CART_INFORMATION> data_list = exec.retrieve_cart_data("not_his", cookie.Value);

                int i = 0;
                foreach (CART_INFORMATION data in data_list)
                {
                    i++;
                    //init the page builder
                    PageElementGenerator pe1 = new PageElementGenerator();

                    maindiv.Controls.Add(pe1.generate_cart_summary_product_breakout(i, data));
                }


                //retrieving and updating the cart summary section
                PlaceHolder1.Controls.Add(peg.generate_cart_summary(cookie.Value));
                Total_Q.Text = peg.generate_cart_summary_total_quantity(cookie.Value);
                Total_Balance.Text = peg.generate_cart_summary_total_balance(cookie.Value);

            }
        }
    }
}