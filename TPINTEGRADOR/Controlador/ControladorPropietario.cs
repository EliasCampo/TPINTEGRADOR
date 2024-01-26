using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TPIntegrador.Datos;

namespace TPIntegrador.Controlador
{
    internal class ControladorPropietario
    {
        private int idPropietario;
        private string nombrePropietario;
        private string razonSocialPropietario;
        private string telefonoPropietario;
        private string cuitPropietario;
        private string personaContactoPropietario;

        

        public ControladorPropietario(int id_Propietario, string nombre, string razonSocial, string telefono, string cuit, string personaContacto)
        {
            idPropietario = id_Propietario;
            nombrePropietario = nombre;
            razonSocialPropietario = razonSocial;
            telefonoPropietario = telefono;
            cuitPropietario = cuit;
            personaContactoPropietario = personaContacto;


		}

		public ControladorPropietario()
		{

		}


		public bool validar()
        {

			if (Validar.ValidaCuit(this.cuitPropietario) == false)
            {
                Validar.mError("El cuit ingresado es invalido");
                return false;
            }

			if ((this.nombrePropietario == "") | (this.razonSocialPropietario == "") | (this.telefonoPropietario == "") | (this.personaContactoPropietario == "") | (this.cuitPropietario == ""))
            {
                return false;
               
            }
            else
            {
				if ((this.nombrePropietario == "Ingrese Nombre") | (this.razonSocialPropietario == "Ingrese Razón Social") | (this.telefonoPropietario == "Ingrese Telefono") | (this.personaContactoPropietario == "Ingrese Persona Contacto") | (this.cuitPropietario == "Ingrese Cuit") )
				{
					return false;
                }
                else
                {
					return true;
				}
				
            }
          
        }



        public void insertarPropietario() 
        {
            DatosPropietario.insertarPropietario(this.nombrePropietario, this.razonSocialPropietario, this.telefonoPropietario, this.cuitPropietario, this.personaContactoPropietario);
            
        }

        //listamos los propietarios de la base de datos que no estan dados de baja
        public static DataTable obtenerPropietariosBDD()
        {
            DataTable listaPropietariosBDD = DatosPropietario.listarPropietariosNoBaja();
            return listaPropietariosBDD;
        }

        public DataTable ModificarDatosPropietarioBDD()  
        {
            
            DataTable listarPropietarios = DatosPropietario.ModificarDatosPropietario(this.idPropietario, this.nombrePropietario, this.razonSocialPropietario, this.telefonoPropietario, Convert.ToInt64(this.cuitPropietario), this.personaContactoPropietario);
            return listarPropietarios;
        }


        public static void BajaDatosPropietarioBDD(int idPropietario)
        {

            DatosPropietario.BajaDatosPropietario(idPropietario);

        }

    }
}