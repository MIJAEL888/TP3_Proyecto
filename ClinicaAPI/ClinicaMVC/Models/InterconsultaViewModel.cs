using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaMVC.Models
{
    public class InterconsultaViewModel
    {
        public List<Solicitud> Solicitudes { get; set; }
        public List<Cama> Camas { get; set; }
        public int idCama { get; set; }
        public int idSolicitud { get; set; }
    }
}