<%@ Page Title="" Language="C#" MasterPageFile="~/Pharmacy.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalTest1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card p-4 shadow-lg" style="width: 300px;">
        <h3 class="text-center">Login</h3>
        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mb-2" Placeholder="Username"></asp:TextBox>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-2" TextMode="Password" Placeholder="Password"></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary w-100" OnClick="btnLogin_Click" />
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-2 d-block"></asp:Label>
    </div>
</asp:Content>
