namespace Formularios
{
    partial class frmMostrarColonos
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblListadoAlumnos = new System.Windows.Forms.Label();
            this.btnEliminarColono = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnPagarCuota = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(576, 244);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblListadoAlumnos
            // 
            this.lblListadoAlumnos.AutoSize = true;
            this.lblListadoAlumnos.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoAlumnos.Location = new System.Drawing.Point(149, 25);
            this.lblListadoAlumnos.Name = "lblListadoAlumnos";
            this.lblListadoAlumnos.Size = new System.Drawing.Size(291, 39);
            this.lblListadoAlumnos.TabIndex = 1;
            this.lblListadoAlumnos.Text = "Listado de colonos";
            // 
            // btnEliminarColono
            // 
            this.btnEliminarColono.Location = new System.Drawing.Point(35, 335);
            this.btnEliminarColono.Name = "btnEliminarColono";
            this.btnEliminarColono.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarColono.TabIndex = 4;
            this.btnEliminarColono.Text = "Borrar";
            this.btnEliminarColono.UseVisualStyleBackColor = true;
            this.btnEliminarColono.Click += new System.EventHandler(this.btnEliminarColono_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(149, 335);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(491, 335);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnPagarCuota
            // 
            this.btnPagarCuota.Location = new System.Drawing.Point(263, 335);
            this.btnPagarCuota.Name = "btnPagarCuota";
            this.btnPagarCuota.Size = new System.Drawing.Size(75, 23);
            this.btnPagarCuota.TabIndex = 7;
            this.btnPagarCuota.Text = "Pagar Cuota";
            this.btnPagarCuota.UseVisualStyleBackColor = true;
            this.btnPagarCuota.Click += new System.EventHandler(this.btnPagarCuota_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(377, 335);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 8;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // frmMostrarColonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 370);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.btnPagarCuota);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminarColono);
            this.Controls.Add(this.lblListadoAlumnos);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmMostrarColonos";
            this.Text = "frmMostrarColonos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label lblListadoAlumnos;
        public System.Windows.Forms.Button btnEliminarColono;
        public System.Windows.Forms.Button btnModificar;
        public System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnPagarCuota;
        private System.Windows.Forms.Button btnComprar;
    }
}