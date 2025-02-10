<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientRegistration.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.PatientRegistration" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title>Register New Patient</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">Register New Patient</h2>

            <asp:Label ID="lblStatus" runat="server" CssClass="text-danger mb-3 d-block"></asp:Label>

            <div class="row g-3">
                <div class="col-md-6">
                    <label for="txtPatientID" class="form-label">Patient ID</label>
                    <asp:TextBox ID="txtPatientID" runat="server" CssClass="form-control" placeholder="Enter Patient ID" AutoPostBack="true"></asp:TextBox>
                    <asp:Label ID="lblPatientIDError" runat="server" CssClass="text-danger d-block"></asp:Label>
                </div>
                <div class="col-md-6">
                    <label for="txtFirstName" class="form-label">First Name</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Enter First Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                        ErrorMessage="First Name is required." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtLastName" class="form-label">Last Name</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Enter Last Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                        ErrorMessage="Last Name is required." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtMiddleInt" class="form-label">Middle Initial</label>
                    <asp:TextBox ID="txtMiddleInt" runat="server" CssClass="form-control" placeholder="Enter Middle Initial (Optional)"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtDOB" class="form-label">Date of Birth</label>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="YYYY-MM-DD"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
                        ErrorMessage="Date of Birth is required." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtGender" class="form-label">Gender</label>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">Select Gender</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="ddlGender"
                        InitialValue="" ErrorMessage="Please select a gender." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtPhoneNumber" class="form-label">Phone Number</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" placeholder="Enter Phone Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                        InitialValue="" ErrorMessage="Please enter a phone number." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        InitialValue="" ErrorMessage="Please enter an email." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtStreetName" class="form-label">Street Name</label>
                    <asp:TextBox ID="txtStreetName" runat="server" CssClass="form-control" placeholder="Enter Street Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                        ControlToValidate="txtStreetName" ErrorMessage="Street name is required." 
                        CssClass="text-danger" Display="Dynamic" />
                </div>
                <div class="col-md-6">
                    <label for="txtCity" class="form-label">City</label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Enter City"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                        InitialValue="" ErrorMessage="Please enter a city." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="ddlState" class="form-label">State</label>
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                        InitialValue="" ErrorMessage="Please select a state." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtZip" class="form-label">Zip Code</label>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="Enter Zip Code"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip"
                        InitialValue="" ErrorMessage="Please enter a zip code." ForeColor="Red" CssClass="small d-block" />
                </div>
                <div class="col-md-6">
                    <label for="txtPrimaryInsurance" class="form-label">Primary Insurance</label>
                    <asp:TextBox ID="txtPrimaryInsurance" runat="server" CssClass="form-control" placeholder="Enter Primary Insurance (Optional)"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtSecondaryInsurance" class="form-label">Secondary Insurance</label>
                    <asp:TextBox ID="txtSecondaryInsurance" runat="server" CssClass="form-control" placeholder="Enter Secondary Insurance (Optional)"></asp:TextBox>
                </div>
            </div>

            <div class="text-center mt-4">
                <asp:Button ID="btnSubmit" runat="server" Text="Register Patient" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" CausesValidation="False" OnClick="btnCancel_Click" />
            </div>

        </div>
    </form>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
