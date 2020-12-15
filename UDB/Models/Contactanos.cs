using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UDB.Models
{
    public class Contactanos
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Consulta { get; set; }
        public string Mensaje { get; set; }
    }
}
