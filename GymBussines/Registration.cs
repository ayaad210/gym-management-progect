
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
    public class RegestrationBl : DAL
    {
        public int Player_ID { get; set; }
        public DateTime RegisterDate { get; set; }
        public int registerPriod { get; set; }
        public int TrainerId { get; set; }
        public Decimal price { get; set; }
        public int TypeId { get; set; }
        public Decimal paid { get; set; }



        public RegestrationBl()
        {

        }
        public RegestrationBl(string x)
            : base(x)
        {

        }
        //insert
        public int Regstration_Insert(RegestrationBl NewRegestration)
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@PlayerId", NewRegestration.Player_ID);
            p[1] = new SqlParameter("@RegiterDate", NewRegestration.RegisterDate);

            p[2] = new SqlParameter("@RegiterPriod", NewRegestration.registerPriod);
            p[3] = new SqlParameter("@TrainerId", NewRegestration.TrainerId);
            p[4] = new SqlParameter("@price", NewRegestration.price);
            p[5] = new SqlParameter("@typeid", NewRegestration.TypeId);
            p[6] = new SqlParameter("@paid", NewRegestration.paid);



            return ExecNonQuery("Registration_Add", para: p);
        }

        //update

        public int Regestratoin_update(RegestrationBl NewRegestration)
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@PlayerId", NewRegestration.Player_ID);
            p[1] = new SqlParameter("@RegisterDate", NewRegestration.RegisterDate);

            p[2] = new SqlParameter("@regiterPriod", NewRegestration.registerPriod);
            p[3] = new SqlParameter("@TrainerID", NewRegestration.TrainerId);
            p[4] = new SqlParameter("@price", NewRegestration.price);
            p[5] = new SqlParameter("@Typeid", NewRegestration.TypeId);
            p[6] = new SqlParameter("@paid", NewRegestration.paid);



            return ExecNonQuery("Registeration_Update", para: p);
        }





        //Delete by id 
        public int Regestration_DeletebyDateID(RegestrationBl Reg)
        {

            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@PlayerId",Reg.Player_ID);
            
            p[1] = new SqlParameter("@RegisterDate", Reg.RegisterDate);
            p[2] = new SqlParameter("@typeid", Reg.TypeId);


            return ExecNonQuery("Registration_Delete", para: p);
        }
        //Delete by id 
        public DataTable GetByTrainerId(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@trainerid", ID);


            return ExecReader("GetByTrainerId", para: p);
        }
        //Search

        //Read All
        public DataTable ReadAll()
        {
            return ExecReader("registriton_GetByall");
        }
        //read By Id 
        public DataTable GetByPlayerID(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@playerid", ID);

            return ExecReader("registertion_GetByplayerID", para: p);
        }
        //Reab By RegesterDateDate
        public DataTable T_GetByRegisterDate(DateTime DayDate)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@regesterdate", DayDate.Date);



            return ExecReader("regetration_GetByregesterdate", para: p);
        }
        //Reab By endDate

        public DataTable Regester_GetByEndDate(DateTime DayDate)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@enddate", DayDate.Date);



            return ExecReader("regetration_GetByEndDate", para: p);
        }
        //read By date and Id 
        public DataTable regetration_GetByregesterBy_date_id_Typeid(int ID, DateTime DayDate,int typeid)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@regesterdate", DayDate.Date);
            p[1] = new SqlParameter("@playerid", ID);
            p[2] = new SqlParameter("@typeid", typeid);





            return ExecReader("[regetration_GetByregesterBy_date_id_Typeid]", para: p);
        }



    }


}
