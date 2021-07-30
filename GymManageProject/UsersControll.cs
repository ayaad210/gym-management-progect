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
using GymBussines;

namespace GymManageProject
{
    public  partial class UsersControll : Form
    {   private string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        UserBl objUserDb;
        public static string selectedid = "0";

        
        public UsersControll()
        {
            InitializeComponent();
        }

        private void UsersControll_Load(object sender, EventArgs e)
        {
            if (PageBl.IsUserAllowedToDoThisOption(LoginForm.Userid, this.Name) == false)
            {
                MessageBox.Show("ليست متاجة لك");
                this.Close();
            }
            else
            {

                objUserDb = new UserBl(ConStr);
                SetDataGridView();
            }
        }

        private void SetDataGridView(DataTable dt = null)
        {
            dt = new DataTable();

            if (txtSearch.Text != "")
            {
                #region Search
                dt.Clear();
                    dt = objUserDb.ReadByName(txtSearch.Text);
                   #endregion

            }
            else
            {
                dt = objUserDb.ReadAll();
            }
            dt.Columns.Add(new DataColumn() { ColumnName = "تعديل", DefaultValue = "تعديل" });

            dt.Columns.Add(new DataColumn() { ColumnName = "التحكم", DefaultValue = "تحكم" });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            if (dataGridView1.Rows.Count < 10)
            {

                dataGridView1.Height = dataGridView1.Rows.Count * 30+ 30;
            }
            else
            {
                dataGridView1.Height = 288;

            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedid = dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString();

            if (e.ColumnIndex == 4)
                {
                    new AddEditUserForm().ShowDialog();
                }
                if (e.ColumnIndex == 5)
                {

                    new UserPagesForm().ShowDialog();
                }
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            SetDataGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetDataGridView();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            selectedid = "0";
            new AddEditUserForm().Show();

        }
    }
}
