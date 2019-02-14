<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Site.Master" CodeBehind="AddDrug.aspx.cs" Inherits="PharmacyApplication.Pages.AddDrug" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row row-padding">
        <div class="col-md-6">
            <h3>
                <asp:Label ID="title" Text="Add New Drug" runat="server" /></h3>
        </div>
    </div>
    <div class="row row-padding">
        <div class="col-md-6">
            <div id="AddDrugPanel" class="row row-padding">
                <div class="row row-padding">
                    <div class="col-md-3">Drug Code</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="code" CssClass="form-control input-sm" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="code" ErrorMessage="Drug Code is Required"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row row-padding">
                    <div class="col-md-3">Name</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="name" CssClass="form-control input-sm" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="name" ErrorMessage="Drug Name is required"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row row-padding">
                    <div class="col-md-3">Unitary Price</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="unitPrice" CssClass="form-control input-sm" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="unitPrice" ErrorMessage="Unit Price is Required"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row row-padding">
                    <div class="col-md-3">Bulk Price</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="bulkPrice" CssClass="form-control input-sm" />
                    </div>
                </div>
                <div class="row row-padding">
                    <div class="col-md-3">Expiry Date</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="expDate" CssClass="form-control input-sm" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="expDate" ErrorMessage="Expiry Date is required"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-offset-7">
                        <button runat="server" id="backButton" onserverclick="back_click" causesvalidation="false" class="btn btn-primary" title="Go back" data-toggle="tooltip"><i class="fa fa-backward"></i></button>
                        <button runat="server" id="cancelButton" onserverclick="cancel_click" causesvalidation="false" class="btn btn-primary" title="Cancel Add" data-toggle="tooltip"><i class="fa fa-times-circle-o"></i></button>
                        <button runat="server" onserverclick="save_Click" class="btn btn-success" title="Save Information" data-toggle="tooltip"><i class="fa fa-save"></i></button>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row row-padding" style="color: orangered">
                <asp:ValidationSummary runat="server" HeaderText="There were errors on the page" />
            </div>
        </div>
    </div>


</asp:Content>
