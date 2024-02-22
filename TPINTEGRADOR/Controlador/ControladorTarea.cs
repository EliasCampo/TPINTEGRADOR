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
        private DateTime fechaFinalTarea;
        private string estadoTarea;
        private string desvioTarea;



		public ControladorTarea(int id_proyecto, string descripcion_tarea, string horaEstimada_tarea, string costoEstimado_tarea,
								string horaReal_tarea, string costoReal_tarea, DateTime fechaFinal_tarea, string estado_tarea, string desvio) 
        {
            idProyecto = id_proyecto; 
            descripcionTarea = descripcion_tarea;
            horaEstimadaTarea = horaEstimada_tarea;
            costoEstimadoTarea = costoEstimado_tarea;
            horaRealTarea = horaReal_tarea;
            costoRealTarea = costoReal_tarea;
            fechaFinalTarea = fechaFinal_tarea;
            estadoTarea = estado_tarea;
            desvioTarea = desvio;
        }


        public ControladorTarea(int id_tarea, string horaReal_tarea, string costoReal_tarea, DateTime fechaFinal_tarea, string estado_tarea, string desvio)
        {
            idTarea = id_tarea;
            horaRealTarea = horaReal_tarea;
            costoRealTarea = costoReal_tarea;
            fechaFinalTarea = fechaFinal_tarea;
            estadoTarea = estado_tarea;
            desvioTarea = desvio;
        }

        public ControladorTarea(string desvio) 
        {
            this.desvioTarea = desvio; 
        }



        public bool validarTarea()
        {
            if (((this.descripcionTarea == null) || (this.horaEstimadaTarea == null) ||
                    (this.costoEstimadoTarea == null) || (this.horaRealTarea == null) || (this.costoRealTarea == null) ||
                    (this.fechaFinalTarea == null) || (this.estadoTarea == null)) || (this.desvioTarea == null) && (Validar.validarFecha(this.fechaFinalTarea.ToString("yyyy-mm-dd")) == false))

            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validarHoraCostoReal()
        {
            if ((this.horaRealTarea == "") || (this.costoRealTarea == ""))
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public void insertarTarea()
        {
            DatosTarea.insertarTarea(this.idProyecto, this.descripcionTarea, Convert.ToInt32(this.horaEstimadaTarea), Convert.ToDecimal(this.costoEstimadoTarea), Convert.ToInt32(this.horaRealTarea), Convert.ToDecimal(this.costoRealTarea), this.fechaFinalTarea, Convert.ToDecimal(this.desvioTarea), this.estadoTarea);

        }

        public static DataTable obtenerTareaProyectoBDD(int idProyecto)
        {
            DataTable listaTareasBDD = DatosTarea.listarTareaNoBaja(idProyecto);
            return listaTareasBDD;
        }


        public static int obtenerUltimoIdTareaBDD()
        {
            int ultimoId = DatosTarea.obtenerUltimoIdTarea();
            return ultimoId;
        }


        public DataTable ModificarDatosTareaBDD()
        {
            DataTable listarTareas = DatosTarea.ModificarDatosTarea(this.idTarea, Convert.ToInt32(this.horaRealTarea), Convert.ToDecimal(this.costoRealTarea), this.fechaFinalTarea, Convert.ToDecimal(this.desvioTarea), this.estadoTarea);
            return listarTareas;
        }


        public static DataTable obtenerCostosBDD(int idTarea)
        {
            DataTable listarCostos = DatosTarea.obtenerCostos(idTarea);
            return listarCostos;
        }

        public DataTable modificarDesvioBDD(int idTarea, decimal desvio)
        {
            DataTable listarCostos = DatosTarea.ModificarCostoTarea(idTarea, desvio);
            return listarCostos;
        }

        public static void BajaDatosTareaBDD(int idTarea)
        {
            DatosTarea.BajaDatosTarea(idTarea);
        }

    }
}

