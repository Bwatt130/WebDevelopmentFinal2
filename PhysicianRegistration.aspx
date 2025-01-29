<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicianRegistration.aspx.cs" Inherits="FinalTest1.PhysicianRegistration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Physician Registration</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">Physician Registration</h2>
            <div class="row g-3">
                <div class="col-md-6">
                    <label for="txtPhysicianCode" class="form-label">Physician Code</label>
                    <asp:TextBox ID="txtPhysicianCode" runat="server" CssClass="form-control" placeholder="Enter physician code"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtFirstName" class="form-label">First Name</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Enter first name"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtLastName" class="form-label">Last Name</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Enter last name"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtMiddleInitial" class="form-label">Middle Initial</label>
                    <asp:TextBox ID="txtMiddleInitial" runat="server" CssClass="form-control" placeholder="Enter middle initial"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtDOB" class="form-label">Date of Birth</label>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="YYYY-MM-DD"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtGender" class="form-label">Gender</label>
                    <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" placeholder="Enter gender"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtPhoneNumber" class="form-label">Phone Number</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" placeholder="Enter phone number"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber" 
                        ValidationExpression="^\(\d{3}\)\s\d{3}-\d{4}$" ErrorMessage="Phone number must be in the format (123) 456-7890." ForeColor="Red" />
                </div>
                <div class="col-md-6">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" 
                        ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ErrorMessage="Invalid email format." ForeColor="Red" />
                </div>
                <div class="col-md-6">
                </div>
                <div class="col-md-6">
                    <label for="txtStreetName" class="form-label">Street Name</label>
                    <asp:TextBox ID="txtStreetName" runat="server" CssClass="form-control" placeholder="Enter street name"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtCity" class="form-label">City</label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Enter city"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtState" class="form-label">State</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="col-md-6">
                    <label for="txtZip" class="form-label">Zip Code</label>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="Enter zip code"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtSpecialty1" class="form-label">Specialty 1</label>
                    <asp:TextBox ID="txtSpecialty1" runat="server" CssClass="form-control" placeholder="Enter first specialty"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtSpecialty2" class="form-label">Specialty 2</label>
                    <asp:TextBox ID="txtSpecialty2" runat="server" CssClass="form-control" placeholder="Enter second specialty"></asp:TextBox>
                </div>
            </div>
            <div class="text-center mt-4">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-danger" OnClick="btnClose_Click" />
            </div>
            <asp:Label ID="lblStatus" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>