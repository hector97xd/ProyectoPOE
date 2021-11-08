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

        public void Add(Paciente paciente)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"INSERT INTO PACIENTE(Dui,Nombre,fechaNacimiento,sexo) VALUES(@Dui,@Nombre,@fechaNacimiento,@sexo);";
                    cn.Open();
                    cn.Execute(query, paciente);
                    
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Update(Paciente paciente)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"UPDATE PACIENTE SET Dui = @Dui,Nombre = @Nombre,fechaNacimiento = @fechaNacimiento, sexo = @sexo WHERE Id = @Id;";
                    cn.Open();
                    cn.Execute(query, paciente);
                    
                  
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Paciente paciente)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"DELETE FROM PACIENTE WHERE ID = @Id;";
                    cn.Open();
                    cn.Execute(query, paciente);
                    
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}
