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
        public int idInterconsultaDet { get; set; }
        public int idInterconsulta { get; set; }
        public string txtDetalle { get; set; }
        public DateTime dtFecha { get; set; }

    }
}
