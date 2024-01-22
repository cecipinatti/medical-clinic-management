namespace ProyectoClinica
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.horafecha = new System.Windows.Forms.Timer(this.components);
            this.lbnFecha = new System.Windows.Forms.Label();
            this.lbnHora = new System.Windows.Forms.Label();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnProfesionales = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // horafecha
            // 
            this.horafecha.Enabled = true;
            this.horafecha.Tick += new System.EventHandler(this.horafecha_Tick);
            // 
            // lbnFecha
            // 
            this.lbnFecha.BackColor = System.Drawing.Color.Transparent;
            this.lbnFecha.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbnFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbnFecha.Location = new System.Drawing.Point(0, 388);
            this.lbnFecha.Name = "lbnFecha";
            this.lbnFecha.Padding = new System.Windows.Forms.Padding(0, 0, 20, 20);
            this.lbnFecha.Size = new System.Drawing.Size(762, 51);
            this.lbnFecha.TabIndex = 2;
            this.lbnFecha.Text = "lunes, 23 de septiembre de 2023";
            this.lbnFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbnHora
            // 
            this.lbnHora.BackColor = System.Drawing.Color.Transparent;
            this.lbnHora.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbnHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbnHora.Location = new System.Drawing.Point(0, 317);
            this.lbnHora.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.lbnHora.Name = "lbnHora";
            this.lbnHora.Padding = new System.Windows.Forms.Padding(20, 0, 30, 0);
            this.lbnHora.Size = new System.Drawing.Size(762, 71);
            this.lbnHora.TabIndex = 3;
            this.lbnHora.Text = "12:00:00";
            this.lbnHora.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnPacientes
            // 
            this.btnPacientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacientes.ForeColor = System.Drawing.Color.White;
            this.btnPacientes.Location = new System.Drawing.Point(16, 35);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(327, 74);
            this.btnPacientes.TabIndex = 4;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnProfesionales
            // 
            this.btnProfesionales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnProfesionales.FlatAppearance.BorderSize = 0;
            this.btnProfesionales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfesionales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfesionales.ForeColor = System.Drawing.Color.White;
            this.btnProfesionales.Location = new System.Drawing.Point(16, 128);
            this.btnProfesionales.Name = "btnProfesionales";
            this.btnProfesionales.Size = new System.Drawing.Size(327, 74);
            this.btnProfesionales.TabIndex = 5;
            this.btnProfesionales.Text = "Profesionales";
            this.btnProfesionales.UseVisualStyleBackColor = false;
            this.btnProfesionales.Click += new System.EventHandler(this.btnProfesionales_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.BackColor = System.Drawing.Color.Teal;
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCitas.ForeColor = System.Drawing.Color.White;
            this.btnCitas.Location = new System.Drawing.Point(16, 277);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Size = new System.Drawing.Size(327, 74);
            this.btnCitas.TabIndex = 6;
            this.btnCitas.Text = "Agendar cita";
            this.btnCitas.UseVisualStyleBackColor = false;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(762, 439);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 439);
            this.Controls.Add(this.btnCitas);
            this.Controls.Add(this.btnProfesionales);
            this.Controls.Add(this.btnPacientes);
            this.Controls.Add(this.lbnHora);
            this.Controls.Add(this.lbnFecha);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer horafecha;
        private System.Windows.Forms.Label lbnFecha;
        private System.Windows.Forms.Label lbnHora;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnProfesionales;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

