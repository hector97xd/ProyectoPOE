using ClinicaPOEDS19.Modelo;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPOEDS19.DbContext
{
    public class DaoPaciente
    {
        private Conexion con = new Conexion();

        public List<Paciente> GetAll()
        {
            var ls = new List<Paciente>();
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"SELECT * FROM PACIENTE";
                    cn.Open();
                    ls = cn.Query<Paciente>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ls;
        }
    }
}
