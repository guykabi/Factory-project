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

    public class EmployeeController : ApiController
    {
        private static EmployeeBL bl = new EmployeeBL();
        // GET: api/Employee
        public IEnumerable<Employeetable> Get(string dep = "" , string fname = "", string lname = "" )
        {
            return bl.GetAll(dep , fname , lname);
        }

        // GET: api/Employee/5
        public Employeetable Get(int id)
        {
            return bl.GetOneEmp(id);
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        { 

        }

        // PUT: api/Employee/5
        public string Put(int id, Employee2 emp)
        { 
            bl.Update(id, emp);
            return "Updated";
        }

        // DELETE: api/Employee/5
        public string Delete(int id)
        { 
            bl.Delete(id);
            return "Deleted";
        }
    }
}
