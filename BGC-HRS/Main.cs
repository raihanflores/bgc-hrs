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
        private string currency = " QR";
        private MySqlConnection connection;
        private MySqlDataAdapter mySqlDataAdapter;

        public string employee_id;

        public Main()
        {
            InitializeComponent();
        }

        private void ClearControl(Control control)
        {
            TextBox tb = control as TextBox;
            if (tb != null)
            {
                tb.Text = String.Empty;
            }
            ComboBox cb = control as ComboBox;
            if (cb != null)
            {
                cb.SelectedIndex = -1;
            }
            // repeat for combobox, listbox, checkbox and any other controls you want to clear
            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    ClearControl(child);
                }
            }
        }

        private void ClearAllControls()
        {
            ClearControl(this);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ClearAllControls();
            JobList();
            JobAsJO();
            SponsorList();
            DegreeList();
            RecruiterList();
            SiteList(); 
            BloodGroupList();
            AccommodationList();
            NationalityList();
            LeaveDaysList();
            loadAllowancesGrid(employee_id);
            loadSalaryIncreasesGrid(employee_id);
            loadEmployeeLeavesGrid(employee_id);
            loadEmployeeRecords(employee_id);
            LoadEmployeeList(employee_id);
            LoadEmployeesWithoutIDList(employee_id);
            LoadHealthCardMonitoringList(employee_id);
            LoadLeaveMonitoringList(employee_id);
            LoadPassportMonitoringList(employee_id);
        }

        private void JobList()
        {
            string[] jobs = { "a/c technician", "aluminum - assistant", "aluminum fabricator", "carpenter", "carpenter - assistant", "chargehand - carpenter", "chargehand - ductman", "chargehand - electrical", "chargehand - gypsum fixer", "chargehand - labor civil", "chargehand - mason", "chargehand - plumber", "cook", "document controller - assistant", "driver - big bus", "driver - pickup", "driver - small bus", "driver - tanker", "driver - trailer", "ductman", "electrician", "electrician - assistant", "gypsum fixer", "gypsum fixer - assistant", "labor - civil", "labor - gardener", "labor - marble", "labor - metal", "labor - plumbing", "labor - safety", "marble worker", "mason - assistant", "mason - block & plaster", "mason - power floating", "mason - water proofing", "mason - water proofing assistant", "mechanic", "mechanic - auto body", "office boy", "operator - dumper", "operator - forklift", "painter", "plumber", "rigger", "scaffolder", "security guard", "steel bender",
"steel fixer - assistant", "storekeeper - assistant", "tiler", "welder", "welder - assistant", "wood worker" };

            BindingSource binding = new BindingSource();
            binding.DataSource = jobs.ToList();
            cbActualJobTitle.DataSource = binding.DataSource;
        }

        private void SiteList()
        {
            string[] sites = { "camp", "dbaf", "kmcc", "ktrh", "ktrs", "oryx", "quce" };

            BindingSource binding = new BindingSource();
            binding.DataSource = sites.ToList();
            cbSiteName.DataSource = binding.DataSource;
        }

        private void AccommodationList()
        {
            string[] accommodations = { "shahania camp" };

            BindingSource binding = new BindingSource();
            binding.DataSource = accommodations.ToList();
            cbAccommodation.DataSource = binding.DataSource;
        }

        private void NationalityList()
        {
            string[] nationality = { "Indian", "Nepali", "Egyptian", "Pakistan", "Syrian", "Bangladesh", "Filipino", "Sri Lankan", "Pakistani", "Srilankan" };

            BindingSource binding = new BindingSource();
            binding.DataSource = nationality.ToList();
            cbNationality.DataSource = binding.DataSource;
        }

        private void LeaveDaysList()
        {
            string[] leave_days = new string[60];

            for (int i = 0; i < 60; i++)
            {
                leave_days[i] = i.ToString();
            }


            BindingSource binding = new BindingSource();
            binding.DataSource = leave_days.ToList();
            cbDaysOfLeave.DataSource = binding.DataSource;
        }

        private void DegreeList()
        {
            string[] jobs = { "Drafting","Accounting Information and Business Management","Business Administration - Banking and Finance","Food & Beverage Coordinator","MS Office & Tally","B.S. Civil Engineer","B.S. Architecture","Civil Draftsman","B.S. Electrical Engineer",
"Computer Science" };

            BindingSource binding = new BindingSource();
            binding.DataSource = jobs.ToList();
            cbDegree.DataSource = binding.DataSource;
        }

        private void RecruiterList()
        {
            string[] jobs = { "hr department", "jupiter overseas", "prudential manpower", "resource management", "sattyam international" };

            BindingSource binding = new BindingSource();
            binding.DataSource = jobs.ToList();
            cbRecruitedBy.DataSource = binding.DataSource;
        }

        private void BloodGroupList()
        {
            string[] jobs = { "A +", "A -", "B +", "B -", "AB +", "AB -", "O +", "O -" };

            BindingSource binding = new BindingSource();
            binding.DataSource = jobs.ToList();
            cbBloodGroup.DataSource = binding.DataSource;
        }

        private void JobAsJO()
        {
            string[] jobs = { "a/c technician", "aluminum - assistant", "aluminum fabricator", "carpenter", "carpenter - assistant", "chargehand - carpenter", "chargehand - ductman", "chargehand - electrical", "chargehand - gypsum fixer", "chargehand - labor civil", "chargehand - mason", "chargehand - plumber", "cook", "document controller - assistant", "driver - big bus", "driver - pickup", "driver - small bus", "driver - tanker", "driver - trailer", "ductman", "electrician", "electrician - assistant", "gypsum fixer", "gypsum fixer - assistant", "labor - civil", "labor - gardener", "labor - marble", "labor - metal", "labor - plumbing", "labor - safety", "marble worker", "mason - assistant", "mason - block & plaster", "mason - power floating", "mason - water proofing", "mason - water proofing assistant", "mechanic", "mechanic - auto body", "office boy", "operator - dumper", "operator - forklift", "painter", "plumber", "rigger", "scaffolder", "security guard", "steel bender",
"steel fixer - assistant", "storekeeper - assistant", "tiler", "welder", "welder - assistant", "wood worker" };

            BindingSource binding = new BindingSource();
            binding.DataSource = jobs.ToList();
            cbJobTitleAsJO.DataSource = binding.DataSource;
        }

        private void SponsorList()
        {
            string[] sponsors = { "boom construction", "boom construction co.", "boom general contractors", "genithon panisales", "husband sponsor", "private", "اليامي للتجارة والخدمات والمقاولات", "شركة اللمسات الاخيرة", "مطعم القصر الابيض للمأكولات", "مفروشات نبع الخليج" };

            BindingSource binding = new BindingSource();
            binding.DataSource = sponsors.ToList();
            cbSponsorship.DataSource = binding.DataSource;
        }

        private void LoadEmployeeList(string id)
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select id as ID, employee_code as `Employee Code`, employee_name as `Employee Name`, allocation_site as `Site NAME`, " +
                                                        "actual_job_title as `Actual Job`, nationality as `Nationality`, sponsorship as `Sponsorship`, joining_date as `Joining Date`, passport_number as `Passport NO.`, " +
                                                        "passport_issue_date as `Date Issued`, passport_expiry_date as `Date expiry`, residence_number as `RP Number`, residence_expiry_date as `RP Exp DATE` " +
                                                        "from employee", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgvEmployeeList.DefaultCellStyle.Font = new Font("Roboto", 10);
                dgvEmployeeList.DataSource = DS.Tables[0];

                //close connection
                this.CloseConnection();
            }
        }

        private void LoadEmployeesWithoutIDList(string id)
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select id as ID, employee_code as `Employee Code`, employee_name as `Employee Name`, allocation_site as `Site NAME`, " +
                                                        "actual_job_title as `Actual Job`, nationality as `Nationality`, passport_number as `Passport No.`, passport_issue_date as `Date Issued`, " +
                                                        "passport_expiry_date as `Date expiry`, doha_entry as `Doha Entry`, joining_date as `Joining Date`, DATEDIFF(NOW(), joining_date) AS `Days In Qatar` " +
                                                        "from employee", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgvEmployeesWithoutID.DefaultCellStyle.Font = new Font("Roboto", 10);
                dgvEmployeesWithoutID.DataSource = DS.Tables[0];

                //close connection
                this.CloseConnection();
            }
        }

        private void LoadHealthCardMonitoringList(string id)
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select id as ID, employee_code as `Employee Code`, employee_name as `Employee Name`, allocation_site as `Site Name`, " +
                                                        "nationality as `Nationality`, passport_number as `Passport No.`, residence_number AS `RP No.`, residence_expiry_date AS `RP Expiry Date`, " +
                                                        "health_card_number AS `HC Number`, health_card_expiry_date AS `HC Expiration Date` " +
                                                        "from employee", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgvHealthCardMonitoring.DefaultCellStyle.Font = new Font("Roboto", 10);
                dgvHealthCardMonitoring.DataSource = DS.Tables[0];

                //close connection
                this.CloseConnection();
            }
        }

        private void LoadLeaveMonitoringList(string id)
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select employee.id as ID, employee.employee_code as `Employee Code`, employee.employee_name as `Employee Name`, " +
                                                        "employee.actual_job_title AS `Actual Job Title`, employee_leave.leave_type, employee_leave.leave_start_date, employee_leave.leave_return_date, " +
                                                        "'' AS `Departure Date`, '' AS `Time`, 'OK' AS `RP Status` " +
                                                        "from employee LEFT JOIN employee_leave ON employee.employee_code = employee_leave.employee_code", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgvLeaveMonitoring.DefaultCellStyle.Font = new Font("Roboto", 10);
                dgvLeaveMonitoring.DataSource = DS.Tables[0];

                //close connection
                this.CloseConnection();
            }
        }

        private void LoadPassportMonitoringList(string id)
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select id as ID, employee_code as `Employee Code`, employee_name as `Employee Name`, allocation_site as `Site Name`, " +
                                                        "nationality as `Nationality`, passport_number as `Passport No.`, passport_issue_date as `Date Issued`, " +
                                                        "passport_expiry_date as `Date expiry`, residence_number as `RP No.`, residence_expiry_date as `RP Exp DATE` " +
                                                        "from employee", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgvPassportMonitoring.DefaultCellStyle.Font = new Font("Roboto", 10);
                dgvPassportMonitoring.DataSource = DS.Tables[0];

                //close connection
                this.CloseConnection();
            }
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

        private Employee AssignValues()
        {
            Employee employee = new Employee();
            if(lblId.Text != "")
            {
                employee.id = int.Parse(lblId.Text);
            }
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
            employee.doha_entry = dtpDohaEntry.Value.ToString("yyyy-MM-dd");
            employee.joining_date = dtpJoiningDate.Value.ToString("yyyy-MM-dd");
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
            employee.leave_days_per_year = float.Parse(cbDaysOfLeave.Text);
            employee.leave_credits = 0;
            employee.vacation_leave_days = float.Parse(cbDaysOfLeave.Text);
            employee.remarks = txtRemarks.Text;
            employee.contact_number = txtContactNumber.Text;
            string img_base64 = ImageToBase64(pbProfilePicture.Image);
            if(img_base64 != "")
            {
                employee.picture = ImageToBase64(pbProfilePicture.Image);
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
            // work category
            if (rbStaff.Checked == true)
            {
                employee.work_category = rbStaff.Text;
            }
            if (rbWorker.Checked == true)
            {
                employee.work_category = rbWorker.Text;
            }
            // cost allocation
            if (rbOffice.Checked == true)
            {
                employee.cost_allocation = rbOffice.Text;
            }
            if (rbSite.Checked == true)
            {
                employee.cost_allocation = rbSite.Text;
            }

            return employee;
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee employee = AssignValues();
            MessageBox.Show(employee.create());
            clearAll();
        }

        private void loadAllowancesGrid(string id)
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select date_submitted AS `Date Submitted`, effective_date AS `Effective Date`, allowance_type AS `Allowance Type`, allowance_amount AS `Allowance Amount` from employee_allowances where employee_code = '"+ id +"'", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgAllowances.DefaultCellStyle.Font = new Font("Roboto", 10);
                dgAllowances.DataSource = DS.Tables[0];

                lblAllowancesCount.Text = DS.Tables[0].Rows.Count.ToString();

                //close connection
                this.CloseConnection();
            }
        }

        private void loadSalaryIncreasesGrid(string id)
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select date_submitted AS `Date Submitted`, date_effective AS `Effective Date`, note AS `Note`, increase_amount AS `Increase Amount` from salary_increases where employee_code = '" + id + "'", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgvSalaryInceases.DefaultCellStyle.Font = new Font("Roboto", 10);
                dgvSalaryInceases.DataSource = DS.Tables[0];

                //close connection
                this.CloseConnection();
            }
        }

        private void loadEmployeeLeavesGrid(string id)
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString());

            if (this.OpenConnection() == true)
            {
                mySqlDataAdapter = new MySqlDataAdapter("select depart_date AS `Depart Date`, return_date AS `Return Date`, rejoining_date AS `Rejoining Date`, reason_for_vacation AS `Reason for Vacation`, days_of_vacation as `Days of Vacation` from employee_leaves where employee_code = '" + id + "'", connection);
                DataSet DS = new DataSet();
                mySqlDataAdapter.Fill(DS);
                dgvVacation.DefaultCellStyle.Font = new Font("Roboto", 10);
                dgvVacation.DataSource = DS.Tables[0];

                lblVacationCount.Text = DS.Tables[0].Rows.Count.ToString();

                //close connection
                this.CloseConnection();
            }
        }

        private void loadEmployeeRecords(string id)
        {
            ClearAllControls();

            using (MySqlConnection connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BGC.connectionstring"].ToString()))
            {
                MySqlCommand command = new MySqlCommand("select * from employee where employee_code = '"+ id +"'", connection);
                connection.Open();

                MySqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    lblId.Text = reader["id"].ToString();
                    // Gender
                    if (reader["gender"].ToString() == "Male")
                    {
                        rbMale.Checked = true;
                    }
                    if (reader["gender"].ToString() == "Female")
                    {
                        rbFemale.Checked = true;
                    }
                    // Work category
                    if (reader["work_category"].ToString() == "Staff")
                    {
                        rbStaff.Checked = true;
                    }
                    if (reader["work_category"].ToString() == "Worker")
                    {
                        rbWorker.Checked = true;
                    }
                    // Cost Allocation
                    if (reader["cost_allocation"].ToString() == "Office")
                    {
                        rbOffice.Checked = true;
                    }
                    if (reader["cost_allocation"].ToString() == "Site")
                    {
                        rbSite.Checked = true;
                    }
                    lblEmployeeName.Text = reader["employee_name"].ToString();
                    lblEmployeeCode.Text = reader["employee_code"].ToString();
                    txtEmployeeName.Text = reader["employee_name"].ToString();
                    txtEmployeeNumber.Text = reader["employee_code"].ToString();
                    txtContactNumber.Text = reader["contact_number"].ToString(); ;
                    txtRPNumber.Text = reader["residence_number"].ToString();
                    txtPassport.Text = reader["passport_number"].ToString();
                    txtBankName.Text = reader["bank_name"].ToString();
                    txtCardNumber.Text = reader["card_number"].ToString();
                    txtHCNumber.Text = reader["health_card_number"].ToString();
                    txtBasicSalary.Text = float.Parse(reader["basic_salary"].ToString()).ToString("#,###.00");
                    cbJobTitleAsJO.SelectedIndex = cbJobTitleAsJO.FindString(reader["job_title_per_offer"].ToString());
                    cbActualJobTitle.SelectedIndex = cbActualJobTitle.FindString(reader["actual_job_title"].ToString());
                    cbSponsorship.Text = reader["sponsorship"].ToString();
                    cbRecruitedBy.Text = ""; //reader["job_title_per_offer"].ToString();
                    cbTicket.Text = "";
                    cbNationality.Text = reader["nationality"].ToString();
                    cbBloodGroup.Text = ""; // reader["job_title_per_offer"].ToString();
                    cbDaysOfLeave.SelectedIndex = cbDaysOfLeave.FindString(reader["vacation_leave_days"].ToString());
                    cbSiteName.SelectedIndex = cbSiteName.FindString(reader["location_site"].ToString());
                    cbAccommodation.SelectedIndex = cbAccommodation.FindString(reader["accommodation"].ToString());
                    cbDegree.SelectedIndex = cbDegree.FindString(reader["degree"].ToString());
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
                        dtpJoiningDate.Value = DateTime.Parse(reader["joining_date"].ToString());
                        int total_days = Convert.ToInt32((DateTime.Now - DateTime.Parse(reader["joining_date"].ToString())).TotalDays);
                        int years = Convert.ToInt32((total_days / 365));
                        int months = Convert.ToInt32((total_days - (365 * years)) / 30);
                        int days = Convert.ToInt32((total_days - ((365 * years) + (30 * months))));
                        lblCurrentContract.Text = lblYearsInBoom.Text = "YEARS IN BOOM : "+ years +" YEARS, "+ months +" MONTHS, "+ days +" DAYS";
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
                    float total_salary_increase = 0;
                    for (int i = 0; i < dgvSalaryInceases.Rows.Count - 1; i++)
                    {
                        total_salary_increase += float.Parse(dgvSalaryInceases.Rows[i].Cells[3].Value.ToString());
                    }
                    txtTotalSalaryIncrease.Text = total_salary_increase.ToString("#,###.00");
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
            Employee employee = AssignValues();
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void DgvEmployeeList_DoubleClick(object sender, EventArgs e)
        {
            var RowsIndex = dgvEmployeeList.CurrentRow.Index;
            DataGridViewRow selectedRow = dgvEmployeeList.Rows[RowsIndex];

            string employee_id = selectedRow.Cells[1].Value.ToString();

            loadAllowancesGrid(employee_id);
            loadSalaryIncreasesGrid(employee_id);
            loadEmployeeLeavesGrid(employee_id);
            LoadEmployeeList(employee_id);
            loadEmployeeRecords(employee_id);

            tabControl1.SelectedIndex = 5;
        }

        private void BtnAddAllowance_Click(object sender, EventArgs e)
        {
            AddAllowance window = new AddAllowance(txtEmployeeNumber.Text);
            window.Show();
        }

        private void PbProfilePicture_MouseEnter(object sender, EventArgs e)
        {
            pbProfilePicture.Cursor = Cursors.Hand;
        }

        private void PbProfilePicture_MouseLeave(object sender, EventArgs e)
        {
            pbProfilePicture.Cursor = Cursors.Default;
        }

        private string ImageToBase64(Image image)
        {
            try
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void PbProfilePicture_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Images (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            if(filePath != "")
            {
                pbProfilePicture.Image = Image.FromFile(filePath);

            }
        }

        private void BtnAddSalaryIncreases_Click(object sender, EventArgs e)
        {
            AddSalaryIncrease window = new AddSalaryIncrease(txtEmployeeNumber.Text);
            window.Show();
        }

        private void EmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearAll();
            tabControl1.SelectedIndex = 5;
        }

        private void clearAll()
        {
            txtAge.Text = "";
            txtBankName.Text = "";
            txtBasicSalary.Text = "";
            txtCardNumber.Text = "";
            txtContactNumber.Text = "";
            txtEmployeeName.Text = "";
            txtEmployeeNumber.Text = "";
            txtHCNumber.Text = "";
            txtLocalHired.Text = "";
            txtPassport.Text = "";
            txtRemarks.Text = "";
            txtRPNumber.Text = "";
            txtStartingSalary.Text = "";
            txtTotalAllowances.Text = "";
            txtTotalSalary.Text = "";
            txtTotalSalaryIncrease.Text = "";
            cbAccommodation.SelectedIndex = 0;
            cbActualJobTitle.SelectedIndex = 0;
            cbBloodGroup.SelectedIndex = 0;
            cbDaysOfLeave.SelectedIndex = 0;
            cbDegree.SelectedIndex = 0;
            cbJobTitleAsJO.SelectedIndex = 0;
            cbNationality.SelectedIndex = 0;
            cbRecruitedBy.SelectedIndex = 0;
            cbSiteName.SelectedIndex = 0;
            cbSponsorship.SelectedIndex = 0;
            dgvSalaryInceases.DataSource = null;
            dgvVacation.DataSource = null;
            dgAllowances.DataSource = null;
            lblAllowancesCount.Text = "";
            lblVacationCount.Text = "";
            lblEmployeeCode.Text = "";
            lblEmployeeName.Text = "";
            lblSalaryIncreasesCount.Text = "";
        }

        private void RefreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadEmployeeList(employee_id);
            LoadEmployeesWithoutIDList(employee_id);
            LoadHealthCardMonitoringList(employee_id);
            LoadLeaveMonitoringList(employee_id);
            LoadPassportMonitoringList(employee_id);
        }
    }
}
