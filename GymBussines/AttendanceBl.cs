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
public    class AttendanceBl:DAL
    {
        public int ID { get; set; }
        public string DayDate { get; set; }



        public AttendanceBl()
        {

        }
        public AttendanceBl(string x) : base(x)
        {

        }
        //insert
        public int AttendanceInsert(AttendanceBl NewAttendance)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@PlayerId", NewAttendance.ID);
            p[1] = new SqlParameter("@DayDate", NewAttendance.DayDate);



            return ExecNonQuery("Attendance_Add", para: p);
        }
    
        //Delete
        public int Attendance_Delete(int ID,DateTime DayDate)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@PlayerId", ID);
            p[1] = new SqlParameter("@dayDate", (DayDate.Date));


            return ExecNonQuery("attendance_Delete", para: p);
        }
        //Search

        //Read All
        public DataTable ReadAll()
        {
            return ExecReader("attendance_GetAll");
        }
        //read By Id 
        public DataTable ReadByPlayerID(int ID)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@plyerid", ID);

            return ExecReader("attendance_GetByPlyerID", para: p);
        }
        //Reab By type 
        public DataTable Attendance_GetByDayDate(DateTime DayDate)
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@DayDate", DayDate);



            return ExecReader("Attendance_GetByDayDate", para: p);
        }
        public DataTable Attendance_GetByDayDate_ID(int Id,DateTime DayDate)
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@DayDate", DayDate);
            p[1] = new SqlParameter("@PlayerId", Id);




            return ExecReader("Attendance_GetByDayDate_Id", para: p);
        }

    }


}

