<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="PharmacyApplication.Pages.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row row-padding">
        <div class="col-md-4">
            <h3>Register a new user</h3>
        </div>
    </div>
    <div class="row row-padding">
        <div class="col-md-4">
            <div class="row row-padding">
                <asp:Label runat="server" AssociatedControlID="firstname">Firstname</asp:Label>
                <div>
                    <asp:TextBox runat="server" CssClass="form-control input-sm" ID="firstname" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="firstname" ErrorMessage="Username is Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row row-padding">
                <asp:Label runat="server" AssociatedControlID="lastname">Lastname</asp:Label>
                <div>
                    <asp:TextBox runat="server" CssClass="form-control input-sm" ID="lastname" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="lastname" ErrorMessage="Username is Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row row-padding">
                <asp:Label runat="server" AssociatedControlID="cell">Cell Number</asp:Label>
                <div>
                    <asp:TextBox runat="server" CssClass="form-control input-sm" ID="cell" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="cell" ErrorMessage="Username is Required"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row row-padding">
                <asp:Label runat="server" AssociatedControlID="UserName">User name</asp:Label>
                <div>
                    <asp:TextBox runat="server" CssClass="form-control input-sm" ID="UserName" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="Username is Required"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row row-padding">
                <asp:Label runat="server" AssociatedControlID="Password">Password</asp:Label>
                <div>
                    <asp:TextBox runat="server" ID="Password" CssClass="form-control input-sm" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is Required"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row row-padding">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                <div>
                    <asp:TextBox runat="server" CssClass="form-control input-sm" ID="ConfirmPassword" TextMode="Password" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Password Confirmation is Required"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div>
                <div class="col-md-offset-9">
                    <button runat="server" onserverclick="back_click" causesvalidation="false" class="btn btn-primary" data-toggle="tooltip" title="Back to User List"><i class="fa fa-backward"></i></button>
                    <button runat="server" onserverclick="CreateUser_Click" class="btn btn-success" data-toggle="tooltip" title="Register user"><i class="fa fa-save"></i></button>
                    <%--<asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" />--%>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row row-padding" style="color: orangered">
                <asp:Literal runat="server" ID="StatusMessage" />
            </div>

            <div class="row row-padding" style="color: orangered">
                <asp:ValidationSummary runat="server" HeaderText="There were errors on the page" />
            </div>
        </div>
    </div>
</asp:Content>
