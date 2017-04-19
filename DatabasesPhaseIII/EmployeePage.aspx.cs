using DatabasesPhaseIII;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources {
    public partial class EmployeePage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            List<string[]> query_result = Database.Query("SELECT TOP (1) [first_name]" +
                    "FROM [dbo].[Employee] " +
                    "WHERE [employee_id] = " + Session["userID"], 20.0);
            WelcomeLabel.Text = "Welcome Employee " + Database.ArrayToString(query_result[0]).Trim() + ", Please choose an option above.";
        }

        protected void LogoutButton_Click(object sender, EventArgs e) {
            Response.Redirect("LoginPage.aspx");
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e) {

        }
    }
}