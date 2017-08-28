using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaMVC.Models
{
    public class InListTurnoModel
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        //public int IdTipoAtencion { get; set; }
        public int IdDoctor { get; set; }
        //public int IdPaciente { get; set; }
    }
}