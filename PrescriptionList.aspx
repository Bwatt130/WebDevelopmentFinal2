<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrescriptionList.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.PrescriptionList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Prescription List</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">Prescription List</h2>

            <asp:GridView ID="gvPrescriptions" runat="server" AutoGenerateColumns="False" DataKeyNames="RXNum"
                CssClass="table table-bordered" AllowSorting="True" OnSorting="gvPrescriptions_Sorting"
                OnRowCommand="gvPrescriptions_RowCommand">
                <Columns>
                    <asp:BoundField DataField="RXNum" HeaderText="RX Number" SortExpression="RXNum" ReadOnly="True" />
                    <asp:BoundField DataField="PatientID" HeaderText="Patient ID" SortExpression="PatientID" />
                    <asp:BoundField DataField="PhysicianID" HeaderText="Physician ID" SortExpression="PhysicianID" />
                    <asp:BoundField DataField="MedicationName" HeaderText="Medication Name" SortExpression="MedicationName" />
                    <asp:BoundField DataField="Dosage" HeaderText="Dosage" SortExpression="Dosage" />
                    <asp:BoundField DataField="Frequency" HeaderText="Frequency" SortExpression="Frequency" />
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="Date Prescribed" SortExpression="PrescriptionDate" />
                    <asp:BoundField DataField="REFILLCOUNT" HeaderText="Refill Count" SortExpression="REFILLCOUNT" />

                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning btn-sm"
                                CommandName="EditPrescription" CommandArgument='<%# Eval("RXNum") %>' />
                            <asp:Button ID="btnViewRefills" runat="server" Text="View Refills" CssClass="btn btn-info btn-sm"
                                CommandName="ViewRefills" CommandArgument='<%# Eval("RXNum") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="text-center mt-4">
                <asp:Button ID="btnUpdate" runat="server" Text="Add Prescription" CssClass="btn btn-primary" OnClick="btnAddPrescription_Click" />
                <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-danger" OnClick="btnClose_Click" />
            </div>

            <asp:Label ID="lblStatus" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
</asp:Content>
