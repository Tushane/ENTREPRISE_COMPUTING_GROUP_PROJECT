<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EStore2.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div style ="display:flex; width:100%">
        <div style ="flex:1">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" 
                    CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>


            <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Username" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Username"
                    CssClass="text-danger" ErrorMessage="The Username field is required." />
            </div>

             <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name:</asp:Label>
            <div class="col-md-10">
                   <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="The First Name field is required." />
            </div>
            <asp:Label runat="server" AssociatedControlID="MiddleName" CssClass="col-md-2 control-label">Middle Name:</asp:Label>
            <div class="col-md-10">
                   <asp:TextBox runat="server" ID="MiddleName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MiddleName"
                    CssClass="text-danger" ErrorMessage="The Middle Name field is required." />
            </div>
             <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last Name:</asp:Label>
            <div class="col-md-10">
                   <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="The Last Name field is required." />
            </div>

            <asp:Label runat="server" AssociatedControlID="PhoneNo" CssClass="col-md-2 control-label">Phone Number:</asp:Label>
            <div class="col-md-10">
                   <asp:TextBox runat="server" ID="PhoneNo" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNo"
                    CssClass="text-danger" ErrorMessage="The Phone Number field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
         </div>
         <div style ="flex:0.5">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Street_No" CssClass="col-md-2 control-label">Street Number:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Street_No" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Street_No"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The Street Number field is required." />
                </div>
            </div>
             <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="City" CssClass="col-md-2 control-label">City:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="City" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="City"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The City field is required." />
                </div>
            </div>
              <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="State_of_Business" CssClass="col-md-2 control-label">State:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="State_of_Business" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="State_of_Business"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The State field is required." />
                </div>
            </div>
               <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Country" CssClass="col-md-2 control-label">Country:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Country" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Country"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The Country field is required." />
                </div>
            </div>

              <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Zip" CssClass="col-md-2 control-label">Zip Code:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Zip" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Zip"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The Zip Code field is required." />
                </div>
            </div>
        </div>
        </div>
       
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
