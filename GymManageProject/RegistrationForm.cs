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
using System.Data.SqlClient;

namespace GymManageProject
{
    public partial class RegistrationForm : Form
    {
        private string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        PriceBl objPriceDb;
        RegestrationBl objRejDb;
        RegestrationBl objRej;

        int id = 0;
        public RegistrationForm()
        {
            InitializeComponent();
        }
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            if (PageBl.IsUserAllowedToDoThisOption(LoginForm.Userid, this.Name) == false)
            {
                MessageBox.Show("ليست متاجة لك");
                this.Close();
            }
            else
            {
                objPriceDb = new PriceBl(ConStr);
                id = Convert.ToInt32(PlayerForm.selectedid);
                lblName.Text = new playerBl(ConStr).ReadByID(id).Rows[0]["Name"].ToString();
                fillCompoBoxes();
                objRejDb = new RegestrationBl(ConStr);
                SetDataGridView();
            }
        }
        
      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DateTime date = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["RegiterDate"].Value.ToString());
            int typeid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());

            SetDataToForm(id,date,typeid);
        }

        


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                #region Insert
                GetData();
                if (objRejDb.Regstration_Insert(objRej) > 0)
                {
                    lblAlert.alertSuccess();
                    Helper.clearText(this);
                    SetDataGridView();

                }
                else
                {
                    lblAlert.alertFailed();
                } 
                #endregion
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("لا تحجز نفس نوع التدريب لنفس تاريخ الحجز");
            }



}


        private void button3_Click(object sender, EventArgs e)
        {
            GetData();
            try
            {
                #region Update
                if (objRejDb.Regestratoin_update(objRej) > 0)
                {
                    lblAlert.alertSuccess();
                    Helper.clearText(this);
                    SetDataGridView();

                }
                else
                {
                    lblAlert.alertFailed();
                }
                #endregion
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("لا تحجز نفس نوع التدريب لنفس تاريخ الحجز");
            }

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal d = (decimal)(numPriod.Value / 30);
            int TypeId = 0;
            int.TryParse(cmbType.SelectedValue.ToString(),out TypeId);
            DataTable dt = objPriceDb.ReadByID(TypeId);
            if (dt.Rows.Count>0)
            {
                string c = dt.Rows[0][2].ToString();
             numPrice.Value = d * Convert.ToDecimal(c);
             }
          
     

        }


        //----------------------------------------------
        private void SetDataToForm(int iD, DateTime date, int typeid)
        {

            if (id != 0 && date != null)
            {
                DataTable RejDt = objRejDb.regetration_GetByregesterBy_date_id_Typeid(id, date, typeid);
                if (RejDt.Rows.Count > 0)
                {
                    dateTimePicker1.Value = DateTime.Parse(RejDt.Rows[0]["RegiterDate"].ToString());
                    cmbTrainer.SelectedValue = RejDt.Rows[0]["TrainerId"].ToString();
                    cmbType.SelectedValue = RejDt.Rows[0]["Tybeid"].ToString();
                    numPriod.Value = decimal.Parse(RejDt.Rows[0]["RegiterPriod"].ToString());
                    numPrice.Value = decimal.Parse(RejDt.Rows[0]["price"].ToString());
                    numPaid.Value = decimal.Parse(RejDt.Rows[0]["paid"].ToString());

                }

            }
        }
        private void SetDataGridView()
        {
            DataTable dt = objRejDb.GetByPlayerID(id);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false;


        }
        private void GetData()
        {

            objRej = new RegestrationBl();
            objRej.TrainerId = int.Parse(cmbTrainer.SelectedValue.ToString());
            objRej.TypeId = int.Parse(cmbType.SelectedValue.ToString());
            objRej.RegisterDate = dateTimePicker1.Value;
            objRej.price = numPrice.Value;
            objRej.registerPriod = Convert.ToInt32(numPriod.Value);
            objRej.Player_ID = id;
            objRej.paid = numPaid.Value;
        }

        private void fillCompoBoxes()
        {
            DataTable dt = new DataTable();
            TrainerBl objTrainerDb = new TrainerBl(ConStr);
            
            dt = objTrainerDb.ReadAll();

            Helper.FillComb(cmbTrainer, dt, "Name", "id");


            dt = new DataTable();
            dt = objPriceDb.ReadAll();
            Helper.FillComb(cmbType, dt, "Type", "id");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"هل انت متاكد من الحذف؟", " حذف دورة ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GetData();
                objRejDb.Regestration_DeletebyDateID(objRej);
                SetDataGridView();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
