using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGC_HRS.Models
{
    public class Employee
    {
        private string server = "localhost";
        private string database = "bgc";
        private string uid = "root";
        private string password = "qwer1234";
        private MySqlConnection connection;

        public Employee()
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        #region Class properties
        public string id;
        public string employee_code;
        public string employee_name;
        public string employee_type;
        public string employee_gender;
        public string allocation_site;
        public string allocation_department;
        public string location_site;
        public string location_division;
        public string location_sub_division;
        public string job_title_per_offer;
        public string actual_job_title;
        public string grade;
        public string degree;
        public string nationality;
        public string sponsorship;
        public string dob;
        public string passport_number;
        public string passport_issue_date;
        public string passport_expiry_date;
        public string residence_number;
        public string residence_expiry_date;
        public string residence_blood_group;
        public string doha_entry;
        public string joining_date;
        public string increment_month;
        public float increment_amount;
        public string basic_salary;
        public string leave_ticket_entitlement;
        public string leave_ticket_family;
        public float leave_days_per_year;
        public string leave_used_ticket;
        public string leave_two_way_ticket;
        public float leave_credits;
        public string vacation_ticket;
        public float vacation_leave_days;
        public string driving_license_issue_date;
        public string driving_license_expiry_date;
        public string health_card_number;
        public string health_card_issue_date;
        public string health_card_expiry_date;
        public string bank_name;
        public string card_number;
        public string recruited_by;
        public string accommodation;
        public string certificate;
        public string cv;
        public string d_paycard_number;
        public string end_date;
        public string status;
        public int age;
        public float starting_salary;
        public string contact_number;
        public string remarks;
        public string picture;
        public string project_manager;
        #endregion

        public string create()
        {
            string SQLSTR = "INSERT INTO employee (employee_code, employee_name, employee_type, allocation_site, allocation_department, location_site, location_division, " +
                "location_sub_division, job_title_per_offer, actual_job_title, grade, degree, nationality, sponsorship, dob, passport_number, passport_issue_date, passport_expiry_date, " +
                "residence_number, residence_expiry_date, residence_blood_group, doha_entry, joining_date, increment_month, increment_amount, basic_salary, " +
                "leave_ticket_entitlement, leave_ticket_family, leave_days_per_year, leave_used_ticket, leave_two_way_ticket, leave_credits, vacation_ticket, vacation_leave_days, " +
                "driving_license_issue_date, driving_license_expiry_date, health_card_number, health_card_issue_date, health_card_expiry_date, bank_name, card_number, recruited_by, " +
                "accommodation, certificate, cv, d_paycard_number, end_date, `status`, project_manager, picture, contact_number, remarks, starting_salary, age) VALUES(" +
                "'"+ employee_code +"', '"+ employee_name + "', '" + employee_type + "', '" + allocation_site + "', '" + allocation_department + "', '" + location_site + "', '" + location_division +"', " +
                "'" + location_sub_division + "', '" + job_title_per_offer + "', '" + actual_job_title + "', '" + grade + "', '" + degree + "', '" + nationality + "', '" + sponsorship + "', '" + dob + "', '" + passport_number + "', '" + passport_issue_date + "', '" + passport_expiry_date +"', " +
                "'" + residence_number + "', '" + residence_expiry_date + "', '" + residence_blood_group + "', '" + doha_entry + "', '" + joining_date + "', '" + increment_month +"', "+ increment_amount + ", " + basic_salary + ", " +
                "'" + leave_ticket_entitlement + "', '" + leave_ticket_family + "', " + leave_days_per_year + ", '" + leave_used_ticket + "', '" + leave_two_way_ticket + "', " + leave_credits + ", '" + vacation_ticket + "', " + vacation_leave_days +", " +
                "'" + driving_license_issue_date + "', '" + driving_license_expiry_date + "', '" + health_card_number + "', '" + health_card_issue_date + "', '" + health_card_expiry_date + "', '" + bank_name + "', '" + card_number + "', '" + recruited_by +"', " +
                "'" + accommodation + "', '" + certificate + "', '" + cv + "', '" + d_paycard_number + "', '" + end_date + "', '" + status + "', '" + project_manager +"', '" + picture +"', '" + contact_number +"', '" + remarks +"', " + starting_salary +", " + age +")";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = SQLSTR;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return "Created";
        }

        public string update()
        {
            return "Updated";
        }

        public string fetch()
        {
            return "fetched";
        }

        public string delete()
        {
            return "deleted";
        }
    }
}
