<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRefills.aspx.cs" MasterPageFile="Pharmacy.Master" Inherits="FinalTest1.ViewRefills" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>View Refills</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server" class="container my-5">
        <div class="card shadow-lg p-4">
            <h2 class="mb-4 text-center">View Refills</h2>

            <asp:GridView ID="gvRefills" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="REFILLID" HeaderText="Refill ID" ReadOnly="True" />
                    <asp:BoundField DataField="RXNUM" HeaderText="Prescription ID" ReadOnly="True" />
                    <asp:BoundField DataField="REMAININGCOUNT" HeaderText="Remaining Count" />
                    <asp:BoundField DataField="DATEFILLED" HeaderText="Date Filled" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblStatus" runat="server" CssClass="text-danger mt-3 d-block"></asp:Label>
        </div>
    </form>
</asp:Content>

