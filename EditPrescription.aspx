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
                    <asp:RequiredFieldValidator ID="rfvDosage" runat="server" ControlToValidate="txtDosage" ErrorMessage="Dosage is required." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtFrequency" class="form-label">Frequency</label>
                    <asp:TextBox ID="txtFrequency" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFrequency" runat="server" ControlToValidate="txtFrequency" ErrorMessage="Frequency is required." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtMedicationName" class="form-label">Medication Name</label>
                    <asp:TextBox ID="txtMedicationName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMedicationName" runat="server" ControlToValidate="txtMedicationName" ErrorMessage="Medication name is required." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtPrescriptionDate" class="form-label">Prescription Date</label>
                    <asp:TextBox ID="txtPrescriptionDate" runat="server" CssClass="form-control" Placeholder="YYYY-MM-DD"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPrescriptionDate" runat="server" ControlToValidate="txtPrescriptionDate" ErrorMessage="Prescription date is required." ForeColor="Red" CssClass="small d-block" />
                    <asp:RegularExpressionValidator ID="revPrescriptionDate" runat="server" ControlToValidate="txtPrescriptionDate" ValidationExpression="\d{4}-\d{2}-\d{2}" ErrorMessage="Date must be in YYYY-MM-DD format." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="ddlAdministrationRoute" class="form-label">Administration Route</label>
                    <asp:DropDownList ID="ddlAdministrationRoute" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select Administration Route" Value="" />
                        <asp:ListItem Text="Oral" Value="Oral" />
                        <asp:ListItem Text="Topical" Value="Topical" />
                        <asp:ListItem Text="Injection" Value="Injection" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvAdministrationRoute" runat="server" ControlToValidate="ddlAdministrationRoute" InitialValue="" ErrorMessage="Please select an administration route." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtRefillCount" class="form-label">Refill Count</label>
                    <asp:TextBox ID="txtRefillCount" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRefillCount" runat="server" ControlToValidate="txtRefillCount" ErrorMessage="Refill count is required." ForeColor="Red" CssClass="small d-block" />
                    <asp:RangeValidator ID="rvRefillCount" runat="server" ControlToValidate="txtRefillCount" MinimumValue="0" MaximumValue="300" Type="Integer" ErrorMessage="Refill count must be between 0 and 300." ForeColor="Red" CssClass="small d-block" />
                </div>
            </div>

            <div class="text-center mt-4">
                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" CausesValidation="false" />
            </div>

            <asp:Label ID="lblStatus" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
</asp:Content>

