using DatabasesPhaseIII;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources {
    public partial class ViewEmployees : System.Web.UI.Page {
		int employee_index;
        int team_index;
		protected void Page_Load(object sender, EventArgs e) {
            LoadEmployees();
            LoadTeams();
        }

        protected void FireButton_Click(object sender, EventArgs e) {
			if (employee_index != -1) {
				string selected = EmployeeListBox.Items[employee_index].Text;
				string employee_id = selected.Split(new char[] { ' ' })[0];
				string sql = "DELETE FROM Employee WHERE employee_id = " + employee_id + " AND EXISTS (SELECT employee_id FROM Grunt WHERE employee_id = " + employee_id + ")";
				try {
					Database.Query(sql, 10.0);
				}
				catch (Exception ex) {
					Debug.WriteLine("\n\n\n/////////////////EXCEPTION: " + ex.ToString() + "\n\n\n");
				}
				LoadEmployees();
				employee_index = -1;
			} else {
                StatusLabel.Text = "Please select an employee to fire";
            }
		}

        protected void ReassignButton_Click(object sender, EventArgs e) {
            if (EmployeeListBox.SelectedIndex != -1) {
                if (TeamListBox.SelectedIndex != -1) {
                    string team_id = TeamListBox.Items[team_index].Text.Split(' ')[0];
                    StatusLabel.Text = "Team reassigned to " + TeamListBox.Items[team_index].Text;
                    if (team_id != "" && Database.Query("SELECT * FROM Team WHERE team_id = " + team_id, 10.0).Count() > 0) {
                        try {
                            Database.Query("UPDATE Grunt SET team_id = " + team_id + " WHERE employee_id = " + EmployeeListBox.Items[employee_index].Text.Split(new char[] { ' ' })[0], 10.0);
                        } catch (Exception ex) {
                            Debug.WriteLine("\n\n\n/////////////////EXCEPTION: " + ex.ToString() + "\n\n\n");
                        }
                        LoadEmployees();
                    }
                } else {
                    StatusLabel.Text = "Please select a team";
                }
            } else {
                if(TeamListBox.SelectedIndex != -1) {
                    StatusLabel.Text = "Please select an employee";
                } else {
                    StatusLabel.Text = "Please select an employee and a team to reassign to";
                }
                
            }
        }

        private void LoadEmployees() {
            employee_index = EmployeeListBox.SelectedIndex;
			EmployeeListBox.Items.Clear();
			List<string[]> query_result = Database.Query("SELECT e.employee_id, first_name, last_name, role, street_address, city, state, zip, team_id, wage FROM Employee e, Grunt g WHERE e.employee_id = g.employee_id", 20.0);
			for (int i = 0; i < query_result.Count(); ++i) {
				EmployeeListBox.Items.Add(Database.ArrayToString(query_result[i]));
			}
            if (employee_index != -1) {
                EmployeeListBox.SelectedIndex = employee_index;
            }
        }

        private void LoadTeams() {
            team_index = TeamListBox.SelectedIndex;
            TeamListBox.Items.Clear();
            List<string[]> query_result = Database.Query("SELECT * FROM Team t", 20.0);
            for (int i = 0; i < query_result.Count(); ++i) {
                TeamListBox.Items.Add(Database.ArrayToString(query_result[i]));
            }
            if (team_index != -1) {
                TeamListBox.SelectedIndex = team_index;
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}