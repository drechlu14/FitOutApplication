using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace FitOutApplication.Classes
{
    public class Excercise
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public Excercise()
        {
        }
        public override string ToString()
        {
            return Name + "" + Info;
        }
    }
}



