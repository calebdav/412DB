using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Diagnostics;
using DatabasesPhaseIII;

namespace HumanResources {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void LoginButton_Click(object sender, EventArgs e) {
            string userID = UserIDTextBox.Text.ToString();
            string password = PasswordTextBox.Text.ToString();

            //query the DB for the password and check if they match
            //if they do check which type of person they are

            string redirect = "";

            if (userID != "" && password != "") {
                //run a SQL query
                string sql = "SELECT * FROM Employee WHERE employee_id = " + userID;
                try {
                    List<string[]> queryResult = Database.Query(sql, 20.0);
                    string employeeRecord = Database.ArrayToString(queryResult[0]);
                    string[] split = employeeRecord.Split(new char[] { ' ' });
                    if (password == split[1]) {
                        Session["userID"] = userID;
                        if (IsManager(userID)) {
                            redirect = "ManagerPage.aspx";
                        } else {
                            redirect = "EmployeePage.aspx";
                        }

                    } else {
                        StatusLabel.Text = "Authentication failed";
                    }
                } catch (Exception ex) {
                    StatusLabel.Text = "Error retrieving credentials";
                }
                if (redirect != "") {
                    Response.Redirect(redirect);
                }

            } else {
                StatusLabel.Text = "Error: Enter userID and password";
            }
        }

        private bool IsManager(string userID) {
            bool output = false;
            string sql = "SELECT * FROM Employee, Manager WHERE Employee.employee_id = Manager.employee_id AND Employee.employee_id =" + userID;
            try {
                List<string[]> queryResult = Database.Query(sql, 20.0);
                string employeeRecord = Database.ArrayToString(queryResult[0]);
                string[] split = employeeRecord.Split(new char[] { ' ' });
                if (userID == split[0]) {
                    output = true;
                } else {
                    output = false;
                }
            } catch (Exception exc) {
                StatusLabel.Text = exc.ToString();
            }

            return output;
        }
    }
}