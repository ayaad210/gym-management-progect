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
using System.Data.SqlClient;
using System.Configuration;
namespace GymManageProject
{//   privent header selection 
    public partial class PlayerForm : Form
    {
        private string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        public static string selectedid = "";

        public PlayerForm()
        {

            InitializeComponent();

        }       
        playerBl objPlyerDb;
        private void Form1_Load(object sender, EventArgs e)
        {
          if(  PageBl.IsUserAllowedToDoThisOption(LoginForm.Userid, this.Name)==false)
            {
                MessageBox.Show("ليست متاجة لك");
                this.Close();
            }
            else
            {
                objPlyerDb = new playerBl(ConStr);

                SetDataGridView();
            }
        }

   

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    selectedid = dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
                    new RegistrationForm().ShowDialog();
                }
                if (e.ColumnIndex == 6)
                {
                    selectedid = dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString();
                    PlayerEditForm _PlayerEditForm = new PlayerEditForm();
                    _PlayerEditForm.ShowDialog();

                }
            }
            catch (Exception)
            {

             }
        }
   


        private void btnSearch_Click(object sender, EventArgs e)
        {

            SetDataGridView();

        }

        private void SetDataGridView(DataTable dt = null)
        {
            dt = new DataTable();

            if (txtSearch.Text != "")
            {
                #region Search

                DateTime date;
                if (DateTime.TryParse(txtSearch.Text, out date))
                {
                    dt.Clear();
                    dt = objPlyerDb.Players_GetBy_RegisterDate(date);
                }


                else
                {
                    dt.Clear();
                    dt = objPlyerDb.Player_GetByName(txtSearch.Text);
                }

                #endregion

            }
            else
            {
                dt = objPlyerDb.ReadAll();
            }

            dt.Columns.Add(new DataColumn() { ColumnName = "الدورات التدريبية", DefaultValue = "الدورات التدريبية" });
            dt.Columns.Add(new DataColumn() { ColumnName = "تعديل", DefaultValue = "تعديل" });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText="عمر اللاعب";
            dataGridView1.Columns[1].HeaderText = "اسم اللاعب";
            dataGridView1.Columns[4].HeaderText = "الموبايل";

            lblNumber.Text = "  "+ dataGridView1.Rows.Count.ToString() + " متدربين ";
            if (dataGridView1.Rows.Count < 13)
            {

                dataGridView1.Height = dataGridView1.Rows.Count * 30 + 30;
            }
            else
            {
                dataGridView1.Height = 370;

            }

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPlayerForm F1 = new AddPlayerForm();
            F1.ShowDialog();
           
        }

       

        private void انواعالتدريبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PricesForm().Show();
        }

        private void المدربينToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new TrainerForm().Show();

        }

        private void تقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            SetDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
