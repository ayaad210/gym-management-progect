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
    public partial class PricesForm : Form
    {
        private string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        PriceBl PriceDb;
        PriceBl objPrice;

        public PricesForm()
        {
            InitializeComponent();
        }

        private void PricesForm_Load(object sender, EventArgs e)
        {

            if (PageBl.IsUserAllowedToDoThisOption(LoginForm.Userid, this.Name) == false)
            {
                MessageBox.Show("ليست متاجة لك");
                this.Close();
            }
            else
            {
                PriceDb = new PriceBl(ConStr);
                SetGridView();
            }
        }

        private void SetGridView()
        {
            dataGridView1.DataSource = PriceDb.ReadAll();
            Helper.clearText(this);
            numPrice.Value =0;
        }

        private void    Getdate()
        {
            objPrice = new PriceBl();
            int d;
            if ( int.TryParse(txtId.Text, out d) )
            {
                objPrice.ID = d;
               
            }
           objPrice.Type = txtName.Text;
                objPrice.Price = numPrice.Value;
            
        }
    
        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            Getdate();
            
            if (PriceDb.Prices_Update(objPrice) > 0)
            {
                lblalert.ForeColor = Color.Green;
                lblalert.Text = "تم التعديل";
                SetGridView();
            }
            else
            {
                lblalert.ForeColor = Color.Red;
                lblalert.Text = "حدث خطا";
            }
          

            objPrice = new PriceBl();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Getdate();
            if (PriceDb.PricerInsert(objPrice)>0)
            {
                lblalert.ForeColor = Color.Green;
                lblalert.Text = "تم الحفظ";
                SetGridView();
            }
            else
            {
                lblalert.ForeColor = Color.Red;
                lblalert.Text = "حدث خطا";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"هل انت متاكد من الحذف؟", "حذف نوع تدريب ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Getdate();
                PriceDb.Prices_Delete(objPrice.ID);
                SetGridView();


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                numPrice.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

            }
            catch (Exception)
            {

            }
        }
    }
}
