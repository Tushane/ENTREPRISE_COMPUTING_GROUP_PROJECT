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

        public string User_Creation()
        {
            string response = "";
            Database_Connection con = new Database_Connection();

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
                                                int.Parse(reader[2].ToString()), decimal.Parse(reader[3].ToString()),
                                                reader[4].ToString(), reader[5].ToString(), reader[6].ToString(),
                                                int.Parse(reader[7].ToString())
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
            string variables = "@PRODUCT_ID;" + prod_id + "-@PURCHASED_AMOUNT;" + amt + "-@USERID;" + user_id;
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

    }
}