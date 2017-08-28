using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicaMVC.Entities.Models;

namespace ClinicaMVC.Models
{
    public class InReservaTurnoModel
    {
        public int IdTipoAtencion { get; set; }
        public int IdDoctor { get; set; }
        public int IdPaciente { get; set; }
        public int IdTurno { get; set; }
        public EstadoCita EstadoCita { get; set; }
        public string Observacion { get; set; }
    }
}