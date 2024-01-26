using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TPIntegrador.Datos;
using static System.Windows.Forms.MonthCalendar;

namespace TPIntegrador.Controlador
{
    internal class ControladorTarea
    {
        private int idProyecto;
        private int idTarea;
        private string ordenTarea;
        private string descripcionTarea;
        private string horaEstimadaTarea;
        private string costoEstimadoTarea;
        private string horaRealTarea;
        private string costoRealTarea;
        private string fechaFinalTarea;
        private string estadoTarea;
        private string desvioTarea;



		public ControladorTarea(int id_tarea, string orden_tarea, string descripcion_tarea, string horaEstimada_tarea, string costoEstimado_tarea,
								string horaReal_tarea, string costoReal_tarea, string fechaFinal_tarea, string estado_tarea, string desvio)
        {
            idTarea = id_tarea;
            ordenTarea = orden_tarea;
            descripcionTarea = descripcion_tarea;
            horaEstimadaTarea = horaEstimada_tarea;
            costoEstimadoTarea = costoEstimado_tarea;
            horaRealTarea = horaReal_tarea;
            costoRealTarea = costoReal_tarea;
            fechaFinalTarea = fechaFinal_tarea;
            estadoTarea = estado_tarea;
            desvioTarea = desvio;
        }



        public bool validarTarea()
        {
            if (((this.ordenTarea == null) || (this.descripcionTarea == null) || (this.horaEstimadaTarea == null) ||
                    (this.costoEstimadoTarea == null) || (this.horaRealTarea == null) || (this.costoRealTarea == null) ||
                    (this.fechaFinalTarea == null) || (this.estadoTarea == null)) && (Validar.validarFecha(this.fechaFinalTarea) == false))
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

