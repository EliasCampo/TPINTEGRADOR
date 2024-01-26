namespace TPIntegrador
{
    partial class FormularioBuscar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBuscarEmpleado = new TextBox();
            btnBuscarEmpleado = new Button();
            btnGenerarLista = new Button();
            dgvBuscarEmpleado = new DataGridView();
            nombre_proyecto = new DataGridViewTextBoxColumn();
            orden_tarea = new DataGridViewTextBoxColumn();
            legajo = new DataGridViewTextBoxColumn();
            fecha_ingreso = new DataGridViewTextBoxColumn();
            nombre_empleado = new DataGridViewTextBoxColumn();
            apellido = new DataGridViewTextBoxColumn();
            celular = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button2 = new Button();
            btnBuscarResponsable = new TextBox();
            dataGridView2 = new DataGridView();
            nombre_propietario = new DataGridViewTextBoxColumn();
            nombre_proyecto1 = new DataGridViewTextBoxColumn();
            numero_legajo = new DataGridViewTextBoxColumn();
            nombre_empleado1 = new DataGridViewTextBoxColumn();
            apellido1 = new DataGridViewTextBoxColumn();
            celular1 = new DataGridViewTextBoxColumn();
            email1 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBuscarEmpleado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // txtBuscarEmpleado
            // 
            txtBuscarEmpleado.Location = new Point(61, 53);
            txtBuscarEmpleado.Margin = new Padding(3, 4, 3, 4);
            txtBuscarEmpleado.Name = "txtBuscarEmpleado";
            txtBuscarEmpleado.Size = new Size(114, 27);
            txtBuscarEmpleado.TabIndex = 0;
            // 
            // btnBuscarEmpleado
            // 
            btnBuscarEmpleado.Location = new Point(202, 53);
            btnBuscarEmpleado.Margin = new Padding(3, 4, 3, 4);
            btnBuscarEmpleado.Name = "btnBuscarEmpleado";
            btnBuscarEmpleado.Size = new Size(121, 31);
            btnBuscarEmpleado.TabIndex = 1;
            btnBuscarEmpleado.Text = "Buscar Empleado";
            btnBuscarEmpleado.UseVisualStyleBackColor = true;
            btnBuscarEmpleado.Click += btnBuscarEmpleado_Click;
            // 
            // btnGenerarLista
            // 
            btnGenerarLista.Location = new Point(353, 53);
            btnGenerarLista.Margin = new Padding(3, 4, 3, 4);
            btnGenerarLista.Name = "btnGenerarLista";
            btnGenerarLista.Size = new Size(104, 31);
            btnGenerarLista.TabIndex = 2;
            btnGenerarLista.Text = "Generar Lista";
            btnGenerarLista.UseVisualStyleBackColor = true;
            // 
            // dgvBuscarEmpleado
            // 
            dgvBuscarEmpleado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBuscarEmpleado.Columns.AddRange(new DataGridViewColumn[] { nombre_proyecto, orden_tarea, legajo, fecha_ingreso, nombre_empleado, apellido, celular, email });
            dgvBuscarEmpleado.Location = new Point(61, 92);
            dgvBuscarEmpleado.Margin = new Padding(3, 4, 3, 4);
            dgvBuscarEmpleado.Name = "dgvBuscarEmpleado";
            dgvBuscarEmpleado.RowHeadersWidth = 51;
            dgvBuscarEmpleado.RowTemplate.Height = 25;
            dgvBuscarEmpleado.Size = new Size(967, 200);
            dgvBuscarEmpleado.TabIndex = 3;
            // 
            // nombre_proyecto
            // 
            nombre_proyecto.HeaderText = "Nombre Proyecto";
            nombre_proyecto.MinimumWidth = 6;
            nombre_proyecto.Name = "nombre_proyecto";
            nombre_proyecto.Width = 125;
            // 
            // orden_tarea
            // 
            orden_tarea.HeaderText = "Numero Tarea";
            orden_tarea.MinimumWidth = 6;
            orden_tarea.Name = "orden_tarea";
            orden_tarea.Width = 125;
            // 
            // legajo
            // 
            legajo.HeaderText = "Numero Legajo";
            legajo.MinimumWidth = 6;
            legajo.Name = "legajo";
            legajo.Width = 125;
            // 
            // fecha_ingreso
            // 
            fecha_ingreso.HeaderText = "Fecha de Ingreso";
            fecha_ingreso.MinimumWidth = 6;
            fecha_ingreso.Name = "fecha_ingreso";
            fecha_ingreso.Width = 125;
            // 
            // nombre_empleado
            // 
            nombre_empleado.HeaderText = "Nombre Empleado";
            nombre_empleado.MinimumWidth = 6;
            nombre_empleado.Name = "nombre_empleado";
            nombre_empleado.Width = 125;
            // 
            // apellido
            // 
            apellido.HeaderText = "Apellido Empleado";
            apellido.MinimumWidth = 6;
            apellido.Name = "apellido";
            apellido.Width = 125;
            // 
            // celular
            // 
            celular.HeaderText = "Celular";
            celular.MinimumWidth = 6;
            celular.Name = "celular";
            celular.Width = 125;
            // 
            // email
            // 
            email.HeaderText = "E-Mail";
            email.MinimumWidth = 6;
            email.Name = "email";
            email.Width = 125;
            // 
            // button1
            // 
            button1.Location = new Point(374, 321);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(104, 31);
            button1.TabIndex = 6;
            button1.Text = "Generar Lista";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(202, 321);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(144, 31);
            button2.TabIndex = 5;
            button2.Text = "Buscar Responsable";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnBuscarResponsable
            // 
            btnBuscarResponsable.Location = new Point(61, 321);
            btnBuscarResponsable.Margin = new Padding(3, 4, 3, 4);
            btnBuscarResponsable.Name = "btnBuscarResponsable";
            btnBuscarResponsable.Size = new Size(114, 27);
            btnBuscarResponsable.TabIndex = 4;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { nombre_propietario, nombre_proyecto1, numero_legajo, nombre_empleado1, apellido1, celular1, email1 });
            dataGridView2.Location = new Point(61, 376);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(853, 200);
            dataGridView2.TabIndex = 7;
            // 
            // nombre_propietario
            // 
            nombre_propietario.HeaderText = "Nombre Propietario";
            nombre_propietario.MinimumWidth = 6;
            nombre_propietario.Name = "nombre_propietario";
            nombre_propietario.ReadOnly = true;
            nombre_propietario.Width = 125;
            // 
            // nombre_proyecto1
            // 
            nombre_proyecto1.HeaderText = "Nombre Proyecto";
            nombre_proyecto1.MinimumWidth = 6;
            nombre_proyecto1.Name = "nombre_proyecto1";
            nombre_proyecto1.ReadOnly = true;
            nombre_proyecto1.Width = 125;
            // 
            // numero_legajo
            // 
            numero_legajo.HeaderText = "Numero Legajo";
            numero_legajo.MinimumWidth = 6;
            numero_legajo.Name = "numero_legajo";
            numero_legajo.ReadOnly = true;
            numero_legajo.Width = 125;
            // 
            // nombre_empleado1
            // 
            nombre_empleado1.HeaderText = "Nombre Lider";
            nombre_empleado1.MinimumWidth = 6;
            nombre_empleado1.Name = "nombre_empleado1";
            nombre_empleado1.ReadOnly = true;
            nombre_empleado1.Width = 125;
            // 
            // apellido1
            // 
            apellido1.HeaderText = "Apellido Lider";
            apellido1.MinimumWidth = 6;
            apellido1.Name = "apellido1";
            apellido1.ReadOnly = true;
            apellido1.Width = 125;
            // 
            // celular1
            // 
            celular1.HeaderText = "Celular";
            celular1.MinimumWidth = 6;
            celular1.Name = "celular1";
            celular1.ReadOnly = true;
            celular1.Width = 125;
            // 
            // email1
            // 
            email1.HeaderText = "E-Mail";
            email1.MinimumWidth = 6;
            email1.Name = "email1";
            email1.ReadOnly = true;
            email1.Width = 125;
            // 
            // FormularioBuscar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 616);
            Controls.Add(dataGridView2);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(btnBuscarResponsable);
            Controls.Add(dgvBuscarEmpleado);
            Controls.Add(btnGenerarLista);
            Controls.Add(btnBuscarEmpleado);
            Controls.Add(txtBuscarEmpleado);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormularioBuscar";
            Text = "FormularioBuscar";
            ((System.ComponentModel.ISupportInitialize)dgvBuscarEmpleado).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuscarEmpleado;
        private Button btnBuscarEmpleado;
        private Button btnGenerarLista;
        private DataGridView dgvBuscarEmpleado;
        private DataGridViewTextBoxColumn nombre_proyecto;
        private DataGridViewTextBoxColumn orden_tarea;
        private DataGridViewTextBoxColumn legajo;
        private DataGridViewTextBoxColumn fecha_ingreso;
        private DataGridViewTextBoxColumn nombre_empleado;
        private DataGridViewTextBoxColumn apellido;
        private DataGridViewTextBoxColumn celular;
        private DataGridViewTextBoxColumn email;
        private Button button1;
        private Button button2;
        private TextBox btnBuscarResponsable;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn nombre_propietario;
        private DataGridViewTextBoxColumn nombre_proyecto1;
        private DataGridViewTextBoxColumn numero_legajo;
        private DataGridViewTextBoxColumn nombre_empleado1;
        private DataGridViewTextBoxColumn apellido1;
        private DataGridViewTextBoxColumn celular1;
        private DataGridViewTextBoxColumn email1;
    }
}