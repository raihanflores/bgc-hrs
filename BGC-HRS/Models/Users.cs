using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGC_HRS.Models
{
    public class Users
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int clearance_level { get; set; }
        public string status { get; set; }

        private MySqlConnection connection;

        public Users()
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());
        }

        public bool ValidateUsers(string username, string password)
        {
            MySqlCommand command = new MySqlCommand("select * from users where username = '" + username + "' and password = '" + password + "'", connection);
            connection.Open();

            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
