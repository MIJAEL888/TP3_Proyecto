using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicaEntity;

namespace ClinicaMVC.Models
{
    public class RegEnfermeriaViewModel
    {
        public List<IngresoSalidaPaciente> IngresoSalidaPacientes { get; set; }
        public IngresoSalidaPaciente IngresoSalidaPaciente { get; set; }

        public int IdIngresoSalidaPaciente { get; set; }

        public string Observacion { get; set; }
        public string Antecedentes { get; set; }
        public int Valor { get; set; }
        public string ValorString { get; set; }

        // Atributos de monitoreo Hermodinamico
        public int HrmTemperatura { get; set; }
        public int HrmRitmoCard { get; set; }
        public int HrmPsPd { get; set; }
        public int HrmPcmPap { get; set; }
        public int HrmPam { get; set; }
        public int HrmGcIc { get; set; }

        // Atributos de monitoreo Respiratorio
        public int RespModalidad { get; set; }
        public int RespVc { get; set; }
        public int RespFr { get; set; }
        public int RespPeeps { get; set; }
        public int RespFio2 { get; set; }
        public int RespSatO2 { get; set; }

        // Atributos de monitoreo Neurologico
        public int NeuroPupila { get; set; }
        public int NeuroEstadoConc { get; set; }
        public int NeuroGlosgow { get; set; }
        public int NeuroRamsay { get; set; }
        public int NeuroMotSd { get; set; }
        public int NeuroMotSi { get; set; }

        // Atributos de monitoreo Hidrico
        public int HidriIngresos { get; set; }
        public int HidriEgresos { get; set; }
    }
}