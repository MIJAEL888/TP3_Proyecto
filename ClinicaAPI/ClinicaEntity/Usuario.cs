using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string Contrasenia { get; set; }
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("RolUsuario")]
        public int IdRolUsuario { get; set; }
        public RolUsuario RolUsuario { get; set; }

        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }
    }
}
