using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using GymBussines;
namespace GymManageProject
{
    public partial class AddPlayerForm : Form
    {
        public AddPlayerForm()
        {
            InitializeComponent();
        }

        private void AddPlayer_Load(object sender, EventArgs e)
        {
            if (PageBl.IsUserAllowedToDoThisOption(LoginForm.Userid, this.Name) == false)
            {
                MessageBox.Show("ليست متاجة لك");
                this.Close();
            }
        }
          
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text!="")
            {
                playerBl newPlayer = new playerBl(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
                newPlayer.Name = txtName.Text;
                newPlayer.age = txtAge.Text;
                newPlayer.Phone = txtPhone.Text;
                if (cmbGnder.SelectedIndex==1)
                {
                    newPlayer.gender = "انثى";
                }
                else
                {
                    newPlayer.gender = "ذكر";


                }

                if (newPlayer.PlayerInsert(newPlayer)>0)
                {
                    label1.alertSuccess();
                    MessageBox.Show("نم  بنجاح");
                    this.Close();
                }
                else
                {
                    label1.alertFailed();
                }
            }
            else
            {
                label1.alertFailed("ادخل اسما");

            }

        }
    }
}
