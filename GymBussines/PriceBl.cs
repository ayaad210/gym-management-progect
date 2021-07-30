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
    public class PriceBl : DAL
    {
        public int ID { get; set; }
        public string Type { get; set; }
        
        public decimal Price { get; set; }


        public PriceBl()
        {

        }
        public PriceBl(string x) : base(x)
        {
            
        }
        //insert
        public int PricerInsert(PriceBl Newprice)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@type", Newprice.Type);
            p[1] = new SqlParameter("@price", Newprice.Price);
     


            return ExecNonQuery("Prices_Add", para: p);
        }
        //Update 
        public int Prices_Update(PriceBl price)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@id", price.ID);
            p[1] = new SqlParameter("@type", price.Type);
            p[2] = new SqlParameter("@price", price.Price);

           



            return ExecNonQuery("prices_Update", para: p);
        }
        //Delete
        public int Prices_Delete(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Id", ID);

            return ExecNonQuery("Prices_Delete", para: p);
        }
        //Search

        //Read All
        public DataTable ReadAll()
        {
            return ExecReader("price_GetAll");
        }
        //read By Id 
        public DataTable ReadByID(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id", ID);

            return ExecReader("Price_GetByID", para: p);
        }
        //Reab By type 
        public DataTable Prices_GetByType(string type)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@type" , type);


            return ExecReader("price_GetByType", para: p);
        }
    }
}
