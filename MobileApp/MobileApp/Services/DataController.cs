using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Services
{
    public class DataController
    {
        private IDataManager dataManager;
        public DataController(IDataManager gotDataManager)
        {
            dataManager = gotDataManager;
        }
        public void WriteData(string writeType, User user)
        {
            dataManager.WriteData(writeType, user);
        }
        public DataTable GetData(string readType, User user)
        {
            return dataManager.GetData(readType, user);
        }
     
        public void ChangePhoto(string picturePath, User user)
        {
            dataManager.ChangePhoto(picturePath,user);
        }
        public void UpdateTable(Table db)
        {
            dataManager.UpdateTable(db);
        }
        public DataTable GetUserByUsername(string username)
        {
            return dataManager.GetUserByUsername(username);
        }
        public DataTable GetUnsedUser(int gender, int ids)
        {
            return dataManager.GetUnsedUser(gender,ids);
        }
        public DataTable GetUserById(int id)
        {
            return dataManager.GetUserById(id);
        }
        public DataTable SearchMatch(User MainUser, int number)
        {
            return dataManager.SearchMatch(MainUser,number);
        }
        public DataTable Searches(User MainUser, User Usern)
        {
            return dataManager.Searches(MainUser,Usern);
        }
    }
}
