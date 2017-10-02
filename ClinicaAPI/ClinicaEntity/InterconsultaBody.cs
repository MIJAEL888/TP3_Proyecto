using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("[T_INTERCONSULTA_UCI_DETALLE]")]
    public class InterconsultaBody
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInterconsultaDet { get; set; }

        [ForeignKey("T_INTERCONSULTA_UCI_CABECERA")]
        public int IdInterconsulta { get; set; }

        public string txtDetalle { get; set; }
        public DateTime dtFecha { get; set; }

    }
}
