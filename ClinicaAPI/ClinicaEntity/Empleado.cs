using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Cargo { get; set; }
        public string CorreoInst { get; set; }
        public string Profesion { get; set; }

        [ForeignKey("Especialidad")]
        public int IdEspecialidad { get; set; }
        public Especialidad Especialidad { get; set; }

        [ForeignKey("Area")]
        public int IdArea{ get; set; }
        public Area Area{ get; set; }

        [ForeignKey("Persona")]
        public int IdPersona { get; set; }
        public Persona Persona { get; set; }
    }
}
