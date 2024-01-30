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

    }
}