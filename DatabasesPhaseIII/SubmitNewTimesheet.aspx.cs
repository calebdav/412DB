using DatabasesPhaseIII;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources {
    public partial class SubmitNewTimesheet : System.Web.UI.Page {
		Random random;

		protected void Page_Load(object sender, EventArgs e) {
			random = new Random();
        }

		private string random_manager() {
			List<string[]> query_result = Database.Query("SELECT employee_id FROM Manager", 20.0);
			return query_result[random.Next(0, query_result.Count())][0];
		}

        protected void SubmitButton_Click(object sender, EventArgs e) {
            string weekOf = "";
			try {
				double mondayHours = Double.Parse(Monday.Text.ToString());
				double tuesdayHours = Double.Parse(Tuesday.Text.ToString());
				double wednesdayHours = Double.Parse(Wednesday.Text.ToString());
				double thursdayHours = Double.Parse(Thursday.Text.ToString());
				double fridayHours = Double.Parse(Friday.Text.ToString());
				weekOf = Calendar.SelectedDate.ToShortDateString();
				string sql =
						"INSERT INTO Timesheet" +
						Database.ParenthesesList(new string[] {
								"mon_hours_worked",
								"tue_hours_worked",
								"wed_hours_worked",
								"thur_hours_worked",
								"fri_hours_worked",
								"week_of",
								"approved_by_manager",
								"manager_employee_id",
								"grunt_employee_id"
							}
						)
						+
						"VALUES"
						+
						Database.ParenthesesList(new string[] {
								Monday.Text,
								Tuesday.Text,
								Wednesday.Text,
								Thursday.Text,
								Friday.Text,
								Database.Quote(weekOf),
								Convert.ToString(0),
								random_manager(),
								(string)Session["userID"]
							}
						);
				try {
					List<string[]> query_result = Database.Query(sql, 20.0);
					Monday.Text = Tuesday.Text = Wednesday.Text = Thursday.Text = Friday.Text;
                    ErrorLabel.Text = "Timesheet submit successful";
				}
				catch (Exception exc) {
					ErrorLabel.Text = "A timesheet associated with you at this week already exists";
					Debug.WriteLine("\n\n\n/////////////////EXCEPTION: " + exc.ToString() + "\n\n\n");
				}
			} catch (Exception ex) {
				ErrorLabel.Text = "Hours not formatted correctly";
				Debug.WriteLine("\n\n\n/////////////////EXCEPTION: " + ex.ToString() + "\n\n\n");
            }
        }

		protected void Monday_TextChanged(object sender, EventArgs e) {

		}
	}
}