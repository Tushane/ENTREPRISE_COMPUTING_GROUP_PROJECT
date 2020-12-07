using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStore2.Backend.Data_Models
{
    public class CART_INFO_SUMMARY
    {
        private string product_name;
        private int quantity;
        private decimal sub_total;
        private string currency;
        private string prod_desc;

        public CART_INFO_SUMMARY(string product_name, int quantity, decimal sub_total, string currency)
        {
            this.product_name = product_name;
            this.quantity = quantity;
            this.sub_total = sub_total;
            this.currency = currency;
        }

        public CART_INFO_SUMMARY(string product_name, int quantity, decimal sub_total, string currency, string temp)
        {
            this.product_name = product_name;
            this.quantity = quantity;
            this.sub_total = sub_total;
            this.currency = currency;
            this.prod_desc = temp;
        }

        //getters
        public string get_product_name()
        {
            return "Product Name: " + this.product_name;
        }

        public int get_quantity()
        {
            return this.quantity;
        }

        public decimal get_sub_total()
        {
            return this.sub_total;
        }

        public string get_currecy()
        {
            return this.currency;
        }

        public string get_quantity_display()
        {
            return "Product Quantity: " + this.quantity.ToString();
        }

        public string get_sub_total_display()
        {
            return "Sub-Total: "  + get_currecy() + "$" + this.sub_total.ToString();
        }

        public string get_prod_desc()
        {
            return this.prod_desc;
        }
    }
}