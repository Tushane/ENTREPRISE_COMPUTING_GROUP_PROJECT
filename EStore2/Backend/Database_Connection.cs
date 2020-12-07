using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EStore2.Backend
{
    public class Database_Connection
    {

        private string AdminConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=ESTORE_DATABASE;User ID=admin;Password=admin";
        private string Non_Admin_Con = "Data Source=.\\SQLEXPRESS;Initial Catalog=ESTORE_DATABASE;User ID=normal_user;Password=normal_user";
        private string Non_login_Con = "Data Source=.\\SQLEXPRESS;Initial Catalog=ESTORE_DATABASE;User ID=new_def_user;Password=new_def_user";

        SqlConnection con;
       
        //create an instant of the connection string 
        private SqlConnection Connection(string serverName)
        {
            return new SqlConnection(serverName);

        }

        //procedure executor determines what access a user should get
        public string ExecuteProcedure(string prod_name, string variables, string user_id)
        {
            SqlCommand cmd = Get_Sql_Command(prod_name, variables.Split('-'));
            this.con = UserType(user_id);
            this.con.Open();
            cmd.Connection = con;

            SqlParameter outPutParameter = new SqlParameter();
            outPutParameter.ParameterName = "@responseMessage";
            outPutParameter.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter.Size = 100;
            outPutParameter.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outPutParameter);

            cmd.ExecuteNonQuery();
            string results = outPutParameter.Value.ToString();

            closeSqlData();

            return results;

        }

        //generic procedure executor
        public string ExecuteProcedure(string prod_name, string variables)
        {
            SqlCommand cmd = Get_Sql_Command(prod_name, variables.Split('-'));
            this.con = Connection(Non_login_Con);
            this.con.Open();
            cmd.Connection = con;

            SqlParameter outPutParameter = new SqlParameter();
            outPutParameter.ParameterName = "@responseMessage";
            outPutParameter.SqlDbType = System.Data.SqlDbType.VarChar;
            outPutParameter.Size = 100;
            outPutParameter.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outPutParameter);

            cmd.ExecuteNonQuery();
            string results = outPutParameter.Value.ToString();

            closeSqlData();

            return results;

        }

        //query executor that executes queries based on the user type
        public SqlDataReader ExecuteQueries(string data, string user_id)
        {
            this.con = UserType(user_id);

            con.Open();
            SqlCommand cmd = new SqlCommand(data, con);

            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        //generic query exector 
        public SqlDataReader ExecuteQueries(string data)
        {
            this.con = Connection(Non_login_Con);

            con.Open();
            SqlCommand cmd = new SqlCommand(data, con);

            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        //function that closes the overall connection
        public void closeSqlData()
        {
            this.con.Close();
        }

        //function that put together the command so that it can be executed
        private SqlCommand Get_Sql_Command(string prod_name, string[] variable_list)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = prod_name;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (string variable in variable_list)
            {
                string[] var = variable.Split(';');
                cmd.Parameters.AddWithValue(var[0], var[1].Replace(':', '-'));
            }

            return cmd;
        }

        //deciding factor for what privilege a user should when connecting to the database
        private SqlConnection UserType(string user_id)
        {
            string prod_name = "Get_User_Type";
            string variable = "@user_id;" + user_id;

           string response = ExecuteProcedure(prod_name, variable);

            SqlConnection con_i;

            if (response == "ADMIN")
            {
                con_i = Connection(AdminConnection);
            }else
            {
                con_i = Connection(Non_Admin_Con);
            }

            return con_i;
        }


        //function that handles getting the user type 
        public string get_user_type(string user_id)
        {
            string prod_name = "Get_User_Type";
            string variable = "@user_id;" + user_id;

            string response = ExecuteProcedure(prod_name, variable);

            return response;
        }

    }
}