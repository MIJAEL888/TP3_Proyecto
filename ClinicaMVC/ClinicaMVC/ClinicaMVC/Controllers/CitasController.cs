using ClinicaMVC.Properties;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicaMVC.Entities.Models;
using ClinicaMVC.Models;

namespace ClinicaMVC.Controllers
{
    public class CitasController : Controller
    {
        // GET: Citas
        private readonly RestClient _client;

        public CitasController()
        {
            _client = new RestClient();
            _client.BaseUrl = new Uri(Settings.Default.UriApi);
        }


        public ActionResult Index()
        {
            var request = new RestRequest("Cita/1", Method.GET);
            var citas = _client.Execute<List<Cita>>(request).Data;
            var citaViewModel = new CitaViewModel();
            citaViewModel.Citas = citas;

            return View(citaViewModel);
        }

        public ActionResult Nueva()
        {
            var request1 = new RestRequest("TipoAtencion", Method.GET);
            var tipoAtenciones = _client.Execute<List<TipoAtencion>>(request1).Data;

            var request2 = new RestRequest("Doctor", Method.GET);
            var doctores = _client.Execute<List<Doctor>>(request2).Data;

            var request3 = new RestRequest("Paciente/1", Method.GET);
            var pacientes = _client.Execute<List<Paciente>>(request3).Data;

            var citaViewModel = new CitaViewModel();
            citaViewModel.TipoAtenciones = tipoAtenciones;
            citaViewModel.Doctores = doctores;
            citaViewModel.Pacientes = pacientes;
            return View(citaViewModel);
        }

        public ActionResult ListTurnos(InListTurnoModel model)
        {
            var request1 = new RestRequest("Turno/" + model.IdDoctor, Method.GET);
            var turnos = _client.Execute<List<Turno>>(request1).Data;

            var outListaTurnosModel = new OutListaTurnosModel();
            outListaTurnosModel.Turnos = turnos;

            return PartialView(outListaTurnosModel);
        }

        public ActionResult ReservarTurno(InReservaTurnoModel model)
        {
            model.EstadoCita = EstadoCita.Pendiente;
            model.Observacion = "Por favor funciona";

            var request1 = new RestRequest("Cita", Method.POST);
            request1.AddHeader("Content-type", "application/json");
            var json = request1.JsonSerializer.Serialize(model);
            request1.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            var response = _client.Execute<Object>(request1);
            return Json(response.ToString());
        }

        public ActionResult Anular(int idCita)
        {
            var request1 = new RestRequest("Cita/" + idCita, Method.POST);
            request1.AddHeader("Content-type", "application/json");
            //var json = request1.JsonSerializer.Serialize(model);
            //request1.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            var response = _client.Execute<Object>(request1);
            return Json(response.ToString());
        }
    }
}