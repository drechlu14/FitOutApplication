using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitOutApplication.Classes
{
    public class WeightDetail
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Reps { get; set; }
        public string Weight { get; set; }
    }
}
