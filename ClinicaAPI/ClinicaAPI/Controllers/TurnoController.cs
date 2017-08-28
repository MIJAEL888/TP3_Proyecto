using ClinicaBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClinicaAPI.Controllers
{
    public class TurnoController : ApiController
    {
        private readonly TurnoBl _turnoBl = new TurnoBl();

        [Route("Api/Turno/{idDoctor}")]
        public IHttpActionResult Get(int idDoctor)
        {
            return Json(_turnoBl.List(idDoctor));
        }
    }
}
