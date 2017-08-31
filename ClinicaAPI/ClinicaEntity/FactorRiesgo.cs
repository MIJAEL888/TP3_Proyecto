using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("FactorRiesgo")]
    public class FactorRiesgo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int ValorMinimo { get; set; }
        public int ValorMaximo { get; set; }
        public string Codigo { get; set; }
        public string Unidades { get; set; }
        public string Grupo { get; set; }
        public string Padre { get; set; }
    }
}
