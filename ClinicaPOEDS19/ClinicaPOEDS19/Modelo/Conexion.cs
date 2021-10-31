using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPOEDS19.Modelo
{
    public class Conexion
    {
        private string con;

        public Conexion()
        {
            con = Properties.Settings.Default.Conexion;
        }
        public IDbConnection GetConnection
        {
            get
            {
                return new SqlConnection(con);
            }
        }

     /*
        public void Add(Product prod)
        {
            try
            {
                using (IDbConnection cn = GetConnection)
                {
                    var query = @"INSERT INTO PRODUCT(Name,Quantity,Price) VALUES(@Name,@Quantity,@Price)";
                    cn.Open();
                    cn.Execute(query, prod);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection cn = GetConnection)
            {
                var query = @"DELETE FROM PRODUCT WHERE ProductId=@Id";
                cn.Open();
                cn.Execute(query, new { Id = id });
            }
        }
        public void Update(Product prod)
        {
            using (IDbConnection cn = GetConnection)
            {
                var query = @"UPDATE PRODUCT SET Name=@Name,Quantity=@Quantity,Price=@Price WHERE ProductId=@ProductId";
                cn.Open();
                cn.Execute(query, prod);
            }
        }*/
    }
}
