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
    class DaoDiagnostico
    {
        private Conexion con = new Conexion();

        public List<Diagnostico> mostrar()
        {
            var ls = new List<Diagnostico>();
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"SELECT * FROM DIAGNOSTICO";
                    cn.Open();
                    ls = cn.Query<Diagnostico>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ls;
        }

        public void Add(Diagnostico diag)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"INSERT INTO DIAGNOSTICO(fechaDiagnostico,Descripcion,Tratamiento,Paciente,Doctor) VALUES(@fechaDiagnostico,@Descripcion,@Tratamiento,@Paciente,@Doctor)";
                    cn.Open();
                    cn.Execute(query, diag);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection cn = con.GetConnection)
            {
                var query = @"DELETE FROM DIAGNOSTICO WHERE Id=@Id";
                cn.Open();
                cn.Execute(query, new { Id = id });
            }
        }
        public void Update(Diagnostico prod)
        {
            using (IDbConnection cn = con.GetConnection)
            {
                var query = @"UPDATE DIAGNOSTICO SET fechaDiagnostico=@fechaDiagnostico,Descripcion=@Descripcion,Tratamiento=@Tratamiento,Paciente=@Paciente,Doctor=@Doctor WHERE Id=@Id";
                cn.Open();
                cn.Execute(query, prod);
            }
        }
    }
}
