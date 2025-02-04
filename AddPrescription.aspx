<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPrescription.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.Prescription" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <h1>Add Prescription</h1>
            <table>
                <tr>
                    <td>Patient ID:</td>
                    <td>
                        <asp:DropDownList ID="cbPatientID" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Physician ID:</td>
                    <td>
                        <asp:DropDownList ID="cbPhysicianID" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Medication Name:</td>
                    <td>
                        <asp:TextBox ID="txtMedName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Dosage:</td>
                    <td>
                        <asp:TextBox ID="txtDosage" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Frequency:</td>
                    <td>
                        <asp:TextBox ID="txtFrequency" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Route of Administration:</td>
                    <td>
                        <asp:RadioButton ID="rbOral" runat="server" GroupName="Route" Text="Oral"/>
                        <asp:RadioButton ID="rbTopical" runat="server" GroupName="Route" Text="Topical" />
                        <asp:RadioButton ID="rbInjection" runat="server" GroupName="Route" Text="Injection" />
                    </td>
                </tr>
                <tr>
                    <td>Refill Amount:</td>
                    <td>
                        <asp:TextBox ID="txtRefillAmt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</asp:Content>
