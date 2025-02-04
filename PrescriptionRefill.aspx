<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrescriptionRefill.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.PrescriptionRefill" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Prescription Refill</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <h1>Prescription Refill</h1>

            <asp:Label ID="lblRXNumber" runat="server" Text="Select RX Number: "></asp:Label>
            <asp:DropDownList ID="cboRX" runat="server"></asp:DropDownList>
            <br /><br />

            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            <asp:Button ID="btnAddRefill" runat="server" Text="Add Refill" OnClick="btnAddRefill_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Refill" OnClick="btnDelete_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
            <br /><br />

            <asp:GridView ID="dgvPrescriptions" runat="server" AutoGenerateColumns="True" Visible="False"
                CssClass="grid-view">
            </asp:GridView>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</asp:Content>
