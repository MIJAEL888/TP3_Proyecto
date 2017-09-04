using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("HistoriaClinica")]
    public class HistoriaClinica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Observacion { get; set; }
        public string GrupoSangineo { get; set; }
        public string Peso { get; set; }
        public string Talla { get; set; }

        [ForeignKey("Diagnostico")]
        public int IdDiagnostico { get; set; }
        public Diagnostico Diagnostico { get; set; }

        [ForeignKey("Tratamiento")]
        public int IdTratamiento { get; set; }
        public Tratamiento Tratamiento { get; set; }

        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }

        [ForeignKey("NivelCriticidad")]
        public int IdNivelCriticidad { get; set; }
        public NivelCriticidad NivelCriticidad { get; set; }
    }
}
