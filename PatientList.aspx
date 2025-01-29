<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientList.aspx.cs" Inherits="FinalTest1.PatientList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">Patient List</h2>

            <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-3 d-block"></asp:Label>

            <asp:GridView ID="gvPatients" runat="server" CssClass="table table-striped table-hover"
            AutoGenerateColumns="False" DataKeyNames="PatientID"
            AllowPaging="True" PageSize="10" AllowSorting="True"
            OnPageIndexChanging="gvPatients_PageIndexChanging"
            OnSorting="gvPatients_Sorting">
                
                <Columns>
                    <asp:BoundField DataField="PatientID" HeaderText="Patient ID" SortExpression="PatientID" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />

                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary btn-sm"
                                Text="Edit"
                                OnClick="btnUpdate_Click"
                                CommandArgument='<%# Eval("PatientID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerStyle CssClass="pagination justify-content-center" />
            </asp:GridView>
            <div class="text-center mt-4">
                <asp:Button ID="btnRegisterPatient" runat="server" Text="Register New Patient"
                    CssClass="btn btn-success" OnClick="btnRegisterPatient_Click" />
                <asp:Button ID="btnBackToMain" runat="server" Text="Back to Main Page"
                    CssClass="btn btn-secondary" OnClick="btnBackToMain_Click" />
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>