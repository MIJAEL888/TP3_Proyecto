using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("RegistroEnfermeria")]
    public class RegistroEnfermeria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Observacion { get; set; }
        public string Antecedentes { get; set; }

        [ForeignKey("IngresoSalidaPaciente")]
        public int IdIngresoSalidaPaciente { get; set; }
        public IngresoSalidaPaciente IngresoSalidaPaciente { get; set; }

        [NotMapped]
        public string FechaRegistroString => FechaRegistro.ToString("dd HH:mm");
    }
}
