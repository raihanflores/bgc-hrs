using BGC_HRS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGC_HRS
{
    public partial class AddAllowance : Form
    {
        public AddAllowance(string employee_code)
        {
            InitializeComponent();
            txtEmployeeCode.Text = employee_code;
        }

        private Allowances AssignValues()
        {
            Allowances allowances = new Allowances();
            allowances.employee_code = txtEmployeeCode.Text;
            allowances.allowance_type = txtAllowanceType.Text;
            allowances.allowance_amount = txtAllowanceAmount.Value.ToString();
            allowances.submitted = dtpSubmitted.Text;
            allowances.effective = dtpEffective.Text;

            return allowances;
        }


        private void BtnCreateAllowance_Click(object sender, EventArgs e)
        {
            Allowances allowances = AssignValues();
            MessageBox.Show(allowances.create());
        }

        private void AddAllowance_Load(object sender, EventArgs e)
        {
            Allowances allowances = AssignValues();
        }

        private void AddAllowance_Load_1(object sender, EventArgs e)
        {

        }
    }
}
