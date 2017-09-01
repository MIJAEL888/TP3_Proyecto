using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClinicaBussines;

namespace ClinicaAPI.Controllers
{
    public class SolicitudController : ApiController
    {
        private readonly SolicitudBl _solicitudBl = new SolicitudBl();

        [Route("Api/Solicitud/{idEstado}")]
        public IHttpActionResult Get(int idEstado)
        {
            return Json(_solicitudBl.List(idEstado));
        }

        [Route("Api/Solicitud")]
        public IHttpActionResult Get()
        {
            return Json(_solicitudBl.List());
        }

        // POST: api/Solicitud
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Solicitud/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Solicitud/5
        public void Delete(int id)
        {
        }
    }
}
