using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPIntegrador.Controlador;

namespace TPIntegrador
{
    public partial class FormularioTarea : Form
    {

        public FormularioTarea(int idProyecto)
        {
            InitializeComponent();
            txtHoraReal.Enabled = false;
            txtCostoReal.Enabled = false;
            idProyectoTarea = idProyecto;
            dgvTarea.DataSource = ControladorTarea.obtenerTareaProyectoBDD(idProyectoTarea);
            btnAgregarEmpleado.Enabled = true;
            btnAgregarFuncion.Enabled = false;
            btnAgregarObservacion.Enabled = false;
        }

        private static int idProyectoTarea;
        private int idTarea;
        private int legajoEmpleadoTarea;

        ///////////////////////////////////////////////////////////
        //////////////        T A R E A S        /////////////////
        /////////////////////////////////////////////////////////




        private void btnAgregarTarea_Click(object sender, EventArgs e)
        {
            try
            {
                FormularioInicio obtenerIdProyecto = new FormularioInicio();
                string descripcionTarea = txtDescripcion.Text.Trim();
                string horaEstimada = txtHoraEstimada.Text.Trim();
                string costoEstimado = txtCostoEstimado.Text.Trim();

                DateTime fechaFinal = DateTime.Now;

                ControladorTarea insertarTarea = new ControladorTarea(idProyectoTarea, descripcionTarea, horaEstimada, costoEstimado, "0", "0", fechaFinal, "EN CURSO", "0.0");

                if (insertarTarea.validarTarea() != false)
                {
                    insertarTarea.insertarTarea();
                    idTarea = ControladorTarea.obtenerUltimoIdTareaBDD();


                    ControladorTrabaja insertarTrabaja = new ControladorTrabaja(idProyectoTarea, idTarea, 1, 1);
                    insertarTrabaja.insertarTrabajaBDD();

                    dgvTarea.DataSource = ControladorTarea.obtenerTareaProyectoBDD(idProyectoTarea);

                    btnAgregarTarea.Enabled = false;
                    btnAgregarEmpleado.Enabled = true;

                    LimpiarCamposTarea();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Validar.mError("Falta completar campos");

            }
        }

        //BOTÓN MODIFICAR TAREA
        private void btnModificarTarea_Click(object sender, EventArgs e)
        {
            int indiceTablaTarea = dgvTarea.CurrentCell.RowIndex;
            int idTarea = Convert.ToInt32(dgvTarea[0, indiceTablaTarea].Value);

            string horaReal = txtHoraReal.Text.Trim();
            string costoReal = txtCostoReal.Text.Trim();



            if (string.IsNullOrEmpty(txtCostoReal.Text) && string.IsNullOrEmpty(txtHoraReal.Text))
            {
                Validar.mError("Faltan completar campos hora real y costo real.");
            }
            else
            {
                ControladorTarea insertarTarea = new ControladorTarea(idTarea, horaReal, costoReal, DateTime.Now, "FINALIZADO", "0");

                if (insertarTarea.validarHoraCostoReal() != false)
                {
                    insertarTarea.ModificarDatosTareaBDD();

                    DataTable obtenerCostos = new DataTable();
                    obtenerCostos = ControladorTarea.obtenerCostosBDD(idTarea);
                    decimal costoTotal = Convert.ToDecimal(obtenerCostos.Rows[0]["costo_estimado"]) - Convert.ToDecimal(obtenerCostos.Rows[0]["costo_real"]);


                    insertarTarea.modificarDesvioBDD(idTarea, costoTotal);
                    LimpiarCamposTarea();
                }
                else
                {
                    Validar.mError("Faltan completar uno o mas campos. (hora real o costo real)");
                }
            }
            dgvTarea.DataSource = ControladorTarea.obtenerTareaProyectoBDD(idProyectoTarea);
        }

        //BOTÓN CANCELAR TAREA
        private void btnCancelarTarea_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = string.Empty;
            txtCostoReal.Text = string.Empty;
            txtHoraEstimada.Text = string.Empty;
            txtHoraReal.Text = string.Empty;
            txtCostoEstimado.Text = string.Empty;

            txtDescripcion.Enabled = true;
            txtCostoReal.Enabled = false;
            txtHoraEstimada.Enabled = true;
            txtHoraReal.Enabled = false;
            txtCostoEstimado.Enabled = true;
            btnAgregarTarea.Enabled = true;
        }

