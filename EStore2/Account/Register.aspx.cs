using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using EStore2.Models;
using EStore2.Backend;

namespace EStore2.Account
{
    public partial class Register : Page
    {

        private static string password;

        protected void CreateUser_Click(object sender, EventArgs e)
        {

            Process_Executor exec = new Process_Executor();

            password = Password.Text;

          string response = exec.User_Creation(Email.Text, Username.Text, FirstName.Text, MiddleName.Text, LastName.Text, PhoneNo.Text, password);

           if (response == "User Creation Sucessful")
            {
                response = exec.User_Address_Insertion
                    (   
                        (FirstName.Text + " " + MiddleName.Text + " " + LastName.Text), Username.Text,  password,
                        Street_No.Text, City.Text, State_of_Business.Text, Country.Text, Zip.Text
                    );

                if (response == "COMPLETED")
                {
                    Response.Redirect("~/Account/Login");
                }
            }

        }
    }
}