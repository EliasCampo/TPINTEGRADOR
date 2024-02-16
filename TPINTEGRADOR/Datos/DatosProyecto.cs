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


        public static void insertarProyecto(string nombreEmpleado, string apellidoEmpleado, string celular, string email, string fechaIngreso)
        {

            string sql = "INSERT INTO Empleado(nombre,apellido,celular, email, fecha_ingreso, baja_empleado) VALUES " +
                                "(@nombre, @apellido,@celular,@email, @fecha_ingreso, @baja_empleado)";

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
                cmd.Parameters[0].Value = nombreEmpleado;

                cmd.Parameters.Add("@apellido", SqlDbType.VarChar);
                cmd.Parameters[1].Value = apellidoEmpleado;

                cmd.Parameters.Add("@celular", SqlDbType.VarChar);
                cmd.Parameters[2].Value = celular;

                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters[3].Value = email;

                cmd.Parameters.Add("@fecha_ingreso", SqlDbType.VarChar);
                cmd.Parameters[4].Value = fechaIngreso;

                cmd.Parameters.Add("@baja_empleado", SqlDbType.Bit);
                cmd.Parameters[5].Value = 0;

                Object nro = cmd.ExecuteScalar(); //.ExecuteNonQuery();


                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());

            }

        }

    }
}