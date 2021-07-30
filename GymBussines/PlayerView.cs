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

public    class PlayerView  :DAL
    {
        public PlayerView(string x) :base(x)
        {

        }
        public DataTable ReadAll()
        {
            return ExecReader("PlayerView_GetAll");
        }
        //read By Id 
    
        public DataTable PlayerView_GetBy_RegisterDate(DateTime Registerdate)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@date", Registerdate.Date);

            return ExecReader("PlayerView_GetBy_RegisterDate", para: p);
        }
        //Reab By Name 
        public DataTable PlayerView_GetByName(string Name)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Name", Name);


            return ExecReader("PlayerView_GetByName", para: p);
        }
        public DataTable PlayerView_GetBy_RegisterType(String Type)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@type", Type);

            return ExecReader("PlayerView_GetByType", para: p);
        }

    }
}
