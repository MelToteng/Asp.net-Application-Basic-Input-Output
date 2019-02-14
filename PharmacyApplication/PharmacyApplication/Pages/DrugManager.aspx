<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="DrugManager.aspx.cs" Inherits="PharmacyApplication.Pages.DrugManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row row-padding">
        <div class="col-md-4">
            <h3>
                <label for="PrdouctList">All Drugs</label>
            </h3>
        </div>
    </div>
    <div class="row row-padding">
        <div class="col-md-4">
            <div class="row">
                <asp:ListBox ID="ProductList" Height="350px" Width="300px" BorderStyle="Groove" runat="server" OnSelectedIndexChanged="ProductList_SelectedIndexChanged"></asp:ListBox>
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
                    <button class="btn btn-primary" runat="server" onserverclick="add_Click" title="Add new Drug" data-toggle="tooltip" data-placement="top"><i class="fa fa-plus-circle"></i></button>
                </div>
                <div class="col-md-1">
                    <button class="btn btn-primary" runat="server" onserverclick="edit_Click" title="Edit Drug" data-toggle="tooltip" data-placement="top"><i class="fa fa-pencil-square-o"></i></button>
                </div>
                <div class="col-md-1">
                    <button class="btn btn-danger" runat="server" onserverclick="delete_Click" title="Delete Drug" data-toggle="tooltip" data-placement="top"><i class="fa fa-trash-o"></i></button>
                </div>
            </div>
            <hr />
            <div id="AddDrugPanel" class="row row-padding" style="visibility: hidden">
                <div class="row row-padding">
                    <div class="col-md-3">Drug Code</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="code" CssClass="form-control input-sm" />
                    </div>
                </div>
                <div class="row row-padding">
                    <div class="col-md-3">Name</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="name" CssClass="form-control input-sm" />
                    </div>
                </div>
                <div class="row row-padding">
                    <div class="col-md-3">Unitary Price</div>
                    <div class="col-md-6">
                        <asp:TextBox runat="server" ID="unitPrice" CssClass="form-control input-sm" />
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
                    </div>
                    <script type="text/javascript">
                        $(document).ready(function () {
                            $(function () {
                                $("#expDate").datepicker();
                            });
                        });
                    </script>
                </div>
                <div class="row">
                    <div class="col-md-offset-7">
                        <button runat="server" onserverclick="cancel_click" class="btn btn-primary" title="Cancel Add" data-toggle="tooltip"><i class="fa fa-times-circle-o"></i></button>
                        <button runat="server" onserverclick="save_Click" class="btn btn-success" title="Save Information" data-toggle="tooltip"><i class="fa fa-save"></i></button>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
