using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPOEDS19.Modelo
{
    public class Cita
    {
     
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaCita { get; set; }
        public string Descripcion { get; set; }
        public int Paciente { get; set; }
        public int Doctor { get; set; }
    }

}
