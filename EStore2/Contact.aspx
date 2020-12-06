<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="EStore2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Where to Find US:</h3>

    <%--div class in which the map will be displayed--%>
   <div id="map"></div>

    <%--java script that handles the configuring of the map--%>
    <script>
        // Initialize and add the map
        function initMap() {
          // The location of Uluru
          var uluru = {lat: 18.0182, lng: -76.7441};
          // The map, centered at Uluru
          var map = new google.maps.Map(
              document.getElementById('map'), {zoom: 10, center: uluru});
          // The marker, positioned at Uluru
          var marker = new google.maps.Marker({position: uluru, map: map});
        }
    </script>
 
    <%--javascript that handles map location rendering--%>
    <script defer
    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBf4uB4jfi4hjUStU5_BMIJKeu9xzkhEek&callback=initMap">
    </script>
   

    <address>
        <h4>OFFICE LOCATION:</h4>
        EStore<br />
        237 W.I, 6 Old Hope Rd,
        <br />Kingston<br />
        <abbr title="Phone">Phone Number:</abbr>
        876-983-2321
        <br />
        <abbr title="Email">Email Address:</abbr>
        enquiry@estore.com
    </address>

    <address>
        <strong>Marketing:</strong> <a href="mailto:marketing@estore.com">marketing@estore.com</a>
    </address>
</asp:Content>
