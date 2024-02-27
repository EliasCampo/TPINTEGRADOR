using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPIntegrador.Datos
{
	internal class DatosObservacion
	{
        public static void insertarObservacion(int legajoEmpleado, DateTime fechaFinal, string observacionEmpleado)
        {

            string sql = "INSERT INTO observaciones(fecha, observacion, legajo_FK) VALUES " +
                                "(@fecha,@observacion, @legajo_FK)";

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
                cmd.Parameters[0].Value = fechaFinal;

                cmd.Parameters.Add("@observacion", SqlDbType.Text);
                cmd.Parameters[1].Value = observacionEmpleado;

                cmd.Parameters.Add("@legajo_FK", SqlDbType.Int);
                cmd.Parameters[2].Value = legajoEmpleado;

                Object nro = cmd.ExecuteScalar(); //.ExecuteNonQuery();

                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());

            }
        }

        public static DataTable listarObservacion(int legajo)
        {
            DataTable listarObservacion = new DataTable("Listatodos");
            String sql = "SELECT [id_observacion],[fecha],[observacion],[legajo_FK] FROM[observaciones] WHERE [legajo_FK] = " + legajo;

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);

                SqlDataAdapter sqlDat = new SqlDataAdapter(Cx.Comando());
                sqlDat.Fill(listarObservacion);
                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                listarObservacion = null;
            }
            return listarObservacion;
        }

        public static DataTable ModificarDatosObservacion(string observacion, DateTime fecha, int idObservacion)
        {
            DataTable listarObservacion = new DataTable("Listatodos");
            String sql = "UPDATE observaciones SET fecha = '" + fecha + "', " + "observacion = '" + observacion + "', " + "WHERE id_observacion = " + idObservacion;

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);

                SqlDataAdapter sqlDat = new SqlDataAdapter(Cx.Comando());
                sqlDat.Fill(listarObservacion);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                listarObservacion = null;
            }
            return listarObservacion;
        }
    }
}
