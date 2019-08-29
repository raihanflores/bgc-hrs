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
        private MySqlConnection connection;

        public Employee()
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());
        }
        #region Class properties
        public int id;
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
        public string gender;
        public string work_category;
        public string cost_allocation;
        #endregion

        public string create()
        {
            string SQLSTR = "INSERT INTO employee (employee_code, employee_name, employee_type, allocation_site, allocation_department, location_site, location_division, " +
                "location_sub_division, job_title_per_offer, actual_job_title, grade, degree, nationality, sponsorship, dob, passport_number, passport_issue_date, passport_expiry_date, " +
                "residence_number, residence_expiry_date, residence_blood_group, doha_entry, joining_date, increment_month, increment_amount, basic_salary, " +
                "leave_ticket_entitlement, leave_ticket_family, leave_days_per_year, leave_used_ticket, leave_two_way_ticket, leave_credits, vacation_ticket, vacation_leave_days, " +
                "driving_license_issue_date, driving_license_expiry_date, health_card_number, health_card_issue_date, health_card_expiry_date, bank_name, card_number, recruited_by, " +
                "accommodation, certificate, cv, d_paycard_number, end_date, `status`, project_manager, picture, contact_number, remarks, starting_salary, age) VALUES(" +
                "'" + employee_code + "', '" + employee_name + "', '" + employee_type + "', '" + allocation_site + "', '" + allocation_department + "', '" + location_site + "', '" + location_division + "', " +
                "'" + location_sub_division + "', '" + job_title_per_offer + "', '" + actual_job_title + "', '" + grade + "', '" + degree + "', '" + nationality + "', '" + sponsorship + "', '" + dob + "', '" + passport_number + "', '" + passport_issue_date + "', '" + passport_expiry_date + "', " +
                "'" + residence_number + "', '" + residence_expiry_date + "', '" + residence_blood_group + "', '" + doha_entry + "', '" + joining_date + "', '" + increment_month + "', " + increment_amount + ", " + basic_salary + ", " +
                "'" + leave_ticket_entitlement + "', '" + leave_ticket_family + "', " + leave_days_per_year + ", '" + leave_used_ticket + "', '" + leave_two_way_ticket + "', " + leave_credits + ", '" + vacation_ticket + "', " + vacation_leave_days + ", " +
                "'" + driving_license_issue_date + "', '" + driving_license_expiry_date + "', '" + health_card_number + "', '" + health_card_issue_date + "', '" + health_card_expiry_date + "', '" + bank_name + "', '" + card_number + "', '" + recruited_by + "', " +
                "'" + accommodation + "', '" + certificate + "', '" + cv + "', '" + d_paycard_number + "', '" + end_date + "', '" + status + "', '" + project_manager + "', '" + picture + "', '" + contact_number + "', '" + remarks + "', " + starting_salary + ", " + age + ")";

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = SQLSTR;
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
                return "Record created for " + employee_name + " successfully!";
            }
            catch (Exception)
            {
                return "Error";
            } finally
            {
                connection.Close();
            }
        }

        public string update()
        {
            string SQLSTR = "UPDATE employee SET " +
                            "employee_code = '" + employee_code + "'," +
                            "employee_name = '" + employee_name + "'," +
                            "employee_type = '" + employee_type + "'," +
                            "allocation_site = '" + allocation_site + "'," +
                            "allocation_department = '" + allocation_department + "'," +
                            "location_site = '" + location_site + "'," +
                            "location_division = '" + location_division + "'," +
                            "location_sub_division = '" + location_sub_division + "'," +
                            "job_title_per_offer = '" + job_title_per_offer + "'," +
                            "actual_job_title = '" + actual_job_title + "'," +
                            "grade = '" + grade + "'," +
                            "degree = '" + degree + "'," +
                            "nationality = '" + nationality + "'," +
                            "sponsorship = '" + sponsorship + "'," +
                            "dob = '" + dob + "'," +
                            "passport_number = '" + passport_number + "'," +
                            "passport_issue_date = '" + passport_issue_date + "'," +
                            "passport_expiry_date = '" + passport_expiry_date + "'," +
                            "residence_number = '" + residence_number + "'," +
                            "residence_expiry_date = '" + residence_expiry_date + "'," +
                            "residence_blood_group = '" + residence_blood_group + "'," +
                            "doha_entry = '" + doha_entry + "'," +
                            "joining_date = '" + joining_date + "'," +
                            "increment_month = '" + increment_month + "'," +
                            "increment_amount = " + increment_amount + "," +
                            "basic_salary = " + basic_salary + "," +
                            "leave_ticket_entitlement = '" + leave_ticket_entitlement + "'," +
                            "leave_ticket_family = '" + leave_ticket_family + "'," +
                            "leave_days_per_year = " + leave_days_per_year + "," +
                            "leave_used_ticket = '" + leave_used_ticket + "'," +
                            "leave_two_way_ticket = '" + leave_two_way_ticket + "'," +
                            "leave_credits = 0," +
                            "vacation_ticket = '" + vacation_ticket + "'," +
                            "vacation_leave_days = " + vacation_leave_days + "," +
                            "driving_license_issue_date = '" + driving_license_issue_date + "'," +
                            "driving_license_expiry_date = '" + driving_license_expiry_date + "'," +
                            "health_card_number = '" + health_card_number + "'," +
                            "health_card_issue_date = '" + health_card_issue_date + "'," +
                            "health_card_expiry_date = '" + health_card_expiry_date + "'," +
                            "bank_name = '" + bank_name + "'," +
                            "card_number = '" + card_number + "'," +
                            "recruited_by = '" + recruited_by + "'," +
                            "accommodation = '" + accommodation + "'," +
                            "certificate = '" + certificate + "'," +
                            "cv = ''," +
                            "d_paycard_number = '" + d_paycard_number + "'," +
                            "end_date = '" + end_date + "'," +
                            "`status`= '" + status + "'," +
                            "project_manager = '" + project_manager + "'," +
                            "picture = '"+ picture +"'," +
                            "contact_number = '" + contact_number + "'," +
                            "remarks = '" + remarks + "'," +
                            "gender = '" + employee_gender + "'," +
                            "work_category = '" + work_category + "'," +
                            "cost_allocation = '" + cost_allocation + "'," +
                            "age = " + age + "" +
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
