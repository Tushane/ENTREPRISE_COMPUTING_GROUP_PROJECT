<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="CONFIRM_ORDER.aspx.cs" Inherits="EStore2.CART_DATA.CONFIRM_ORDER" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <div class="row" style ="display:flex">
         <asp:PlaceHolder ID ="maindiv" runat="server">    </asp:PlaceHolder>
    </div>
     <br />
    <div class="row" style ="display:flex">
          <asp:PlaceHolder ID ="PlaceHolder1" runat="server">    </asp:PlaceHolder>
    </div>
     <br />
    <br />
     <asp:Button runat="server" Text ="CONFIRMS ORDER" CssClass="btn btn-default" />
</asp:Content>