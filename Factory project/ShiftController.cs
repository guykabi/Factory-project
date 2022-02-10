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
    public class ShiftController : ApiController
    {
        private static shiftBL bl = new shiftBL();
        // GET: api/Shift
        public IEnumerable<shifttable> Get()
        {
            return bl.GetAll();
        }

        // GET: api/Shift/5
        public void Get(int id)
        {
            
        }

        // POST: api/Shift
        public string Post(Shift s)
        { 
            bl.Add(s);
            return "Created";
        }

        // PUT: api/Shift/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shift/5
        public void Delete(int id)
        {
        }
    }
}
