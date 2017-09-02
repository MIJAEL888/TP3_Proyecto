using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicaMVC.Properties;
using RestSharp;

namespace ClinicaMVC.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: Solicitud
        private readonly RestClient _client;

        public SolicitudController()
        {
            _client = new RestClient();
            _client.BaseUrl = new Uri(Settings.Default.UriApi);
        }

        public ActionResult Index()
        {
            
            return View();
        }
    }
}