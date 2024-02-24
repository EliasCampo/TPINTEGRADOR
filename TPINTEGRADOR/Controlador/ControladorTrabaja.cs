using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPIntegrador.Datos;

namespace TPIntegrador.Controlador
{
    internal class ControladorTrabaja
    {
        private int idProyecto;
        private int idTarea;
        private int legajo;
        private int idFuncion;

        public ControladorTrabaja(int id_proyecto, int id_tarea, int legajo_trabaja, int id_funcion)
        {
            this.idProyecto = id_proyecto;
            this.idTarea = id_tarea;
            this.legajo = legajo_trabaja;
            this.idFuncion = id_funcion;
        }


        public void insertarTrabajaBDD() 
        {
            DatosTrabaja.insertarTrabaja(this.idProyecto, this.idTarea, this.legajo, this.idFuncion);
        }
        
        public DataTable ModificarDatosTrabajaBDD()
        {
            DataTable listarTrabaja = DatosTrabaja.ModificarDatosTrabaja(this.idProyecto, this.legajo);
            return listarTrabaja;
        }

        public DataTable ModificarEmpleadoTrabajaBDD()
        {
            DataTable listarTrabaja = DatosTrabaja.ModificarEmpleadoTrabaja(this.idTarea, this.legajo);
            return listarTrabaja;
        }
    }
}
