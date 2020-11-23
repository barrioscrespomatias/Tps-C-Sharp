namespace Formularios
{
    partial class frmPrincipal
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
            this.btnMostrarAlumnos = new System.Windows.Forms.Button();
            this.btnAltaAlumno = new System.Windows.Forms.Button();
            this.btnAltaProfesor = new System.Windows.Forms.Button();
            this.bntControlador = new System.Windows.Forms.Button();
            this.btnMostrarGrupos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMostrarAlumnos
            // 
            this.btnMostrarAlumnos.Location = new System.Drawing.Point(292, 101);
            this.btnMostrarAlumnos.Name = "btnMostrarAlumnos";
            this.btnMostrarAlumnos.Size = new System.Drawing.Size(199, 92);
            this.btnMostrarAlumnos.TabIndex = 0;
            this.btnMostrarAlumnos.Text = "MOSTRAR COLONOS";
            this.btnMostrarAlumnos.UseVisualStyleBackColor = true;
            this.btnMostrarAlumnos.Click += new System.EventHandler(this.btnMostrarAlumnos_Click);
            // 
            // btnAltaAlumno
            // 
            this.btnAltaAlumno.Location = new System.Drawing.Point(19, 101);
            this.btnAltaAlumno.Name = "btnAltaAlumno";
            this.btnAltaAlumno.Size = new System.Drawing.Size(199, 92);
            this.btnAltaAlumno.TabIndex = 1;
            this.btnAltaAlumno.Text = "ALTA ALUMNO";
            this.btnAltaAlumno.UseVisualStyleBackColor = true;
            this.btnAltaAlumno.Click += new System.EventHandler(this.btnAltaAlumno_Click);
            // 
            // btnAltaProfesor
            // 
            this.btnAltaProfesor.Location = new System.Drawing.Point(19, 261);
            this.btnAltaProfesor.Name = "btnAltaProfesor";
            this.btnAltaProfesor.Size = new System.Drawing.Size(380, 92);
            this.btnAltaProfesor.TabIndex = 2;
            this.btnAltaProfesor.Text = "CARGAR PROFESORES";
            this.btnAltaProfesor.UseVisualStyleBackColor = true;
            this.btnAltaProfesor.Click += new System.EventHandler(this.btnAltaProfesor_Click);
            // 
            // bntControlador
            // 
            this.bntControlador.Location = new System.Drawing.Point(405, 261);
            this.bntControlador.Name = "bntControlador";
            this.bntControlador.Size = new System.Drawing.Size(377, 92);
            this.bntControlador.TabIndex = 5;
            this.bntControlador.Text = "RESUMEN DE CUENTAS";
            this.bntControlador.UseVisualStyleBackColor = true;
            this.bntControlador.Click += new System.EventHandler(this.bntControlador_Click);
            // 
            // btnMostrarGrupos
            // 
            this.btnMostrarGrupos.Location = new System.Drawing.Point(583, 101);
            this.btnMostrarGrupos.Name = "btnMostrarGrupos";
            this.btnMostrarGrupos.Size = new System.Drawing.Size(199, 92);
            this.btnMostrarGrupos.TabIndex = 4;
            this.btnMostrarGrupos.Text = "MOSTRAR GRUPOS";
            this.btnMostrarGrupos.UseVisualStyleBackColor = true;
            this.btnMostrarGrupos.Click += new System.EventHandler(this.btnMostrarGrupos_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(219, 35);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(363, 31);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "COLONIA CATALINAS 2021";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.bntControlador);
            this.Controls.Add(this.btnMostrarGrupos);
            this.Controls.Add(this.btnAltaProfesor);
            this.Controls.Add(this.btnAltaAlumno);
            this.Controls.Add(this.btnMostrarAlumnos);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMostrarAlumnos;
        private System.Windows.Forms.Button btnAltaAlumno;
        private System.Windows.Forms.Button btnAltaProfesor;
        private System.Windows.Forms.Button bntControlador;
        private System.Windows.Forms.Button btnMostrarGrupos;
        private System.Windows.Forms.Label lblTitulo;
    }
}

