using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStore2.Backend.Data_Models
{
    public class USER_CARD_INFO
    {
        private string id;
        private string card_holder_name;
        private string card_no;
        private string card_type;
        private USER_ADDRESS_DETAIL address;

        public USER_CARD_INFO
            (
                string id, string card_holder_name, string card_no, string card_type,
                string street_no, string city, string state, string country, string zip_code
            )
        {
            this.id = id;
            this.card_holder_name = card_holder_name;
            this.card_no = card_no;
            this.card_type = card_type;
            this.address = new USER_ADDRESS_DETAIL(street_no, city, state, country, zip_code);
        }

        //getters
        public string get_id()
        {
            return this.id;
        }

        public string get_card_holder_nae()
        {
            return this.card_holder_name;
        }

        public string get_card_no()
        {
            return this.card_no;
        }

        public string get_card_type()
        {
            return this.card_type;
        }

        public USER_ADDRESS_DETAIL get_address()
        {
            return this.address;
        }
    }
}