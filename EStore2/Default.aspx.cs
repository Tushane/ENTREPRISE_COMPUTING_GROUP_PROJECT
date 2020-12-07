using EStore2.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EStore2
{
    public partial class _Default : Page
    {
       
        //function that loads when the page is loading 
        protected void Page_Load(object sender, EventArgs e)
        {
           
            HttpCookie cookie = Request.Cookies["user_id"];//getting the user_id 
            List<System.Web.UI.HtmlControls.HtmlGenericControl> element_list = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();

            //declaring default buttons 
            Button add_button = new Button();
            Button del_button = new Button();
            Button clear_button = new Button();
            Button addq_button = new Button();
            Button lessenq_button = new Button();

            //adding the respective events to the specific button
            addq_button.Click += new EventHandler(increased_quantity);
            lessenq_button.Click += new EventHandler(decreased_quantity);

            if (cookie != null)//check if the cookie exists
            {
                //the page builder
                PageElementGenerator peg = new PageElementGenerator(add_button, clear_button, del_button,addq_button, lessenq_button);

                if (cookie.Value != "0")
                {
                    //adding the respective events to the specific button
                    add_button.Click += new EventHandler(add_to_cart);

                    //retrieving all the elements
                    element_list = peg.generate_products("", cookie.Value);
                }
                else
                {
                    //adding the respective events to the specific button
                    add_button.Click += new EventHandler(login_transfer);

                    //getting page element the default way 
                    element_list = peg.generate_products("", "");
                  
                }
            }

            //adding each element to the page
            foreach(System.Web.UI.HtmlControls.HtmlGenericControl element in element_list)
            {
                maindiv.Controls.Add(element);
            }

        }

        //handles the adding of products to the cart 
        protected void add_to_cart(object sender, EventArgs e)
        {
            string[] result = ((Button)sender).ID.Split('_');//attempting to retrive the product id 

            HttpCookie cookie = Request.Cookies["user_id"];//getting the user_id 

            //attempting to find the box that holds the quantity of the product customer wants to purchase
            TextBox box = (TextBox)maindiv.FindControl("box" + result[1]);
          
            Process_Executor exec = new Process_Executor();

            string response = exec.insert_into_cart(cookie.Value, result[1], box.Text);

            //cehcking to see if the process of adding to cart is completed
            if(response == "SUCCESSFULLY_ADDED_TO_CART")
            {
                //System.Web.UI.HtmlControls.HtmlGenericControl temp = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("cart_amount");
                //temp.InnerText ='' 
                Response.Redirect("~/");
            }
        }

        //handles the increase in quantity per item 
        protected void increased_quantity(object sender, EventArgs e)
        {
            string[] result = ((Button)sender).ID.Split('_');//attempting to retrive the product id 

            Process_Executor exec = new Process_Executor();

            //attempting to find the box that holds the quantity of the product customer wants to purchase
            TextBox box = (TextBox)maindiv.FindControl("box" + result[1]);

            if (box != null)
            {
                int amt = (int.Parse(box.Text) + 1);
                if (amt <= int.Parse(exec.item_purchase_limit(get_user_id(), result[1])))
                {
                    box.Text = (amt).ToString();

                    System.Web.UI.HtmlControls.HtmlGenericControl avail = (System.Web.UI.HtmlControls.HtmlGenericControl)maindiv.FindControl("amt_avail" + result[1]);

                    if (avail != null)
                    {
                        avail.InnerHtml = (int.Parse(avail.InnerHtml) - 1).ToString();
                    }
                }
            }
        }

        //handles the decrease in quantity per item 
        protected void decreased_quantity(object sender, EventArgs e)
        {
            string[] result = ((Button)sender).ID.Split('_');//attempting to retrive the product id 

            //attempting to find the box that holds the quantity of the product customer wants to purchase
            TextBox box = (TextBox)maindiv.FindControl("box" + result[1]);

            if (box != null)
            {
                int amt = (int.Parse(box.Text) - 1);

                if (amt >= 1)
                {
                    box.Text = (amt).ToString();

                    System.Web.UI.HtmlControls.HtmlGenericControl avail = (System.Web.UI.HtmlControls.HtmlGenericControl)maindiv.FindControl("amt_avail" + result[1]);

                    if (avail != null)
                    {
                        avail.InnerHtml = (int.Parse(avail.InnerHtml) + 1).ToString();
                    }
                }
            }
        }

        protected void login_transfer(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login.aspx");
        }

        private string get_user_id()
        {
            HttpCookie cookie = Request.Cookies["user_id"];

            if (cookie!= null)
            {
                return cookie.Value;
            }

            return "";
        }
    }
}