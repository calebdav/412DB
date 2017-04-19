<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProjects.aspx.cs" Inherits="HumanResources.ViewProjects" %>

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
                <asp:MenuItem NavigateUrl="~/ViewEmployees.aspx" Text="View Employees" Value="View Employees"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/ViewSpecialReports.aspx" Text="View Special Reports" Value="View Special Reports"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LoginPage.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        ID&nbsp;&nbsp;&nbsp; Name&nbsp;&nbsp;&nbsp; Cost&nbsp;&nbsp;&nbsp; % Completed&nbsp;&nbsp;&nbsp; Estimated Completion&nbsp;&nbsp;&nbsp; Start&nbsp;&nbsp;&nbsp; Completion<br />
        <asp:ListBox ID="ProjectListBox" runat="server" Width="882px"></asp:ListBox>
        <br />
        <asp:Button ID="TerminateButton" runat="server" OnClick="TerminateButton_Click" Text="Terminate" />
    
        <br />
        <asp:Label ID="StatusLabel" runat="server" style="font-weight: 700"></asp:Label>
    
    </div>
    </form>
</body>
</html>
