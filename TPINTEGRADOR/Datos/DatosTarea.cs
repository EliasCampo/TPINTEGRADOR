using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPIntegrador.Datos
{
    internal class DatosTarea
    {
        public static void insertarTarea(int idProyecto, string descripcionTarea, int horaEstimadaTarea, decimal costoEstimadoTarea, int horaRealTarea, decimal costoReal, DateTime fechaFinalTarea, decimal desvio, string estado)
        {

            string sql = "INSERT INTO Tarea(id_proyecto,descripcion,horas_estimadas,costo_estimado, horas_reales, costo_real, fecha_final, desvio, estado, baja_tarea) VALUES " +
                                "(@id_proyecto,@descripcion, @horas_estimadas,@costo_estimado,@horas_reales, @costo_real, @fecha_final, @desvio, @estado, @baja_tarea)";

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                cmd.Parameters.Add("@id_proyecto", SqlDbType.Int);
                cmd.Parameters[0].Value = idProyecto;

                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar);
                cmd.Parameters[1].Value = descripcionTarea;

                cmd.Parameters.Add("@horas_estimadas", SqlDbType.Int);
                cmd.Parameters[2].Value = horaEstimadaTarea;

                cmd.Parameters.Add("@costo_estimado", SqlDbType.Decimal);
                cmd.Parameters[3].Value = costoEstimadoTarea;

                cmd.Parameters.Add("@horas_reales", SqlDbType.Int);
                cmd.Parameters[4].Value = horaRealTarea;

                cmd.Parameters.Add("@costo_real", SqlDbType.Decimal);
                cmd.Parameters[5].Value = costoReal;

                cmd.Parameters.Add("@fecha_final", SqlDbType.Date);
                cmd.Parameters[6].Value = fechaFinalTarea;

                cmd.Parameters.Add("@desvio", SqlDbType.Decimal);
                cmd.Parameters[7].Value = desvio;

                cmd.Parameters.Add("@estado", SqlDbType.VarChar);
                cmd.Parameters[8].Value = estado;

                cmd.Parameters.Add("@baja_tarea", SqlDbType.Bit);
                cmd.Parameters[9].Value = 0;

                Object nro = cmd.ExecuteScalar(); //.ExecuteNonQuery();


                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());

            }

        }

        public static DataTable listarTareaNoBaja(int idProyecto)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "SELECT [nro_tarea],[id_proyecto],[descripcion],[horas_estimadas],[costo_estimado],[horas_reales],[costo_real],[fecha_final],[desvio],[estado] FROM[Tarea] WHERE [baja_tarea] = 0 AND [id_proyecto] = " + idProyecto ;

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);

                SqlDataAdapter sqlDat = new SqlDataAdapter(Cx.Comando());
                sqlDat.Fill(listarNoBaja);
                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                listarNoBaja = null;
            }
            return listarNoBaja;
        }

        public static int obtenerUltimoIdTarea() // obtener ultimo idTarea para poder actualizar la tabla trabaja y guardar el id del proyecto
        {
            int nro_tarea = -1;
            var resultado = "";
            string sql = "SELECT TOP 1 nro_tarea FROM Tarea ORDER BY nro_tarea DESC";
            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                if (cmd.ExecuteScalar() != null)
                {
                    resultado = cmd.ExecuteScalar().ToString(); //.ExecuteNonQuery();
                    nro_tarea = Convert.ToInt32(resultado);
                    Cx.CerrarConexion();
                    return nro_tarea;
                }
                else
                {
                    return -1;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                return nro_tarea;
            }
        }



        public static DataTable ModificarDatosTarea(int idTarea, int horaRealTarea, decimal costoRealTarea, DateTime fechaFinalTarea, decimal desvioTarea, string estadoTarea)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "UPDATE Tarea SET horas_reales = '" + horaRealTarea + "', costo_real = '" + costoRealTarea + "', fecha_final = '" + fechaFinalTarea + "', desvio = '" + desvioTarea + "', estado = '" + estadoTarea + "'  WHERE nro_tarea = " + idTarea;

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);

                SqlDataAdapter sqlDat = new SqlDataAdapter(Cx.Comando());
                sqlDat.Fill(listarNoBaja);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                listarNoBaja = null;
            }
            return listarNoBaja;
        }


        public static DataTable obtenerCostos(int idTarea)
        {
            DataTable listaCostos = new DataTable("Listatodos");
            String sql = "SELECT [costo_estimado],[costo_real] FROM[Tarea] WHERE [nro_tarea] = " + idTarea + "AND [baja_tarea] = 0";

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);

                SqlDataAdapter sqlDat = new SqlDataAdapter(Cx.Comando());
                sqlDat.Fill(listaCostos);
                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                listaCostos = null;
            }
            return listaCostos;
        }


        public static DataTable ModificarCostoTarea(int idTarea, decimal desvioTarea)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = $"UPDATE Tarea SET desvio={desvioTarea.ToString().Replace(",", ".")} WHERE nro_tarea={idTarea}";

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);

                SqlDataAdapter sqlDat = new SqlDataAdapter(Cx.Comando());
                sqlDat.Fill(listarNoBaja);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                listarNoBaja = null;
            }
            return listarNoBaja;
        }


        public static bool BajaDatosTarea(int nroTarea)
        {
            string sql = "UPDATE Tarea SET baja_tarea = 1 WHERE nro_tarea = " + nroTarea; // 1 = true -- dado de baja
            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                Object nro = cmd.ExecuteScalar(); //.ExecuteNonQuery();
                Cx.CerrarConexion();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                return false;

            }
        }



        

    }
}
