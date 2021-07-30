using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymBussines;
using System.Configuration;

namespace GymManageProject
{
    public partial class PlayerEditForm : Form
    {
        int id;
        private string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        playerBl PlayerDb;
        playerBl newplayer = new playerBl();

        public PlayerEditForm()
        {
            InitializeComponent();
        }
        private void PlayerEdit_Load(object sender, EventArgs e)
        {
            if (PageBl.IsUserAllowedToDoThisOption(LoginForm.Userid, this.Name) == false)
            {
                MessageBox.Show("ليست متاجة لك");
                this.Close();
            }
            else
            {
                PlayerDb = new playerBl(ConStr);
                id = Convert.ToInt32(PlayerForm.selectedid);
                SetDataToForm();
            }        
        }

        private void SetDataToForm()
        {
            DataTable Playerdt = PlayerDb.ReadByID(id);
            if (Playerdt.Rows.Count>0)
            {
                txtID.Text=    Playerdt.Rows[0][0].ToString();
                txtName.Text = Playerdt.Rows[0][1].ToString();
               string s= Playerdt.Rows[0][2].ToString();
                cmbGnder.SelectedText = s;

               
               txtAge.Text = Playerdt.Rows[0][3].ToString();
                txtPhone.Text = Playerdt.Rows[0][4].ToString();

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        void GetDate()
        {
            newplayer.ID =Convert.ToInt32( txtID.Text);
            newplayer.Name = txtName.Text;
            newplayer.age = txtAge.Text;
            newplayer.Phone = txtPhone.Text;

            if (cmbGnder.SelectedIndex==0)
            {
            newplayer.gender = "ذكر";

            }
            else
            {
                newplayer.gender = "انثى";

            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetDate();
            if (newplayer.ID!=0)
            {
                if (PlayerDb.Player_Update(newplayer)>0)
                {
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("حدث خطأ");
                }
               
            }
            newplayer = new playerBl();
            this.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"هل انت متاكد من الحذف؟", " حذف متدرب ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                PlayerDb.Player_Delete(id);
                this.Close();
            }
        }
    }
}
