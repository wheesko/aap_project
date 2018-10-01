using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public static void CreateUser(User user)
        {
            //get params from user class
            string username = user.getusername();
            string password = user.getpassword();
            string email = user.getemail();
            string name = user.getname();
            //create sql params
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            List<SqlParameter> checkParams = new List<SqlParameter>();
            //stage check params
            checkParams.Add(new SqlParameter("Username", username));
            checkParams.Add(new SqlParameter("Email", email));
            if (executeStoredProcedure("GetByEmailOrUsername", checkParams).Rows.Count == 0)//check if query returned only 1 row
            {

                string savedPasswordHash = new HashFunctions().GetHash(password);
                sqlParams.Add(new SqlParameter("Name", name));
                sqlParams.Add(new SqlParameter("Email", email));
                sqlParams.Add(new SqlParameter("Username", username));
                sqlParams.Add(new SqlParameter("Password", savedPasswordHash));

                executeStoredProcedure("AddUser", sqlParams);
            }
            else
            {
                throw new Exception();//else throw exception
            }
        }
        public static bool CompareToHash(User user)
        {
            //get from user class
            string gotUsernameString = user.getusername();
            string gotPassString = user.getpassword();
            //find user by username
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            sqlParams.Add(new SqlParameter("Username", gotUsernameString));
            DataTable dtLoginResults = DAL.executeStoredProcedure("ValidateLogin", sqlParams);
            if (dtLoginResults.Rows.Count == 1) //if only 1 user found
            {
                string gotString = dtLoginResults.Rows[0]["password"].ToString();

                if (new HashFunctions().GetNewHash(gotPassString, gotString) == true) //compare hashed passwords
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
