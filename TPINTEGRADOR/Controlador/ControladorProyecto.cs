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
        private decimal montoEstimado; 
        private decimal costoEstimado;
        private decimal costoReal;
        private decimal desvioProyecto;
        private int gradoAvance;
        private int legajoFk;
        private int idPropietarioFK;
        

		public ControladorProyecto()
		{

		}
		public ControladorProyecto(string nombre_proyecto, string empresa_proyecto, decimal monto_estimado, decimal costo_estimado, decimal costo_real, decimal desvio_proyecto, int grado_avance, int legajo_FK, int id_propietario_FK)
        {
            
            nombreProyecto = nombre_proyecto;
            empresa = empresa_proyecto;
            montoEstimado = monto_estimado;
            gradoAvance = grado_avance;
            costoEstimado = costo_estimado;
            costoReal = costo_real;
            desvioProyecto = desvio_proyecto;
            legajoFk = legajo_FK;
            idPropietarioFK = id_propietario_FK; 
        }

        public ControladorProyecto(int id_proyecto, string nombre_proyecto, string empresa_proyecto)
        {
            idProyecto = id_proyecto;
            nombreProyecto = nombre_proyecto;
            empresa = empresa_proyecto;
        }

        public ControladorProyecto(int id_proyecto, decimal monto_estimado, decimal costo_estimado, decimal costo_real, decimal desvio_proyecto, int grado_avance)
        {
            montoEstimado = monto_estimado;
            gradoAvance = grado_avance;
            costoEstimado = costo_estimado;
            costoReal = costo_real;
            desvioProyecto = desvio_proyecto;
            idProyecto = id_proyecto;
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

        public void insertarProyectoBDD()
        {
            DatosProyecto.insertarProyecto(this.nombreProyecto, this.empresa, this.montoEstimado, this.costoEstimado, this.costoReal, this.desvioProyecto, this.gradoAvance, this.legajoFk, this.idPropietarioFK);

        }


        public static DataTable listarProyectoPropietarioBDD(int idPropietario)
        {
            DataTable proyectoPropietario = DatosProyecto.listarProyectosPropietario(idPropietario);
            return proyectoPropietario;
        }

        public static DataTable listarProyectosLiderBDD(int idLider)
        {
            DataTable proyectoLider = DatosProyecto.listarProyectosLider(idLider);
            return proyectoLider;
        }

        public static int obtenerUltimoIdProyectoBDD()
        {
            int ultimoId = DatosProyecto.obtenerUltimoIdProyecto();
            return ultimoId;
        }

        public DataTable ModificarDatosProyectoBDD()
        {

            DataTable listarProyecto = DatosProyecto.ModificarDatosProyecto(this.idProyecto, this.nombreProyecto, this.empresa);
            return listarProyecto;
        }

        public static void BajaDatosProyectoBDD(int idProyecto)
        {
            DatosProyecto.BajaDatosProyecto(idProyecto);
        }

        public DataTable ModificarCostoYGradoAvanceBDD()
        {
            DataTable listarProyecto = DatosProyecto.ModificarCostoYGradoAvance(this.idProyecto, this.montoEstimado, this.costoEstimado, this.costoReal, this.gradoAvance, this.desvioProyecto);
            return listarProyecto;
        }
    }

}