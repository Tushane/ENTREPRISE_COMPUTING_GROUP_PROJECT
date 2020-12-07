using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStore2.Backend.Data_Models
{
    public class USER_SHIPPING_INFO
    {

        private string delivery_instruction;
        private string delivery_date;
        private USER_ADDRESS_DETAIL address;

        public USER_SHIPPING_INFO(string resident_name, string street_no, string city, string state, string country, string zip_code, string delivery_instruction, string delivery_date)
        {
            this.delivery_instruction = delivery_instruction;
            this.delivery_date = delivery_date;
            this.address = new USER_ADDRESS_DETAIL(resident_name, street_no, city, state, country, zip_code);
        }

        //getters
        public string get_instruction()
        {
            return this.delivery_instruction;
        }

        public string get_delivery_date()
        {
            return this.delivery_date;
        }

        public USER_ADDRESS_DETAIL get_address()
        {
            return this.address;
        }
    }
}