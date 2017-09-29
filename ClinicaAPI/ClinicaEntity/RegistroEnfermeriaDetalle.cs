using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("RegistroEnfermeriaDetalle")]
    public class RegistroEnfermeriaDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Valor { get; set; }
        public string ValorString { get; set; }

        [ForeignKey("RegistroEnfermeria")]
        public int IdRegistroEnfermeria { get; set; }
        public RegistroEnfermeria RegistroEnfermeria { get; set; }

        [ForeignKey("FactorRiesgo")]
        public int IdFactorRiesgo { get; set; }
        public FactorRiesgo FactorRiesgo { get; set; }

        [ForeignKey("NivelCriticidad")]
        public int IdNivelCriticidad { get; set; }
        public NivelCriticidad NivelCriticidad { get; set; }

    }
}
