using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPOEDS19.Modelo
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave {get; set;}
        public string Estado { get; set;}
        public DateTime FechaCreacion { get; set; }

    }
}
