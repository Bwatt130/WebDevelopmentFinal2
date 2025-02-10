<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.PatientList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title>Patient List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container-fluid my-5">
        <div class="card shadow-lg p-4">
            <div class="row justify-content-center">
                <h2 class="mb-4 text-center">Patient List</h2>
                <div class="col-12">
                    <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-3 d-block"></asp:Label>

                    <div class="row mb-4">
                        <div class="col-md-4">
                            <label for="txtPatientID" class="form-label">Patient ID</label>
                            <asp:TextBox ID="txtPatientID" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label for="txtFirstName" class="form-label">First Name</label>
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-4">
                            <label for="txtLastName" class="form-label">Last Name</label>
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="text-center mb-4">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" CausesValidation="False" />
                    </div>
                    
                    <div class="table-responsive">
                        <asp:GridView ID="gvPatients" runat="server" CssClass="table table-striped table-hover text-center"
                        AutoGenerateColumns="False" DataKeyNames="PatientID"
                        AllowPaging="True" PageSize="10" AllowSorting="True"
                        OnPageIndexChanging="gvPatients_PageIndexChanging"
                        OnSorting="gvPatients_Sorting">
                
                            <Columns>
                                <asp:BoundField DataField="PatientID" HeaderText="Patient ID" SortExpression="PatientID" />
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                                <asp:BoundField DataField="MiddleInitial" HeaderText="Middle Initial" SortExpression="MiddleInitial" />
                                <asp:BoundField DataField="DOB" HeaderText="Date of Birth" SortExpression="DOB" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                <asp:BoundField DataField="StreetName" HeaderText="Street Name" SortExpression="StreetName" />
                                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                                <asp:BoundField DataField="State" HeaderText="State" SortExpression="State" />
                                <asp:BoundField DataField="ZipCode" HeaderText="Zip Code" SortExpression="ZipCode" />
                                <asp:BoundField DataField="PrimaryInsurance" HeaderText="Primary Insurance" SortExpression="PrimaryInsurance" />
                                <asp:BoundField DataField="SecondaryInsurance" HeaderText="Secondary Insurance" SortExpression="SecondaryInsurance" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <div class="d-flex justify-content-start gap-2">
                                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary btn-sm"
                                                Text="Edit"
                                                OnClick="btnUpdate_Click"
                                                CommandArgument='<%# Eval("PatientID") %>' />

                                            <asp:Button ID="btnViewPrescriptions" runat="server" CssClass="btn btn-info btn-sm mx-1"
                                                Text="View Prescriptions"
                                                OnClick="btnViewPrescriptions_Click"
                                                CommandArgument='<%# Eval("PatientID") %>' />

                                            <asp:Button ID="btnAddPrescription" runat="server" CssClass="btn btn-success btn-sm"
                                                Text="Add Prescription"
                                                OnClick="btnAddPrescription_Click"
                                                CommandArgument='<%# Eval("PatientID") %>' />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <PagerStyle CssClass="pagination justify-content-center" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="text-center mt-4">
                <asp:Button ID="btnRegisterPatient" runat="server" Text="Register New Patient"
                    CssClass="btn btn-success" OnClick="btnRegisterPatient_Click" />
                <asp:Button ID="btnBackToMain" runat="server" Text="Back to Main Page"
                    CssClass="btn btn-secondary" OnClick="btnBackToMain_Click" />
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
