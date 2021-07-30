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
    public partial class AddEditUserForm : Form
    {      private string ConStr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        int id;
        UserBl objUserDb;
        UserBl objUser;

        public AddEditUserForm()
        {
            InitializeComponent();
        }

        private void AddEditUserForm_Load(object sender, EventArgs e)
        {
         
                objUserDb = new UserBl(ConStr);
            objUser = new UserBl();

            id =int.Parse(UsersControll.selectedid);

            if (id>0)
            {
                btnEddit.Visible = true;
                btnDelete.Visible = true;
                btnAdd.Visible = false;
              
              SetDataToForm(id);
            }
           
        }

        private void SetDataToForm(int id)
        {
            DataTable   dt=   objUserDb.ReadByByID(id);
            txtID.Text = dt.Rows[0]["id"].ToString();
            txtName.Text = dt.Rows[0]["Name"].ToString();
            txtUsrName.Text = dt.Rows[0]["UserName"].ToString();
            txtPass.Text= dt.Rows[0]["Password"].ToString();
            txtPassConfirm.Text = dt.Rows[0]["Password"].ToString();

        }

        private void btnEddit_Click(object sender, EventArgs e)
        {            GetData();

            if (CheckData("Eddit"))
            {
                if (objUserDb.User_Update(objUser)>0)
                {
                    MessageBox.Show("تم بنجاح");
                       this.Close();
                }
                else
                {
                    lblalert.alertFailed();
                }
            }
         
        }

        private bool CheckData(string option="Add")
        {
            bool b = true;
            if (txtPass.Text != txtPassConfirm.Text )
            {
            lblalert.alertFailed(" كلمة المرور لاتتطابق ");
                b = false;
            }
            if (objUserDb.Users_CheckUserName(txtUsrName.Text)==0&&option=="Add"|| objUserDb.Users_CheckUserNameForEdit(txtUsrName.Text,id) == 0 && option == "Eddit")
            {
                lblalert.alertFailed(" جرب اسم مستخدم اخر");
                b = false;
            }
            if (!(txtPass.Text != "" && txtUsrName.Text != "" && txtName.Text != ""))
            {
                lblalert.alertFailed(" ادخل البيانات كاملة");
                b = false;
            }

            return b;
        }

        private void GetData()
        {
            objUser.ID = id;
            objUser.Name = txtName.Text;
            objUser.UserName = txtUsrName.Text;
            objUser.Password = txtPass.Text;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetData();
            if (CheckData())
            {
                if (objUserDb.UserInsert(objUser) > 0)
                {
                    MessageBox.Show("تم بنجاح");
                    this.Close();
                }
                else
                {
                    lblalert.alertFailed();
                }
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"هل انت متاكد من الحذف؟", "حذف مستخدم", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                if (PageBl.IsUserAllowedToDoThisOption(id,"UsersControll"))
                {
                    if ( objUserDb.howMenyAdmin() >= 2)
                    {
                        objUserDb.User_Delete(id);

                    }
                }
                else
                {
                    objUserDb.User_Delete(id);

                }


            }
        }
    }
}
