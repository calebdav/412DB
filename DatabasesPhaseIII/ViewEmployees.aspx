<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="HumanResources.ViewEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server">
            <Items>
                <asp:MenuItem NavigateUrl="~/ManagerPage.aspx" Text="Manager Welcome Page" Value="Manager Welcome Page"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewUnapprovedTimesheets.aspx" Text="View Unapproved Timesheets" Value="View Unapproved Timesheets"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewProjects.aspx" Text="View Projects" Value="View Projects"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewSpecialReports.aspx" Text="View Special Reports" Value="View Special Reports"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LoginPage.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        Employees:<br />
        ID&nbsp;&nbsp;&nbsp; First&nbsp;&nbsp;&nbsp; Last&nbsp;&nbsp;&nbsp; Role&nbsp;&nbsp;&nbsp; Address&nbsp;&nbsp;&nbsp; City&nbsp;&nbsp;&nbsp; State&nbsp;&nbsp;&nbsp; Zip&nbsp;&nbsp;&nbsp; Team ID&nbsp;&nbsp;&nbsp; Wage<br />
        <asp:ListBox ID="EmployeeListBox" runat="server"></asp:ListBox>
        <br />
        <asp:Button ID="FireButton" runat="server" OnClick="FireButton_Click" Text="Fire Employee" style="height: 26px" />
        <br />
        <br />
        Teams:<br />
        ID&nbsp;&nbsp;&nbsp; Name<br />
        <asp:ListBox ID="TeamListBox" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
        <br />
        <asp:Button ID="ReassignButton" runat="server" OnClick="ReassignButton_Click" Text="Reassign Team" />
    
        <br />
        <asp:Label ID="StatusLabel" runat="server" style="font-weight: 700"></asp:Label>
    
    </div>
    </form>
</body>
</html>
