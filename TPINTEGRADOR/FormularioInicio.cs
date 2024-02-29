using System.Data;
using System.Numerics;
using System.Windows.Forms;
using TPIntegrador.Controlador;
using TPIntegrador.Datos;


namespace TPIntegrador
{
    public partial class FormularioInicio : Form
    {
        public FormularioInicio()
        {
            InitializeComponent();
            dgvPropietario.DataSource = ControladorPropietario.obtenerPropietariosBDD();
            dgvLider.DataSource = ControladorEmpleado.listarEmpleadoLiderBDD();

            btnAgregarEmpleado.Enabled = false;

            if (dgvLider.Rows.Count != 0)
            {
                btnAgregarEmpleado.Enabled = false;
            }
            else
            {

                btnAgregarEmpleado.Enabled = true;
            }

            gbxPrincipalProyecto.Paint += gbx_Paint;
            gbxPropietario.Paint += gbx_Paint;
            gbxProyecto.Paint += gbx_Paint;
            gbxLider.Paint += gbx_Paint;

            gbxPrincipalProyecto.BackColor = Color.Black;
        }

        private bool banderaAgregarLider = false; // esta bandera se activa cuando agregamos un nuevo lider y
                                                  // para ese lider agregar un nuevo proyecto para actualizar
                                                  // la tabla trabaja ya que al agregar un nuevo lider hay que
                                                  // actualizar la tabla trabaja con los datos del id proyecto


        /*estas banderas son para cuando modificamos algun dato de un proyecto
         y no sabemos si el proyecto se muestra en base al id de un propietario
         o de un lider */

        private bool banderaListarLider = false;

        public DataTable limpiarDgvProyecto()
        {
            DataTable dt = (DataTable)dgvProyecto.DataSource;
            dt.Rows.Clear();

            return dt;
        }

        private void FormularioInicio_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            //Establecer el color del texto del placeholder
            txtNombrePropietario.ForeColor = Color.Gray;
            txtRazonSocial.ForeColor = Color.Gray;
            txtTelefono.ForeColor = Color.Gray;
            txtCuit.ForeColor = Color.Gray;
            txtPersonaContacto.ForeColor = Color.Gray;
            txtNombreProyecto.ForeColor = Color.Gray;
            txtEmpresa.ForeColor = Color.Gray;
            txtNombreLider.ForeColor = Color.Gray;
            txtApellidoLider.ForeColor = Color.Gray;
            txtCelularLider.ForeColor = Color.Gray;
            txtCorreoLider.ForeColor = Color.Gray;
        }


