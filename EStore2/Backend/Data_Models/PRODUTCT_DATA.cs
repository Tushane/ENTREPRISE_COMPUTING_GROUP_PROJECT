using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStore2.Backend.Data_Models
{
    public class PRODUTCT_DATA
    {
        //all the variables needed to store the products information
        private string product_name;
        private decimal unit_price;
        private string description;
        private string currency;
        private string id;
        private int avaiable_amt;
        private int quantity;
        private string product_image;

        public PRODUTCT_DATA(string product_name, decimal unit_price, string description,
            string currency, string id, int avaiable_amt, int quantity, string prod_image)
        {
            this.product_name = product_name;
            this.unit_price = unit_price;
            this.description = description;
            this.currency = currency;
            this.id = id;
            this.avaiable_amt = avaiable_amt;
            this.quantity = quantity;
            this.product_image = prod_image;
        }


        //getters 
        public string get_prod_name()
        {
            return this.product_name;
        }
        public decimal get_unit_price()
        {
            return unit_price;
        }
        public string get_unit_price_display()
        {
            return this.currency + "$" + unit_price.ToString("0.00");
        }
        public string get_description()
        {
            return description;
        }
        public string get_id()
        {
            return this.id;
        }
        public int get_available_amt()
        {
            return this.avaiable_amt;
        }
        public int get_qauntity()
        {
            return this.quantity;
        }
        public string get_product_image()
        {
            return this.product_image;
        }

        //setters
        public void set_qauntity(int amt)
        { 
            this.quantity = amt;
        }
    }
}