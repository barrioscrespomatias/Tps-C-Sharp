namespace Formularios
{
    partial class frmAltaProfesor
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
            this.txtBoxFechaNacimiento = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.txtBoxDni = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtBoxApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.bntAceptar = new System.Windows.Forms.Button();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtBoxSueldo = new System.Windows.Forms.TextBox();
            this.lblSueldo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(192, 252);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtBoxFechaNacimiento
            // 
            this.txtBoxFechaNacimiento.Location = new System.Drawing.Point(185, 93);
            this.txtBoxFechaNacimiento.Name = "txtBoxFechaNacimiento";
            this.txtBoxFechaNacimiento.Size = new System.Drawing.Size(121, 20);
            this.txtBoxFechaNacimiento.TabIndex = 3;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(185, 77);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(93, 13);
            this.lblFechaNacimiento.TabIndex = 20;
            this.lblFechaNacimiento.Text = "Fecha Nacimiento";
            // 
            // txtBoxDni
            // 
            this.txtBoxDni.Location = new System.Drawing.Point(11, 93);
            this.txtBoxDni.Name = "txtBoxDni";
            this.txtBoxDni.Size = new System.Drawing.Size(121, 20);
            this.txtBoxDni.TabIndex = 2;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(11, 77);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(26, 13);
            this.lblDni.TabIndex = 18;
            this.lblDni.Text = "DNI";
            // 
            // txtBoxApellido
            // 
            this.txtBoxApellido.Location = new System.Drawing.Point(186, 35);
            this.txtBoxApellido.Name = "txtBoxApellido";
            this.txtBoxApellido.Size = new System.Drawing.Size(121, 20);
            this.txtBoxApellido.TabIndex = 1;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(183, 19);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 16;
            this.lblApellido.Text = "Apellido";
            // 
            // bntAceptar
            // 
            this.bntAceptar.Location = new System.Drawing.Point(49, 252);
            this.bntAceptar.Name = "bntAceptar";
            this.bntAceptar.Size = new System.Drawing.Size(75, 23);
            this.bntAceptar.TabIndex = 5;
            this.bntAceptar.Text = "Aceptar";
            this.bntAceptar.UseVisualStyleBackColor = true;
            this.bntAceptar.Click += new System.EventHandler(this.bntAceptar_Click);
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(12, 35);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(121, 20);
            this.txtBoxNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(9, 19);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 14;
            this.lblNombre.Text = "Nombre";
            // 
            // txtBoxSueldo
            // 
            this.txtBoxSueldo.Location = new System.Drawing.Point(11, 161);
            this.txtBoxSueldo.Name = "txtBoxSueldo";
            this.txtBoxSueldo.Size = new System.Drawing.Size(121, 20);
            this.txtBoxSueldo.TabIndex = 4;
            // 
            // lblSueldo
            // 
            this.lblSueldo.AutoSize = true;
            this.lblSueldo.Location = new System.Drawing.Point(11, 145);
            this.lblSueldo.Name = "lblSueldo";
            this.lblSueldo.Size = new System.Drawing.Size(40, 13);
            this.lblSueldo.TabIndex = 28;
            this.lblSueldo.Text = "Sueldo";
            // 
            // frmAltaProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 328);
            this.Controls.Add(this.txtBoxSueldo);
            this.Controls.Add(this.lblSueldo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtBoxFechaNacimiento);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.txtBoxDni);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtBoxApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.bntAceptar);
            this.Controls.Add(this.txtBoxNombre);
            this.Controls.Add(this.lblNombre);
            this.Name = "frmAltaProfesor";
            this.Text = "frmAltaProfesor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.TextBox txtBoxFechaNacimiento;
        public System.Windows.Forms.Label lblFechaNacimiento;
        public System.Windows.Forms.TextBox txtBoxDni;
        public System.Windows.Forms.Label lblDni;
        public System.Windows.Forms.TextBox txtBoxApellido;
        public System.Windows.Forms.Label lblApellido;
        public System.Windows.Forms.Button bntAceptar;
        public System.Windows.Forms.TextBox txtBoxNombre;
        public System.Windows.Forms.Label lblNombre;
        public System.Windows.Forms.TextBox txtBoxSueldo;
        public System.Windows.Forms.Label lblSueldo;
    }
}