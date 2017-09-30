using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.XpressionMapper;
using ClinicaMVC.Properties;

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
            string fileName = "ReporteCubo.xlsx";
            return File(Resources.PowerPivot, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}