using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoryfinal.Models
{
    public class Employeetable
    {
        public int ID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int Start_year { get; set; }
        public string Department { get; set; }
        public List<string> shifts { get; set; }
    }
}