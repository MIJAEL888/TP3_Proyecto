using ClinicaBussines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClinicaAPI.Controllers
{
    public class DoctorController : ApiController
    {
        private readonly DoctorBl _doctorBl = new DoctorBl();

        [Route("Api/Doctor")]
        public IHttpActionResult Get()
        {
            return Json(_doctorBl.List());
        }
    }
}
