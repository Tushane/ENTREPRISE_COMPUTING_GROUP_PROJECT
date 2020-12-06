using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using EStore2.Models;
using EStore2.Backend;

namespace EStore2.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //    RegisterHyperLink.NavigateUrl = "Register";
        //    // Enable this once you have account confirmation enabled for password reset functionality
        //    //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
        //    OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
        //    var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        //    if (!String.IsNullOrEmpty(returnUrl))
        //    {
        //        RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
        //    }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            Process_Executor exec = new Process_Executor();

            if (username.Text != null)
            {
               if (Password.Text != null)
                {
                    string response = exec.log_in(username.Text, Password.Text);

                    if (response.Contains("error"))
                    {
                        string[] res = response.Split(':');

                        FailureText.Text = res[1];
                    }else
                    {
                        Response.Cookies["user_id"].Value = response;
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    FailureText.Text = "Please Enter a Password";
                }
            }
            else
            {
                FailureText.Text = "Please Enter a Username";
            }
        }
    }
}