<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePhysician.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.UpdatePhysician" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Update Physician</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">Update Physician</h2>

            <div class="row g-3">            
                <div class="col-md-6">
                    <label for="txtPhysicianID" class="form-label">Patient ID</label>
                    <asp:TextBox ID="txtPhysicianID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
                    <label for="txtMiddleInitial" class="form-label">Middle Initial</label>
                    <asp:TextBox ID="txtMiddleInitial" runat="server" CssClass="form-control"></asp:TextBox>
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
                    <label for="txtZipCode" class="form-label">Zip Code</label>
                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control"></asp:TextBox>
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
                    <label for="ddlGender" class="form-label">Gender</label>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">Select Gender</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <label for="txtDOB" class="form-label">Date of Birth</label>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtSpecialty1" class="form-label">Specialty 1</label>
                    <asp:TextBox ID="txtSpecialty1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtSpecialty2" class="form-label">Specialty 2</label>
                    <asp:TextBox ID="txtSpecialty2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="text-center mt-4">
                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>

            <asp:Label ID="lblStatus" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
</asp:Content>
