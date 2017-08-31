
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("Inmueble")]
    public class Inmueble
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public string DesInmueble { get; set; }
        public string DesTipo { get; set; }
        public string Estado { get; set; }
    }
}
