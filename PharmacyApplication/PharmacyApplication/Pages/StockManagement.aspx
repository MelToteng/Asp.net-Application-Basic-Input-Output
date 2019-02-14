<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Site.Master" CodeBehind="StockManagement.aspx.cs" Inherits="PharmacyApplication.Pages.StockManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h3>
                <label>Stock Management</label>
            </h3>
        </div>
    </div>
    <div class="row row-padding">
        <div class="col-md-4">
            <div class="row">
                <asp:ListBox ID="ProductList" Height="350px" Width="300px" AutoPostBack="true" BorderStyle="Groove" runat="server" OnSelectedIndexChanged="ProductList_SelectedIndexChanged"></asp:ListBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    <label>Add/Remove Stock</label>
                </div>
            </div>
            <div class="row">
            </div>
            <hr />
            <div class="row row-padding">
                <div class="row row-padding">
                    <div class="col-md-3">Supplier Name:</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="supplier" CssClass="form-control input-sm" />
                    </div>
                </div>
            </div>
            <div class="row row-padding">
                <div class="row row-padding">
                    <div class="col-md-3">Supplier Notes:</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="notes" TextMode="MultiLine" CssClass="form-control input-sm" />
                    </div>
                </div>
            </div>
            <div class="row row-padding">
                <div class="row row-padding">
                    <div class="col-md-3">Quantity:</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="qty" Enabled="false" TextMode="Number" CssClass="form-control input-sm" />
                    </div>
                </div>
            </div>
            <div class="row row-padding">
                <div class="row row-padding">
                    <div class="col-md-3">Quantity to Add/Remove:</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="qtyUpdate" CssClass="form-control input-sm" />
                    </div>
                    <div class="col-md-1">
                        <button class="btn btn-danger" runat="server" onserverclick="remove_stock" title="Remove from Stock" data-toggle="tooltip" data-placement="top"><i class="fa fa-minus-circle"></i></button>
                    </div>
                    <div class="col-md-1">
                        <button class="btn btn-primary" runat="server" onserverclick="add_stock" title="Add to stock" data-toggle="tooltip" data-placement="top"><i class="fa fa-plus-circle"></i></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
