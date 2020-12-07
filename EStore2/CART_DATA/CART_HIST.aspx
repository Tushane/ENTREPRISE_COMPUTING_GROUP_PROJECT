<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CART_HIST.aspx.cs" Inherits="EStore2.CART_DATA.CART_HIST" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />
    <div class="row" style ="display:flex">
        <div style ="flex:1">
            <asp:PlaceHolder ID ="maindiv" runat="server">    </asp:PlaceHolder>
            <div runat="server" id ="error"></div>
        </div>
        <div style ="flex :0.4; background:grey; opacity:0.8; width:100%; color:white">
            <div class="row" style ="display:flex">
                <asp:Label runat="server" CssClass="col-md-2 control-label" style="width:100%; font-size:200%; color:white; display:block">ORDER SUMMARY</asp:Label>
            </div>
            <hr />
            <div style="margin-left:2%; margin-top:2%; width:100%; font-size:120%" >
                 <asp:PlaceHolder ID ="PlaceHolder1" runat="server">    </asp:PlaceHolder>
                <hr />
                <div style="width:160%">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Total_Q" CssClass="col-md-2 control-label" style="width:40%">Total Quantity:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Total_Q" CssClass="form-control" style="width:30%" ReadOnly="true"/>
                        </div>
                    </div>
                    <div class="form-group">
                         <asp:Label runat="server"  AssociatedControlID="Total_Balance" CssClass="col-md-2 control-label" style="width:40%">Total Balance:</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Total_Balance" CssClass="form-control" style="width:30%"  ReadOnly="true"/>
                        </div>
                    </div>
                </div>
                <br />
                <div>
                    <hr />
                    <div>
                        <asp:Button runat="server" type="submit" ID="submit" Text ="CHECK OUT" CssClass="btn btn-default" OnClick="check_out_cart" />
                        <asp:Button runat="server" Text ="CLEAR CART" CssClass="btn btn-default" OnClick="clear_cart"/>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>