<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTimesheets.aspx.cs" Inherits="HumanResources.ViewEmployeeTimesheets" %>

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
                <asp:MenuItem NavigateUrl="~/EmployeePage.aspx" Text="Employee Welcome Page" Value="Employee Welcome Page"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/SubmitNewTimesheet.aspx" Text="Submit New Timesheet" Value="Submit New Timesheet"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LoginPage.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
        <br />
        <asp:ListBox ID="TimesheetListBox" runat="server" OnSelectedIndexChanged="TimesheetListBox_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
        <br />
        <asp:Button ID="UpdateButton" runat="server" OnClick="UpdateButton_Click" Text="Update" />
        <asp:Panel ID="UpdatePanel" runat="server" Visible="False">
            <p>
                Hours worked:</p>
            <p>
                Monday&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Monday" runat="server"></asp:TextBox>
            </p>
            <p>
                Tuesday&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Tuesday" runat="server"></asp:TextBox>
            </p>
            <p>
                Wednesday
                <asp:TextBox ID="Wednesday" runat="server"></asp:TextBox>
            </p>
            <p>
                Thursday&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Thursday" runat="server"></asp:TextBox>
            </p>
            <p>
                Friday&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Friday" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Submit" />
            </p>
            <p>
                <asp:Label ID="StatusLabel" runat="server" style="font-weight: 700"></asp:Label>
            </p>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
