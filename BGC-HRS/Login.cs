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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ValidateLogin()
        {
            Users users = new Users();
            if (users.ValidateUsers(txtUsername.Text, txtPassword.Text))
            {
                Main window = new Main();
                window.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username/Password mismtch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtPassword_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyValue.Equals(13))
            {
                ValidateLogin();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ValidateLogin();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
