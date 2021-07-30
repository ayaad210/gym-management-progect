using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManageProject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {




        }

        private void button3_Click(object sender, EventArgs e)
        {
            new PlayerForm().Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new UsersControll().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new PricesForm().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new TrainerForm().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UsersControll.selectedid = LoginForm.Userid.ToString();
         
            new AddEditUserForm().Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
        }
    }
}
