using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateSeer
{
    public class DataController
    {
        private IDataManager dataManager;
        public DataController(IDataManager gotDataManager)
        {
            dataManager = gotDataManager;
        }
        public void WriteData(string writeType, Dictionary<string, string> data)
        {
            dataManager.WriteData(writeType, data);
        }
        public DataTable GetData(string readType)
        {
            return dataManager.GetData(readType);
        }
    }
}
