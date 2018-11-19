using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Models
{
    public class DataController
    {
        private IDataManager dataManager;
        public DataController(IDataManager gotDataManager)
        {
            dataManager = gotDataManager;
        }
        public void WriteData(string writeType, MobileApp.Models.User user)
        {
            dataManager.WriteData(writeType, user);
        }
        public DataTable GetData(string readType, MobileApp.Models.User user)
        {
            return dataManager.GetData(readType, user);
        }
    }
}
