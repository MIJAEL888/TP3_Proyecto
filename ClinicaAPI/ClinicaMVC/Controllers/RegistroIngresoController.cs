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
    [SessionFilter]
    public class RegistroIngresoController : BaseController
    {
        readonly RegistroIngresoBl _registroIngresoBl = RegistroIngresoBl.Instance;
        // GET: RegistroIngreso
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult GetPacientes()
        //{
        //    RegistroIngresoViewModel model = new RegistroIngresoViewModel
        //    {
        //       IngresoSalidaPacientes = _registroIngresoBl.List((int)EstadoRegistroIngreso.Activado)
        //    };
        //    return PartialView("_ListPacientes", model);
        //}
        public ActionResult GetPacientes(string name)
        {
            RegistroIngresoViewModel model = new RegistroIngresoViewModel
            {
                IngresoSalidaPacientes = string.IsNullOrEmpty(name) ? 
                    _registroIngresoBl.List((int)EstadoRegistroIngreso.Activado) : 
                    _registroIngresoBl.List((int)EstadoRegistroIngreso.Activado, name)
            };
            return PartialView("_ListPacientes", model);
        }
    }
}