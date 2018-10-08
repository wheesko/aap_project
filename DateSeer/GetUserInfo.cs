using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateSeer
{
    class GetUserInfo
    {
        private string Name ;
        private string Email;
        private int Genre;
        private String Image;


        public GetUserInfo(string username)
        {
            string strConn = "Server=" + Environment.MachineName + "\\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";
            string sql = "SELECT * FROM dbo.logins_table WHERE Username ='" + username+"';";

            SqlConnection con = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {
                con = new SqlConnection(strConn);
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                SqlCommand command = con.CreateCommand();
                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            
           Name = dt.Rows[0]["Name"].ToString();
            Email = dt.Rows[0]["Email"].ToString();
            Genre = int.Parse(dt.Rows[0]["Genre"].ToString());
            Image = dt.Rows[0]["ImageName"].ToString();
          
           
            
        }
        public string getName()
        {
            return Name;
        }

        public int getGenre()
        {
            return Genre;
        }
        public string getImage()
        {
            return Image;
        }
        public string getEmail()
        {
            return Email;
        }
    }

}
