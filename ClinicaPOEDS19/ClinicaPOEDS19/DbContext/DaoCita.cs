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
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"INSERT INTO CITA(FechaIngreso,FechaCita,Descripcion,Paciente,Doctor) VALUES(GETDATE(),@FechaCita,@Descripcion,@Paciente,@Doctor);";
                    cn.Open();
                    cn.Execute(query, cita);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
