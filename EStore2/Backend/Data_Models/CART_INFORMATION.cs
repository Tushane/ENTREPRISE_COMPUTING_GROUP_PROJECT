using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStore2.Backend.Data_Models
{
    public class CART_INFORMATION
    {
        private string id;
        private string product_name;
        private int quantity_amount;
        private decimal payment;
        private string currency;
        private string purchased_date;
        private string product_image;
        private decimal unit_cost;
        private string transaction_id; 

        public CART_INFORMATION(string id, string product_name, int quantity_amount, decimal payment, string currency, string purchased_date, string product_image, decimal unit_cost)
        {
            this.id = id;
            this.product_name = product_name;
            this.quantity_amount = quantity_amount;
            this.payment = payment;
            this.currency = currency;
            this.purchased_date = purchased_date;
            this.product_image = product_image;
            this.unit_cost = unit_cost;
        }

        public CART_INFORMATION(string id, string product_name, int quantity_amount, decimal payment, string currency, string purchased_date, string product_image, decimal unit_cost, string temp)
        {
            this.id = id;
            this.product_name = product_name;
            this.quantity_amount = quantity_amount;
            this.payment = payment;
            this.currency = currency;
            this.purchased_date = purchased_date;
            this.product_image = product_image;
            this.unit_cost = unit_cost;
            this.transaction_id = temp;
        }

        //getters

        public string get_transaction_id()
        {
            return this.transaction_id;
        }
        public string get_cart_id()
        {
            return id;
        }
        public string get_prod_name()
        {
            return product_name;
        }
        public int get_qauntity()
        {
            return quantity_amount;
        }
        public decimal get_payment()
        {
            return payment;
        }
        public string get_payment_display()
        {
            return currency + "$" + payment.ToString();
        }
        public string get_purchased_date()
        {
            return purchased_date;
        }
        public string get_prod_image()
        {
            return product_image;
        }
        public decimal get_unit_cost()
        {
            return unit_cost;
        }
        public string get_unit_cost_display()
        {
            return currency + "$" + unit_cost.ToString();
        }
    }
}