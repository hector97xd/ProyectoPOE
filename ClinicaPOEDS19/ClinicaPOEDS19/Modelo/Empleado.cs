using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPOEDS19.Modelo
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoEmpleado { get; set; }
        public string Especialidad { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public int Estado { get; set; }
        public int Usuario { get; set; }
    }
}
