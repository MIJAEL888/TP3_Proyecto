using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicaBussines;
using ClinicaMVC.Models;
using ClinicaUtil;

namespace ClinicaMVC.Controllers
{
    public class RegEnfermeriaController : Controller
    {
        readonly RegistroIngresoBl _registroIngresoBl = new RegistroIngresoBl();
        // GET: RegEnfermeria
        public ActionResult Index()
        {
            RegEnfermeriaViewModel model =  new RegEnfermeriaViewModel();
            model.IngresoSalidaPacientes = _registroIngresoBl.List((int) EstadoRegistroIngreso.Activado);
            return View(model);
        }

        public ActionResult Nuevo()
        {
            RegEnfermeriaViewModel model = new RegEnfermeriaViewModel();

            return PartialView(model);
        }
    }
}