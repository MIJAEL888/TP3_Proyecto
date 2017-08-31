using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("FactorRiesgoCriticidad")]
    public class FactorRiesgoCriticidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ValorMaximo { get; set; }
        public int ValorMinimo { get; set; }

        [ForeignKey("FactorRiesgo")]
        public int IdFactorRiesgo { get; set; }
        public FactorRiesgo FactorRiesgo { get; set; }

        [ForeignKey("NivelCriticidad")]
        public int IdNivelCriticidad { get; set; }
        public NivelCriticidad NivelCriticidad { get; set; }
    }
}
