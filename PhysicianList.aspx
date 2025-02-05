<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicianList.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.PhysicianList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <title>Physician List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">Physician List</h2>

            <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-3 d-block"></asp:Label>

            <asp:GridView ID="gvPhysicians" runat="server" CssClass="table table-striped table-hover" 
                AutoGenerateColumns="False" DataKeyNames="PhysicianID"
                AllowPaging="True" PageSize="10" AllowSorting="True" 
                OnPageIndexChanging="gvPhysicians_PageIndexChanging" 
                OnRowCommand="gvPhysicians_RowCommand" OnSorting="gvPhysicians_Sorting">
            
                    <Columns>
                        <asp:BoundField DataField="PhysicianID" HeaderText="Physician ID" ReadOnly="True" SortExpression="PhysicianID"/>
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName"/>
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName"/>
                        <asp:BoundField DataField="DOB" HeaderText="Date of Birth" SortExpression="DOB"/>
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber"/>
                        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"/>
                        <asp:BoundField DataField="Specialty1" HeaderText="Specialty 1" SortExpression="SpecialtyOne"/>
                        <asp:BoundField DataField="Specialty2" HeaderText="Specialty 2" SortExpression="SpecialtyTwo"/>

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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

