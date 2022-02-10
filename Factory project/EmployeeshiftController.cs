using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Factoryfinal.Models;

using System.Web.Http.Cors;

namespace Factoryfinal.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeshiftController : ApiController
    {
        private static EmployeeshiftBL bl = new EmployeeshiftBL();
        // GET: api/Employeeshift
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Employeeshift/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employeeshift
        public string Post(Employeeshift e)
        { 
            bl.Add(e);
            return "Created"; 
        }

        // PUT: api/Employeeshift/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employeeshift/5
        public string Delete(int id)
        { 
            bl.Delete(id);
            return "Deleted"; 
        }
    }
}
