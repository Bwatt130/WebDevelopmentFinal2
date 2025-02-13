<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPrescription.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.Prescription" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Prescription</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">Add Prescription</h2>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block mb-3"></asp:Label>

            <div class="row g-3">
                <div class="col-md-6">
                    <label for="txtPatientID" class="form-label">Patient Name</label>
                    <asp:TextBox ID="txtPatientID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="cbPhysicianID" class="form-label">Physician ID</label>
                    <asp:DropDownList ID="cbPhysicianID" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvPhysicianID" runat="server" ControlToValidate="cbPhysicianID"
                        InitialValue="" ErrorMessage="Physician ID is required." CssClass="text-danger small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtMedName" class="form-label">Medication Name</label>
                    <asp:TextBox ID="txtMedName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMedName" runat="server" ControlToValidate="txtMedName"
                        ErrorMessage="Medication name is required." CssClass="text-danger small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtDosage" class="form-label">Dosage</label>
                    <asp:TextBox ID="txtDosage" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDosage" runat="server" ControlToValidate="txtDosage"
                        ErrorMessage="Dosage is required." CssClass="text-danger small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtFrequency" class="form-label">Frequency</label>
                    <asp:TextBox ID="txtFrequency" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFrequency" runat="server" ControlToValidate="txtFrequency"
                        ErrorMessage="Frequency is required." CssClass="text-danger small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtRoute" class="form-label">Route of Administration (Required)</label>
                    <div class="form-check">
                        <asp:RadioButton ID="rbOral" runat="server" GroupName="Route" Text="Oral" CssClass="form-check-input me-2" />
                    </div>
                    <br />
                    <div class="form-check">
                        <asp:RadioButton ID="rbTopical" runat="server" GroupName="Route" Text="Topical" CssClass="form-check-input me-2" />
                    </div>
                    <br />
                    <div class="form-check">
                        <asp:RadioButton ID="rbInjection" runat="server" GroupName="Route" Text="Injection" CssClass="form-check-input me-2" />
                    </div>
                    <br />
                    <asp:CustomValidator ID="cvRoute" runat="server" ErrorMessage="Route of administration is required."
                        CssClass="text-danger small d-block" OnServerValidate="ValidateRoute"></asp:CustomValidator>
                </div>
                <div class="col-md-6">
                    <label for="txtRefillAmt" class="form-label">Refill Amount</label>
                    <asp:TextBox ID="txtRefillAmt" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRefillAmt" runat="server" ControlToValidate="txtRefillAmt"
                        ErrorMessage="Refill amount is required." CssClass="text-danger small d-block" />
                </div>
            </div>

            <div class="text-center mt-4">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary me-2" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" CausesValidation="false"/>
            </div>
        </div>
    </form>
</asp:Content>