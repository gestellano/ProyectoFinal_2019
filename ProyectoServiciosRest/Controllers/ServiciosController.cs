using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoServiciosRest.Controllers
{
    public class ServiciosController : ApiController
    {
        // GET: api/Servicios
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Servicios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Servicios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Servicios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Servicios/5
        public void Delete(int id)
        {
        }
    }
}
