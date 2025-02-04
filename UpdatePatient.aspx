<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePatient.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.UpdatePatient" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Update Patient Information</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">Update Patient Information</h2>
            <div class="row g-3">
                <div class="col-md-6">
                    <label for="txtPatientID" class="form-label">Patient ID</label>
                    <asp:TextBox ID="txtPatientID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtFirstName" class="form-label">First Name</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtLastName" class="form-label">Last Name</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtMiddleInt" class="form-label">Middle Initial</label>
                    <asp:TextBox ID="txtMiddleInt" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtDOB" class="form-label">Date of Birth</label>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="YYYY-MM-DD"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtGender" class="form-label">Gender</label>
                    <asp:TextBox ID="txtGender" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtPhoneNumber" class="form-label">Phone Number</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtStreetName" class="form-label">Street Name</label>
                    <asp:TextBox ID="txtStreetName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtCity" class="form-label">City</label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="ddlState" class="form-label">State</label>
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                        InitialValue="" ErrorMessage="Please select a state." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtZip" class="form-label">Zip Code</label>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtPrimaryInsurance" class="form-label">Primary Insurance</label>
                    <asp:TextBox ID="txtPrimaryInsurance" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtSecondaryInsurance" class="form-label">Secondary Insurance</label>
                    <asp:TextBox ID="txtSecondaryInsurance" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="text-center mt-4">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-danger" OnClick="btnClose_Click" />
            </div>
            <asp:Label ID="lblStatus" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

