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
    public partial class CART_INFO : System.Web.UI.Page
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

                    //declaring default buttons 
                    Button del_button = pe1.get_delete_from_cart();

                    del_button.Click += delete_from_cart;

                    pe1.set_delete_from_cart(del_button);

                    maindiv.Controls.Add(pe1.generate_cart_summary_product_breakout(i, data));
                }
                

                //retrieving and updating the cart summary section
                PlaceHolder1.Controls.Add(peg.generate_cart_summary(cookie.Value));
                Total_Q.Text = peg.generate_cart_summary_total_quantity(cookie.Value);
                Total_Balance.Text = peg.generate_cart_summary_total_balance(cookie.Value);

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