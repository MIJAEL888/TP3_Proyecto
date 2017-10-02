using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaMVC.Models;
using ClinicaBussines;
using ClinicaUtil;

namespace ClinicaMVC.Controllers
{
    [SessionFilter]
    public class InterconsultaController : BaseController
    {

        readonly SolicitudBl _solicitudBl = SolicitudBl.Instance;
        readonly CamaBl _camaBl = CamaBl.Instance;

        
        public ActionResult Index()
        {
            var model = new SolicitudViewModel();
            model.Solicitudes = _solicitudBl.List((int)EstadoSolicitud.Pendiente);
            return View(model);
        }
        public ActionResult Nuevo()
        {
            var model = new SolicitudViewModel();
            model.Camas = _camaBl.List((int)EstadoCama.Disponible);
            return PartialView(model);
        }
    }
}