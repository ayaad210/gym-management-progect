using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using DataAccessLayer;

namespace GymBussines
{
    public class playerBl : DAL
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string gender { get; set; }
        public string age{ get; set; }
        public string Phone { get; set; }


        public playerBl()
        {

        }
        public playerBl(string x) : base(x)
        {

        }
        //insert
        public int PlayerInsert(playerBl Newplyer)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@Name", Newplyer.Name);
            p[1] = new SqlParameter("@gender",Newplyer.gender);
            p[2] = new SqlParameter("@age", Newplyer.age);
            p[3] = new SqlParameter("@Phone", Newplyer.Phone);



            return ExecNonQuery("Player_Add", para: p);
        }
        //Update 
        public int Player_Update(playerBl Player)
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@id", Player.ID);
            p[1] = new SqlParameter("@Name", Player.Name);
            p[2] = new SqlParameter("@gender", Player.gender);
            p[3] = new SqlParameter("@age", Player.age);
            p[4] = new SqlParameter("@Phone", Player.Phone);




            return ExecNonQuery("Player_Update", para: p);
        }
        //Delete
        public int Player_Delete(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Id", ID);

            return ExecNonQuery("players_Delete", para: p);
        }
        //Search

        //Read All
        public DataTable ReadAll()
        {
            return ExecReader("Player_GetAll");
        }
        //read By Id 
        public DataTable ReadByID(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id", ID);

            return ExecReader("Player_GetByID", para: p);
        }
        public DataTable Players_GetBy_RegisterDate(DateTime Registerdate)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@date", Registerdate.Date);

            return ExecReader("Players_GetBy_RegisterDate", para: p);
        }
        //Reab By Name 
        public DataTable Player_GetByName(string Name)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Name", Name);
           

            return ExecReader("Player_GetByName", para: p);
        }
    }
}
