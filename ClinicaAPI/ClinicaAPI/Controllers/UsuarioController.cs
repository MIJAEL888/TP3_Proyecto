using ClinicaBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClinicaAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly UsuarioBl _usuarioBl = new UsuarioBl();

        [Route("Api/Usuario/{idUsuario}")]
        public IHttpActionResult Get(int idUsuario)
        {
            return Json(_usuarioBl.Get(idUsuario));
        }
    }
}
