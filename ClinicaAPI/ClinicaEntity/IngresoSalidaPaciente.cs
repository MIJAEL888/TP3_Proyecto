﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaUtil;

namespace ClinicaEntity
{
    [Table("IngresoSalidaPaciente")]
    public class IngresoSalidaPaciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public string Motivo { get; set; }
        public EstadoRegistroIngreso Estado { get; set; }

        [ForeignKey("Cama")]
        public int IdCama { get; set; }
        public Cama Cama { get; set; }

        [ForeignKey("Solicitud")]
        public int IdSolicitud { get; set; }
        public Solicitud Solicitud { get; set; }

    }
}
