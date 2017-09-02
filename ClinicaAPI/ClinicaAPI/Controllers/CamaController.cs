using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClinicaBussines;

namespace ClinicaAPI.Controllers
{
    public class CamaController : ApiController
    {
        private readonly CamaBl _camaBl = new CamaBl();

        [Route("Api/Cama")]
        public IHttpActionResult Get()
        {
            return Json(_camaBl.List());
        }

        [Route("Api/Cama/{idEstado}")]
        public IHttpActionResult Get(int idEstado)
        {
            return Json(_camaBl.List(idEstado));
        }

        // POST: api/Cama
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cama/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cama/5
        public void Delete(int id)
        {
        }
    }
}
