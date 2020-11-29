namespace Formularios
{
    partial class frmDatosPersonales
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtBoxNombre = new System.Windows.Forms.TextBox();
            this.txtBoxApellido = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtBoxFechaNacimiento = new System.Windows.Forms.TextBox();
            this.txtBoxDni = new System.Windows.Forms.TextBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.txtBoxGrupo = new System.Windows.Forms.TextBox();
            this.txtBoxEdad = new System.Windows.Forms.TextBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnPagarSaldo = new System.Windows.Forms.Button();
            this.lblMes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxMes = new System.Windows.Forms.TextBox();
            this.txtBoxDeuda = new System.Windows.Forms.TextBox();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 20F);
            this.label2.Location = new System.Drawing.Point(32, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "INFORMACIÓN PERSONAL";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(25, 248);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(181, 41);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtBoxNombre
            // 
            this.txtBoxNombre.Location = new System.Drawing.Point(96, 92);
            this.txtBoxNombre.Name = "txtBoxNombre";
            this.txtBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.txtBoxNombre.TabIndex = 0;
            // 
            // txtBoxApellido
            // 
            this.txtBoxApellido.Location = new System.Drawing.Point(320, 89);
            this.txtBoxApellido.Name = "txtBoxApellido";
            this.txtBoxApellido.Size = new System.Drawing.Size(100, 20);
            this.txtBoxApellido.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(22, 95);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(239, 92);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 6;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(239, 128);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(75, 13);
            this.lblFechaNacimiento.TabIndex = 10;
            this.lblFechaNacimiento.Text = "F. Nacimiento:";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(22, 131);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(26, 13);
            this.lblDni.TabIndex = 9;
            this.lblDni.Text = "DNI";
            // 
            // txtBoxFechaNacimiento
            // 
            this.txtBoxFechaNacimiento.Location = new System.Drawing.Point(320, 125);
            this.txtBoxFechaNacimiento.Name = "txtBoxFechaNacimiento";
            this.txtBoxFechaNacimiento.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFechaNacimiento.TabIndex = 3;
            // 
            // txtBoxDni
            // 
            this.txtBoxDni.Location = new System.Drawing.Point(96, 128);
            this.txtBoxDni.Name = "txtBoxDni";
            this.txtBoxDni.Size = new System.Drawing.Size(100, 20);
            this.txtBoxDni.TabIndex = 2;
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(239, 165);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 14;
            this.lblGrupo.Text = "Grupo:";
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(22, 168);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(35, 13);
            this.lblEdad.TabIndex = 13;
            this.lblEdad.Text = "Edad:";
            // 
            // txtBoxGrupo
            // 
            this.txtBoxGrupo.Location = new System.Drawing.Point(320, 162);
            this.txtBoxGrupo.Name = "txtBoxGrupo";
            this.txtBoxGrupo.Size = new System.Drawing.Size(100, 20);
            this.txtBoxGrupo.TabIndex = 5;
            // 
            // txtBoxEdad
            // 
            this.txtBoxEdad.Location = new System.Drawing.Point(96, 165);
            this.txtBoxEdad.Name = "txtBoxEdad";
            this.txtBoxEdad.Size = new System.Drawing.Size(100, 20);
            this.txtBoxEdad.TabIndex = 4;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(229, 248);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(181, 41);
            this.btnBorrar.TabIndex = 9;
            this.btnBorrar.Text = "BORRAR";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnPagarSaldo
            // 
            this.btnPagarSaldo.Location = new System.Drawing.Point(25, 295);
            this.btnPagarSaldo.Name = "btnPagarSaldo";
            this.btnPagarSaldo.Size = new System.Drawing.Size(181, 41);
            this.btnPagarSaldo.TabIndex = 10;
            this.btnPagarSaldo.Text = "SALDAR DEUDA";
            this.btnPagarSaldo.UseVisualStyleBackColor = true;
            this.btnPagarSaldo.Click += new System.EventHandler(this.btnPagarSaldo_Click);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(239, 201);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(27, 13);
            this.lblMes.TabIndex = 21;
            this.lblMes.Text = "Mes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Deuda:";
            // 
            // txtBoxMes
            // 
            this.txtBoxMes.Location = new System.Drawing.Point(320, 198);
            this.txtBoxMes.Name = "txtBoxMes";
            this.txtBoxMes.Size = new System.Drawing.Size(100, 20);
            this.txtBoxMes.TabIndex = 7;
            // 
            // txtBoxDeuda
            // 
            this.txtBoxDeuda.Location = new System.Drawing.Point(96, 201);
            this.txtBoxDeuda.Name = "txtBoxDeuda";
            this.txtBoxDeuda.Size = new System.Drawing.Size(100, 20);
            this.txtBoxDeuda.TabIndex = 6;
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(229, 295);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(181, 41);
            this.btnComprar.TabIndex = 11;
            this.btnComprar.Text = "COMPRAR";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(25, 342);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(385, 41);
            this.btnSalir.TabIndex = 22;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmDatosPersonales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxMes);
            this.Controls.Add(this.txtBoxDeuda);
            this.Controls.Add(this.btnPagarSaldo);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.txtBoxGrupo);
            this.Controls.Add(this.txtBoxEdad);
            this.Controls.Add(this.lblFechaNacimiento);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.txtBoxFechaNacimiento);
            this.Controls.Add(this.txtBoxDni);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtBoxApellido);
            this.Controls.Add(this.txtBoxNombre);
            this.Controls.Add(this.btnModificar);
            this.Name = "frmDatosPersonales";
            this.Text = "frmDatosPersonales";
            this.Load += new System.EventHandler(this.frmDatosPersonales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtBoxNombre;
        private System.Windows.Forms.TextBox txtBoxApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtBoxFechaNacimiento;
        private System.Windows.Forms.TextBox txtBoxDni;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtBoxGrupo;
        private System.Windows.Forms.TextBox txtBoxEdad;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnPagarSaldo;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxMes;
        private System.Windows.Forms.TextBox txtBoxDeuda;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnSalir;
    }
}