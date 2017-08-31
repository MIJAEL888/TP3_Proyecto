using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("Cama")]
    public class Cama
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public string Descripcion { get; set; }
        public string AppMedica { get; set; }
        public string Garantia { get; set; }
        public string Tipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Estado { get; set; }

        [ForeignKey("Inmueble")]
        public int IdInmueble { get; set; }
        public Inmueble Inmueble { get; set; }
    }
}
