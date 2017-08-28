using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicaMVC.Entities.Models;

namespace ClinicaMVC.Models
{
    public class CitaViewModel
    {
        public List<Cita> Citas { get; set; }
        public List<TipoAtencion> TipoAtenciones { get; set; }
        public List<Doctor> Doctores { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public Usuario Usuario { get; set; }

    }
}