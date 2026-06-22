using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserActivity
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem.ToString() == "Yönetici")
            {
                lblPassword.Visible = true;
                txtPassword.Visible = true;
            }
            else
            {
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                txtPassword.Clear();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbRole.SelectedIndex = 0;
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir rol seçiniz.");
                return;
            }

            string secilenRol = cmbRole.SelectedItem.ToString();

            if (secilenRol == "Yönetici")
            {
                if (txtPassword.Text == "123")
                {
                    DashboardForm dashboard = new DashboardForm();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı şifre", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (secilenRol == "Çalışan")
            {
                Form1 trackerForm = new Form1();
                trackerForm.Show();
                trackerForm.Hide();
                this.Hide();
            }
        }
    }
}
