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
    public class DaoRol
    {
        private Conexion con = new Conexion();
        public List<Rol> GetRoles()
        {
            var ls = new List<Rol>();
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"SELECT * FROM ROL";
                    cn.Open();
                    ls = cn.Query<Rol>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ls;
        }
        public List<Rol> GetAll()
        {
            var ls = new List<Rol>();
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"SELECT Id,Nombre, case when Estado>0 then 'Activo' else 'Inactivo' end as Estado FROM ROL";
                    cn.Open();
                    ls = cn.Query<Rol>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ls;
        }

        public void Add(Rol rol)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"INSERT INTO ROL(Nombre,Estado) VALUES(@Nombre,@Estado);";
                    cn.Open();
                    cn.Execute(query, rol);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Update(Rol rol)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"UPDATE ROL SET Nombre= @Nombre, Estado = @Estado WHERE Id = @Id;";
                    cn.Open();
                    cn.Execute(query, rol);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Rol rol)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"DELETE FROM ROL WHERE Id = @Id;";
                    cn.Open();
                    cn.Execute(query, rol);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
