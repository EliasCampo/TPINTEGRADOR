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
            String sql = "select E.legajo, E.fecha_ingreso, E.nombre, E.apellido,E.celular, E.email " +
                "from Proyecto P " +
                "INNER JOIN Empleado E ON P.legajo_FK = E.legajo " +
                "INNER JOIN Trabaja T ON  E.legajo = T.legajo AND P.id_proyecto = T.id_proyecto " +
                "WHERE P.baja_proyecto = 0 " +
                "Group by E.legajo, E.fecha_ingreso, E.nombre, E.apellido,E.celular, E.email " +
                "HAVING COUNT (P.id_proyecto) < 3 ";    


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

        public static DataTable listarUltimoIdLider(int idLider)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "SELECT [legajo],[nombre],[apellido],[celular],[email],[fecha_ingreso] FROM[Empleado] WHERE [baja_empleado] = 0 AND legajo = " + idLider;

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

    }
}
