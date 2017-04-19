using DatabasesPhaseIII;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources {
    public partial class ViewManagerTimesheets : System.Web.UI.Page {
		int selected_index;

		protected void Page_Load(object sender, EventArgs e) {
			LoadTimesheets();
        }

        protected void ApproveButton_Click(object sender, EventArgs e) {
			if (selected_index != -1) {
				string selected = TimesheetListBox.Items[selected_index].Text;
				string[] selected_split = selected.Split(new char[] { ' ' });
				string sql = "UPDATE Timesheet SET approved_by_manager = 1 WHERE grunt_employee_id = " + selected_split[8] + " AND week_of = " + Database.Quote(selected_split[5]);
				try {
					Database.Query(sql, 10.0);
				}
				catch (Exception ex) {
					Debug.WriteLine("\n\n\n/////////////////EXCEPTION: " + ex.ToString() + "\n\n\n");
				}
				LoadTimesheets();
				selected_index = -1;
			} else {
                StatusLabel.Text = "Please select a timesheet to approve";
            }
        }
		
        private void LoadTimesheets() {
			selected_index = TimesheetListBox.SelectedIndex;
			TimesheetListBox.Items.Clear();
			string sql = 
				"SELECT t.mon_hours_worked, t.tue_hours_worked, t.wed_hours_worked, t.thur_hours_worked, t.fri_hours_worked, week_of, grunt_employee_id FROM Timesheet t WHERE t.manager_employee_id = " +
				Session["userID"] +
				" AND " +
				"t.approved_by_manager = 0";
			List<string[]> query_result = Database.Query(sql, 20.0);
			for (int i=0; i<query_result.Count(); ++i) {
				TimesheetListBox.Items.Add(Database.ArrayToString(query_result[i]));
			}
        }

		protected void TimesheetListBox_SelectedIndexChanged(object sender, EventArgs e) {

		}
	}
}