using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBussines
{
    public class UserBl : DAL
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }



        public UserBl()
        {

        }
        public UserBl(string x) : base(x)
        {

        }
        //insert
        public int UserInsert(UserBl NewUserBl)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@Name", NewUserBl.Name);
            p[1] = new SqlParameter("@UserName", NewUserBl.UserName);

            p[2] = new SqlParameter("@Password", NewUserBl.Password);




            return ExecNonQuery("AddUser", para: p);
        }
        public int User_Delete(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id", ID);


            return ExecNonQuery("DeleteUser", para: p);
        }
       
        public int User_Update(UserBl user)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@id", user.ID);
            p[1] = new SqlParameter("@Name", user.Name);
            p[2] = new SqlParameter("@UserName", user.UserName);

            p[3] = new SqlParameter("@Password", user.Password);
           




            return ExecNonQuery("EditUser", para: p);
        }


        public DataTable ReadAll()
        {
            return ExecReader("Users_GetAll");
        }
 
        public DataTable ReadByByID(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id", ID);

            return ExecReader("GetUserByID", para: p);
        }


        public DataTable ReadByName(string name)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Name", name);

            return ExecReader("User_GetByName", para: p);
        }
        public DataTable ReadByUserName_Pass(string name,string password)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@usrName", name);
            p[1] = new SqlParameter("@Password", password);

            return ExecReader("User_GetByUserName_Password", para: p);
        }
        public int Users_CheckUserName(string UserName)
        {
            int x = 0;
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@UserName", UserName);
            int.TryParse(ExecScalar("Users_CheckUserName", para: p).ToString(), out x);
            return x;
        }
        public int Users_CheckUserNameForEdit(string UserName,int id)
        {
            int x = 0;
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@UserName", UserName);
            p[1] = new SqlParameter("@id", id);
            int.TryParse(ExecScalar("Users_CheckUserNameForEdit", para: p).ToString(), out x);
            return x;
        }
        public int IsUserHavePage(int userid, int pageid)
        {
            int x = 0;
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@Userid", userid);

            p[1] = new SqlParameter("@pageid", pageid);
            int.TryParse(ExecScalar("UsersPagesisContain", para: p).ToString(), out x);
            return x;
        }

        public int howMenyAdmin()
        {

            int x = 0;
            int.TryParse(ExecScalar("howMenyAdmin").ToString(), out x);
            return x;
        }

    }


}
