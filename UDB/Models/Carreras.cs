using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UDB.Models
{
    public class Carreras
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Carrera { get; set; }
        public string Grado { get; set; }
        public string Duracion { get; set; }
        public string Campus { get; set; }
        public string Detalles { get; set; }


    }
}
