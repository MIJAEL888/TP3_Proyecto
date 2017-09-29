using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("DiagnosticoGravedad")]
    public class DiagnosticoGravedad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Observacion { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaRegistro { get; set; }

        [ForeignKey("NivelCriticidad")]
        public int IdNivelCriticidad { get; set; }
        public NivelCriticidad NivelCriticidad { get; set; }

        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }

        [ForeignKey("IngresoSalidaPaciente")]
        public int IdIngresoSalidaPaciente { get; set; }
        public IngresoSalidaPaciente IngresoSalidaPaciente { get; set; }
    }
}
