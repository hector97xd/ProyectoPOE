using ClinicaPOEDS19.Modelo;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPOEDS19.DbContext
{
    public class DaoEmpleado
    {
        private Conexion con = new Conexion();

        public List<Empleado> GetAll()
        {
            var ls = new List<Empleado>();
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"SELECT * FROM EMPLEADO";
                    cn.Open();
                    ls = cn.Query<Empleado>(query).ToList();
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
