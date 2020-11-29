namespace Formularios
{
    partial class frmBuscarColono
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
            this.txtBoxBuscarColono = new System.Windows.Forms.TextBox();
            this.lblBuscarColono = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxBuscarColono
            // 
            this.txtBoxBuscarColono.Location = new System.Drawing.Point(48, 63);
            this.txtBoxBuscarColono.Name = "txtBoxBuscarColono";
            this.txtBoxBuscarColono.Size = new System.Drawing.Size(100, 20);
            this.txtBoxBuscarColono.TabIndex = 0;
            // 
            // lblBuscarColono
            // 
            this.lblBuscarColono.AutoSize = true;
            this.lblBuscarColono.Location = new System.Drawing.Point(67, 38);
            this.lblBuscarColono.Name = "lblBuscarColono";
            this.lblBuscarColono.Size = new System.Drawing.Size(67, 13);
            this.lblBuscarColono.TabIndex = 1;
            this.lblBuscarColono.Text = "Ingresar DNI";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(59, 124);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmBuscarColono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 196);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblBuscarColono);
            this.Controls.Add(this.txtBoxBuscarColono);
            this.Name = "frmBuscarColono";
            this.Text = "frmBuscarColono";
            this.Load += new System.EventHandler(this.frmBuscarColono_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxBuscarColono;
        private System.Windows.Forms.Label lblBuscarColono;
        private System.Windows.Forms.Button btnBuscar;
    }
}