        //////////////////////////////////////////////////
        //       MENÚ
        /////////////////////////////////////////////////
        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gbxPrincipalProyecto.Visible = false;
            FormularioBuscar formularioBuscar = new FormularioBuscar();
            formularioBuscar.TopLevel = false;
            PanelPrincipal.Controls.Add(formularioBuscar);
            formularioBuscar.Show();
        }
        ///////////////////////////////////////////////////////////////////////////
        ///////////////          P R O P I E T A R I O              ///////////////
        ///////////////////////////////////////////////////////////////////////////

        //CAMPO CUIT PROPIETARIO
        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                Validar.mAdvertencia("Solo se admiten numeros");
            }
        }

        //CAMPO TELEFONO PROPIETARIO
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                Validar.mAdvertencia("Solo se admiten numeros");
            }
        }

        //LIMPIAR TEXTBOX DE PROPIETARIO
        private void LimpiarCamposPropietario()
        {
            txtNombrePropietario.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtCuit.Text = string.Empty;
            txtPersonaContacto.Text = string.Empty;
        }

        /*public void LimpiarTodoFormularioInicio()
		{
			btnAgregarPropietario.Enabled = true;
			this.LimpiarCamposPropietario();

		}*/

        //BOTON AGREGAR PROPIETARIO
        private void btnAgregarPropietario_Click(object sender, EventArgs e)
        {
            try
            {
                string nombrePropietario = txtNombrePropietario.Text.Trim();
                string razonSocial = txtRazonSocial.Text.Trim();
                string telefonoPropietario = txtTelefono.Text.Trim();
                string cuitPropietario = txtCuit.Text.Trim();
                string personaContacto = txtPersonaContacto.Text.Trim();

                ControladorPropietario insertarPropietario = new ControladorPropietario(0, nombrePropietario, razonSocial, telefonoPropietario, cuitPropietario, personaContacto);

                if (insertarPropietario.validar() != false)
                {
                    insertarPropietario.insertarPropietario();
                    dgvPropietario.DataSource = ControladorPropietario.obtenerPropietariosBDD();
                    LimpiarCamposPropietario();
                    btnAgregarPropietario.Enabled = false;
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

        private void btnModificarPropietario_Click(object sender, EventArgs e)
        {
            int indiceTablaPropietario = dgvPropietario.CurrentCell.RowIndex;
            int idPropietario = Convert.ToInt32(dgvPropietario[0, indiceTablaPropietario].Value);
            string nombrePropietario = txtNombrePropietario.Text.Trim();
            string razonSocialPropietario = txtRazonSocial.Text.Trim();
            string telefonoPropietario = txtTelefono.Text.Trim();
            string cuitPropietario = txtCuit.Text.Trim();
            string personaContactoPropietario = txtPersonaContacto.Text.Trim();


            ControladorPropietario insertarPropietario = new ControladorPropietario(idPropietario, nombrePropietario, razonSocialPropietario, telefonoPropietario, cuitPropietario, personaContactoPropietario);

            if (insertarPropietario.validar() != false)
            {
                insertarPropietario.ModificarDatosPropietarioBDD();
                dgvPropietario.DataSource = ControladorPropietario.obtenerPropietariosBDD();

                LimpiarCamposPropietario();
            }
            else
            {
                Validar.mError("El cuit ingresado no es valido o faltan completar campos.");
            }


        }
        //DAR DE BAJA UN PROPIETARIO.
        private void btnBajaPropietario_Click(object sender, EventArgs e)
        {
            int indiceTablaPropietario = dgvPropietario.CurrentCell.RowIndex;
            int idPropietario = Convert.ToInt32(dgvPropietario[0, indiceTablaPropietario].Value);

            if (Validar.mConsulta("Si da de baja este propietario dara de baja todo el proyecto completo ¿Desea Continuar?"))
            {
                ControladorPropietario.BajaDatosPropietarioBDD(idPropietario); // doy de baja propietario

                dgvPropietario.DataSource = ControladorPropietario.obtenerPropietariosBDD(); //actualizo

                dgvProyecto.DataSource = limpiarDgvProyecto();  // cuando damos de baja un lider que no se recupere el proyecto y deja vacio el dgv
                LimpiarCamposPropietario();
            }
            else
            {
                Validar.mError("No se pudo dar de baja los datos");
            }
        }

        private void btnLimpiarPropietario_Click(object sender, EventArgs e)
        {
            LimpiarCamposPropietario();
            btnAgregarPropietario.Enabled = true;
        }

        // rellenar campos al seleccionar x fila de la tabla propietario ( dgvPropietario)
        private void dgvPropietario_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex >= 0)
            {
                int indiceTablaPropietario = dgvPropietario.CurrentCell.RowIndex;
                int idPropietario = Convert.ToInt32(dgvPropietario[0, indiceTablaPropietario].Value);
                txtNombrePropietario.Text = dgvPropietario[1, indiceTablaPropietario].Value.ToString();
                txtRazonSocial.Text = dgvPropietario[2, indiceTablaPropietario].Value.ToString();
                txtTelefono.Text = dgvPropietario[3, indiceTablaPropietario].Value.ToString();
                txtCuit.Text = dgvPropietario[4, indiceTablaPropietario].Value.ToString();
                txtPersonaContacto.Text = dgvPropietario[5, indiceTablaPropietario].Value.ToString();

                dgvProyecto.DataSource = ControladorProyecto.listarProyectoPropietarioBDD(idPropietario);

                btnAgregarProyecto.Enabled = false;
                btnAgregarPropietario.Enabled = false;
                banderaListarLider = false;
            }
        }
        ///////////////////////////////////////////////////////////////////////
        ///////////////           P R O Y E C T O           ///////////////////
        ///////////////////////////////////////////////////////////////////////

        //LIMPIAR TEXTBOX DEL PROYECTO. 
        private void LimpiarCamposProyecto()
        {
            txtNombreProyecto.Text = string.Empty;
            txtEmpresa.Text = string.Empty;
        }

        //AGREGAR UN PROYECTO NUEVO.
        private void btnAgregarProyecto_Click(object sender, EventArgs e)
        {
            string nombreProyecto = txtNombreProyecto.Text.Trim();
            string empresaProyecto = txtEmpresa.Text.Trim();
            int indiceTablaPropietario = dgvPropietario.CurrentCell.RowIndex;
            int idPropietario = Convert.ToInt32(dgvPropietario[0, indiceTablaPropietario].Value);

            int indiceTablaLider = dgvLider.CurrentCell.RowIndex;
            int nroLegajoLider = Convert.ToInt32(dgvLider[0, indiceTablaLider].Value.ToString());

            ControladorProyecto insertarProyecto = new ControladorProyecto(nombreProyecto, empresaProyecto, 0, 0, 0, 0, 0, nroLegajoLider, idPropietario);

            if (insertarProyecto.ValidarDatosProyecto() != false)
            {
                insertarProyecto.insertarProyectoBDD();
                dgvProyecto.DataSource = ControladorProyecto.listarProyectosLiderBDD(nroLegajoLider);
                LimpiarCamposProyecto();
            }

            if (banderaAgregarLider == true) //agregamos un nuevo proyecto a un nuevo lider
            {
                int ultimoIdProyecto = ControladorProyecto.obtenerUltimoIdProyectoBDD();
                int ultimoIdLider = ControladorEmpleado.obtenerUltimoIdBDD();

                ControladorTrabaja actualizarTrabaja = new ControladorTrabaja(ultimoIdProyecto, 0, ultimoIdLider, 1);

                actualizarTrabaja.ModificarDatosTrabajaBDD();
            }
            else
            {
                int ultimoIdProyecto = ControladorProyecto.obtenerUltimoIdProyectoBDD();

                ControladorTrabaja insertarTrabaja = new ControladorTrabaja(ultimoIdProyecto, 0, nroLegajoLider, 1);

                insertarTrabaja.insertarTrabajaBDD();
            }

            dgvLider.DataSource = ControladorEmpleado.listarEmpleadoLiderBDD();
            LimpiarCamposLider();


            if (dgvLider.Rows.Count == 0)
            {
                btnAgregarEmpleado.Enabled = true;
            }
        }


        //////BOTON MODIFICAR PROYECTO/////
        private void btnModificarProyecto_Click(object sender, EventArgs e)
        {
            string nombreProyecto = txtNombreProyecto.Text.Trim();
            string empresaProyecto = txtEmpresa.Text.Trim();
            int indiceTablaProyecto = dgvProyecto.CurrentCell.RowIndex;
            int idProyecto = Convert.ToInt32(dgvProyecto[0, indiceTablaProyecto].Value);

            ControladorProyecto insertarProyecto = new ControladorProyecto(idProyecto, nombreProyecto, empresaProyecto);

            if (insertarProyecto.ValidarDatosProyecto() != false)
            {
                insertarProyecto.ModificarDatosProyectoBDD();

                if (banderaListarLider == true)
                {
                    int indiceTablaLider = dgvLider.CurrentCell.RowIndex;
                    int idLider = Convert.ToInt32(dgvLider[0, indiceTablaLider].Value);

                    dgvProyecto.DataSource = ControladorProyecto.listarProyectosLiderBDD(idLider);
                }
                else
                {
                    int indiceTablaPropietario = dgvPropietario.CurrentCell.RowIndex;
                    int idPropietario = Convert.ToInt32(dgvPropietario[0, indiceTablaPropietario].Value);

                    dgvProyecto.DataSource = ControladorProyecto.listarProyectoPropietarioBDD(idPropietario);

                }
                LimpiarCamposProyecto();
                btnAgregarProyecto.Enabled = true;
            }
            else
            {
                Validar.mError("Faltan completar campos.");
            }
        }

        private void btnBajaProyecto_Click(object sender, EventArgs e)
        {
            int indiceTablaProyecto = dgvProyecto.CurrentCell.RowIndex;
            int idProyecto = Convert.ToInt32(dgvProyecto[0, indiceTablaProyecto].Value);


            if (Validar.mConsulta("Si da de baja este proyecto, dara de baja todo el proyecto completo ¿Desea Continuar?"))
            {
                ControladorProyecto.BajaDatosProyectoBDD(idProyecto);


                if (banderaListarLider == true)
                {
                    int indiceTablaLider = dgvLider.CurrentCell.RowIndex;
                    int idLider = Convert.ToInt32(dgvLider[0, indiceTablaLider].Value);

                    dgvProyecto.DataSource = ControladorProyecto.listarProyectosLiderBDD(idLider);
                }
                else
                {
                    int indiceTablaPropietario = dgvPropietario.CurrentCell.RowIndex;
                    int idPropietario = Convert.ToInt32(dgvPropietario[0, indiceTablaPropietario].Value);

                    dgvProyecto.DataSource = ControladorProyecto.listarProyectoPropietarioBDD(idPropietario);

                }
                LimpiarCamposProyecto();
                btnAgregarProyecto.Enabled = true;
                dgvLider.DataSource = ControladorEmpleado.listarEmpleadoLiderBDD();
            }
            else
            {
                Validar.mError("No se pudo dar de baja los datos");
            }

        }


        private void btnLimpiarProyecto_Click(object sender, EventArgs e)
        {
            LimpiarCamposProyecto();
        }

        private void dgvProyecto_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex >= 0)
            {
                int indiceTablaProyecto = dgvProyecto.CurrentCell.RowIndex;
                int idProyecto = Convert.ToInt32(dgvProyecto[0, indiceTablaProyecto].Value);

                string nombreProyecto = dgvProyecto[1, indiceTablaProyecto].Value.ToString();
                string empresaProyecto = dgvProyecto[2, indiceTablaProyecto].Value.ToString();

                txtNombreProyecto.Text = nombreProyecto;
                txtEmpresa.Text = empresaProyecto;

                btnAgregarProyecto.Enabled = false;
            }
        }


        ///////////////////////////////////////////////////////////////////////
        ///////////////              L Í D E R              ///////////////////
        ///////////////////////////////////////////////////////////////////////

        private void LimpiarCamposLider()
        {
            txtNumeroLegajo.Text = string.Empty;
            txtNombreLider.Text = string.Empty;
            txtApellidoLider.Text = string.Empty;
            txtCelularLider.Text = string.Empty;
            txtCorreoLider.Text = string.Empty;
        }

        private void txtCelularLider_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                Validar.mAdvertencia("Solo se admiten numeros");
            }
        }
        private void txtNumeroLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                Validar.mAdvertencia("Solo se admiten numeros");
            }
        }

        private void btnAgregarEmpleado_Click_1(object sender, EventArgs e)
        {

            if (dgvLider.Rows.Count == 0)
            {
                string nombreLider = txtNombreLider.Text.Trim();
                string apellidoLider = txtApellidoLider.Text.Trim();
                string celularLider = txtCelularLider.Text.Trim();
                string emailLider = txtCorreoLider.Text.Trim();
                string fechaIngreso = DateTime.Now.ToString("yyyy-MM-dd");

                ControladorEmpleado insertarLider = new ControladorEmpleado(0, nombreLider, apellidoLider, celularLider, emailLider, fechaIngreso);
                insertarLider.insertarNuevoLiderBDD();

                int ultimoId = ControladorEmpleado.obtenerUltimoIdBDD();

                ControladorTrabaja insertarTrabaja = new ControladorTrabaja(0, 0, ultimoId, 1);
                insertarTrabaja.insertarTrabajaBDD();

                dgvLider.DataSource = ControladorEmpleado.listarUltimoLiderBDD();
                banderaAgregarLider = true;
            }
        }



        private void btnModificarEmpleado_Click_1(object sender, EventArgs e)
        {
            int indiceTablaLider = dgvLider.CurrentCell.RowIndex;
            int idLider = Convert.ToInt32(dgvLider[0, indiceTablaLider].Value);

            string nombreLider = txtNombreLider.Text.Trim();
            string apellidoLider = txtApellidoLider.Text.Trim();
            string celularLider = txtCelularLider.Text.Trim();
            string emailLider = txtCorreoLider.Text.Trim();

            ControladorEmpleado insertarLider = new ControladorEmpleado(idLider, nombreLider, apellidoLider, celularLider, emailLider, "0000-00-00");

            if (insertarLider.ValidarDatos() != false)
            {
                insertarLider.ModificarDatosLiderBDD();
                dgvLider.DataSource = ControladorEmpleado.listarEmpleadoLiderBDD();


                LimpiarCamposLider();
            }
            else
            {
                Validar.mError("El mail ingresado no es valido o faltan completar campos.");
            }
        }

        private void dgvLider_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            if (e.RowIndex != -1 && e.ColumnIndex >= 0)
            {

                int indiceTablaLider = dgvLider.CurrentCell.RowIndex;
                int nroLegajoLider = Convert.ToInt32(dgvLider[0, indiceTablaLider].Value.ToString());
                string nombreLider = dgvLider[1, indiceTablaLider].Value.ToString();
                string apellidoLider = dgvLider[2, indiceTablaLider].Value.ToString();
                string celularLider = dgvLider[3, indiceTablaLider].Value.ToString();
                string emailLider = dgvLider[4, indiceTablaLider].Value.ToString();


                txtNumeroLegajo.Text = nroLegajoLider.ToString();
                txtNombreLider.Text = nombreLider;
                txtApellidoLider.Text = apellidoLider;
                txtCelularLider.Text = celularLider;
                txtCorreoLider.Text = emailLider;


                dgvProyecto.DataSource = ControladorProyecto.listarProyectosLiderBDD(nroLegajoLider);

                btnAgregarProyecto.Enabled = true;
                btnAgregarEmpleado.Enabled = false;

                banderaListarLider = true;

            }


        }



        ///////////////////////////////////////////////////////////
        //    PARA SACAR EL BORDE A LOS GROUP BOX  (Evento Paint)
        /// ///////////////////////////////////////////////////////

        private void gbx_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = (GroupBox)sender;
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawString(groupBox.Text, groupBox.Font, Brushes.Black, 5, 5);

        }


        /// ////////////////////////////////////////////////////////////////////////////////
        //   PARA BORRAR EL TEXTO DEL PLACEHOLDER AL HACER CLICK EN EN TEXTBOX (Evento Enter)
        /////////////////////////////////////////////////////////////////////////////////////
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string placeholder = borrarTextoClick(textBox);

            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
            }
            textBox.ForeColor = Color.Black; // Color de texto predeterminado
        }

        private string borrarTextoClick(TextBox textBox)
        {
            if (textBox == txtNombrePropietario)
            {
                return "Ingrese Nombre";
            }
            else if (textBox == txtRazonSocial)
            {
                return "Ingrese Razón Social";
            }
            else if (textBox == txtTelefono)
            {
                return "Ingrese Teléfono";
            }
            else if (textBox == txtCuit)
            {
                return "Ingrese Cuit";
            }
            else if (textBox == txtPersonaContacto)
            {
                return "Ingrese Persona Contacto";
            }
            else if (textBox == txtNombreProyecto)
            {
                return "Ingrese Nombre Proyecto";
            }
            else if (textBox == txtEmpresa)
            {
                return "Ingrese Nombre Empresa";
            }
            else if (textBox == txtNombreLider)
            {
                return "Ingrese Nombre Líder";
            }
            else if (textBox == txtApellidoLider)
            {
                return "Ingrese Apellido";
            }
            else if (textBox == txtCelularLider)
            {
                return "Ingrese N° Celular";
            }
            else if (textBox == txtCorreoLider)
            {
                return "Ingrese Correo";
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
                case "txtNombrePropietario":
                    return "Ingrese Nombre";
                case "txtRazonSocial":
                    return "Ingrese Razón Social";
                case "txtTelefono":
                    return "Ingrese Teléfono";
                case "txtCuit":
                    return "Ingrese Cuit";
                case "txtPersonaContacto":
                    return "Ingrese Persona Contacto";
                case "txtNombreProyecto":
                    return "Ingrese Nombre Proyecto";
                case "txtEmpresa":
                    return "Ingrese Nombre Empresa";
                case "txtNombreLider":
                    return "Ingrese Nombre Líder";
                case "txtApellidoLider":
                    return "Ingrese Apellido";
                case "txtCelularLider":
                    return "Ingrese N° Celular";
                case "txtCorreoLider":
                    return "Ingrese Correo";
                default:
                    return "";
            }
        }

        private void dgvProyecto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBajaEmpleado_Click_1(object sender, EventArgs e)
        {
            int indiceTablaLider = dgvLider.CurrentCell.RowIndex;
            int idLider = Convert.ToInt32(dgvLider[0, indiceTablaLider].Value);

            if (Validar.mConsulta("Si da de baja este lider, perdera el proyecto."))
            {
                ControladorEmpleado.BajaDatosLiderBDD(idLider);
                dgvLider.DataSource = ControladorEmpleado.listarEmpleadoLiderBDD();
                dgvProyecto.DataSource = limpiarDgvProyecto();
                btnAgregarEmpleado.Enabled = true;
            }
            else
            {
                Validar.mOk("No se dio de baja el lider.");
                btnAgregarEmpleado.Enabled = false;
            }
            LimpiarCamposLider();

        }
        private void btnLimpiarEmpleado_Click(object sender, EventArgs e)
        {
            LimpiarCamposLider();
        }

        private void dgvProyecto_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gbxPrincipalProyecto.Visible = false;
            int indiceTablaProyecto = dgvProyecto.CurrentCell.RowIndex;
            int IdProyecto = Convert.ToInt32(dgvProyecto[0, indiceTablaProyecto].Value.ToString());
            FormularioTarea formularioTarea = new FormularioTarea(IdProyecto);

            formularioTarea.TopLevel = false;
            PanelPrincipal.Controls.Add(formularioTarea);
            formularioTarea.Show();
        }

        private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
    }
}