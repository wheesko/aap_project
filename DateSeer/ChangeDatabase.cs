using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSeer
{
    class ChangeDatabase
    {
        public ChangeDatabase(string picturePath, User user)
        {
            string strConn = "Server=" + Environment.MachineName + "\\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";
            string sql = "UPDATE dbo.logins_table SET ImageName ='" + picturePath + "'WHERE Username='" + user.getUsername() + "'";

            SqlConnection con = new SqlConnection();

            try
            {
                con = new SqlConnection(strConn);
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                SqlCommand command = con.CreateCommand();
                SqlDataReader dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }


        }
    }
}
