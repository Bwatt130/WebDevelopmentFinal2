<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicianList.aspx.cs" Inherits="FinalTest1.PhysicianList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Physician List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container my-5">
    <div class="card shadow-lg p-4">
        <h2 class="mb-4 text-center">Patient List</h2>

        <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-3 d-block"></asp:Label>

        <asp:GridView ID="gvPhysicians" runat="server" AutoGenerateColumns="False" DataKeyNames="PhysicianID"
            CssClass="table table-bordered" OnRowCommand="gvPhysicians_RowCommand">
            
            <Columns>
                <asp:BoundField DataField="PhysicianID" HeaderText="Physician ID" ReadOnly="True" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="DOB" HeaderText="Date of Birth" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Specialty1" HeaderText="Specialty 1" />
                <asp:BoundField DataField="Specialty2" HeaderText="Specialty 2" />

                <!-- Edit Button -->
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm"
                            CommandName="EditPhysician" CommandArgument='<%# Eval("PhysicianID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <PagerStyle CssClass="pagination justify-content-center" />
        </asp:GridView>
        <div class="text-center mt-4">
            <asp:Button ID="btnRegisterNew" runat="server" Text="Register New Physician" CssClass="btn btn-success"
                OnClick="btnRegisterNew_Click" />
            <asp:Button ID="btnBackToMain" runat="server" Text="Back to Main Page"
                CssClass="btn btn-secondary" OnClick="btnBackToMain_Click" />
        </div>
    </div>
</form>
</body>
</html>
