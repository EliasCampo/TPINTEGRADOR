using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPIntegrador.Controlador
{
    internal class ControladorObservacion
    {
        private int idObservacion;
        private string fechaObservacion;
        private string observacion;

		

		public ControladorObservacion(string fecha_observacion, string observacion_empleado)
        {
            fechaObservacion = fecha_observacion;
            observacion = observacion_empleado;
        }


        public bool validacionFecha()
        {
            if ((this.fechaObservacion == null) & (Validar.validarFecha(this.fechaObservacion) == false))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}

