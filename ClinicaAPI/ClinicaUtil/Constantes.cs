﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaUtil
{
    public class Constantes
    {
        public class FatoresRiesgo
        {
            public const string HrmTemperatura = "TEM";
            public const string HrmRitmoCard = "RC";
            public const string HrmPsPd = "PSPD";
            public const string HrmPcmPap = "PCMPAP";
            public const string HrmPam = "PAM";
            public const string HrmGcIc = "GCIC";

            public const string RespModalidad = "MODALIDAD";
            public const string RespVc = "VCV";
            public const string RespFr = "FR";
            public const string RespPeeps = "PEEPS";
            public const string RespFio2 = "FIO2";
            public const string RespSatO2 = "SATO2";

            public const string NeuroPupila = "PUPILA";
            public const string NeuroEstadoConc = "ESTADOCONC";
            public const string NeuroGlosgow = "GLASGOW";
            public const string NeuroRamsay = "RAMSAY";
            public const string NeuroMotSd = "MSD";
            public const string NeuroMotSi = "MSI";

            public const string HidriIngresos = "INGRESO";
            public const string HidriEgresos = "EGRESO";
        }

        public class CodigoRoles
        {
            public const string Doctor = "DOC";
            public const string Enfermera = "ENFER";
        }

        public class NombreSession
        {
            public const string Usuario = "UsuarioData";
        }

        public class NivelCriticidad
        {
            public const string Observacion = "OBS";
            public const string VigilanciaActiva = "VA";
            public const string VigilanciaIntensiva = "VI";
            public const string TerapeuticaIntensiva = "TI";

        }
    }
}
