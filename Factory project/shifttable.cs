using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoryfinal.Models
{
    public class shifttable
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string strat_time { get; set; }
        public string End_time { get; set; } 
        public List<Employee2> employees { get; set; }
    }
}