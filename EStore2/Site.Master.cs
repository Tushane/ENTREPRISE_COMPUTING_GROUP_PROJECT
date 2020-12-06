using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using EStore2.Backend;
using Microsoft.AspNet.Identity;

namespace EStore2
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["user_id"];//getting the user_id 

            //checking if the cookie exists and if it doesn't to create it 
            if (cookie == null) {

                Unnamed_LoggingOut();

                //creating a default user id 
                cookie = new HttpCookie("user_id");
                cookie.Value = "0";
                cookie.Expires = DateTime.Now.AddDays(1);
                // cookie.Path = Request.ApplicationPath;
                Response.Cookies.Add(cookie);

            }

            if (cookie.Value == "0")
            {
                cart.Visible = false;
                carts.HRef = "";
                cart_amount.HRef = "";
               
            }else
            {
                Process_Executor exec = new Process_Executor();
                cart.Visible = true;
                carts.HRef = "~/CART_DATA/CART_INFO.aspx";
                cart_amount.HRef = "~/CART_DATA/CART_INFO.aspx";
                user.InnerText = "Hello, " + exec.get_user_name(cookie.Value);
                login_state.Visible = true;
                logout_state.Visible = false;
            }
        }

        private void Unnamed_LoggingOut()
        {
            logout_state.Visible = true;
            login_state.Visible = false;
         //   Response.Cookies["user_id"].Expires = DateTime.Now.AddDays(-1);
        }
    }

}