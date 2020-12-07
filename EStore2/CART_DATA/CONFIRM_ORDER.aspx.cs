using EStore2.Backend;
using EStore2.Backend.Data_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;
using Stripe.Checkout;

namespace EStore2.CART_DATA
{
    public partial class CONFIRM_ORDER : System.Web.UI.Page
    {
        public string sessionId = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["user_id"];//getting the user_id 

            Process_Executor exec = new Process_Executor();

            if (cookie != null)
            {
                List<CART_INFO_SUMMARY> items = exec.get_cart_summary(cookie.Value);

             
                List<SessionLineItemOptions> transactions = new List<SessionLineItemOptions>();

                foreach (CART_INFO_SUMMARY transaction_summary in items) {
                    SessionLineItemOptions item_list = new SessionLineItemOptions
                    {
                        Name = transaction_summary.get_product_name(),
                        Description = transaction_summary.get_prod_desc(),
                        Amount = Convert.ToInt64(decimal.Round(transaction_summary.get_sub_total()).ToString()),
                        Currency = transaction_summary.get_currecy(),
                        Quantity = Convert.ToInt64(transaction_summary.get_quantity().ToString()),
                    };

                    transactions.Add(item_list);
               }

                StripeConfiguration.ApiKey = "sk_test_4eC39HqLyjWDarjtT1zdp7dc";

                var options = new SessionCreateOptions
                {
                    //todo: change routes to a success or failure page (both woudld be nice )
                    //test card numbers cn=an be found at https://stripe.com/docs/testing#cards
                    //also if error occurs remove above link

                    SuccessUrl = "https://localhost:44324/CART_DATA/INSERT_HISTORY.aspx",
                    CancelUrl = "https://localhost:44324/Default.aspx",
                    PaymentMethodTypes = new List<string> { "card", },

                    //line items stores the items that are being checkout to be sent to stripe server
                    LineItems = transactions,
                    Mode = "payment",
                };

                var service = new SessionService();
                Session session = service.Create(options);
                sessionId = session.Id;
            }

          
        }
    }
}