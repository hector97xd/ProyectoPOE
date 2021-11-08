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

        public void Add(Empleado empleado)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"INSERT INTO EMPLEADO(Id,Nombre,TipoEmpleado,Especialidad,fechaNacimiento,sexo,Estado,Usuario) 
                                VALUES(@Id,@Nombre,@TipoEmpleado,@Especialidad,@fechaNacimiento,@sexo,@Estado,@Usuario);";
                    cn.Open();
                    cn.Execute(query, empleado);

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Update(Empleado empleado)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"UPDATE EMPLEADO SET Id = @Id,Nombre = @Nombre,TipoEmpleado = @TipoEmpleado,Especialidad = @Especialidad
                                fechaNacimiento = @fechaNacimiento,sexo = @sexo,Estado = @Estado,Usuario = @Usuario WHERE Id = @Id;";
                    cn.Open();
                    cn.Execute(query, empleado);


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Empleado empleado)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"DELETE FROM EMPLEADO WHERE ID = @Id;";
                    cn.Open();
                    cn.Execute(query, empleado);

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}

