using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPIntegrador.Datos
{
    internal class DatosTrabaja
    {


        public static void insertarTrabaja(int idProyecto, int idTarea, int legajo, int idFuncion)
        {
            string sql = "INSERT INTO Trabaja(id_proyecto, id_tarea, legajo, id_funcion_fk) VALUES " +
                                "(@id_proyecto, @id_tarea,@legajo,@id_funcion_fk)";

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                cmd.Parameters.Add("@id_proyecto", SqlDbType.VarChar);
                cmd.Parameters[0].Value = idProyecto;

                cmd.Parameters.Add("@id_tarea", SqlDbType.VarChar);
                cmd.Parameters[1].Value = idTarea;

                cmd.Parameters.Add("@legajo", SqlDbType.VarChar);
                cmd.Parameters[2].Value = legajo;

                cmd.Parameters.Add("@id_funcion_fk", SqlDbType.BigInt);
                cmd.Parameters[3].Value = idFuncion;


                Object nro = cmd.ExecuteScalar(); //.ExecuteNonQuery();


                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());

            }

        }

        public static DataTable ModificarDatosTrabaja(int idProyecto, int legajo)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "UPDATE Trabaja SET id_proyecto = '" + idProyecto + "' WHERE legajo = " + legajo;

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

        public static DataTable ModificarEmpleadoTrabaja(int idTarea, int legajo)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "UPDATE Trabaja SET legajo = '" + legajo + "' WHERE id_tarea = " + idTarea;

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



        public static DataTable ModificarEmpleadoFuncion(int legajo, int funcion)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "UPDATE Trabaja SET id_funcion_fk = '" + funcion + "' WHERE legajo = " + legajo;

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


        public static int obtenerIdFuncionEmpleado(int legajo)
        {
            int id_funcion = -1;
            var resultado = "";
            string sql = "SELECT TOP 1 id_funcion_fk FROM Trabaja " +
                " WHERE legajo = '" + legajo +
                "' ORDER BY id_funcion_fk DESC "; 
            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                if (cmd.ExecuteScalar() != null)
                {
                    resultado = cmd.ExecuteScalar().ToString(); //.ExecuteNonQuery();
                    id_funcion = Convert.ToInt32(resultado);
                    Cx.CerrarConexion();
                    return id_funcion;
                }
                else
                {
                    return -1;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());
                return id_funcion;
            }
        }

    }
}
