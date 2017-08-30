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

        [ForeignKey("Diagnostico")]
        public int IdDiagnostico { get; set; }
        public Diagnostico Diagnostico { get; set; }

        [ForeignKey("Tratamiento")]
        public int IdTratamiento { get; set; }
        public Tratamiento Tratamiento { get; set; }

    }
}
