using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicaEntity;

namespace ClinicaMVC.Models
{
    public class DiagnosticoGravedadViewModel
    {
        public List<NivelCriticidad> NivelCriticidades { get; set; }
        public List<DiagnosticoGravedad> DiagnosticoGravedades { get; set; }

        public string Observaciones { get; set; }
        public string Detalle { get; set; }
        public int IdNivelCriticidad { get; set; }
    }
}