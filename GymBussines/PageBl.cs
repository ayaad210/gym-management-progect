using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBussines
{
 public   class PageBl:DAL
    {
        public PageBl()
        {

        }
        public PageBl(String Con):base(Con)
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Name_Ar { get; set; }

        public DataTable ReadAll()
        {
            return ExecReader("Pages_GetAll");
        }
        public DataTable ReadByID(int id)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id", id); 
            return ExecReader("Pages_GetPageById",para:p);
        }

        public int InsertPageForUser(int Userid, int pageId)
        {
            SqlParameter[] p = new SqlParameter[2];

            p[0] = new SqlParameter("@Userid", Userid);
            p[1] = new SqlParameter("@Pageid", pageId);





            return ExecNonQuery("AddUserPages", para: p);
        }

        public int DeletePageByUsers(int ID,int pageid)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@userid", ID);
            p[1] = new SqlParameter("@pageid", pageid);


            return ExecNonQuery("DeletUserPages", para: p);
        }
        public DataTable ReadByPagesByUserID(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Userid", ID);

            return ExecReader("GetPagesByUserID", para: p);
        }


       public static bool IsUserAllowedToDoThisOption(int UserId,string OptionName)
        {
            
            DataTable dt = new PageBl(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString).ReadByPagesByUserID(UserId);
            foreach (DataRow item in dt.Rows)
            {
                if (item["Page Name"].ToString()==OptionName)
                {

                    return true;
                }
            }
            return false;
        }


    }
    
}
