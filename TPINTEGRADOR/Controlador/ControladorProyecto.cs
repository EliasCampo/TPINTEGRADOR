using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPIntegrador.Datos;
using System.Runtime.CompilerServices;

namespace TPIntegrador.Controlador
{
    internal class ControladorProyecto
    {
        private int idProyecto;
        private string nombreProyecto;
        private string empresa;
        private decimal costoEstimado;
        private decimal costoReal;
        private decimal desvioProyecto;
        private int id_propietario;
        private int id_empleado;

		public ControladorProyecto()
		{

		}
		public ControladorProyecto(int id_proyecto, string nombre_proyecto, string empresa_proyecto, decimal costo_estimado, decimal costo_real, decimal desvio_proyecto)
        {
            idProyecto = id_proyecto;
            nombreProyecto = nombre_proyecto;
            empresa = empresa_proyecto;
            //gradoAvance = grado_avance;
            costoEstimado = costo_estimado;
            costoReal = costo_real;
            desvioProyecto = desvio_proyecto;
        }

        public bool ValidarDatosProyecto()
        {
            if ( ((this.nombreProyecto == "") | (this.empresa == "")) | ((this.nombreProyecto == "Ingrese Nombre Proyecto") | (this.empresa == "Ingrese Nombre Empresa")) )

			{
                return false;
            }
            else
            {
                return true;
            }
        }


        public static DataTable listarProyectoPropietarioBDD(int idPropietario)
        {
            DataTable proyectoPropietario = DatosProyecto.listarProyectosPropietario(idPropietario);
            return proyectoPropietario;
        }
    }

}