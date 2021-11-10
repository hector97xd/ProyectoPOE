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
    public class DaoUsuarioRol
    {
        private Conexion con = new Conexion();

        public List<Rol_Usuario> GetAll()
        {
            var ls = new List<Rol_Usuario>();
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"SELECT * FROM ROL_USUARIO";
                    cn.Open();
                    ls = cn.Query<Rol_Usuario>(query).ToList();
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
