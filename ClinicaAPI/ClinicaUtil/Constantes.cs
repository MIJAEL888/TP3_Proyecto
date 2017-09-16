using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaUtil
{
    public class Constantes
    {
       public class NivelesCriticidad
       {
            public const string HrmTemperatura = "TEM";
            public const string HrmRitmoCard = "RC";
            public const string HrmPsPd = "PES";
            public const string HrmPcmPap = "PAM";
            public const string HrmPam = "PCP";
            public const string HrmGcIc = "GC";

            public const string RespModalidad = "VCV";
            public const string RespVc = "FR";
            public const string RespFr = "FIO2";
            public const string RespPeeps = "SAT02";
            public const string RespFio2 = "GLASGOW";
            public const string RespSatO2 = "RAMSAY";

            public const string NeuroPupila = "MSD";
            public const string NeuroEstadoConc = "MSI";
            public const string NeuroGlosgow = "EGRESO";
            public const string NeuroRamsay = "INGRESO";
            public const string NeuroMotSd = "INGRESO";
            public const string NeuroMotSi = "INGRESO";

            public const string HidriIngresos = "INGRESO";
            public const string HidriEgresos = "INGRESO";
        }
    }
}
