using ClinicaPOEDS19.Modelo;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicaPOEDS19.DbContext
{
    public class DaoUsuario
    {
        private Conexion con = new Conexion();

        public int FindUsuario(Usuarios usu)
        {
            int retorno = 0;
            try
            {
                SqlConnection con = new SqlConnection(Properties.Settings.Default.Conexion);
                string usua = usu.Usuario;
                string contra = usu.Clave;
                string query = @"	SELECT  COUNT(*)  FROM USUARIO WHERE Usuario ='" + usua + "' AND CONVERT(VARCHAR,DECRYPTBYPASSPHRASE('Itca123!',CLAVE)) = '" + contra + "' ";
                con.Open();

                SqlCommand command = new SqlCommand(query, con);
                int resultado = Convert.ToInt32(command.ExecuteScalar());
                if (resultado > 0)
                {
                retorno = 1;
                     
                    }
                    else
                    {
                    retorno = 0;
                }
             
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return retorno;
        }
        public List<Usuarios> GetAll()
        {
            var ls = new List<Usuarios>();
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"SELECT Id, Usuario, case when Estado>0 then 'Activo' else 'Inactivo' end as Estado, CONVERT(VARCHAR,DECRYPTBYPASSPHRASE('Itca123!',CLAVE)) CLAVE, FechaCreacion FROM USUARIO";
                    cn.Open();
                    ls = cn.Query<Usuarios>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return ls;
        }

        public void Add(Usuarios usu)
        {
            try
            {
                usu.FechaCreacion = DateTime.Now;
                using (IDbConnection cn = con.GetConnection)
                {
                    string contra = usu.Clave;
                    var query = @"INSERT INTO USUARIO(USUARIO,CLAVE,ESTADO,FechaCreacion) 
                    VALUES(@USUARIO, ENCRYPTBYPASSPHRASE('Itca123!', '" + contra+ "'), @Estado,@FechaCreacion)";
                    cn.Open();
                    cn.Execute(query, usu);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Update(Usuarios usu)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    string contra = usu.Clave;
                    var query = "UPDATE USUARIO SET USUARIO = @USUARIO, CLAVE = ENCRYPTBYPASSPHRASE('Itca123!','" + contra + "'), ESTADO=@Estado  WHERE Id = @Id";
                    cn.Open();
                    cn.Execute(query, usu);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Delete(Usuarios usu)
        {
            try
            {
                using (IDbConnection cn = con.GetConnection)
                {
                    var query = @"DELETE FROM Usuario WHERE Id = @Id;";
                    cn.Open();
                    cn.Execute(query, usu);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
