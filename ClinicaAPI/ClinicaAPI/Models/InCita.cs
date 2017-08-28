using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicaEntity;

namespace ClinicaAPI.Models
{
    public class InCita
    {
        public int Id { get; set; }
        public EstadoCita EstadoCita { get; set; }
        public string Observacion { get; set; }
        public int IdDoctor { get; set; }
        public int IdTurno { get; set; }
        public int IdPaciente { get; set; }
        public int IdTipoAtencion { get; set; }
    }
}