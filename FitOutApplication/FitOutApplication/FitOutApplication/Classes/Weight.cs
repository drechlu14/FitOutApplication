using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace FitOutApplication.Classes
{
    public class Weight
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Actual { get; set; }
        public string Begin { get; set; }
    
    }
}



