using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class Table
    {
       public int MainId { get; set; }
        public int Id { get; set; }
        public int number { get; set; }
        public string table { get; set; }
        public string collumname1 { get; set; }
        public string collumname2 { get; set; }
        
        public Table(int MainId,int Id,int number,string table,string collumname1,string collumname2)
        {
            this.MainId = MainId;
            this.Id = Id;
            this.number = number;
            this.table = table;
            this.collumname1 = collumname1;
            this.collumname2 = collumname2;
        }
    }
}
