using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ClinicaBussines;
using ClinicaEntity;
using ClinicaMVC.Models;
using ClinicaUtil;

namespace ClinicaMVC.Controllers
{
    public class RegEnfermeriaController : Controller
    {
        readonly RegistroIngresoBl _registroIngresoBl = RegistroIngresoBl.Instance;
        readonly RegistroEnfermeriaBl _registroEnfermeriaBl = RegistroEnfermeriaBl.Instance;
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
            model.IdIngresoSalidaPaciente = idRegistroIngreso;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Save(RegEnfermeriaViewModel model)
        {
            try
            {
                var registroEnfermeriaModel = Mapper.Map<RegEnfermeriaViewModel, RegistroEnfermeriaModel>(model);
                _registroEnfermeriaBl.SaveDetails(registroEnfermeriaModel);
                return Json("Se guardo la informacion sin problemas.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
            }
            
        }
    }
}