using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("Cita")]
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public EstadoCita EstadoCita { get; set; }
        public string Observacion { get; set; }

        [ForeignKey("Doctor")]
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Turno")]
        public int IdTurno { get; set; }
        public Turno Turno { get; set; }

        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }

        [ForeignKey("TipoAtencion")]
        public int IdTipoAtencion { get; set; }
        public TipoAtencion TipoAtencion { get; set; }
    }
}
