using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPIntegrador.Datos;

namespace TPIntegrador.Controlador
{
    internal class ControladorFuncion
    {
        private int idFuncion;
        private string funcionEmpleado;

       
        public ControladorFuncion(string funcion_empleado)
        {

            funcionEmpleado = funcion_empleado;
        }

        public bool validarFuncion()
        {
            if (this.funcionEmpleado == null)
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

