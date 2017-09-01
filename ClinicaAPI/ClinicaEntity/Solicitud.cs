using ClinicaUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("Solicitud")]
    public class Solicitud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Observacion { get; set; }
        public EstadoSolicitud Estado { get; set; }

        [ForeignKey("HistoriaClinica")]
        public int IdHistoriaClinica { get; set; }
        public HistoriaClinica HistoriaClinica{ get; set; }

        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }
    }
}
