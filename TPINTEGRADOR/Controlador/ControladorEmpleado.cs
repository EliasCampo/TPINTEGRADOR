using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TPIntegrador.Datos;

namespace TPIntegrador.Controlador
{
    internal class ControladorEmpleado
    {
		
        private int legajoEmpleado;
        private string fechaIngresoEmpleado; //validacion 2023-06-27 año 4 digitos, mes 2 digitos y dia 2 digitos
        private string nombreEmpleado;
        private string apellidoEmpleado;
        private string celularEmpleado;
        private string emailEmpleado;

        


        public ControladorEmpleado( int legajo_empleado, string nombre_empleado, string apellido_empleado, string celular_empleado, string email_empleado, string fecha_ingreso)
        {
			
            legajoEmpleado = legajo_empleado;
            fechaIngresoEmpleado = fecha_ingreso;
            nombreEmpleado = nombre_empleado;
            apellidoEmpleado = apellido_empleado;
            celularEmpleado = celular_empleado;
            emailEmpleado = email_empleado;

        }

		public ControladorEmpleado()
		{

		}

        public bool ValidarDatos()
        {
			
			if ((Validar.validarCorreo(this.emailEmpleado) == false) && (Validar.validarFecha(this.fechaIngresoEmpleado) == false))
			{
				return false;
			}
			
            if ((this.fechaIngresoEmpleado == "") | (this.nombreEmpleado == "") | (this.apellidoEmpleado == "") | (this.celularEmpleado == "") | (this.emailEmpleado == ""))
            {
                return false;
            }
            else
            {
				if ((this.fechaIngresoEmpleado == "Ingrese Fecha") | (this.nombreEmpleado == "Ingrese Nombre") | (this.apellidoEmpleado == "Ingrese Apellido") | (this.celularEmpleado == "Ingrese N° Celular") | (this.emailEmpleado == "Ingrese Correo"))
				{
					return false;
				}
				else
				{
					return true;
				}
            }
        }



        public static DataTable listarEmpleadoLiderBDD() 
        {
            DataTable liderMenorA3 = DatosEmpleado.listarLider();
            return liderMenorA3;
        }


        public void insertarNuevoLiderBDD()
        {
            DatosEmpleado.insertarLider(this.nombreEmpleado, this.apellidoEmpleado, this.celularEmpleado, this.emailEmpleado, this.fechaIngresoEmpleado);

        }

        public static DataTable listarUltimoLiderBDD(int idLider)
        {
            DataTable ultimoLider = DatosEmpleado.listarUltimoIdLider(idLider);
            return ultimoLider;
        }

        public static int obtenerUltimoIdBDD() 
        {
            int ultimoId = DatosEmpleado.obtenerUltimoId();
            return ultimoId;
        }



    }
}