using DatabasesPhaseIII;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HumanResources {
	public partial class ViewProjects : System.Web.UI.Page {
		int selected_index;

		protected void Page_Load(object sender, EventArgs e) {
            LoadProjects();
        }

        protected void TerminateButton_Click(object sender, EventArgs e) {
			if (selected_index != -1) {
				string selected = ProjectListBox.Items[selected_index].Text;
				string[] selected_split = selected.Split(new char[] { ' ' });
				string sql = "DELETE FROM Project WHERE project_id = " + selected_split[0];
				try {
					Database.Query(sql, 10.0);
				}
				catch (Exception ex) {
					Debug.WriteLine("\n\n\n/////////////////EXCEPTION: " + ex.ToString() + "\n\n\n");
				}
				LoadProjects();
				selected_index = -1;
			} else {
                StatusLabel.Text = "Please select a project to terminate";
            }
		}

        private void LoadProjects() {
			selected_index = ProjectListBox.SelectedIndex;
			ProjectListBox.Items.Clear();
			List<string[]> query_result = Database.Query("SELECT * FROM Project", 20.0);
			for (int i = 0; i < query_result.Count(); ++i) {
				ProjectListBox.Items.Add(Database.ArrayToString(query_result[i]));
			}
		}
    }
}