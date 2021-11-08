using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicaPOEDS19.DbContext;
using ClinicaPOEDS19.Modelo;
using Dapper;

namespace ClinicaPOEDS19.DbContext
{
    public class DaoCita
    {
        private Conexion con = new Conexion();

        public List<Cita> GetAll()
        {
            var ls = new List<Cita>();
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"SELECT * FROM CITA";
                    cn.Open();
                    ls = cn.Query<Cita>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ls;
        }
        public void Add(Cita cita)
        {
            try
            {
                cita.FechaIngreso = DateTime.Now;
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"INSERT INTO CITA(FechaIngreso,FechaCita,Descripcion,Paciente,Doctor) VALUES(@FechaIngreso,@FechaCita,@Descripcion,@Paciente,@Doctor);";
                    cn.Open();
                    cn.Execute(query, cita);
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
                var query = @"DELETE FROM CITA WHERE Id=@Id";
                cn.Open();
                cn.Execute(query, new { Id = id });
            }
        }
        public void Update(Cita cita)
        {
            using (IDbConnection cn = con.GetConnection)
            {
                cita.FechaIngreso = DateTime.Now;
                var query = @"UPDATE CITA SET FechaIngreso=@FechaIngreso,FechaCita=@FechaCita,Descripcion=@Descripcion,Paciente=@Paciente,Doctor=@Doctor WHERE Id=@Id";
                cn.Open();
                cn.Execute(query, cita);
            }
        }
    }
}
