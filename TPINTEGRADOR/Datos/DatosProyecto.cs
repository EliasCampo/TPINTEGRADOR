using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using System.Reflection.Metadata.Ecma335;

namespace TPIntegrador.Datos
{
    internal class DatosProyecto
    {

        public static DataTable listarProyectosPropietario(int idPropietario)
        {
            DataTable listarProyecto = new DataTable("Listatodos");
            String sql = "SELECT [id_proyecto],[nombre],[empresa],[monto_estimado],[costo_estimado],[costo_real],[desvio] FROM[Proyecto] WHERE [baja_proyecto] = 0 AND [id_propietario_FK] = " + idPropietario;

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);

                SqlDataAdapter sqlDat = new SqlDataAdapter(Cx.Comando());
                sqlDat.Fill(listarProyecto);
                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                listarProyecto = null;
            }
            return listarProyecto;
        }


        public static void insertarProyecto(string nombre, string empresa, decimal montoEstimado, decimal costoEstimado, decimal costoReal, decimal desvio, int legajoFK, int idPropietarioFK)
        {

            string sql = "INSERT INTO Proyecto(nombre,empresa,monto_estimado, costo_estimado, costo_real, desvio, legajo_FK, id_propietario_FK, baja_proyecto) VALUES " +
                                "(@nombre, @empresa,@monto_estimado,@costo_estimado, @costo_real, @desvio, @legajo_FK, @id_propietario_FK, @baja_proyecto)";

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                cmd.Parameters[0].Value = nombre;

                cmd.Parameters.Add("@empresa", SqlDbType.VarChar);
                cmd.Parameters[1].Value = empresa;

                cmd.Parameters.Add("@monto_estimado", SqlDbType.Decimal);
                cmd.Parameters[2].Value = montoEstimado;

                cmd.Parameters.Add("@costo_estimado", SqlDbType.Decimal);
                cmd.Parameters[3].Value = costoEstimado;

                cmd.Parameters.Add("@costo_real", SqlDbType.Decimal);
                cmd.Parameters[4].Value = costoReal;

                cmd.Parameters.Add("@desvio", SqlDbType.Decimal);
                cmd.Parameters[5].Value = desvio;

                cmd.Parameters.Add("@legajo_FK", SqlDbType.Int);
                cmd.Parameters[6].Value = legajoFK;

                cmd.Parameters.Add("@id_propietario_FK", SqlDbType.Int);
                cmd.Parameters[7].Value = idPropietarioFK;

                cmd.Parameters.Add("@baja_proyecto", SqlDbType.Bit);
                cmd.Parameters[8].Value = 0;

                Object nro = cmd.ExecuteScalar(); //.ExecuteNonQuery();


                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());

            }

        }

        public static DataTable listarProyectosLider(int idLider)
        {
            DataTable listarProyecto = new DataTable("Listatodos");
            String sql = "SELECT [id_proyecto],[nombre],[empresa],[monto_estimado],[costo_estimado],[costo_real],[desvio] FROM[Proyecto] WHERE [baja_proyecto] = 0 AND [legajo_FK] = " + idLider;

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);

                SqlDataAdapter sqlDat = new SqlDataAdapter(Cx.Comando());
                sqlDat.Fill(listarProyecto);
                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                listarProyecto = null;
            }
            return listarProyecto;
        }

        public static int obtenerUltimoIdProyecto() // obtener ultimo idProyecto para poder actualizar la tabla trabaja y guardar el id del proyecto
        {
            int id_proyecto = -1;
            var resultado = "";
            string sql = "SELECT TOP 1 id_proyecto FROM Proyecto ORDER BY id_proyecto DESC";
            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                if (cmd.ExecuteScalar() != null)
                {
                    resultado = cmd.ExecuteScalar().ToString(); //.ExecuteNonQuery();
                    id_proyecto = Convert.ToInt32(resultado);
                    Cx.CerrarConexion();
                    return id_proyecto;
                }
                else
                {
                    return -1;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                return id_proyecto;
            }
        }

        public static DataTable ModificarDatosProyecto(int idProyecto, string nombreProyecto, string nombreEmpresa)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "UPDATE Proyecto SET nombre = '" + nombreProyecto + "', " + "empresa = '" + nombreEmpresa + "' WHERE id_proyecto = " + idProyecto;

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

        public static bool BajaDatosProyecto(int idProyecto)
        {
            string sql = "UPDATE Proyecto SET baja_proyecto = 1 WHERE id_proyecto = " + idProyecto;
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