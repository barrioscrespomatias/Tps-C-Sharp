namespace Formularios
{
    partial class frmAltaAntiparra
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.bntAceptar = new System.Windows.Forms.Button();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtBoxPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.cmbBoxColores = new System.Windows.Forms.ComboBox();
            this.cmbBoxMarca = new System.Windows.Forms.ComboBox();
            this.txtBoxCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(133, 250);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // bntAceptar
            // 
            this.bntAceptar.Location = new System.Drawing.Point(18, 250);
            this.bntAceptar.Name = "bntAceptar";
            this.bntAceptar.Size = new System.Drawing.Size(75, 23);
            this.bntAceptar.TabIndex = 4;
            this.bntAceptar.Text = "Aceptar";
            this.bntAceptar.UseVisualStyleBackColor = true;
            this.bntAceptar.Click += new System.EventHandler(this.bntAceptar_Click);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(18, 14);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(37, 13);
            this.lblMarca.TabIndex = 22;
            this.lblMarca.Text = "Marca";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(18, 64);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(31, 13);
            this.lblNombre.TabIndex = 20;
            this.lblNombre.Text = "Color";
            // 
            // txtBoxPrecio
            // 
            this.txtBoxPrecio.Location = new System.Drawing.Point(18, 155);
            this.txtBoxPrecio.Name = "txtBoxPrecio";
            this.txtBoxPrecio.Size = new System.Drawing.Size(190, 20);
            this.txtBoxPrecio.TabIndex = 2;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(18, 125);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 27;
            this.lblPrecio.Text = "Precio";
            // 
            // cmbBoxColores
            // 
            this.cmbBoxColores.FormattingEnabled = true;
            this.cmbBoxColores.Location = new System.Drawing.Point(18, 91);
            this.cmbBoxColores.Name = "cmbBoxColores";
            this.cmbBoxColores.Size = new System.Drawing.Size(190, 21);
            this.cmbBoxColores.TabIndex = 1;
            // 
            // cmbBoxMarca
            // 
            this.cmbBoxMarca.FormattingEnabled = true;
            this.cmbBoxMarca.Location = new System.Drawing.Point(18, 30);
            this.cmbBoxMarca.Name = "cmbBoxMarca";
            this.cmbBoxMarca.Size = new System.Drawing.Size(190, 21);
            this.cmbBoxMarca.TabIndex = 0;
            // 
            // txtBoxCantidad
            // 
            this.txtBoxCantidad.Location = new System.Drawing.Point(18, 208);
            this.txtBoxCantidad.Name = "txtBoxCantidad";
            this.txtBoxCantidad.Size = new System.Drawing.Size(190, 20);
            this.txtBoxCantidad.TabIndex = 3;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(18, 192);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 29;
            this.lblCantidad.Text = "Cantidad";
            // 
            // frmAltaAntiparra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 285);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtBoxCantidad);
            this.Controls.Add(this.cmbBoxMarca);
            this.Controls.Add(this.cmbBoxColores);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtBoxPrecio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.bntAceptar);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmAltaAntiparra";
            this.Text = "frmAltaAntiparra";
            this.Load += new System.EventHandler(this.frmAltaAntiparra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button bntAceptar;
        public System.Windows.Forms.Label lblMarca;
        public System.Windows.Forms.Label lblNombre;
        public System.Windows.Forms.TextBox txtBoxPrecio;
        public System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.ComboBox cmbBoxColores;
        private System.Windows.Forms.ComboBox cmbBoxMarca;
        private System.Windows.Forms.TextBox txtBoxCantidad;
        public System.Windows.Forms.Label lblCantidad;
    }
}