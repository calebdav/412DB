using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace DatabasesPhaseIII {
	public class Database {
		public SqlConnection Connection;

		const string credentials =
			"user id=CSEGroup5;" +
			"password=C$EGroup5;server=cadavis.database.windows.net;" +
			"database=CSE412DB; " +
			"connection timeout = ";

		public static SqlConnection NewConnection(double timeout) {
			SqlConnection connection = new SqlConnection(credentials + timeout);
			try {
				connection.Open();
			}
			catch (Exception exc) {
				Debug.WriteLine(exc.ToString());
				connection = null;
			}
			return connection;
		}

		public void Connect(double timeout) {
			Connection = new SqlConnection(credentials + timeout);
			try {
				Connection.Open();
			}
			catch (Exception exc) {
				Debug.WriteLine(exc.ToString());
			}
		}

		public void Disconnect() {
			Connection.Close();
		}

		public SqlDataReader Run(string sql, double timeout) {
			Connect(timeout);
			SqlDataReader reader = new SqlCommand(sql, Connection).ExecuteReader();
			return reader;
		}

		public static string AppendCommaSeparatedStrings(string command, string[] list) {
			string result = command;
			if (list.Count() > 0) {
				for (int i = 0; i < list.Count() - 1; ++i) {
					result += list[i];
					result += ",";
				}
				result += list[list.Count() - 1];
			}
			return result;
		}

		public static string ParenthesesList(string[] list) {
			return AppendCommaSeparatedStrings("(", list) + ")";
		}

		public static string Quote(string str) {
			return "'" + str + "'";
		}

		public static string ArrayToString(string[] array) {
			string result = "";
			for (int i=0; i<array.Length; ++i) {
				result += (array[i] + " ");
			}
			return result;
		}

        public List<string> GetResults(SqlDataReader reader, string fieldName) {
			List<string> result = new List<string>();
			while (reader.Read()) {
				result.Add(reader[fieldName].ToString());
			}
			return result;
		}

		public static List<string[]> Query(string sql, double timeout) {
			SqlConnection connection = NewConnection(timeout);
			SqlDataReader reader = new SqlCommand(sql, connection).ExecuteReader();
			IDataRecord current_record;
			string[] current_row;
			List<string[]> result = new List<string[]>();
			while (reader.Read()) {
				current_record = reader;
				current_row = new string[current_record.FieldCount];
				for (int j = 0; j < current_record.FieldCount; ++j) {
					current_row[j] = current_record[j].ToString();
				}
				result.Add(current_row);
			}
			reader.Close();
			connection.Close();
			return result;
		}
	}
}













