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
using GymBussines;
namespace GymManageProject
{
    public partial class TrainerForm : Form
    {
        private string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
     private   TrainerBl trainerDb;
        TrainerBl ObjTRainer = new TrainerBl();

        DataTable dt = new DataTable();
        public TrainerForm()
        {
            InitializeComponent();
        }

        private void TrainerForm_Load(object sender, EventArgs e)
        {
            if (PageBl.IsUserAllowedToDoThisOption(LoginForm.Userid, this.Name) == false)
            {
                MessageBox.Show("ليست متاجة لك");
                this.Close();
            }
            else
            {
                SetDataGrid();
                cmbGender.SelectedIndex = 0;
            }
        }

        private void SetDataGrid()
        {
            trainerDb = new TrainerBl(ConStr);
            if (txtSearch.Text!="")
            {
                dt = trainerDb.ReadByTrainerName(txtSearch.Text);

            }
            else
            {
            dt = trainerDb.ReadAll();

            }
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try {
                string x = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                int id = Convert.ToInt32(x);

                SetDataToForm(id);
            }catch
            {

            }
               
            
        }

        private void SetDataToForm(int id)
        {

            if (id>0)
            {
                DataTable TrainerDT = trainerDb.ReadByTrainerID(id);
                if (TrainerDT.Rows.Count > 0)
                {
                    txtID.Text = TrainerDT.Rows[0][0].ToString();
                    txtName.Text = TrainerDT.Rows[0][1].ToString();
                    txtPHONE.Text = TrainerDT.Rows[0][2].ToString();

                    cmbGender.Text = null;
                    cmbGender.SelectedText = TrainerDT.Rows[0][3].ToString(); ;
                }

            }
        }
        
        private void GetData()
        { 
            
            if(cmbGender.SelectedIndex==1)
            {
                ObjTRainer.Gender = "انثى";
            }
            else
            {
               
                    ObjTRainer.Gender = "ذكر";
                
            }

            ObjTRainer.Name = txtName.Text;
            int d=0 ;
            
                int.TryParse(txtID.Text,out d);
            ObjTRainer.ID = d;
            ObjTRainer.phone = txtPHONE.Text ;


          
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetData();

            if (txtName.Text!="")
            {
                if (trainerDb.TrainerInsert(ObjTRainer) > 0)
                {
                    label4.alertSuccess();
                    SetDataGrid();
                    Helper.clearText(this);

                }
                else
                {
                    label4.alertFailed();
                }

            }
            else
            {
                label4.ForeColor = Color.Green;
                label4.Text = "لا يوجد اسم";
            }
            ObjTRainer = new TrainerBl();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            GetData();
            if (txtName.Text != "")
            {
                if (trainerDb.Trainer_Update(ObjTRainer) > 0)
                {
                    label4.alertSuccess();
                    SetDataGrid();
                    Helper.clearText(this);
                }
                else
                {
                    label4.alertFailed();
                }

            }
            else
            {
                label4.ForeColor = Color.Green;
                label4.Text = "لا يوجد اسم";
            }
            ObjTRainer = new TrainerBl();

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"هل انت متاكد من الحذف؟", "حذف مدرب ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GetData();

                trainerDb.trainer_Delete(ObjTRainer.ID);
                SetDataGrid();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetDataGrid();

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            SetDataGrid();
        }
    }
}
