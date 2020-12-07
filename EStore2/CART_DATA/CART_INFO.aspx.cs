using EStore2.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EStore2.CART_DATA
{
    public partial class CART_INFO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["user_id"];//getting the user_id 
            List<System.Web.UI.HtmlControls.HtmlGenericControl> element_list = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();


            //declaring default buttons 
            Button del_button = new Button();

            del_button.Click += delete_from_cart;

            if (cookie != null)//check if the cookie exists
            {
                //init the page builder
                PageElementGenerator peg = new PageElementGenerator(del_button);

                //retrieving the breakout elements 
                element_list = peg.generate_cart_summary_product_breakout(cookie.Value, del_button);

                //retrieving and updating the cart summary section
                PlaceHolder1.Controls.Add(peg.generate_cart_summary(cookie.Value));
                Total_Q.Text = peg.generate_cart_summary_total_quantity(cookie.Value);
                Total_Balance.Text = peg.generate_cart_summary_total_balance(cookie.Value);

            }

            //adding each cart breakout element to the page
            foreach (System.Web.UI.HtmlControls.HtmlGenericControl element in element_list)
            {
                maindiv.Controls.Add(element);
            }

        }

        protected void clear_cart(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["user_id"];//getting the user_id 

            Process_Executor exec = new Process_Executor();

            string response = exec.clear_cart(cookie.Value);

            if(response == "CART_EMPTY")
            {
                Response.Redirect("~/Default");
            }
          
        }

        protected void check_out_cart(object sender, EventArgs e)
        {
            
        }

        protected void delete_from_cart(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["user_id"];//getting the user_id 

            Process_Executor exec = new Process_Executor();

            string[] sub_id = ((Button)sender).ID.Split('_');


            string response = exec.delete_from_cart(cookie.Value, sub_id[1]);

            if (response == "CART_EMPTY")
            {
                Response.Redirect("~/Default");
            }
            else
            {
                Response.Redirect("~/CART_DATA/CART_INFO");
            }
        }
    }
}