using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStore2.Backend.Data_Models
{
    public class USER_ADDRESS_DETAIL
    {
        private string id;
        private string resident_name;
        private string street_no;
        private string city;
        private string state;
        private string country;
        private string zip_code;

        public USER_ADDRESS_DETAIL(string id, string resident_name, string street_no, string city, string state, string country, string zip_code)
        {
            this.id = id;
            this.resident_name = resident_name;
            this.street_no = street_no;
            this.city = city;
            this.state = state;
            this.country = country;
            this.zip_code = zip_code;
        }

        public USER_ADDRESS_DETAIL(string street_no, string city, string state, string country, string zip_code)
        {
            this.street_no = street_no;
            this.city = city;
            this.state = state;
            this.country = country;
            this.zip_code = zip_code;
        }

        public USER_ADDRESS_DETAIL(string resident_name, string street_no, string city, string state, string country, string zip_code)
        {
            this.resident_name = resident_name;
            this.street_no = street_no;
            this.city = city;
            this.state = state;
            this.country = country;
            this.zip_code = zip_code;
        }


        //getters 
        public string get_id()
        {
            return this.id;
        }

        public string get_resident_name()
        {
            return this.resident_name;
        }

        public string get_street_no()
        {
            return this.street_no;
        }

        public string get_city()
        {
            return this.city;
        }

        public string get_state()
        {
            return this.state;
        }

        public string get_country()
        {
            return this.country;
        }

        public string get_zip_code()
        {
            return this.zip_code;
        }
    }
}