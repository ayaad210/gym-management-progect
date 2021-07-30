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
    public class TrainerBl:DAL
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public string Gender { get; set; }



        public TrainerBl()
        {

        }
        public TrainerBl(string x) : base(x)
        {

        }
        //insert
        public int TrainerInsert(TrainerBl NewTrainer)
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@Name", NewTrainer.Name);
            p[1] = new SqlParameter("@phone", NewTrainer.phone);
            p[2] = new SqlParameter("@gender", NewTrainer.Gender);



            return ExecNonQuery("trainer_Add", para: p);
        }

        public int trainer_Delete(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Id", ID);


            return ExecNonQuery("trainers_Delete", para: p);
        }
        //Search
        public int Trainer_Update(TrainerBl trainer)
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@id", trainer.ID);
            p[1] = new SqlParameter("@Name", trainer.Name);
            p[2] = new SqlParameter("@phone", trainer.phone);
            p[3] = new SqlParameter("@gender", trainer.Gender);




            return ExecNonQuery("trainer_Update", para: p);
        }
        public DataTable ReadAll()
        {
            return ExecReader("trainer_GetAll");
        }
        public DataTable ReadByTrainerID(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@id", ID);

            return ExecReader("Trainers_GetAllById", para: p);
        }

        public DataTable ReadByTrainerName(string name)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Name", name);

            return ExecReader("Trainers_GetAllByName", para: p);
        }


    }


}
