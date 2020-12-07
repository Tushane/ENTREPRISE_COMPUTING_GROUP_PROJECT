using EStore2.Backend.Data_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace EStore2.Backend
{
    public class Process_Executor
    {

        //function that handles user creation 
        public string User_Creation
            (
                string email, string username, string firstname, 
                string middlename, string lastname, string phonenumber, string userpassword
            )
        {
            //all the requred information to create a user
            string variabes = "@FIRST_NAME;" + firstname + "-@MIDDLE_NAME;" + middlename + "-@LAST_NAME;" + lastname
                                + "-@PHONE_NUMBER;" + phonenumber + "-@EMAIL_ADDRESS1;" + email + "-@USERNAME;" + username
                                + "-@USERPASSWORD;" + userpassword + "-@USER_TYPE;NON:ADMIN";

            
            Database_Connection con = new Database_Connection();

            string response = con.ExecuteProcedure("USER_CREATION", variabes);

            return response;
        }

        //function that handles the adding of customer card information
        public string Add_Customer_Card_Info
          (
              string userid, string cardholder_name, string card_no, string card_type, string address_id
          )
        {
            //all the requred information to create a user
            string variabes = "@CARD_HOLDER_NAME;" + cardholder_name + "-@CARD_NO;" + card_no + "-@CARD_TYPE;" + card_type
                                + "-@ADDRESS_ID;" + address_id + "-@USERID;" + userid;


            Database_Connection con = new Database_Connection();

            string response = con.ExecuteProcedure("ADD_CUSTOMER_CARD_DATA", variabes);

            return response;
        }

        //function that handles the adding of customer shipping information 
        public string Add_Shipping_Info(string userid, string deliver_info, string address_id)
        {
            //all the requred information to create a user
            string variabes = "@DELIVERY_INSTRUCTIONS;" + deliver_info + "-@ADDRESS_ID;" + address_id + "@USERID;" + userid; 

            Database_Connection con = new Database_Connection();

            string response = con.ExecuteProcedure("ADD_CUSTOMER_SHIPPING_DATA", variabes);

            con.closeSqlData();

            return response;
        }

        //adding the user address to the database for user that are not logged in 
        public string User_Address_Insertion
         (
             string resident_name, string username, string userpassword,
             string streetNo, string city, string state, string country,
             string zip_code
         )
        {

            //checking if the user was successfully created by retrieving the user id 
            string user_id = log_in(username, userpassword);

            //all the requred information to create a user
            string variabes = "@RESIDENT_NAME;" + resident_name + "-@USERID;" + user_id + "-@STREET_NO;" + streetNo
                                + "-@CITY;" + city + "-@STATE_OF_RESIDENCES;" + state + "-@COUNTRY;" + country
                                + "-@ZIP_CODE;" + zip_code;


            Database_Connection con = new Database_Connection();

            string response = con.ExecuteProcedure("ADD_CUSTOMER_ADDRESSES", variabes);

            con.closeSqlData();

            return response;
        }

        //adding the user address to the database for user that are logged in 
        public string User_Address_Insertion
         (
             string resident_name, string user_id,
             string streetNo, string city, string state, string country,
             string zip_code
         )
        {

            //all the requred information to create a user
            string variabes = "@RESIDENT_NAME;" + resident_name + "-@USERID;" + user_id + "-@STREET_NO;" + streetNo
                                + "-@CITY;" + city + "-@STATE_OF_RESIDENCES;" + state + "-@COUNTRY;" + country
                                + "-@ZIP_CODE;" + zip_code;


            Database_Connection con = new Database_Connection();

            string response = con.ExecuteProcedure("ADD_CUSTOMER_ADDRESSES", variabes);

            return response;
        }

        //retrieved product information to be displayed on the product page
        public List<PRODUTCT_DATA> retrieve_product(string search, string userid)
        {
            List<PRODUTCT_DATA> product_list = new List<PRODUTCT_DATA>();

            Database_Connection con = new Database_Connection();

            string query = "SELECT * FROM DBO.PRODUCT_DISPLAY_INFO"; //he base query

            //checking if the user is search for anything 
            if(search!= "")
            {
                query += " WHERE PROUCT_NAME LIKE '%" + search + "%'";
            }

            SqlDataReader reader;

            //checking if the user has a user id
            if (userid == "")
            {
                reader = con.ExecuteQueries(query);
            }
            else
            {
                reader = con.ExecuteQueries(query, userid);
            }

            //reading data that has been returned from the executed process 
            while (reader.Read())
            {

                //storing the data that has been received into an model 
                PRODUTCT_DATA temp = new PRODUTCT_DATA
                                            (
                                                reader[2].ToString(), decimal.Parse(reader[5].ToString()), 
                                                reader[4].ToString(), reader[6].ToString(), 
                                                reader[0].ToString(), 
                                                int.Parse(reader[7].ToString())
                                                , 0,
                                                reader[3].ToString()
                                            );

                //adding each row of data that has been read to data model list
                product_list.Add(temp);
            }

            con.closeSqlData();//closing sql data stream

            return product_list;//returning the data model list of data
        }

        //retrieving cart information whether historical or current information
        public List<CART_INFORMATION> retrieve_cart_data(string type, string userid)
        {
            Database_Connection con = new Database_Connection();
            List<CART_INFORMATION> cart_list = new List<CART_INFORMATION> ();
            string query = "";
            SqlDataReader reader = null;

            //checking which base query data will be pulling from 
            if(type == "his")
            {
                query = "SELECT * FROM [dbo].[VIEW_CART_HISTORY]('" + userid + "')";
            }
            else
            {
                query = "SELECT * FROM [dbo].[VIEW_CART]('" + userid + "')";
            }

            //retrieving data 
            reader = con.ExecuteQueries(query, userid);

            //reading data
            while (reader.Read())
            {
                //storing information into a class model 
                CART_INFORMATION cart = new CART_INFORMATION
                                            (
                                                reader[0].ToString(), reader[1].ToString(),
                                                int.Parse(reader[2].ToString()),
                                                decimal.Parse(reader[3].ToString()), reader[4].ToString(), reader[5].ToString(),
                                               reader[6].ToString(), decimal.Parse(reader[7].ToString())
                                            );

                //adding the model to a list of models
                cart_list.Add(cart);
            }

            con.closeSqlData();//closing sql data stream

            return cart_list;// returning the list
        }

        //retrieving user name 
        public string get_user_name(string user_id)
        {
            Database_Connection con = new Database_Connection();

            //retrieving user name 
            string response = con.ExecuteProcedure("GET_USER_NAME", "@user_id;" + user_id, user_id);

            con.closeSqlData();

            return response;//returning the username
        }

        //insert data into cart
        public string insert_into_cart(string user_id, string prod_id, string amt)
        {
            string response = "";
            Database_Connection con = new Database_Connection();
            string variables = "@PRODUCT_ID;" + prod_id + "-@USERID;" + user_id + "-@PURCHASED_AMOUNT;" + amt;
            response = con.ExecuteProcedure("ADD_PRODUCTS_TO_CART", variables, user_id);//retreiving the response

            con.closeSqlData();//closing the connection stream 

            return response;//returning the response
        }

        //retrieving the total amount of items in the customers cart
        public string cart_items_count(string user_id)
        {
            string response = "";
            Database_Connection con = new Database_Connection();
            string variables = "@USERID;" + user_id;
            response = con.ExecuteProcedure("CART_ITEMS_COUNT", variables, user_id);//retreiving the response

            con.closeSqlData();//closing the connection stream 

            return response;//returning the response
        }

        //retriving the available amount per item 
        public string item_purchase_limit(string user_id, string prod_id)
        {
            string response = "";
            Database_Connection con = new Database_Connection();
            string variables = "@PROD_ID;" + prod_id;
            if (user_id != "0")
            {
                response = con.ExecuteProcedure("GET_PROD_AVAIL_COUNT", variables, user_id);//retreiving the response
            }
            else
            {
                response = con.ExecuteProcedure("GET_PROD_AVAIL_COUNT", variables);//retreiving the response
            }

            con.closeSqlData();//closing the connection stream 

            return response;//returning the response
        }

        //function that handles the login into the website 
        public string log_in(string username, string password)
        {
            string response = null;
            Database_Connection con = new Database_Connection();
            string variables = "@user_name;" + username + "-@password;" + password;

            response = con.ExecuteProcedure("USER_LOGIN", variables);

            con.closeSqlData();

            return response;
        }

        //functionn that handles the retrieval of users addresses 
        public List<USER_ADDRESS_DETAIL> retrieve_customer_addresses(string user_id)
        {
            //declaring list to store all the customer addresses available on the database 
            List<USER_ADDRESS_DETAIL> add = new List<USER_ADDRESS_DETAIL>();

            Database_Connection con = new Database_Connection();

            //putting together the query that handles the retrieval of the address information 
            string query = "SELECT * FROM GET_ADDRESSES('" + user_id + "')";

            SqlDataReader reader = con.ExecuteQueries(query, user_id); //reading data from the database 

            while (reader.Read())
            {
                //storing an  user address in the data model that was created to host it
                USER_ADDRESS_DETAIL info = new USER_ADDRESS_DETAIL
                                                        (
                                                            reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                                                            reader[4].ToString(), reader[5].ToString(), reader[6].ToString()
                                                        );

                add.Add(info);// adding the user address to the user list of addresses if more than one exists
            }

            reader.Close();//closing the data reader 

            con.closeSqlData();// closing data connection 

            return add;

        }

        
        //function that handles the retrieval of the customer card information 
        public List<USER_CARD_INFO> retrieve_customer_card_info(string user_id)
        {
            List<USER_CARD_INFO> list_of_card = new List<USER_CARD_INFO>();

            Database_Connection con = new Database_Connection();

            string query = "SELECT * FROM GET_CARD_INFO('" + user_id + "')";

            SqlDataReader reader = con.ExecuteQueries(query, user_id);

            while (reader.Read())
            {

                USER_CARD_INFO card = new USER_CARD_INFO
                                                (
                                                    reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                                                    reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(),
                                                    reader[8].ToString()
                                                );

                list_of_card.Add(card);

            }

            reader.Close();

            con.closeSqlData();

            return list_of_card;
        }


        //function that retrive the information to handle the tracking of the product
        public List<USER_SHIPPING_INFO> retrieve_shipping_info(string user_id)
        {
            List<USER_SHIPPING_INFO> list_of_card = new List<USER_SHIPPING_INFO>();

            Database_Connection con = new Database_Connection();

            string query = "SELECT * FROM GET_SHIPPING_INFO('" + user_id + "')";

            SqlDataReader reader = con.ExecuteQueries(query, user_id);

            while (reader.Read())
            {

                USER_SHIPPING_INFO card = new USER_SHIPPING_INFO
                                                (
                                                    reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(),
                                                    reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString()
                                                );

                list_of_card.Add(card);

            }

            reader.Close();

            con.closeSqlData();

            return list_of_card;
        }

        //function that handles the retrieval of the user type
        public string get_user_type(string user_id)
        {
            Database_Connection con = new Database_Connection();
            return con.get_user_type(user_id);
        }

        //function that handles getting the cart summary information
        public List<CART_INFO_SUMMARY> get_cart_summary(string user_id)
        {

            List<CART_INFO_SUMMARY> cart_summary = new List<CART_INFO_SUMMARY>();

            Database_Connection con = new Database_Connection();

            string query = "SELECT * FROM GET_CART_SUMMARY('" + user_id + "')";

            SqlDataReader reader = con.ExecuteQueries(query, user_id);

            while (reader.Read())
            {

                CART_INFO_SUMMARY item_sum = new CART_INFO_SUMMARY
                                                (
                                                    reader[0].ToString(), int.Parse(reader[1].ToString()), decimal.Parse(reader[2].ToString()), reader[3].ToString()
                                                );

                cart_summary.Add(item_sum);

            }

            reader.Close();

            con.closeSqlData();

            return cart_summary;

        }

      //function that handles the deleting of items from the cart 
        public string delete_from_cart(string user_id, string cart_id)
        {
            Database_Connection con = new Database_Connection();

            string response = con.ExecuteProcedure("DELETE_FROM_CART", ("@CART_ID;" + cart_id + "-@USER_ID;" + user_id), user_id);

            return response;
        }

        //function that handles the clear of the cart information 
        public string clear_cart(string user_id)
        {
            Database_Connection con = new Database_Connection();

            string response = con.ExecuteProcedure("CLEAR_CART", ("@USER_ID;" + user_id), user_id);

            return response;
        }

    }
}