<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinalMainPage.aspx.cs" Inherits="FinalTest1.FinalMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pharmacy System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Pharmacy Management System</h1>
            <asp:Button ID="btnPatientRegistration" runat="server" Text="Patient Registration" OnClick="btnPatientRegistration_Click" />
            <asp:Button ID="btnListPatients" runat="server" Text="Patients" OnClick="btnUpdatePatient_Click" />
            <asp:Button ID="btnPhysicianRegistration" runat="server" Text="Physician Registration" OnClick="btnPhysicianRegistration_Click" />
            <asp:Button ID="btnUpdatePhysician" runat="server" Text="Update Physician" OnClick="btnUpdatePhysician_Click" />
            <!--We still need a way to modify / delete / view prescriptions-->
            <asp:Button ID="btnPrescription" runat="server" Text="Add Prescription" OnClick="btnPrescription_Click" />
            <asp:Button ID="btnPrescriptionRefill" runat="server" Text="Prescription Refill" OnClick="btnPrescriptionRefill_Click" />
            <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
        </div>
    </form>
</body>
</html>