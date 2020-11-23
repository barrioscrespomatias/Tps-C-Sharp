namespace Formularios
{
    partial class frmAltaGorrito
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
            this.lblColor = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.bntAceptar = new System.Windows.Forms.Button();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.cmbColores = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(10, 28);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 10;
            this.lblColor.Text = "Color";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(127, 205);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // bntAceptar
            // 
            this.bntAceptar.Location = new System.Drawing.Point(12, 205);
            this.bntAceptar.Name = "bntAceptar";
            this.bntAceptar.Size = new System.Drawing.Size(75, 23);
            this.bntAceptar.TabIndex = 16;
            this.bntAceptar.Text = "Aceptar";
            this.bntAceptar.UseVisualStyleBackColor = true;
            this.bntAceptar.Click += new System.EventHandler(this.bntAceptar_Click);
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(12, 134);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(190, 20);
            this.textBoxPrecio.TabIndex = 18;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(12, 107);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(37, 13);
            this.lblPrecio.TabIndex = 19;
            this.lblPrecio.Text = "Precio";
            // 
            // cmbColores
            // 
            this.cmbColores.FormattingEnabled = true;
            this.cmbColores.Location = new System.Drawing.Point(12, 55);
            this.cmbColores.Name = "cmbColores";
            this.cmbColores.Size = new System.Drawing.Size(190, 21);
            this.cmbColores.TabIndex = 20;
            // 
            // frmAltaGorrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 240);
            this.Controls.Add(this.cmbColores);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.bntAceptar);
            this.Controls.Add(this.lblColor);
            this.Name = "frmAltaGorrito";
            this.Text = "frmAltaProducto";
            this.Load += new System.EventHandler(this.frmAltaGorrito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblColor;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button bntAceptar;
        public System.Windows.Forms.TextBox textBoxPrecio;
        public System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.ComboBox cmbColores;
    }
}