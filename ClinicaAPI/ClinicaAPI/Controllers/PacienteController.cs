using ClinicaBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClinicaAPI.Controllers
{
    public class PacienteController : ApiController
    {
        private readonly PacienteBl _pacienteBl = new PacienteBl();

        [Route("Api/Paciente/{idUsuario}")]
        public IHttpActionResult Get(int idUsuario)
        {
            return Json(_pacienteBl.List(idUsuario));
        }
    }
}
