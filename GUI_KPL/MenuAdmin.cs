using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apotekku_API.Models;

namespace GUI_KPL
{
    public partial class MenuAdmin : Form
    {
        private User _currentUser;

        public MenuAdmin(User user)
        {
            InitializeComponent();
            _currentUser = user;


            label2.Text = $"Halo, {_currentUser.Nama}";
            label3.Text = $"Selamat Bekerja, {_currentUser.Nama}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout berhasil.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //implementasi disini ya
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //implentasi disini
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //implentasi disini
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //implentasi disini
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //implentasi disini
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //implentasi disini
        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
