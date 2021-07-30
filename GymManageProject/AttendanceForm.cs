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
    public partial class AttendanceForm : Form
    {
        private string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        int id=0;
       RegestrationBl objRegDb;
        AttendanceBl objAttDb;
        public AttendanceForm()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            objRegDb = new RegestrationBl(ConStr);
            objAttDb = new AttendanceBl(ConStr);
    //         id=     Convert.ToInt32(  PlayerForm.selectedid);

            if (id!=0)
            {
                label2.Text = new playerBl(ConStr).ReadByID(id).Rows[0][1].ToString();
                DataTable Regdt =    objRegDb.GetByPlayerID(id);
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn() { ColumnName = " اليوم" }, new DataColumn() { ColumnName = "تارخ اليوم" }, new DataColumn() { ColumnName = "حاضر"  } });
                TimeSpan ts = ((DateTime)Regdt.Rows[0]["EndDate"]) - ((DateTime)Regdt.Rows[0]["RegiterDate"]); 
                 DateTime day = ((DateTime)Regdt.Rows[0]["RegiterDate"]);
                
                for (int i = 0; i<=  ts.TotalDays; i++)
                {
                   
                    DataRow dr = dt.NewRow();
                    dr[0] = day.DayOfWeek.ToString();
                    dr[1] = day.Date.ToString();
                    DataTable Attdt = objAttDb.Attendance_GetByDayDate_ID(id, day);
                    if (Attdt.Rows.Count>0)
                    {
                        dr[2] = "حاضر";
                       
                        Attdt = new DataTable();
                    }
                    else
                    {
                        dr[2] = "لم يسجل";

                    }
                    day =   day.AddDays(1);
                    dt.Rows.Add(dr);
                }

                dataGridView1.DataSource = dt;     
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==2&&id!=0)
            {
                AttendanceBl att = new AttendanceBl() { ID = id, DayDate = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningRow.Cells[1].Value.ToString()};
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()=="حاضر")
                {
                    objAttDb.Attendance_Delete(att.ID, DateTime.Parse(att.DayDate));
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "لم يسجل";
                }
                else
                {
                    objAttDb.AttendanceInsert(att);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "حاضر";

                }

            }
        }
    }
}
