using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public abstract class DAL
    {
        private readonly string _StrCon;
        public DAL()
        {

        }
        public DAL(string con)
        {
            _StrCon = con;
        }
        public string StrCon
        {
            get
            {
                return _StrCon;
            }
        }

        //CUD
        protected int ExecNonQuery(string cmdtext, CommandType cmdtype = CommandType.StoredProcedure, SqlParameter[] para = null)
        {
            using (SqlConnection con = new SqlConnection(_StrCon))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(cmdtext, con);
                cmd.CommandType = cmdtype;
                if (para != null)
                {
                    for (int i = 0; i < para.Length; i++)
                    {
                        cmd.Parameters.Add(para[i]);
                    }
                }
                return cmd.ExecuteNonQuery();
            }
        }
        //Read
        protected DataTable ExecReader(string cmdtext, CommandType cmdtype = CommandType.StoredProcedure, SqlParameter[] para = null)
        {
            using (SqlConnection con = new SqlConnection(_StrCon))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(cmdtext, con);
                cmd.CommandType = cmdtype;
                if (para != null)
                {
                    for (int i = 0; i < para.Length; i++)
                    {
                        cmd.Parameters.Add(para[i]);
                    }
                }
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }
        //Scalar
        protected object ExecScalar(string cmdtext, CommandType cmdtype = CommandType.StoredProcedure, SqlParameter[] para = null)
        {
            using (SqlConnection con = new SqlConnection(_StrCon))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(cmdtext, con);
                cmd.CommandType = cmdtype;
                if (para != null)
                {
                    for (int i = 0; i < para.Length; i++)
                    {
                        cmd.Parameters.Add(para[i]);
                    }
                }
                return cmd.ExecuteScalar();
            }
        }
    }
}
