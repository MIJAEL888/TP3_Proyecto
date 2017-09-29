﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ClinicaBussines;
using ClinicaEntity;
using ClinicaMVC.Models;

namespace ClinicaMVC.Controllers
{
    [SessionFilter]
    public class DiagnosticoGravedadController : BaseController
    {
        readonly FactorRiesgoBl _factorRiesgoBl = FactorRiesgoBl.Instance;
        readonly NivelCriticidadBl _nivelCriticidadBl = NivelCriticidadBl.Instance;
        readonly DiagnosticoGravedadBl _diagnosticoGravedadBl = DiagnosticoGravedadBl.Instance;
        // GET: DiagnosticoGravedad
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Nuevo()
        {
            var model = new DiagnosticoGravedadViewModel
            {
                NivelCriticidades = _nivelCriticidadBl.List()
            };

            return View(model);
        }
        [HttpPost]
        public ActionResult Save(DiagnosticoGravedadViewModel model)
        {
            try
            {
                var diagnosticoGravedad = Mapper.Map<DiagnosticoGravedadViewModel, DiagnosticoGravedad>(model);
                _diagnosticoGravedadBl.Save(diagnosticoGravedad);
                return Json("Se guardo la informacion sin problemas.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
            }
        }

        public ActionResult Detalle(int idIngreso)
        {
            var model = new DiagnosticoGravedadViewModel
            {
                DiagnosticoGravedades = _diagnosticoGravedadBl.List(idIngreso)
            };

            return View(model);
        }
        public JsonResult GetValuesCriticidad(int idRegistroIngreso)
        {
            return Json(_factorRiesgoBl.ListByCriticidad(idRegistroIngreso));
        }
    }
}