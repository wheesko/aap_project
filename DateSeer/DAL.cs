using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DateSeer
{
    public static class DAL
    {
        public static DataTable executeStoredProcedure(string spName, List<SqlParameter> sqlParams = null){

            string strConn = "Server=DESKTOP-39HKRUP\\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";

            SqlConnection conn = new SqlConnection();

            DataTable dt = new DataTable();

            try
            {
                //connect to db
                conn = new SqlConnection(strConn);
                conn.Open();

                //make sql query
                SqlCommand cmd = new SqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange((sqlParams).ToArray());

                //Execute command
                SqlCommand command = conn.CreateCommand();
                SqlDataReader dr = cmd.ExecuteReader();

                //Load results to data table
                dt.Load(dr);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return dt;

        }
    }
}
