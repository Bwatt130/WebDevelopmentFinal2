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
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Enter first name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                        ErrorMessage="First Name is required." ForeColor="Red" CssClass="small d-block"/>
                    <asp:RegularExpressionValidator ID="revFirstName" runat="server" ControlToValidate="txtFirstName"
                        ValidationExpression="^[A-Za-z\s]{1,50}$" ErrorMessage="First Name must be 1-50 alphabetic characters."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>
                <div class="col-md-6">
                    <label for="txtLastName" class="form-label">Last Name</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Enter last name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                        ErrorMessage="Last Name is required." ForeColor="Red" CssClass="small d-block"/>
                    <asp:RegularExpressionValidator ID="revLastName" runat="server" ControlToValidate="txtLastName"
                        ValidationExpression="^[A-Za-z\s]{1,50}$" ErrorMessage="Last Name must be 1-50 alphabetic characters."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>

                <div class="col-md-6">
                    <label for="txtMiddleInt" class="form-label">Middle Initial</label>
                    <asp:TextBox ID="txtMiddleInt" runat="server" CssClass="form-control" placeholder="Enter middle initial (Optional)"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revMiddleInt" runat="server" ControlToValidate="txtMiddleInt"
                        ValidationExpression="^[A-Za-z]?$" ErrorMessage="Middle Initial must be a single letter if provided."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>

                <div class="col-md-6">
                    <label for="txtDOB" class="form-label">Date of Birth</label>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" placeholder="YYYY-MM-DD"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
                        ErrorMessage="Date of Birth is required." ForeColor="Red" CssClass="small d-block"/>
                    <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
                        ValidationExpression="^\d{4}-\d{2}-\d{2}$" ErrorMessage="Date of Birth must be in YYYY-MM-DD format."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>

                <div class="col-md-6">
                    <label for="txtGender" class="form-label">Gender</label>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                        <asp:ListItem Value="">Select Gender</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="ddlGender"
                        ErrorMessage="Gender is required." ForeColor="Red" CssClass="small d-block" />
                </div>

                <div class="col-md-6">
                    <label for="txtPhoneNumber" class="form-label">Phone Number</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" placeholder="XXX-XXX-XXXX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                        ErrorMessage="Phone Number is required." ForeColor="Red" CssClass="small d-block"/>
                    <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                        ValidationExpression="^\d{3}-\d{3}-\d{4}$" ErrorMessage="Phone number must be in XXX-XXX-XXXX format."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>

                <div class="col-md-6">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Email is required." ForeColor="Red" CssClass="small d-block"  EnableClientScript="true"/>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Email must be in xx@xxx.xx format." 
                        ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ForeColor="Red" CssClass="small d-block" />
                </div>

                <div class="col-md-6">
                    <label for="txtStreetName" class="form-label">Street Name</label>
                    <asp:TextBox ID="txtStreetName" runat="server" CssClass="form-control" placeholder="Enter street name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvStreetName" runat="server" ControlToValidate="txtStreetName"
                        ErrorMessage="Street Name is required." ForeColor="Red" CssClass="small d-block"/>
                    <asp:RegularExpressionValidator ID="revStreetName" runat="server" ControlToValidate="txtStreetName"
                        ValidationExpression="^.{1,100}$" ErrorMessage="Street Name must be between 1-100 characters."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>

                <div class="col-md-6">
                    <label for="txtCity" class="form-label">City</label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Enter city"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                        ErrorMessage="City is required." ForeColor="Red" CssClass="small d-block"/>
                    <asp:RegularExpressionValidator ID="revCity" runat="server" ControlToValidate="txtCity"
                        ValidationExpression="^.{1,50}$" ErrorMessage="City must be between 1-50 characters."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>

                <div class="col-md-6">
                    <label for="ddlState" class="form-label">State</label>
                    <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control"/>
                    <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                        InitialValue="" ErrorMessage="Please select a state." ForeColor="Red" CssClass="small d-block" />
                </div>

                <div class="col-md-6">
                    <label for="txtZip" class="form-label">Zip Code</label>
                    <asp:TextBox ID="txtZip" runat="server" CssClass="form-control" placeholder="Enter zip code"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" ControlToValidate="txtZip"
                        ErrorMessage="Zip Code is required." ForeColor="Red" CssClass="small d-block"/>
                    <asp:RegularExpressionValidator ID="revZipCode" runat="server" ControlToValidate="txtZip"
                        ValidationExpression="^\d{5}$" ErrorMessage="Zip Code must be exactly 5 digits."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>
                <div class="col-md-6">
                    <label for="txtPrimaryInsurance" class="form-label">Primary Insurance</label>
                    <asp:TextBox ID="txtPrimaryInsurance" runat="server" CssClass="form-control" placeholder="Enter Primary Insurance (Optional)"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPrimaryInsurance" runat="server" ControlToValidate="txtPrimaryInsurance"
                        ValidationExpression="^.{0,50}$" ErrorMessage="Primary insurance must be up to 50 characters long if provided."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>
                <div class="col-md-6">
                    <label for="txtSecondaryInsurance" class="form-label">Secondary Insurance</label>
                    <asp:TextBox ID="txtSecondaryInsurance" runat="server" CssClass="form-control" placeholder="Enter Secondary Insurance (Optional)"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revSecondaryInsurance" runat="server" ControlToValidate="txtSecondaryInsurance"
                        ValidationExpression="^.{0,50}$" ErrorMessage="Second insurance must be up to 50 characters long if provided."
                        ForeColor="Red" CssClass="small d-block"/>
                </div>
            </div>
            <div class="text-center mt-4">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-danger" OnClick="btnClose_Click"  CausesValidation="False"/>
            </div>
            <asp:Label ID="lblStatus" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

