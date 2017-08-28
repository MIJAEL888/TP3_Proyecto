using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMVC.Entities.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public EstadoTurno EstadoTurno { get; set; }

        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; }

        public int IdSala { get; set; }
        public Sala Sala { get; set; }
    }
}
