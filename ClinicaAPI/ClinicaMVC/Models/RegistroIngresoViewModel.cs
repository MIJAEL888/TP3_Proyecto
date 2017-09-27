using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicaEntity;

namespace ClinicaMVC.Models
{
    public class RegistroIngresoViewModel
    {
        public List<IngresoSalidaPaciente> IngresoSalidaPacientes { get; set; }
    }
}