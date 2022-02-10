﻿using System;
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

    public class UserController : ApiController
    {
        private static userBL bl = new userBL();
        // GET: api/User
        public string[] Get(string u1 , string u2)
        {
            return bl.Get( u1 , u2);
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public string Put(int id)
        {
            return bl.update(id);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
