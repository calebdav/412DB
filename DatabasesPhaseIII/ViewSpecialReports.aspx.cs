using DatabasesPhaseIII;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources {
    public partial class ViewSpecialReports : System.Web.UI.Page {

        int selectedIndex = -1;

        protected void Page_Load(object sender, EventArgs e) {
            if (!Query12Panel.Visible) {
                selectedIndex = Query12ListBox.SelectedIndex;
                Query12ListBox.Items.Clear();
                List<string[]> query_result = Database.Query("SELECT DISTINCT e.employee_id, e.first_name, e.last_name, e.city " +
                    "FROM Grunt g, Employee e, Timesheet t " +
                    "WHERE g.employee_id = e.employee_id AND g.employee_id = t.grunt_employee_id AND NOT g.employee_id IN( " +
                        "SELECT employee_id " +
                        "FROM Employee " +
                        "WHERE city = 'Chicago' " +
                    ") " +
                    "AND g.employee_id IN( " +
                    "SELECT  g.employee_id " +
                    "FROM Grunt g, Timesheet t " +
                    "WHERE g.employee_id = t.grunt_employee_id " +
                    "GROUP BY g.employee_id, t.week_of " +
                    "HAVING(SUM(t.mon_hours_worked) + SUM(t.tue_hours_worked) + SUM(t.wed_hours_worked) + SUM(t.thur_hours_worked) + SUM(t.fri_hours_worked)) < 40 " +
                    ") ", 20.0);
                for (int i = 0; i < query_result.Count(); ++i) {
                    Query12ListBox.Items.Add(Database.ArrayToString(query_result[i]));
                }
            }

            if (!CorrelatedNestedQueryPanel.Visible) {
                selectedIndex = ManagerBySalaryListBox.SelectedIndex;
                ManagerBySalaryListBox.Items.Clear();
                List<string[]> query_result = Database.Query(" SELECT e1.first_name, e1.last_name, e1.street_address, m1.salary " +
                    "FROM Employee e1, Manager m1 " +
                    "WHERE e1.employee_id = m1.employee_id AND 10 > ( " +
                    "SELECT COUNT(*) " +
                    "FROM Employee e2, Manager m2 " +
                    "WHERE e2.employee_id = m2.employee_id AND m2.salary > m1.salary " +
                    ") " +
                    "ORDER BY m1.salary DESC", 20.0);
                for (int i = 0; i < query_result.Count(); ++i) {
                    ManagerBySalaryListBox.Items.Add(Database.ArrayToString(query_result[i]));
                }
            }
        }

        protected void Query12Button_Click(object sender, EventArgs e) {
            CorrelatedNestedQueryPanel.Visible = false;
            Query12Panel.Visible = !Query12Panel.Visible;
        }

        protected void CorrelatedNestedQueryButton_Click(object sender, EventArgs e) {
            Query12Panel.Visible = false;
            CorrelatedNestedQueryPanel.Visible = !CorrelatedNestedQueryPanel.Visible;
        }
    }
}