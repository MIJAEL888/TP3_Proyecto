using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicaMVC.Controllers
{
    [SessionFilter]
    public class ReporteController : BaseController
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFile()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(@"D:\SeguimientoPlanEjecucion.xlsx");
            string fileName = "SeguimientoPlanEjecucion.xlsx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}