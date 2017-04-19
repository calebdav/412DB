using DatabasesPhaseIII;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources {
    public partial class ViewEmployeeTimesheets : System.Web.UI.Page {
        int selectedIndex = -1;
        protected void Page_Load(object sender, EventArgs e) {
            LoadTimesheets();
        }

        protected void UpdateButton_Click(object sender, EventArgs e) {
            selectedIndex = TimesheetListBox.SelectedIndex;
            UpdatePanel.Visible = !UpdatePanel.Visible;
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            try {
                double mondayHours = Double.Parse(Monday.Text.ToString());
                double tuesdayHours = Double.Parse(Tuesday.Text.ToString());
                double wednesdayHours = Double.Parse(Wednesday.Text.ToString());
                double thursdayHours = Double.Parse(Thursday.Text.ToString());
                double fridayHours = Double.Parse(Friday.Text.ToString());

                if (TimesheetListBox.SelectedIndex != -1) {
                    string selected = TimesheetListBox.Items[TimesheetListBox.SelectedIndex].Text;
                    string[] selectedSplit = selected.Split(new char[] { ' ' });
                    string sql = "UPDATE Timesheet SET mon_hours_worked = " + mondayHours+ ", " +
                    "tue_hours_worked = "+tuesdayHours+", " +
                    "wed_hours_worked = " + wednesdayHours + ", " +
                    "thur_hours_worked = " + thursdayHours + ", " +
                    "fri_hours_worked = " + fridayHours + ", " +
                    "approved_by_manager = 0 " +
                    "WHERE grunt_employee_id = " + Session["userID"] + " AND week_of = " + Database.Quote(selectedSplit[5]);
                    try {
                        Database.Query(sql, 10.0);
                    } catch (Exception ex) {
                        StatusLabel.Text = "\n\n\n/////////////////EXCEPTION: " + ex.ToString() + "\n\n\n";
                    }
                    LoadTimesheets();
                    StatusLabel.Text = "Timesheet update successful";
                } else {
                    StatusLabel.Text = "Please select a sheet to update";
                }
            } catch (Exception ex) {
                StatusLabel.Text = "Please input proper number of hours";
            }
        }

        private void LoadTimesheets() {
            selectedIndex = TimesheetListBox.SelectedIndex;
            TimesheetListBox.Items.Clear();
            List<string[]> queryResult = Database.Query("SELECT * FROM Timesheet WHERE grunt_employee_id = " + Session["userID"], 20.0);
            for (int i = 0; i < queryResult.Count(); i++) {
                TimesheetListBox.Items.Add(Database.ArrayToString(queryResult[i]));
            }
            if (selectedIndex != -1) {
                TimesheetListBox.SelectedIndex = selectedIndex;
            }
        }

        protected void TimesheetListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (TimesheetListBox.SelectedIndex != -1) {
                string selected = TimesheetListBox.Items[TimesheetListBox.SelectedIndex].Text;
                string[] selectedSplit = selected.Split(new char[] { ' ' });
                Monday.Text = selectedSplit[0];
                Tuesday.Text = selectedSplit[1];
                Wednesday.Text = selectedSplit[2];
                Thursday.Text = selectedSplit[3];
                Friday.Text = selectedSplit[4];

                LoadTimesheets();
            }
        }
    }
}