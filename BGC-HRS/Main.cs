using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BGC_HRS.Models;
using MySql.Data.MySqlClient;

namespace BGC_HRS
{
    public partial class Main : Form
    {
        private string server = "localhost";
        private string database = "bgc";
        private string uid = "root";
        private string password = "qwer1234";
        private string currency = " QR";
        private MySqlConnection connection;
        private MySqlDataAdapter mySqlDataAdapter;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            loadAllowancesGrid();
            loadEmployeeRecords();
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void Search(string searchString)
        {

        }

        private void DgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.employee_code = txtEmployeeNumber.Text;
            employee.employee_name = txtEmployeeName.Text;
            // employee type
            if (rbStaff.Checked == true)
            {
                employee.employee_type = rbStaff.Text;
            }
            if (rbWorker.Checked == true)
            {
                employee.employee_type = rbWorker.Text;
            }
            // employee gender
            if (rbMale.Checked == true)
            {
                employee.employee_gender = rbMale.Text;
            }
            if (rbFemale.Checked == true)
            {
                employee.employee_gender = rbFemale.Text;
            }
            // Site
            if (rbOffice.Checked == true)
            {
                employee.allocation_site = rbOffice.Text;
            }
            if (rbSite.Checked == true)
            {
                employee.allocation_site = rbSite.Text;
            }
            employee.allocation_department = "";
            employee.location_site = "";
            employee.location_division = "";
            employee.location_sub_division = "";
            employee.job_title_per_offer = cbJobTitleAsJO.Text;
            employee.actual_job_title = cbActualJobTitle.Text;
            employee.grade = "";
            employee.degree = cbDegree.Text;
            employee.nationality = cbNationality.Text;
            employee.sponsorship = cbSponsorship.Text;
            employee.dob = dtpDateOfBirth.Text;
            employee.passport_number = txtPassport.Text;
            employee.passport_issue_date = dtpPassportIssued.Text;
            employee.passport_expiry_date = dtpPassportExpires.Text;
            employee.residence_number = txtRPNumber.Text;
            employee.residence_expiry_date = dtpRPExpiryDate.Text;
            employee.residence_blood_group = cbBloodGroup.Text;
            employee.doha_entry = dtpDohaEntry.Text;
            employee.joining_date = dtpJoiningDate.Text;
            employee.basic_salary = txtBasicSalary.Text.Replace(currency, "").Replace(",", "");
            employee.driving_license_issue_date = dtpDriverLicenseIssued.Text;
            employee.driving_license_expiry_date = dtpDriverLicenseExpiry.Text;
            employee.health_card_number = txtHCNumber.Text;
            employee.health_card_issue_date = dtpHealthCardIssued.Text;
            employee.health_card_expiry_date = dtpHealthCardExpiry.Text;
            employee.bank_name = txtBankName.Text;
            employee.card_number = txtCardNumber.Text;
            employee.recruited_by = cbRecruitedBy.Text;
            employee.accommodation = cbAccommodation.Text;
            employee.d_paycard_number = txtCardNumber.Text;
            employee.end_date = dtpDateOfSeparation.Text;
            employee.status = gbStatus.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            employee.increment_amount = 0;
            employee.leave_days_per_year = 0;
            employee.leave_credits = 0;
            employee.vacation_leave_days = 0;

            MessageBox.Show(employee.create());
        }

        private void loadAllowancesGrid()
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select date_submitted AS `Date Submitted`, effective_date AS `Effective Date`, allowance_type AS `Allowance Type`, allowance_amount AS `Allowance Amount` from employee_allowances where employee_code = 'BGC0002'", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgAllowances.DefaultCellStyle.Font = new Font("Roboto", 10);
                dgAllowances.DataSource = DS.Tables[0];

