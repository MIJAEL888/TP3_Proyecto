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
    public class SolicitudController : Controller
    {
        readonly SolicitudBl _solicitudBl = SolicitudBl.Instance;
        readonly CamaBl _camaBl = CamaBl.Instance;

        // GET: Solicitud
        public ActionResult Index()
        {
            var model = new SolicitudViewModel();
            model.Solicitudes = _solicitudBl.List((int) EstadoSolicitud.Pendiente);
            return View(model);
        }

        public ActionResult Nuevo()
        {
            var model = new SolicitudViewModel();
            model.Camas = _camaBl.List((int) EstadoCama.Disponible);
            return PartialView(model);
        }

        public ActionResult Aprobar(int idSolicitud, int idCama)
        {
            try
            {
                _solicitudBl.Aprobar(idSolicitud, idCama);
                return Json("Se aprobo la solicitud");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
            }
           
        }

        public ActionResult DesAprobar(int idSolicitud)
        {
            try
            {
                _solicitudBl.DesAprobar(idSolicitud);
                return Json("Se rechazo la solicitud");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
            }
            
        }
    }
}