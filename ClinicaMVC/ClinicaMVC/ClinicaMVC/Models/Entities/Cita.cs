using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMVC.Entities.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public EstadoCita EstadoCita { get; set; }
        public string Observacion { get; set; }
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; }
        public int IdTurno { get; set; }
        public Turno Turno { get; set; }
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public int IdTipoAtencion { get; set; }
        public TipoAtencion TipoAtencion { get; set; }
    }
}
