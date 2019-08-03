using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGC_HRS.Models
{
    public class SalaryIncrease
    {
        private MySqlConnection connection;

        public SalaryIncrease()
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());
        }
        #region Class properties
        public int id;
        public string employee_code;
        public string date_submitted;
        public string date_effective;
        public string note;
        public float increase_amount;
        #endregion

        public string create()
        {
            string SQLSTR = "INSERT INTO salary_increases (employee_code, date_submitted, date_effective, note, increase_amount) VALUES('" + employee_code + "', '" + date_submitted + "', '" + date_effective + "', '" + note + "', " + increase_amount + ")";

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
                            "allowance_type = '" + date_submitted + "'," +
                            "allowance_amount = " + date_effective + "," +
                            "date_submitted = '" + note + "'," +
                            "effective_date = '" + increase_amount + "'," +
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