        private void dgvTarea_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex >= 0)
            {
                int indiceTablaTarea = dgvTarea.CurrentCell.RowIndex;
                idTarea = Convert.ToInt32(dgvTarea[0, indiceTablaTarea].Value.ToString());
                txtDescripcion.Text = dgvTarea[2, indiceTablaTarea].Value.ToString();
                txtHoraEstimada.Text = dgvTarea[3, indiceTablaTarea].Value.ToString();
                txtCostoEstimado.Text = dgvTarea[4, indiceTablaTarea].Value.ToString();

                dgvEmpleado.DataSource = ControladorEmpleado.listarEmpleadoTrabajaBDD(idTarea);
                txtHoraReal.Text = string.Empty;
                txtCostoReal.Text = string.Empty;

                txtDescripcion.Enabled = false;
                txtHoraEstimada.Enabled = false;
                txtCostoEstimado.Enabled = false;
                txtHoraReal.Enabled = true;
                txtCostoReal.Enabled = true;

                btnAgregarTarea.Enabled = false;
            }
        }

        /////////////////////////////////////////
        //    PARA SACAR EL BORDE A LOS GROUP BOX  (Evento Paint)
        /// ////////////////////////////////////

        private void gpxFormularioTarea_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = (GroupBox)sender;
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawString(groupBox.Text, groupBox.Font, Brushes.Black, 5, 5);

        }

        private void gbxEmpleado_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = (GroupBox)sender;
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawString(groupBox.Text, groupBox.Font, Brushes.Black, 5, 5);
        }


        ////////////////////////////////////////////////////////////////////////////////
        //   PARA BORRAR EL TEXTO DEL PLACEHOLDER AL HACER CLICK EN EN TEXTBOX (Evento Enter)
        ////////////////////////////////////////////////////////////////////////////////

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string placeholder = textoPlaceholder(textBox);

            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
            }
            textBox.ForeColor = Color.Black; // Color de texto predeterminado
        }

        private string textoPlaceholder(TextBox textBox)
        {
            if (textBox == txtDescripcion)
            {
                return "Ingrese descripción";
            }
            else if (textBox == txtHoraEstimada)
            {
                return "Ingrese horas estimadas";
            }
            else if (textBox == txtCostoEstimado)
            {
                return "Ingrese costo estimado";
            }
            else if (textBox == txtHoraReal)
            {
                return "Ingrese horas reales";
            }
            else if (textBox == txtCostoReal)
            {
                return "Ingrese costo real";
            }
            else if (textBox == txtNombreEmpleado)
            {
                return "Ingrese nombre";
            }
            else if (textBox == txtApellidoEmpleado)
            {
                return "Ingrese apellido";
            }
            else if (textBox == txtTelefonoEmpleado)
            {
                return "Ingrese teléfono";
            }
            else if (textBox == txtCorreoEmpleado)
            {
                return "Ingrese email";
            }
            else if (textBox == txtObservacion)
            {
                return "Ingrese observación";
            }

            return string.Empty;
        }



        //////////////////////////////////////////////////////////////////////////
        //    RESTAURAR TEXTO DEL PLACEHOLDER SI NO SE INGRESÓ NADA EN EL TEXTBOX (Evento Leave)
        //////////////////////////////////////////////////////////////////////////

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string placeholder = restaurarTextoPlaceholder(textBox);

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray; // Color de texto más claro para el placeholder
            }
        }

        private string restaurarTextoPlaceholder(TextBox textBox)
        {
            switch (textBox.Name)
            {
                case "txtDescripcion":
                    return "Ingrese descripción";
                case "txtHorasEstimadasTarea":
                    return "Ingrese horas estimadas"; ;
                case "txtCostoEstimadoTarea":
                    return "Ingrese costo estimado";
                case "txtHoraReal":
                    return "Ingrese horas reales";
                case "txtCostoReal":
                    return "Ingrese costo real";
                case "txtNombreEmpleado":
                    return "Ingrese nombre";
                case "txtApellidoEmpleado":
                    return "Ingrese apellido";
                case "txtTelefonoEmpleado":
                    return "Ingrese teléfono";
                case "txtCorreoEmpleado":
                    return "Ingrese email";
                case "txtObservacion":
                    return "Ingrese observación";
                default:
                    return "";
            }
        }



        private void LimpiarCamposTarea()
        {
            txtDescripcion.Text = string.Empty;
            txtCostoReal.Text = string.Empty;
            txtHoraEstimada.Text = string.Empty;
            txtHoraReal.Text = string.Empty;
            txtCostoEstimado.Text = string.Empty;

        }

        private void btnCancelarObservacion_Click(object sender, EventArgs e)
        {

        }

        private void gpxFormularioTarea_Enter(object sender, EventArgs e)
        {

        }

        private void txtCostoEstimado_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtOrdenTarea_TextChanged(object sender, EventArgs e)
        {
        }

        private void lbHorasRealesTarea_Click(object sender, EventArgs e)
        {
        }

        private void lbCostoEstimadoTarea_Click(object sender, EventArgs e)
        {
        }

        private void lbHorasEstimadasTarea_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pbOrdenTarea_Click(object sender, EventArgs e)
        {
        }

        private void txtHoraEstimada_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtHoraReal_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pbHorasRealesTarea_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pbCostoEstimadoTarea_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pbHorasEstimadasTareas_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pbDescripcionTarea_Click(object sender, EventArgs e)
        {
        }

        private void lbDescripcionTarea_Click(object sender, EventArgs e)
        {
        }

        private void lbCostoRealTarea_Click(object sender, EventArgs e)
        {
        }

        private void txtCostoReal_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void pbCostoRealTarea_Click(object sender, EventArgs e)
        {
        }

        private void btnBajaTarea_Click(object sender, EventArgs e)
        {
            int indiceTablaTarea = dgvTarea.CurrentCell.RowIndex;
            int idTarea = Convert.ToInt32(dgvTarea[0, indiceTablaTarea].Value);

            if (Validar.mConsulta("Si da de baja esta tarea, dara de baja todo el proyecto completo ¿Desea Continuar?"))
            {
                ControladorTarea.BajaDatosTareaBDD(idTarea); // doy de baja propietario

                dgvTarea.DataSource = ControladorTarea.obtenerTareaProyectoBDD(idProyectoTarea); //actualizo
                LimpiarCamposTarea();
            }
            else
            {
                Validar.mError("No se pudo dar de baja los datos");
            }
        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            string nombreLider = txtNombreEmpleado.Text.Trim();
            string apellidoLider = txtApellidoEmpleado.Text.Trim();
            string celularLider = txtTelefonoEmpleado.Text.Trim();
            string emailLider = txtCorreoEmpleado.Text.Trim();
            string fechaIngreso = DateTime.Now.ToString("yyyy-MM-dd");

            if (dgvEmpleado.Rows.Count == 0)
            {
                ControladorEmpleado insertarEmpleado = new ControladorEmpleado(0, nombreLider, apellidoLider, celularLider, emailLider, fechaIngreso);
                insertarEmpleado.insertarEmpleadoBDD();
                legajoEmpleadoTarea = ControladorEmpleado.obtenerUltimoIdBDD(); // obtenemos el ultimo legajo para agregar la funcion a dicho empleado

                ControladorTrabaja modificarTrabaja = new ControladorTrabaja(idProyectoTarea, idTarea, legajoEmpleadoTarea, 1);
                modificarTrabaja.ModificarEmpleadoTrabajaBDD(); // reemplazamos el legajo por el valor del empleado
                btnAgregarEmpleado.Enabled = false;
                btnAgregarFuncion.Enabled = true;
                LimpiarCamposEmpleado();
            }
            else
            {
                ControladorEmpleado insertarEmpleado = new ControladorEmpleado(0, nombreLider, apellidoLider, celularLider, emailLider, fechaIngreso);
                insertarEmpleado.insertarEmpleadoBDD();

                legajoEmpleadoTarea = ControladorEmpleado.obtenerUltimoIdBDD();
                ControladorTrabaja modificarTrabaja = new ControladorTrabaja(idProyectoTarea, idTarea, legajoEmpleadoTarea, 1);
                modificarTrabaja.insertarTrabajaBDD();
                btnAgregarEmpleado.Enabled = false;
                btnAgregarFuncion.Enabled = true;
                LimpiarCamposEmpleado();
            }
            dgvEmpleado.DataSource = ControladorEmpleado.listarEmpleadoTrabajaBDD(idTarea);
        }

        private void LimpiarCamposEmpleado()
        {
            txtNombreEmpleado.Text = string.Empty;
            txtApellidoEmpleado.Text = string.Empty;
            txtTelefonoEmpleado.Text = string.Empty;
            txtCorreoEmpleado.Text = string.Empty;
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {

        }
    }
}
