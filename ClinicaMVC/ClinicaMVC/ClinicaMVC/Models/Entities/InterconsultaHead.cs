using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaMVC.Models.Entities
{
    public class InterconsultaHead
    {
        public int idInterconsulta { get; set; }
        public int idEmpleadoConsulta { get; set; }
        public int idEmpleadoConsultado { get; set; }
        public char Estado { get; set; }
        public int idHistoriaClinica { get; set; }
        public List<InterconsultaBody> DetalleInterconsulta { get; set; };
    }
}