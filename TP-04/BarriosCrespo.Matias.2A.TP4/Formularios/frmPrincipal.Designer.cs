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
            this.btnBuscarColono = new System.Windows.Forms.Button();
            this.btnAltaColono = new System.Windows.Forms.Button();
            this.bntControlador = new System.Windows.Forms.Button();
            this.btnMostrarGrupos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAltaProducto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuscarColono
            // 
            this.btnBuscarColono.Location = new System.Drawing.Point(295, 101);
            this.btnBuscarColono.Name = "btnBuscarColono";
            this.btnBuscarColono.Size = new System.Drawing.Size(189, 92);
            this.btnBuscarColono.TabIndex = 1;
            this.btnBuscarColono.Text = "BUSCAR COLONO";
            this.btnBuscarColono.UseVisualStyleBackColor = true;
            this.btnBuscarColono.Click += new System.EventHandler(this.btnBuscarColono_Click);
            // 
            // btnAltaColono
            // 
            this.btnAltaColono.Location = new System.Drawing.Point(12, 101);
            this.btnAltaColono.Name = "btnAltaColono";
            this.btnAltaColono.Size = new System.Drawing.Size(189, 92);
            this.btnAltaColono.TabIndex = 0;
            this.btnAltaColono.Text = "ALTA COLONO";
            this.btnAltaColono.UseVisualStyleBackColor = true;
            this.btnAltaColono.Click += new System.EventHandler(this.btnAltaAlumno_Click);
            // 
            // bntControlador
            // 
            this.bntControlador.Location = new System.Drawing.Point(583, 261);
            this.bntControlador.Name = "bntControlador";
            this.bntControlador.Size = new System.Drawing.Size(205, 92);
            this.bntControlador.TabIndex = 4;
            this.bntControlador.Text = "DETALLES INGRESOS";
            this.bntControlador.UseVisualStyleBackColor = true;
            this.bntControlador.Click += new System.EventHandler(this.bntControlador_Click);
            // 
            // btnMostrarGrupos
            // 
            this.btnMostrarGrupos.Location = new System.Drawing.Point(583, 101);
            this.btnMostrarGrupos.Name = "btnMostrarGrupos";
            this.btnMostrarGrupos.Size = new System.Drawing.Size(205, 92);
            this.btnMostrarGrupos.TabIndex = 2;
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
            // btnAltaProducto
            // 
            this.btnAltaProducto.Location = new System.Drawing.Point(12, 261);
            this.btnAltaProducto.Name = "btnAltaProducto";
            this.btnAltaProducto.Size = new System.Drawing.Size(189, 92);
            this.btnAltaProducto.TabIndex = 3;
            this.btnAltaProducto.Text = "ALTA PRODUCTO";
            this.btnAltaProducto.UseVisualStyleBackColor = true;
            this.btnAltaProducto.Click += new System.EventHandler(this.btnAbmProductos_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAltaProducto);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.bntControlador);
            this.Controls.Add(this.btnMostrarGrupos);
            this.Controls.Add(this.btnAltaColono);
            this.Controls.Add(this.btnBuscarColono);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarColono;
        private System.Windows.Forms.Button btnAltaColono;
        private System.Windows.Forms.Button bntControlador;
        private System.Windows.Forms.Button btnMostrarGrupos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAltaProducto;
    }
}

