using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaMVC.Controllers
{
    [SessionFilter]
    public class DiagnosticoGravedadController : BaseController
    {
        // GET: DiagnosticoGravedad
        public ActionResult Index()
        {
            return View();
        }
    }
}