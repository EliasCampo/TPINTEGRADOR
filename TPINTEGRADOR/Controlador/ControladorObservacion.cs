using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPIntegrador.Datos;

namespace TPIntegrador.Controlador
{
    internal class ControladorObservacion
    {
        private int idObservacion;
        private DateTime fechaObservacion;
        private string observacion;
        private int legajoEmpleadoFK;

		

		public ControladorObservacion(int id_observacion, int legajo_empleado,DateTime fecha_observacion, string observacion_empleado)
        {
            idObservacion = id_observacion;
            fechaObservacion = fecha_observacion;
            observacion = observacion_empleado;
            legajoEmpleadoFK = legajo_empleado;
        }



        public bool validacionFecha()
        {
            if ((this.fechaObservacion == null) & (Validar.validarFecha(this.fechaObservacion.ToString("yyyy-mm-dd")) == false) & (this.observacion == null || this.observacion == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void insertarObservacionBDD(int legajo, DateTime fecha, string observacion)
        {
            DatosObservacion.insertarObservacion(this.legajoEmpleadoFK, this.fechaObservacion, this.observacion);

        }

        public static DataTable obtenerObservacionBDD(int legajoEmpleado)
        {
            DataTable listaObservacionBDD = DatosObservacion.listarObservacion(legajoEmpleado);
            return listaObservacionBDD;
        }

        public DataTable ModificarDatosObservacionBDD()
        {

            DataTable listarObservacion = DatosObservacion.ModificarDatosObservacion(this.observacion, this.fechaObservacion, this.idObservacion);
            return listarObservacion;
        }


    }
}

