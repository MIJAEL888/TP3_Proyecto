using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicaEntity;

namespace ClinicaMVC.Models
{
    public class InterconsultaViewModel
    {
        public List<Solicitud> Solicitudes { get; set; }
        public List<Cama> Camas { get; set; }
    }
}