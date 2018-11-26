using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Android.Database.Sqlite;


namespace MobileApp.Services
{
    public class DatabaseDataManager : IDataManager
    {
        public void WriteData(string typeOfWrite, User gotUser)
        {            
            switch (typeOfWrite)
            {
                case "AddUser": CreateUser(gotUser); break;
                case "UpdateFacebookID": checkforFacebook(gotUser); break;
                default: return; 
            }
        

        }
        public DataTable GetData(string typeOfRead, User gotUser)
        {
            List<SqlParameter> checkParams = new List<SqlParameter>();
            DataTable dt = new DataTable();
            switch (typeOfRead)
            {
                case "ValidateLogin":
                    checkParams.Add(new SqlParameter("Username", gotUser.username));
                    dt = executeStoredProcedure("ValidateLogin", checkParams);
                    return dt;
                case "GetByEmailOrUsername":
                    checkParams.Add(new SqlParameter("Username", gotUser.username));
                    checkParams.Add(new SqlParameter("Email", gotUser.email));
                    dt = executeStoredProcedure("GetByEmailOrUsername", checkParams);
                    return dt;
                default: return null;
            }
           
        }
        private DataTable executeStoredProcedure(string spName, List<SqlParameter> sqlParams = null)
        {

            string strConn = "Server=" + Environment.MachineName + @"\SQLEXPRESS;Database=Login_data;Trusted_Connection=True";
           
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
        private void CreateUser(User user)
        {
            //get params from user class
            /*string username = user.getUsername();
            string password = user.getpassword();
            string email = user.getemail();
            string name = user.getUsername();
            int gender = user.getGender();*/
            string username = user.username;
            string password = user.password;
            string email = user.email;
            string name = user.name;
            int gender = user.gender;
            string birthday = user.birthdate.ToString();
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
                sqlParams.Add(new SqlParameter("Gender", gender));
                sqlParams.Add(new SqlParameter("Birthday", birthday));
                executeStoredProcedure("AddUser", sqlParams);
            }
            else
            {
                throw new Exception();//else throw exception
            }
        }
        private void checkforFacebook(User user)
        {

            List<SqlParameter> checkParams = new List<SqlParameter>();
            List<SqlParameter> sqlParams = new List<SqlParameter>();
            //stage check params
            checkParams.Add(new SqlParameter("Username", user.username));
            checkParams.Add(new SqlParameter("Email", user.email));
            DataTable dt = executeStoredProcedure("GetByEmailOrUsername", checkParams);
            if (dt.Rows.Count == 0)//user not created and first time logging in
            {
                sqlParams.Add(new SqlParameter("Name", user.name));
                sqlParams.Add(new SqlParameter("Email", user.email));
                sqlParams.Add(new SqlParameter("Username", " "));
                sqlParams.Add(new SqlParameter("Password", " "));
                sqlParams.Add(new SqlParameter("Gender", user.gender));
                sqlParams.Add(new SqlParameter("Birthday", user.birthdate.ToString()));
                sqlParams.Add(new SqlParameter("FacebookID", user.facebookID));
                executeStoredProcedure("AddUser", sqlParams);
            }
            else if (dt.Rows.Count == 1 && (dt.Rows[0]["FacebookID"].ToString() == "0" || dt.Rows[0]["FacebookID"] == null))//user created, logging in with facebook
            {
                sqlParams.Add(new SqlParameter("FacebookID", user.facebookID));
                sqlParams.Add(new SqlParameter("Email", user.email));
                executeStoredProcedure("UpdateFacebookID", sqlParams);
            }
            else //user created and has facebookID
            {
                return;
            }

        }
    }
}
