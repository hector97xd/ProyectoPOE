using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPOEDS19.Modelo
{
    class Diagnostico
    {
        public int Id { get; set; }
        public DateTime fechaDiagnostico { get; set; }
        public string Descripcion { get; set; }
        public string Tratamiento { get; set; }
        public int Paciente { get; set; }
        public int Doctor { get; set; }
    }
}
