using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaEntity
{
    [Table("T_INTERCONSULTA_UCI_CABECERA")]
    public class InterconsultaHead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("DoctorConsulta")]
        public int IdDoctorConsulta { get; set; }
        public Doctor DoctorConsulta { get; set; }

        [ForeignKey("DoctorConsultado")]
        public int IdDoctorConsultado { get; set; }
        public Doctor DoctorConsultado { get; set; }


        public char Estado { get; set; }

        
        [ForeignKey("HistoriaClinica")]
        public int idHistoriaClinica { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }



    }
}
