namespace ProyectoClinica
{
    partial class CitaListado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lista = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbBuscar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpSeleccion = new System.Windows.Forms.DateTimePicker();
            this.rbtSeleccion = new System.Windows.Forms.RadioButton();
            this.rbtProximas = new System.Windows.Forms.RadioButton();
            this.rbtAntiguas = new System.Windows.Forms.RadioButton();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lista)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.AllowUserToAddRows = false;
            this.lista.AllowUserToDeleteRows = false;
            this.lista.AllowUserToResizeColumns = false;
            this.lista.AllowUserToResizeRows = false;
            this.lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lista.BackgroundColor = System.Drawing.Color.Gray;
            this.lista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista.EnableHeadersVisualStyles = false;
            this.lista.GridColor = System.Drawing.Color.Teal;
            this.lista.Location = new System.Drawing.Point(12, 161);
            this.lista.Name = "lista";
            this.lista.ReadOnly = true;
            this.lista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.lista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            this.lista.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lista.Size = new System.Drawing.Size(815, 278);
            this.lista.TabIndex = 6;
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(12, 457);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 44);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(186, 457);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(140, 44);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(674, 457);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 44);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.cmbBuscar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(12, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.groupBox2.Size = new System.Drawing.Size(815, 69);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // cmbBuscar
            // 
            this.cmbBuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuscar.FormattingEnabled = true;
            this.cmbBuscar.Location = new System.Drawing.Point(357, 31);
            this.cmbBuscar.Name = "cmbBuscar";
            this.cmbBuscar.Size = new System.Drawing.Size(274, 28);
            this.cmbBuscar.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "BUSCAR POR:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Location = new System.Drawing.Point(17, 33);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(297, 26);
            this.txtBuscar.TabIndex = 6;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(199, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "BUSCAR PROFESIONAL:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.dtpSeleccion);
            this.groupBox1.Controls.Add(this.rbtSeleccion);
            this.groupBox1.Controls.Add(this.rbtProximas);
            this.groupBox1.Controls.Add(this.rbtAntiguas);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.groupBox1.Size = new System.Drawing.Size(815, 62);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // dtpSeleccion
            // 
            this.dtpSeleccion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSeleccion.Location = new System.Drawing.Point(437, 15);
            this.dtpSeleccion.Name = "dtpSeleccion";
            this.dtpSeleccion.Size = new System.Drawing.Size(124, 26);
            this.dtpSeleccion.TabIndex = 18;
            this.dtpSeleccion.ValueChanged += new System.EventHandler(this.dtpSeleccion_ValueChanged);
            // 
            // rbtSeleccion
            // 
            this.rbtSeleccion.AutoSize = true;
            this.rbtSeleccion.Location = new System.Drawing.Point(331, 17);
            this.rbtSeleccion.Name = "rbtSeleccion";
            this.rbtSeleccion.Size = new System.Drawing.Size(100, 24);
            this.rbtSeleccion.TabIndex = 17;
            this.rbtSeleccion.TabStop = true;
            this.rbtSeleccion.Text = "Selección:";
            this.rbtSeleccion.UseVisualStyleBackColor = true;
            this.rbtSeleccion.CheckedChanged += new System.EventHandler(this.rbtSeleccion_CheckedChanged);
            // 
            // rbtProximas
            // 
            this.rbtProximas.AutoSize = true;
            this.rbtProximas.Location = new System.Drawing.Point(226, 17);
            this.rbtProximas.Name = "rbtProximas";
            this.rbtProximas.Size = new System.Drawing.Size(91, 24);
            this.rbtProximas.TabIndex = 16;
            this.rbtProximas.TabStop = true;
            this.rbtProximas.Text = "Próximas";
            this.rbtProximas.UseVisualStyleBackColor = true;
            this.rbtProximas.CheckedChanged += new System.EventHandler(this.rbtProximas_CheckedChanged);
            // 
            // rbtAntiguas
            // 
            this.rbtAntiguas.AutoSize = true;
            this.rbtAntiguas.Location = new System.Drawing.Point(122, 17);
            this.rbtAntiguas.Name = "rbtAntiguas";
            this.rbtAntiguas.Size = new System.Drawing.Size(90, 24);
            this.rbtAntiguas.TabIndex = 15;
            this.rbtAntiguas.TabStop = true;
            this.rbtAntiguas.Text = "Antiguas";
            this.rbtAntiguas.UseVisualStyleBackColor = true;
            this.rbtAntiguas.CheckedChanged += new System.EventHandler(this.rbtAntiguas_CheckedChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Location = new System.Drawing.Point(662, 8);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(140, 44);
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "FECHA:";
            // 
            // CitaListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(839, 513);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CitaListado";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Listado de citas";
            this.Load += new System.EventHandler(this.CitaListado_Load);
            this.DoubleClick += new System.EventHandler(this.CitaListado_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lista;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpSeleccion;
        private System.Windows.Forms.RadioButton rbtSeleccion;
        private System.Windows.Forms.RadioButton rbtProximas;
        private System.Windows.Forms.RadioButton rbtAntiguas;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label3;
    }
}