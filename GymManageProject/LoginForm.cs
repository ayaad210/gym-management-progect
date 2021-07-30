using GymBussines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace GymManageProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public static int Userid = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "" && txtPass.Text != "")
            {
                string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

                DataTable dt = new UserBl(ConStr).ReadByUserName_Pass(txtUserName.Text, txtPass.Text);
                if (dt.Rows.Count > 0)
                {
                    Userid =int.Parse( dt.Rows[0]["id"].ToString());
                    new Home().Show();
                    this.Hide();
                    dt.Rows.Clear();
                    Helper.clearText(this);



                }
                else
                {
                    MessageBox.Show("اسم المستخدم او الباسودر خاطئ");
                    txtPass.Text = "";
                }
            }
            else
            {
                MessageBox.Show("يجب ادخال البيانات");

            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
