<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinalMainPage.aspx.cs" MasterPageFile ="Pharmacy.Master" Inherits="FinalTest1.FinalMainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">
        <div>
            <h1>Pharmacy Management System</h1>
            <asp:Button ID="btnListPatients" runat="server" Text="Patients" OnClick="btnUpdatePatient_Click" />
            <asp:Button ID="btnListPhysicians" runat="server" Text="Physicians" OnClick="btnUpdatePhysician_Click" />
            <asp:Button ID="btnPrescription" runat="server" Text="Prescriptions" OnClick="btnPrescriptions_Click" />
            <asp:Button ID="btnRefill" runat="server" Text="Refills" OnClick="btnRefill_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
        </div>
    </form>
</asp:Content>
