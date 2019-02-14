<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Dispensary.aspx.cs" Inherits="PharmacyApplication.Pages.Dispensary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <h3>
                <label>Drug Despensary</label>
            </h3>
        </div>
    </div>
    <div class="row row-padding">
        <div class="col-md-4">
            <asp:ListBox ID="ProductList" Height="350px" Width="300px" AutoPostBack="true" BorderStyle="Groove" runat="server"
                OnSelectedIndexChanged="ProductList_SelectedIndexChanged"></asp:ListBox>
        </div>
        <div class="col-md-6">
            <div class="row row-padding">
                <div class="col-md-3">Price Type:</div>
                <div class="col-md-6">
                    <asp:RadioButton Text="Unit Price" ID="UntPrc" GroupName="pricing" runat="server" />&nbsp;&nbsp;
                    <asp:RadioButton Text="Bulk Price" ID="BlkPrc" GroupName="pricing" runat="server" />
                </div>
            </div>
            <div class="row row-padding">
                <div class="col-md-3">Enter Drug Code:</div>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="code" CssClass="form-control input-sm" />
                </div>
                <div class="col-md-1">
                    <button runat="server" onserverclick="SearchClick" class="btn btn-success input-sm" title="search for drug using code" data-toggle="tooltip"><i class="fa fa-search"></i></button>
                </div>
            </div>
            <div class="row row-padding">
                <div class="col-md-3">Total Items:</div>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="totalItems" Enabled="false" CssClass="form-control input-sm" />
                </div>
            </div>
            <div class="row row-padding">
                <div class="col-md-3">Total Cost:</div>
                <div class="col-md-6">
                    <asp:TextBox runat="server" ID="totalCost" Enabled="false" CssClass="form-control input-sm" />
                </div>
            </div>
            <hr />
            <div class="row row-padding">
                <div class="row row-padding">
                    <div class="col-md-3">Amount Paid:</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="amountPaid" CssClass="form-control input-sm" />
                    </div>
                </div>
            </div>
            <div class="row row-padding">
                <div class="col-md-6"></div>
                <div class="col-md-6" style="text-align: right;">
                    <button class="btn btn-danger input-sm" runat="server" onserverclick="CancelPayClick" title="Cancel Payment" data-toggle="tooltip" data-placement="top"><i class="fa fa-stop-circle-o"></i>&nbsp;&nbsp;Cancel</button>
                    <button class="btn btn-primary input-sm" runat="server" onserverclick="PayServerClick" title="Accept Payment" data-toggle="tooltip" data-placement="top"><i class="fa fa-money"></i>&nbsp;&nbsp;Accept</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
