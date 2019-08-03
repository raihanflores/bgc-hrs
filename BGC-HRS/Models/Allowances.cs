using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGC_HRS.Models
{
    public class Allowances
    {
        private MySqlConnection connection;

        public Allowances()
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());
        }
        #region Class properties
        public int id;
        public string employee_code;
        public string allowance_type;
        public string allowance_amount;
        public string submitted;
        public string effective;
        #endregion

        public string create()
        {
            string SQLSTR = "INSERT INTO employee_allowances (employee_code, allowance_type, allowance_amount, date_submitted, effective_date) VALUES('" + employee_code + "', '" + allowance_type + "', " + allowance_amount + ", '" + submitted + "', '" + effective + "')";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = SQLSTR;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return "Record created for " + employee_code + " successfully!";
        }

        public string update()
        {
            string SQLSTR = "UPDATE employee_allowances SET " +
                            "employee_code = '" + employee_code + "'," +
                            "allowance_type = '" + allowance_type + "'," +
                            "allowance_amount = " + allowance_amount + "," +
                            "date_submitted = '" + submitted + "'," +
                            "effective_date = '" + effective + "'," +
                            " WHERE id = " + id + "";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = SQLSTR;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return "Record of " + employee_code + " updated successfully!";
        }

        public string fetch()
        {
            return "Fetched";
        }

        public string delete()
        {
            return "deleted";
        }
    }
}
