namespace CPresentacion
{
    partial class FiltroProblematica
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRegistrarSolicitud = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.tipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportesUADYDataSet1 = new CPresentacion.ReportesUADYDataSet1();
            this.txtTipo4 = new System.Windows.Forms.TextBox();
            this.txtTipo3 = new System.Windows.Forms.TextBox();
            this.lblTipo3 = new System.Windows.Forms.Label();
            this.lblTipo4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTipo2 = new System.Windows.Forms.TextBox();
            this.txtTipo1 = new System.Windows.Forms.TextBox();
            this.lblTipo2 = new System.Windows.Forms.Label();
            this.lblTipo1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtApellido1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoTableAdapter = new CPresentacion.ReportesUADYDataSet1TableAdapters.TipoTableAdapter();
            this.dtgvActores = new System.Windows.Forms.DataGridView();
            this.ColumnaClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaApellido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaApellido2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaDependencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnaPuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tipoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesUADYDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvActores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegistrarSolicitud
            // 
            this.btnRegistrarSolicitud.BackColor = System.Drawing.Color.CadetBlue;
            this.btnRegistrarSolicitud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegistrarSolicitud.Enabled = false;
            this.btnRegistrarSolicitud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarSolicitud.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegistrarSolicitud.Location = new System.Drawing.Point(406, 570);
            this.btnRegistrarSolicitud.Name = "btnRegistrarSolicitud";
            this.btnRegistrarSolicitud.Size = new System.Drawing.Size(98, 41);
            this.btnRegistrarSolicitud.TabIndex = 80;
            this.btnRegistrarSolicitud.Text = "Registrar Solicitud";
            this.btnRegistrarSolicitud.UseVisualStyleBackColor = false;
            this.btnRegistrarSolicitud.Click += new System.EventHandler(this.btnRegistrarSolicitud_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModificar.Enabled = false;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnModificar.Location = new System.Drawing.Point(638, 330);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(98, 41);
            this.btnModificar.TabIndex = 79;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Location = new System.Drawing.Point(288, 570);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(98, 41);
            this.btnBuscar.TabIndex = 78;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtApellido2
            // 
            this.txtApellido2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtApellido2.Location = new System.Drawing.Point(260, 273);
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(165, 20);
            this.txtApellido2.TabIndex = 77;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 76;
            this.label5.Text = "Apellido M";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DataSource = this.tipoBindingSource;
            this.cmbTipo.DisplayMember = "Descripcion";
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(277, 84);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(165, 21);
            this.cmbTipo.TabIndex = 75;
            this.cmbTipo.ValueMember = "IdTipo";
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // tipoBindingSource
            // 
            this.tipoBindingSource.DataMember = "Tipo";
            this.tipoBindingSource.DataSource = this.reportesUADYDataSet1;
            // 
            // reportesUADYDataSet1
            // 
            this.reportesUADYDataSet1.DataSetName = "ReportesUADYDataSet1";
            this.reportesUADYDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtTipo4
            // 
            this.txtTipo4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTipo4.Location = new System.Drawing.Point(613, 302);
            this.txtTipo4.Name = "txtTipo4";
            this.txtTipo4.Size = new System.Drawing.Size(165, 20);
            this.txtTipo4.TabIndex = 74;
            // 
            // txtTipo3
            // 
            this.txtTipo3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTipo3.Location = new System.Drawing.Point(613, 269);
            this.txtTipo3.Name = "txtTipo3";
            this.txtTipo3.Size = new System.Drawing.Size(165, 20);
            this.txtTipo3.TabIndex = 73;
            // 
            // lblTipo3
            // 
            this.lblTipo3.AutoSize = true;
            this.lblTipo3.Location = new System.Drawing.Point(529, 276);
            this.lblTipo3.Name = "lblTipo3";
            this.lblTipo3.Size = new System.Drawing.Size(40, 13);
            this.lblTipo3.TabIndex = 72;
            this.lblTipo3.Text = "Puesto";
            // 
            // lblTipo4
            // 
            this.lblTipo4.AutoSize = true;
            this.lblTipo4.Location = new System.Drawing.Point(529, 309);
            this.lblTipo4.Name = "lblTipo4";
            this.lblTipo4.Size = new System.Drawing.Size(29, 13);
            this.lblTipo4.TabIndex = 71;
            this.lblTipo4.Text = "Area";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(425, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 70;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(75, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 24);
            this.label8.TabIndex = 69;
            this.label8.Text = "Tipo de Solicitante";
            // 
            // txtTipo2
            // 
            this.txtTipo2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTipo2.Location = new System.Drawing.Point(613, 240);
            this.txtTipo2.Name = "txtTipo2";
            this.txtTipo2.Size = new System.Drawing.Size(165, 20);
            this.txtTipo2.TabIndex = 68;
            // 
            // txtTipo1
            // 
            this.txtTipo1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTipo1.Location = new System.Drawing.Point(613, 207);
            this.txtTipo1.Name = "txtTipo1";
            this.txtTipo1.Size = new System.Drawing.Size(165, 20);
            this.txtTipo1.TabIndex = 67;
            // 
            // lblTipo2
            // 
            this.lblTipo2.AutoSize = true;
            this.lblTipo2.Location = new System.Drawing.Point(529, 243);
            this.lblTipo2.Name = "lblTipo2";
            this.lblTipo2.Size = new System.Drawing.Size(71, 13);
            this.lblTipo2.TabIndex = 66;
            this.lblTipo2.Text = "Dependencia";
            // 
            // lblTipo1
            // 
            this.lblTipo1.AutoSize = true;
            this.lblTipo1.Location = new System.Drawing.Point(529, 214);
            this.lblTipo1.Name = "lblTipo1";
            this.lblTipo1.Size = new System.Drawing.Size(34, 13);
            this.lblTipo1.TabIndex = 65;
            this.lblTipo1.Text = "Clave";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 64;
            this.label7.Text = "Correo";
            // 
            // txtCorreo
            // 
            this.txtCorreo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtCorreo.Location = new System.Drawing.Point(260, 341);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(165, 20);
            this.txtCorreo.TabIndex = 63;
            // 
            // txtTelefono
            // 
            this.txtTelefono.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTelefono.Location = new System.Drawing.Point(260, 306);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(165, 20);
            this.txtTelefono.TabIndex = 62;
            // 
            // txtApellido1
            // 
            this.txtApellido1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtApellido1.Location = new System.Drawing.Point(260, 241);
            this.txtApellido1.Name = "txtApellido1";
            this.txtApellido1.Size = new System.Drawing.Size(165, 20);
            this.txtApellido1.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Telefono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Apellido P";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNombre.Location = new System.Drawing.Point(260, 208);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(165, 20);
            this.txtNombre.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 24);
            this.label1.TabIndex = 56;
            this.label1.Text = "Datos del Solicitante";
            // 
            // tipoTableAdapter
            // 
            this.tipoTableAdapter.ClearBeforeFill = true;
            // 
            // dtgvActores
            // 
            this.dtgvActores.AllowUserToAddRows = false;
            this.dtgvActores.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dtgvActores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvActores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvActores.BackgroundColor = System.Drawing.Color.White;
            this.dtgvActores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvActores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnaClave,
            this.ColumnaNombre,
            this.ColumnaApellido1,
            this.ColumnaApellido2,
            this.ColumnaDependencia,
            this.ColumnaArea,
            this.ColumnaPuesto});
            this.dtgvActores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtgvActores.Location = new System.Drawing.Point(12, 391);
            this.dtgvActores.MultiSelect = false;
            this.dtgvActores.Name = "dtgvActores";
            this.dtgvActores.ReadOnly = true;
            this.dtgvActores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvActores.Size = new System.Drawing.Size(944, 169);
            this.dtgvActores.TabIndex = 81;
            this.dtgvActores.Click += new System.EventHandler(this.dtgvActores_Click);
            // 
            // ColumnaClave
            // 
            this.ColumnaClave.HeaderText = "Clave";
            this.ColumnaClave.Name = "ColumnaClave";
            this.ColumnaClave.ReadOnly = true;
            // 
            // ColumnaNombre
            // 
            this.ColumnaNombre.HeaderText = "Nombre";
            this.ColumnaNombre.Name = "ColumnaNombre";
            this.ColumnaNombre.ReadOnly = true;
            // 
            // ColumnaApellido1
            // 
            this.ColumnaApellido1.HeaderText = "Apellido P.";
            this.ColumnaApellido1.Name = "ColumnaApellido1";
            this.ColumnaApellido1.ReadOnly = true;
            // 
            // ColumnaApellido2
            // 
            this.ColumnaApellido2.HeaderText = "Apellido M.";
            this.ColumnaApellido2.Name = "ColumnaApellido2";
            this.ColumnaApellido2.ReadOnly = true;
            // 
            // ColumnaDependencia
            // 
            this.ColumnaDependencia.HeaderText = "Dependencia";
            this.ColumnaDependencia.Name = "ColumnaDependencia";
            this.ColumnaDependencia.ReadOnly = true;
            // 
            // ColumnaArea
            // 
            this.ColumnaArea.HeaderText = "Area";
            this.ColumnaArea.Name = "ColumnaArea";
            this.ColumnaArea.ReadOnly = true;
            // 
            // ColumnaPuesto
            // 
            this.ColumnaPuesto.HeaderText = "Puesto";
            this.ColumnaPuesto.Name = "ColumnaPuesto";
            this.ColumnaPuesto.ReadOnly = true;
            // 
            // FiltroProblematica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 623);
            this.Controls.Add(this.dtgvActores);
            this.Controls.Add(this.btnRegistrarSolicitud);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtApellido2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtTipo4);
            this.Controls.Add(this.txtTipo3);
            this.Controls.Add(this.lblTipo3);
            this.Controls.Add(this.lblTipo4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTipo2);
            this.Controls.Add(this.txtTipo1);
            this.Controls.Add(this.lblTipo2);
            this.Controls.Add(this.lblTipo1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtApellido1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Name = "FiltroProblematica";
            this.Text = "FiltroProblematica";
            this.Load += new System.EventHandler(this.FiltroProblematica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tipoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportesUADYDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvActores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrarSolicitud;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtApellido2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtTipo4;
        private System.Windows.Forms.TextBox txtTipo3;
        private System.Windows.Forms.Label lblTipo3;
        private System.Windows.Forms.Label lblTipo4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTipo2;
        private System.Windows.Forms.TextBox txtTipo1;
        private System.Windows.Forms.Label lblTipo2;
        private System.Windows.Forms.Label lblTipo1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtApellido1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private ReportesUADYDataSet1 reportesUADYDataSet1;
        private System.Windows.Forms.BindingSource tipoBindingSource;
        private ReportesUADYDataSet1TableAdapters.TipoTableAdapter tipoTableAdapter;
        private System.Windows.Forms.DataGridView dtgvActores;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaApellido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaApellido2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaDependencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnaPuesto;
    }
}