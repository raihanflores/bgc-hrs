using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BGC_HRS.Models;

namespace BGC_HRS
{
    public partial class AddSalaryIncrease : Form
    {
        public AddSalaryIncrease(string employee_code)
        {
            InitializeComponent();
            txtEmployeeCode.Text = employee_code;
        }

        private SalaryIncrease AssignValues()
        {
            SalaryIncrease salary_increase = new SalaryIncrease();
            salary_increase.employee_code = txtEmployeeCode.Text;
            salary_increase.date_submitted = dtpSubmitted.Text;
            salary_increase.date_effective = dtpEffective.Text;
            salary_increase.note = txtNote.Text;
            salary_increase.increase_amount = float.Parse(txtIncreaseAmount.Value.ToString());

            return salary_increase;
        }

        private void BtnCreateSalaryIncrease_Click(object sender, EventArgs e)
        {
            SalaryIncrease salary_increase = AssignValues();
            MessageBox.Show(salary_increase.create());
        }

        private void AddSalaryIncrease_Load(object sender, EventArgs e)
        {
 
        }
    }
}
