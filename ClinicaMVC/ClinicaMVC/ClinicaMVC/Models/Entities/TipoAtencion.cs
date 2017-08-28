using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaMVC.Entities.Models
{
    public class TipoAtencion
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}
