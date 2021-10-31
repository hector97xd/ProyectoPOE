using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPOEDS19.Modelo
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Dui { get; set; }
        public string Nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string sexo { get; set; }
    }
}
