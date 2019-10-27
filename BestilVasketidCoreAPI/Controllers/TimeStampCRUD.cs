using BestilVasketidCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BestilVasketidCoreAPI.Controllers
{
    public class TimeStampCRUD
    {
        DBTools dbTools = new DBTools();
        internal List<TimeStamp> TimeStampList()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from [timestamp]");
            DataTable dataTable = dbTools.SQL2Datatable(cmd);
            if (dataTable.Rows.Count > 0) return dbTools.Datatable2List<TimeStamp>(dataTable);
            else return null;
        }

        internal TimeStamp ReadTimeStamp(int? id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * from [timestamp] WHERE id = @id");
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@ID"].Value = id;

            DataTable dataTable = dbTools.SQL2Datatable(cmd);
            if (dataTable.Rows.Count > 0) return dbTools.Datatable2List<TimeStamp>(dataTable)[0];
            else return null;
        }

    }
}
