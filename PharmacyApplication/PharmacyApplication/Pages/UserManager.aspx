<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="PharmacyApplication.Pages.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="row row-padding">
        <div class="col-md-4">
            <h3>
                <label for="PrdouctList">All Users</label>
            </h3>
        </div>
    </div>
    <div class="row row-padding">
        <div class="col-md-4">
            <div class="row">
                <asp:ListBox ID="UsersList" Height="350px" Width="300px" BorderStyle="Groove" runat="server"></asp:ListBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-2">
                    <label>Actions</label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <button class="btn btn-primary" runat="server" onserverclick="add_Click" title="Add new User" data-toggle="tooltip" data-placement="top"><i class="fa fa-plus-circle"></i></button>
                </div>
                <div class="col-md-1">
                    <button class="btn btn-danger" runat="server" onserverclick="delete_Click" title="Delete User" data-toggle="tooltip" data-placement="top"><i class="fa fa-trash-o"></i></button>
                </div>
            </div>
            <hr />
            
        </div>
    </div>
</asp:Content>
