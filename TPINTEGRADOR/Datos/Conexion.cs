using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TPIntegrador.Datos
{
    internal class Conexion
    {
        private SqlConnection conexion = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();

        string servidor = ConfigurationManager.AppSettings["server"];
        string dbname = ConfigurationManager.AppSettings["dbname"];

        public void AbrirConexion()
        {
            try
            {
                
                string stringConx = "Data Source=ELIAS\\SQLEXPRESS;Initial Catalog=final-programacion3;Integrated Security=True;";
                conexion.ConnectionString = stringConx;
                conexion.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show("No Se Pudo Conectar: " + e.ToString());
            }


        }

        public void CerrarConexion()
        {
            try
            {
                this.conexion.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show("no hay coenxion: " + e.ToString());
            }
        }

        public void SetComnadoSQL(string sql)
        {
            this.cmd.CommandText = sql;
            this.cmd.CommandType = System.Data.CommandType.Text;
            this.cmd.Connection = this.conexion;
        }

        public SqlCommand Comando()
        {
            return this.cmd;
        }

        

        public static bool ComprobarGuardado(string sql2, Conexion cx)
        {
            try
            {
                SqlCommand cmd = cx.Comando();
                cx.SetComnadoSQL(sql2);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}