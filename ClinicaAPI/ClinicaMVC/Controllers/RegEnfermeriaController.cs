using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicaBussines;
using ClinicaMVC.Models;
using ClinicaUtil;

namespace ClinicaMVC.Controllers
{
    public class RegEnfermeriaController : Controller
    {
        readonly RegistroIngresoBl _registroIngresoBl = RegistroIngresoBl.Instance;
        // GET: RegEnfermeria
        public ActionResult Index()
        {
            RegEnfermeriaViewModel model = new RegEnfermeriaViewModel
            {
                IngresoSalidaPacientes = _registroIngresoBl.List((int)EstadoRegistroIngreso.Activado)
            };
            return View(model);
        }

        public ActionResult Nuevo(int idRegistroIngreso)
        {
            RegEnfermeriaViewModel model = new RegEnfermeriaViewModel
            {
                IngresoSalidaPaciente = _registroIngresoBl.Get(idRegistroIngreso)
            };

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Save(RegEnfermeriaViewModel model)
        {
            try
            {

                return Json("Se aprobo la solicitud");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
            }
            
        }
    }
}