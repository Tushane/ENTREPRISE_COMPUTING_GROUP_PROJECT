<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CONFIRM_ORDER.aspx.cs" Inherits="EStore2.CART_DATA.CONFIRM_ORDER" %>

<!DOCTYPE html>
<html>
<head runat="server">
<title>Default</title>
</head>
<body>
    <!--random checkout button to test checkout-->
<form id="form1" runat="server" style="margin-top:20%">
<div>
 <center> <h4> WELCOME TO ESTORE PAYMENT PORTAL</h4> </center>
</div>
<center><button type="submit" class="btn btn-default" >COMFIRM ORDERS</button></center>
    <br />
<center><a href="~/CART_DATA/CART_INFO.aspx" runat="server" class="button">RETURN TO CHECKOUT</a></center>
</form>
<script src="https://js.stripe.com/v3/"></script>

<script>
    // public key for stripe server
    var stripe = Stripe('pk_test_TYooMQauvdEDq54NiTphI7jx');

var form = document.getElementById('form1');
form.addEventListener('submit', function(e) {
    e.preventDefault();
    stripe.redirectToCheckout({
        sessionId: "<%= sessionId %>"
    });
    })
</script>
</body>
</html>