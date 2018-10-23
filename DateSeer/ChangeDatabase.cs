using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSeer
{
    class ChangeDatabase
    {
        public ChangeDatabase(string picturePath, User user)
        {
            string strConn = "Server=" + Environment.MachineName + "\\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";
            string sql = "UPDATE dbo.logins_table SET ImageName ='" + picturePath + "'WHERE Username='" + user.username + "'";

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
        public ChangeDatabase(int MainId, int Id)
        {
            string strConn = "Server=" + Environment.MachineName + "\\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";
            string sql = @"Insert into dbo.UsedIDs(ID, UsedID)
                          Values("+MainId+","+Id+")";

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
