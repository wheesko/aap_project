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
        private int id;
        private string Name ;
        private string Email;
        private int Gender;
        private string Image;
        private string Username;

        public GetUserInfo()
        {

        }
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
            Gender = int.Parse(dt.Rows[0]["Gender"].ToString());
            Image = dt.Rows[0]["ImageName"].ToString();
            id = int.Parse(dt.Rows[0]["ID"].ToString());
            Username = dt.Rows[0]["Username"].ToString();
        }
        public GetUserInfo(int gender, int ids, int z)
        {
            string strConn = "Server=" + Environment.MachineName + "\\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";
            string sql = @"With nereikalingi As (
            SELECT dbo.UsedIDs.UsedID AS 'ID'
            FROM dbo.logins_table INNER JOIN
            dbo.UsedIDs ON dbo.logins_table.ID = dbo.UsedIDs.UsedID
            Where dbo.UsedIDs.ID = "+ids+"),Reikalingi AS( Select ID From dbo.logins_table        EXCEPT        Select ID From nereikalingi)       Select top 1 * from dbo.logins_table JOIN Reikalingi   ON    Reikalingi.ID = dbo.logins_table.id      Where Gender ="+gender;
            SqlConnection cdon = new SqlConnection();
            DataTable dt = new DataTable();
            try
            {
                cdon = new SqlConnection(strConn);
                cdon.Open();

                SqlCommand cmd = new SqlCommand(sql, cdon);

                SqlCommand command = cdon.CreateCommand();
                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cdon.Close();
            }
            try
            {
                Name = dt.Rows[0]["Name"].ToString();
                Email = dt.Rows[0]["Email"].ToString();
                Gender = int.Parse(dt.Rows[0]["Gender"].ToString());
                Image = dt.Rows[0]["ImageName"].ToString();
                id = (int)dt.Rows[0]["ID"];
                Username = dt.Rows[0]["Username"].ToString();

            }
            catch (Exception ex)
            {

            }

        }

        public string getUsername()
        {
            return Username;
        }

        public GetUserInfo(int id, int v)
        {
            string strConn = "Server=" + Environment.MachineName + "\\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";
            string sql = "SELECT * FROM dbo.logins_table WHERE ID ='" + id + "';";

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
            try
            {
                Name = dt.Rows[0]["Name"].ToString();
                Email = dt.Rows[0]["Email"].ToString();
                Gender = int.Parse(dt.Rows[0]["Gender"].ToString());
                Image = dt.Rows[0]["ImageName"].ToString();
                id = int.Parse(dt.Rows[0]["ID"].ToString());
                Username = dt.Rows[0]["Username"].ToString();
            }
            catch (Exception ex)
            {

            }
        }
        public void SearchMatch(User MainUser,int number)
        {
            string strConn = "Server=" + Environment.MachineName + "\\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";
            string sql = "SELECT * FROM dbo.Matches WHERE PersonID ='"+ MainUser.Id + "' AND Number = '" + number + "';";

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
            try
            {
                int idp = int.Parse(dt.Rows[0]["MatchedID"].ToString());
                this.id = idp;
            }
            catch (Exception ex)
            { }

        }
        public void Searches(User MainUser,User Usern)
        {
            string strConn = "Server=" + Environment.MachineName + "\\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";
            string sql = "SELECT * FROM dbo.Likes WHERE PersonID ='" + Usern.Id + "' AND Liked =" + MainUser.Id + ";";

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
            try
            {
                int idp = int.Parse(dt.Rows[0]["PersonID"].ToString());
                this.id = idp;
            }
            catch ( Exception ex)
            { }
            
        }
        public int getId()
        {
            return id;
        }
        public string getName()
        {
            return Name;
        }

        public int getGender()
        {
            return Gender;
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
