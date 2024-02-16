using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPIntegrador.Datos
{
    internal class DatosEmpleado
    {
        public static DataTable listarLider()
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "SELECT E.legajo, E.nombre, E.apellido, E.celular, E.email, E.fecha_ingreso " +
                "FROM Empleado E " +
                "LEFT JOIN Trabaja T ON E.legajo = T.legajo " +
                "LEFT JOIN Proyecto P ON T.id_proyecto = P.id_proyecto " +
                "WHERE P.baja_proyecto = 0 OR P.id_proyecto IS NULL AND E.baja_empleado = 0 " +
                "GROUP BY E.legajo, E.fecha_ingreso, E.nombre, E.apellido, E.celular, E.email, E.baja_empleado " +
                "HAVING COUNT(T.id_proyecto) < 3 OR COUNT(T.id_proyecto) IS NULL ";    


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



        public static void insertarLider(string nombreEmpleado, string apellidoEmpleado, string celular, string email, string fechaIngreso)
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


        public static DataTable ModificarDatosLider(int idLider, string nombre, string apellido, string celular,  string email)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "UPDATE Empleado SET nombre = '" + nombre + "', " + "apellido = '" + apellido + "', " + "celular = '" + celular + "', " + "email = '" + email + "' " +
                "WHERE legajo = " + idLider;

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

        public static bool BajaDatosLider(int idLider)
        {
            string sql = "UPDATE Empleado SET baja_empleado = 1 WHERE legajo = " + idLider;
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

        public static int obtenerUltimoId() 
        {
            int id_empleado = -1;
            var resultado = "";
            string sql = "SELECT TOP 1 legajo FROM Empleado ORDER BY legajo DESC";
            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                if (cmd.ExecuteScalar() != null)
                {
                    resultado = cmd.ExecuteScalar().ToString(); //.ExecuteNonQuery();
                    id_empleado = Convert.ToInt32(resultado);
                    Cx.CerrarConexion();
                    return id_empleado;
                }
                else
                {
                    return -1;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                return id_empleado;
            }
        }

       

    }
}