                //close connection
                this.CloseConnection();
            }
        }

        private void loadEmployeeRecords()
        {
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("select * from employee where employee_code = 'BGC0002'", connection);
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    lblEmployeeName.Text = reader["employee_name"].ToString();
                    lblEmployeeCode.Text = reader["employee_code"].ToString();
                    txtEmployeeNumber.Text = reader["employee_code"].ToString();
                    txtEmployeeName.Text = reader["employee_name"].ToString();
                    txtContactNumber.Text = "";
                    txtRPNumber.Text = reader["residence_number"].ToString();
                    txtPassport.Text = reader["passport_number"].ToString();
                    txtBankName.Text = reader["bank_name"].ToString();
                    txtCardNumber.Text = reader["card_number"].ToString();
                    txtHCNumber.Text = reader["health_card_number"].ToString();
                    txtBasicSalary.Text = float.Parse(reader["basic_salary"].ToString()).ToString("#,###.00");
                    cbJobTitleAsJO.Text = reader["job_title_per_offer"].ToString();
                    cbActualJobTitle.Text = reader["actual_job_title"].ToString();
                    cbSponsorship.Text = reader["sponsorship"].ToString();
                    cbRecruitedBy.Text = ""; //reader["job_title_per_offer"].ToString();
                    cbTicket.Text = "";
                    cbNationality.Text = reader["nationality"].ToString();
                    cbBloodGroup.Text = ""; // reader["job_title_per_offer"].ToString();
                    cbDaysOfLeave.Text = reader["leave_days_per_year"].ToString() + " Days";
                    cbSiteName.Text = reader["location_site"].ToString();
                    cbAccommodation.Text = reader["accommodation"].ToString();
                    cbDegree.Text = reader["degree"].ToString();
                    cbProjectManager.Text = reader["project_manager"].ToString();
                    txtContactNumber.Text = reader["contact_number"].ToString();
                    cbRecruitedBy.Text = reader["recruited_by"].ToString();
                    txtRemarks.Text = reader["remarks"].ToString();
                    txtAge.Text = reader["age"].ToString();
                    cbBloodGroup.Text = reader["residence_blood_group"].ToString();
                    txtStartingSalary.Text = float.Parse(reader["starting_salary"].ToString()).ToString("#,###.00");
                    if (reader["dob"].ToString() != "")
                    {
                        dtpDateOfBirth.Value = DateTime.Parse(reader["dob"].ToString());
                    }
                    if (reader["residence_expiry_date"].ToString() != "")
                    {
                        dtpRPExpiryDate.Value = DateTime.Parse(reader["residence_expiry_date"].ToString());
                    }
                    if (reader["passport_issue_date"].ToString() != "")
                    {
                        dtpPassportIssued.Value = DateTime.Parse(reader["passport_issue_date"].ToString());
                    }
                    if (reader["passport_expiry_date"].ToString() != "")
                    {
                        dtpPassportExpires.Value = DateTime.Parse(reader["passport_expiry_date"].ToString());
                    }
                    if (reader["doha_entry"].ToString() != "")
                    {
                        dtpDohaEntry.Value = DateTime.Parse(reader["doha_entry"].ToString());
                    }
                    if (reader["joining_date"].ToString() != "")
                    {
                        dtpJoiningDate.Value = DateTime.Parse(reader["doha_entry"].ToString());
                    }
                    if (reader["end_date"].ToString() != "")
                    {
                        dtpDateOfSeparation.Value = DateTime.Parse(reader["end_date"].ToString());
                    }
                    // Allowances
                    float total_allowances = 0;
                    for (int i = 0; i < dgAllowances.Rows.Count - 1; i++)
                    {
                        total_allowances += float.Parse(dgAllowances.Rows[i].Cells[3].Value.ToString());
                    }
                    txtTotalAllowances.Text = total_allowances.ToString("#,###.00");
                    txtTotalSalary.Text = (float.Parse(txtBasicSalary.Text) + float.Parse(txtTotalAllowances.Text)).ToString("#,###.00");
                    // Append currency
                    txtBasicSalary.Text += currency;
                    txtTotalAllowances.Text += currency;
                    txtTotalSalary.Text += currency;
                    txtStartingSalary.Text += currency;
                    // Picture
                    try
                    {
                        pbProfilePicture.Image = base64StringToImage(reader["picture"].ToString());
                    }
                    catch (Exception)
                    {
                        pbProfilePicture.Image = null;
                    }
                }

                // Call Close when done reading.
                reader.Close();
            }
        }

        private Image base64StringToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                return Image.FromStream(ms, true);
            }

        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            MessageBox.Show(employee.update());
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            MessageBox.Show(employee.delete());
        }

        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            MessageBox.Show(employee.fetch());
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GbStatus_Paint(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(Color.White);
            p.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
        }

        private void GbGender_Paint(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(Color.White);
            p.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
        }

        private void GroupBox1_Paint(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(Color.White);
            p.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
        }

        private void GroupBox2_Paint(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(Color.White);
            p.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
        }
    }
}
