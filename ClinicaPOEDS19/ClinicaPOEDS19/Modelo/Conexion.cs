using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPOEDS19.Modelo
{
    public class Conexion
    {
        private string con;

        public Conexion()
        {
            con = Properties.Settings.Default.Conexion;
        }
        public IDbConnection GetConnection
        {
            get
            {
                return new SqlConnection(con);
            }
        }

     
    }
}
