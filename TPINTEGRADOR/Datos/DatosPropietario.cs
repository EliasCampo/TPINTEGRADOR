using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TPIntegrador.Datos
{
    internal class DatosPropietario
    {
        public static void insertarPropietario(string nombrePropietario, string razonSocial, string telefono, string cuit, string personaContacto ) 
        {

             string sql = "INSERT INTO Propietario(nombre_propietario,razon_social,telefono,cuit, persona_contacto, baja_propietario) VALUES " +
                                 "(@nombre_propietario,@razon_social, @telefono,@cuit,@persona_contacto, @baja_propietario)"; 

            try
            {
                Conexion Cx = new Conexion();
                Cx.AbrirConexion();
                Cx.SetComnadoSQL(sql);
                SqlCommand cmd = Cx.Comando();

                cmd.Parameters.Add("@nombre_propietario", SqlDbType.VarChar);
                cmd.Parameters[0].Value = nombrePropietario;

                cmd.Parameters.Add("@razon_social", SqlDbType.VarChar);
                cmd.Parameters[1].Value = razonSocial;

                cmd.Parameters.Add("@telefono", SqlDbType.VarChar);
                cmd.Parameters[2].Value = telefono;

                cmd.Parameters.Add("@cuit", SqlDbType.BigInt);
                cmd.Parameters[3].Value = cuit;

                cmd.Parameters.Add("@persona_contacto", SqlDbType.VarChar);
                cmd.Parameters[4].Value = personaContacto;

                cmd.Parameters.Add("@baja_propietario", SqlDbType.Bit);
                cmd.Parameters[5].Value = 0;

                Object nro = cmd.ExecuteScalar(); //.ExecuteNonQuery();


                Cx.CerrarConexion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error por excepción " + e.ToString());

            }

        }

        public static DataTable listarPropietariosNoBaja() 
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "SELECT [id_propietario],[nombre_propietario],[razon_social],[telefono],[cuit],[persona_contacto] FROM[Propietario] WHERE [baja_propietario] = 0";

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

        public static DataTable ModificarDatosPropietario(int idPropietario, string nombrePropietario, string razonSocial, string telefono, Int64 cuit, string personaContacto)
        {
            DataTable listarNoBaja = new DataTable("Listatodos");
            String sql = "UPDATE Propietario SET nombre_propietario = '" + nombrePropietario + "', " + "razon_social = '" + razonSocial + "', " + "telefono = '" + telefono + "', " + "cuit = " + cuit + ", " + "persona_contacto = '" + personaContacto + "' " + "WHERE id_propietario = " + idPropietario;

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




        public static bool BajaDatosPropietario(int idPropietario)
        {
            string sql = "UPDATE Propietario SET baja_propietario = 1 WHERE id_propietario = " + idPropietario;
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

