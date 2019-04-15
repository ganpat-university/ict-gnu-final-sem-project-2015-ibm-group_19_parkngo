using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ParkNGoFinal.Controllers
{
    public class VehicleController : ApiController
    {
        // GET api/vehicle
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/vehicle/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/vehicle
        public void Post([FromBody]string value)
        {
        }

        // PUT api/vehicle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/vehicle/5
        public void Delete(int id)
        {
        }
    }
}
