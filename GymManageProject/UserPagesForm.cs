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
    public partial class UserPagesForm : Form
    {
        private string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        PageBl objPageDb;
        private static int UserId;
        List<PageBl> list = new List<PageBl>();
        public UserPagesForm()
        {
            InitializeComponent();
        }




        private void UserPagesForm__Load(object sender, EventArgs e)
        {
         
                UserId = int.Parse(UsersControll.selectedid);

                objPageDb = new PageBl(ConStr);

                SetData();


            

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Helper.MoveListBoxItems(listBoxOages, listboxUsers);


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Helper.MoveListBoxItems(listboxUsers, listBoxOages);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

          
            foreach (DataRow item in objPageDb.ReadAll().Rows)
            {
                if
                (
          new UserBl(ConStr).IsUserHavePage(UserId, int.Parse(item["id"].ToString())) > 0&& listBoxOages.Items.Contains(item["Page Name_ar"].ToString())
                )
                {
                    objPageDb.DeletePageByUsers(UserId, int.Parse(item["id"].ToString()));

                }
                 if
                     (  new UserBl(ConStr).IsUserHavePage(UserId, int.Parse(item["id"].ToString())) <=0&& listboxUsers.Items.Contains(item["Page Name_ar"].ToString())                )
                {
                    objPageDb.InsertPageForUser(UserId, int.Parse(item["id"].ToString()));

                }

            }

                MessageBox.Show("تم بنجاح");
                SetData();

            

        }


        private void SetData()
        {
            listboxUsers.Items.Clear();
            listBoxOages.Items.Clear();

            foreach (DataRow item in objPageDb.ReadAll().Rows)
            { 
                if (new UserBl(ConStr).IsUserHavePage(UserId,int.Parse(item["id"].ToString()))>0)
                {
                    listboxUsers.Items.Add(item["Page Name_ar"].ToString());
                }
                else
                {
                listBoxOages.Items.Add(item["Page Name_ar"].ToString());

                }

            }

        }
    }
}
