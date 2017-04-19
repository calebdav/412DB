<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitNewTimesheet.aspx.cs" Inherits="HumanResources.SubmitNewTimesheet" %>

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
                <asp:MenuItem NavigateUrl="~/ViewTimesheets.aspx" Text="View Timesheets" Value="View Timesheets"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/LoginPage.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>
        <p>
            mon_hours_worked
            <asp:TextBox ID="Monday" runat="server" OnTextChanged="Monday_TextChanged"></asp:TextBox>
        </p>
        <p>
&nbsp;tue_hours_worked
            <asp:TextBox ID="Tuesday" runat="server"></asp:TextBox>
        </p>
        <p>
&nbsp;wed_hours_worked
            <asp:TextBox ID="Wednesday" runat="server"></asp:TextBox>
        </p>
        <p>
&nbsp;thur_hours_worked
            <asp:TextBox ID="Thursday" runat="server"></asp:TextBox>
        </p>
        <p>
&nbsp;fri_hours_worked
            <asp:TextBox ID="Friday" runat="server"></asp:TextBox>
        </p>
        <p>
&nbsp;week_of
            <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>
        </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" Text="Submit" />
        </p>
        <asp:Label ID="ErrorLabel" runat="server" Font-Bold="True"></asp:Label>
    </form>
    </body>
</html>
