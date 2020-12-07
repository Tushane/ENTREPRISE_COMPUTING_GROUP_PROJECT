using EStore2.Backend.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EStore2.Backend
{
    public class PageElementGenerator
    {
        //all the interactive componentss
        private Button add_to_cart;
        private Button clear_cart;
        private Button delete_from_cart;
        private Button add_quantity;
        private Button lessen_quantity;

        public PageElementGenerator(Button add_to_cart, Button clear_cart, Button delete_from_cart, Button add_quantity, Button lessen_quantity)
        {
            this.add_to_cart = add_to_cart;
            this.clear_cart = clear_cart;
            this.delete_from_cart = delete_from_cart;
            this.add_quantity = add_quantity;
            this.lessen_quantity = lessen_quantity;
        }

        public PageElementGenerator(Button delete_from_cart)
        {
         
            this.delete_from_cart = delete_from_cart;
   
        }

        //creating product hmtl elements 
        public List<System.Web.UI.HtmlControls.HtmlGenericControl> generate_products(string search, string user_id)
        {
            Process_Executor exec = new Process_Executor();
            List<System.Web.UI.HtmlControls.HtmlGenericControl> all_prod_display = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();
            List<PRODUTCT_DATA> data_list = exec.retrieve_product(search, user_id);

            foreach (PRODUTCT_DATA data in data_list) {

                System.Web.UI.HtmlControls.HtmlGenericControl newdiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                newdiv.Attributes.Add("Style", "border:1px; border-color:blue; padding-bottom:2%");
                newdiv.Attributes.Add("class", "col-md-4");
                newdiv.ID = "cart_info_" + data.get_id();

                
                string prod_image = "<img style='width:60%; height:200px;' src='" + data.get_product_image() +"'/>";
                string price = "<p>" + "Unit Cost: " + data.get_unit_price_display() + "</p>";
                string prod_name = "<p> Item Name: " + data.get_prod_name() + "<p>";
                string description = "<p> Item Description: " + data.get_description() + "</p>";
                string quantity = "<p style = 'flex:1'> Amount Available: </p>";

                //creating the section that holds the amount of available quantity is there per product
                System.Web.UI.HtmlControls.HtmlGenericControl avail_amt_host = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                avail_amt_host.ID = "amt_avail" + data.get_id();
                avail_amt_host.Attributes.Add("runat", "server");
                avail_amt_host.InnerHtml = (data.get_available_amt() - 1).ToString();

                //configuring the add to cart button
                add_to_cart.Text = "ADD TO CART >>";
                add_to_cart.CssClass = "btn btn-default";
                add_to_cart.ID = "cart_" + data.get_id();


                newdiv.InnerHtml = prod_image + prod_name + price + description;


                System.Web.UI.HtmlControls.HtmlGenericControl quan_host = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                System.Web.UI.HtmlControls.HtmlGenericControl avail_host = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                avail_host.Attributes.Add("Style", "display:flex; width:50%");

                avail_host.InnerHtml = quantity;

                quan_host.Attributes.Add("Style", "display:flex; width:50%");
                TextBox quan = new TextBox(); //text box that will display the amount of quantity that is being selected

                //button that will lessen the quantity of the product customer would like to order
                lessen_quantity.Text = "-";
                lessen_quantity.CssClass = "btn btn-default";
                lessen_quantity.Attributes.Add("Style", "flex:0.2");
                lessen_quantity.ID = "lessen_" + data.get_id();
               

                //button that will increase the quantity of the product customer would like to order
                add_quantity.Text = "+";
                add_quantity.CssClass = "btn btn-default";
                add_quantity.Attributes.Add("Style", "flex:0.2");
                add_quantity.ID = "add_" + data.get_id();

                //box that handles the displaying of the quantity
                quan.Attributes.Add("Style", "width:20%; flex:1");
                quan.ReadOnly = true;
                quan.Text = "1";
                quan.ID = "box" + data.get_id();

                quan_host.Controls.Add(lessen_quantity);
                quan_host.Controls.Add(quan);
                quan_host.Controls.Add(add_quantity);

                avail_host.Controls.Add(avail_amt_host);
                newdiv.Controls.Add(avail_host);
                newdiv.Controls.Add(quan_host);
                newdiv.Controls.Add(add_to_cart);

                all_prod_display.Add(newdiv);//adding each product element to the list 
            }

            return all_prod_display;//returning all the product that will be displaying 
        }

        //creating the elements for the cart product summary 
        public System.Web.UI.HtmlControls.HtmlGenericControl generate_cart_summary(string user_id)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            Process_Executor exec = new Process_Executor();

            List<CART_INFO_SUMMARY> summary = exec.get_cart_summary(user_id);

            foreach(CART_INFO_SUMMARY detail in summary)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl sub_div_name = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                System.Web.UI.HtmlControls.HtmlGenericControl sub_div_q = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                System.Web.UI.HtmlControls.HtmlGenericControl sub_div_t = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                sub_div_name.InnerText = detail.get_product_name();
                sub_div_q.InnerText = detail.get_quantity_display();
                sub_div_t.InnerText = detail.get_sub_total_display();

                div.Controls.Add(sub_div_name);
                div.Controls.Add(sub_div_q);
                div.Controls.Add(sub_div_t);
            }

            return div;
        }

        public string generate_cart_summary_total_quantity(string user_id)
        {
           Process_Executor exec = new Process_Executor();

            int amt = 0;

            List<CART_INFO_SUMMARY> summary = exec.get_cart_summary(user_id);

            foreach (CART_INFO_SUMMARY detail in summary)
            {
                amt += detail.get_quantity();
            }

            return amt.ToString();
        }

        public string generate_cart_summary_total_balance(string user_id)
        {
            Process_Executor exec = new Process_Executor();

            decimal amt = 0;

            List<CART_INFO_SUMMARY> summary = exec.get_cart_summary(user_id);

            foreach (CART_INFO_SUMMARY detail in summary)
            {
                amt += detail.get_sub_total();
            }

            return amt.ToString();
        }

       public List<System.Web.UI.HtmlControls.HtmlGenericControl> generate_cart_summary_product_breakout(string user_id, Button del_from_cart)
        {
            Process_Executor exec = new Process_Executor();
            List<System.Web.UI.HtmlControls.HtmlGenericControl> all_prod_display = new List<System.Web.UI.HtmlControls.HtmlGenericControl>();
            List<CART_INFORMATION> data_list = exec.retrieve_cart_data("not_his", user_id);
            int i = 0;
            foreach (CART_INFORMATION data in data_list)
            {

                i++;

                System.Web.UI.HtmlControls.HtmlGenericControl newdiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                newdiv.Attributes.Add("Style", "border:1px; border-color:blue; padding-bottom:2%");
                newdiv.Attributes.Add("class", "col-md-4");
                newdiv.ID = "cart_info_" + i.ToString() + "_" + data.get_cart_id();


                string prod_image = "<img style='width:60%; height:200px;' src='" + data.get_prod_image() + "'/>";
                string price = "<p>" + "Unit Cost: " + data.get_unit_cost_display() + "</p>";
                string prod_name = "<p> Item Name: " + data.get_prod_name() + "<p>";
                string description = "<p> Sub-Total: " + data.get_payment_display() + "</p>";
                string quantity = "<p style = 'flex:1'> Amount Purchase: </p>";

                //creating the section that holds the amount of available quantity is there per product
                System.Web.UI.HtmlControls.HtmlGenericControl avail_amt_host = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                avail_amt_host.ID = "amt_avail" + i.ToString() + "_" + data.get_cart_id();
                avail_amt_host.Attributes.Add("runat", "server");

                //configuring the delete from cart button
                del_from_cart.Text = "DELETE>>";
                del_from_cart.CssClass = "btn btn-default";
                del_from_cart.ID = "cart" + i.ToString() + "_" + data.get_cart_id();


                newdiv.InnerHtml = prod_image + prod_name + price + description;


                System.Web.UI.HtmlControls.HtmlGenericControl quan_host = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                System.Web.UI.HtmlControls.HtmlGenericControl avail_host = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                avail_host.Attributes.Add("Style", "display:flex;");

                avail_host.InnerHtml = quantity;

                quan_host.Attributes.Add("Style", "display:flex; width:30%");
                TextBox quan = new TextBox(); //text box that will display the amount of quantity that is being selected


                //box that handles the displaying of the quantity
                quan.Attributes.Add("Style", "width:20%; flex:1");
                quan.ReadOnly = true;
                quan.Text = data.get_qauntity().ToString();
                quan.ID = "box" + i.ToString() + "_" + data.get_cart_id();
                quan_host.Controls.Add(quan);

                avail_host.Controls.Add(avail_amt_host);
                newdiv.Controls.Add(avail_host);
                newdiv.Controls.Add(quan_host);
                newdiv.Controls.Add(del_from_cart);

                all_prod_display.Add(newdiv);//adding each product element to the list 
            }

            return all_prod_display;//returning all the product that will be displaying 
        }

    }
}