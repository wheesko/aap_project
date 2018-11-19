using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Models
{
    public interface IDataManager //interface for objects that work with data storage systems (database, file system, etc.)
    {
         void WriteData(string writeType, User user);//expects a write type as string, that specifies how to write data, provides data in form of dictionary
         DataTable GetData(string readType, User user); //Expects readType, specifiying what data to get. Provides key which specifies what data to get  
    }
}
