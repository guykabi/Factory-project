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
    public class DepartmentController : ApiController
    {
        private static departmentBL bl = new departmentBL();
        // GET: api/Department
        public IEnumerable<Departable> Get()
        {
            return bl.GetAll();
        }

        // GET: api/Department/5
        public Department2 Get(int id)
        {
          return bl.GetOneDep(id);    
        }

        // POST: api/Department
        public string Post(Departable d)
        { 
            bl.Add(d);
            return "Created";
        }

        // PUT: api/Department/5
        public string Put(int id, Departable d)
        { 
            bl.Update(id, d);
            return "Updated";
        }

        // DELETE: api/Department/5
        public int Delete(int id)
        { 
           return bl.Delete(id);
            
        }
    }
}
