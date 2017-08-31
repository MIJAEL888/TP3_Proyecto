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

        [ForeignKey("HistoriaClinica")]
        public int IdHistoriaClinica { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }

        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }


    }
}
