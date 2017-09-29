using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaMVC.Models.Entities
{
    public class InterconsultaBody
    {
        public int idInterconsultaDet { get; set; }
        public int idInterconsulta { get; set; }
        public string txtDetalle { get; set; }
        public DateTime dtFecha { get; set; }


        //[txtDetalle] [varchar](2000) NOT NULL,

    }
}