<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPrescription.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.EditPrescription" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title>Edit Prescription</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">Edit Prescription</h2>

            <asp:HiddenField ID="hfRXNum" runat="server" />

            <div class="row g-3">
                <div class="col-md-6">
                    <label for="txtDosage" class="form-label">Dosage</label>
                    <asp:TextBox ID="txtDosage" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtFrequency" class="form-label">Frequency</label>
                    <asp:TextBox ID="txtFrequency" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtPrescriptionDate" class="form-label">Prescription Date</label>
                    <asp:TextBox ID="txtPrescriptionDate" runat="server" CssClass="form-control" Placeholder="YYYY-MM-DD"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtAdministrationRoute" class="form-label">Administration Route</label>
                    <asp:TextBox ID="txtAdministrationRoute" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtRefillCount" class="form-label">Refill Count</label>
                    <asp:TextBox ID="txtRefillCount" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="text-center mt-4">
                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>

            <asp:Label ID="lblStatus" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
</asp:Content>

