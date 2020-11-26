using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BaseDatos;
using System.Data.Sql;
using System.Data.SqlClient;
using Excepciones;

namespace Formularios
{
    public partial class frmDatosPersonales : Form
    {
        public Colono colono;
        public Colonia catalinas;
        public SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexionDB);
        public VincularDB vincular;

        public frmDatosPersonales()
        {
            InitializeComponent();
        }

        public frmDatosPersonales(Colono colono,Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
            this.colono = colono;
        }


        public TextBox Nombre
        {
            get { return this.txtBoxNombre; }
            set { this.txtBoxNombre = value; }
        }

        public Button Comprar
        {
            get { return this.btnComprar; }
            set { this.btnComprar = value; }
        }





        private void frmDatosPersonales_Load(object sender, EventArgs e)
        {

            this.txtBoxApellido.Enabled = false;
            this.txtBoxNombre.Enabled = false;
            this.txtBoxDni.Enabled = false;
            this.txtBoxFechaNacimiento.Enabled = false;
            this.txtBoxEdad.Enabled = false;
            this.txtBoxGrupo.Enabled = false;
            this.txtBoxDeuda.Enabled = false;


            //this.txtBoxNombre.Text = this.colono.Nombre;
            //this.txtBoxApellido.Text = this.colono.Apellido;
            //this.txtBoxDni.Text = this.colono.Dni.ToString();
            //this.txtBoxNombre.Text = this.colono.Nombre;
            //this.txtBoxFechaNacimiento.Text = this.colono.FechaNacimiento.ToString();
            //this.txtBoxEdad.Text = this.colono.Edad.ToString();
            //this.txtBoxGrupo.Text = this.colono.EdadGrupo.ToString();
            //this.txtBoxDeuda.Text = this.colono.Saldo.ToString();
            if (!this.ActualizarTextBox())
            {
                MessageBox.Show("El dni ingresado no coincide con ninguno de los colonos");
            }


        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            frmVenta venta = new frmVenta(this.colono,this.catalinas);
            venta.Owner = this;
            venta.StartPosition = FormStartPosition.CenterParent;

            if (venta.ShowDialog() == DialogResult.OK)
            {
                this.ActualizarTextBox();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool modificado = false;
            this.vincular = new VincularDB(this.conexion);
            frmModificarColono modificar = new frmModificarColono(this.colono);
            modificar.Owner = this;
            modificar.StartPosition = FormStartPosition.CenterParent;

            if (modificar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.colono.Nombre = Validaciones.Validar.ValidarSoloLetras(modificar.txtBoxNombre.Text);
                    this.colono.Apellido = Validaciones.Validar.ValidarSoloLetras(modificar.txtBoxApellido.Text);
                    this.colono.Dni = Validaciones.Validar.ValidarSoloNumeros(modificar.txtBoxDni.Text);
                    this.colono.CargarMes = (EMesIncripcion)modificar.cmbMes.SelectedIndex;
                    this.colono.Periodo = (EPeriodoInscripcion)modificar.cmbPeriodo.SelectedIndex;
                    this.colono.FechaNacimiento = Validaciones.Validar.ValidarFecha(modificar.txtBoxFechaNacimiento.Text);

                    this.colono.Edad = (int)DateTime.Today.Year - colono.FechaNacimiento.Year;
                    this.colono.EdadGrupo = this.colono.AsignarGrupo(this.colono.Edad);
                    if (this.colono.SinDeudas == false)
                        this.colono.Saldo = Colono.CalcularDeuda(this.colono.Periodo);
                    else
                        this.colono.Saldo = 0;
                    modificado = true;
                }
                catch (ValidacionIncorrectaException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (Colono.EsValido(this.colono) && modificado == true)
                {
                    if (this.vincular.ModificarColono(this.colono))
                    {
                        this.ActualizarTextBox();
                        MessageBox.Show("Se ha modificado el colono!");
                    }
                }
            }

        }

        private bool ActualizarTextBox()
        {
            bool retorno = false;
            if (this.colono.Dni > 0)
            {
                this.txtBoxNombre.Text = colono.Nombre;
                this.txtBoxApellido.Text = colono.Apellido;
                this.txtBoxDni.Text = colono.Dni.ToString();
                this.txtBoxEdad.Text = colono.Edad.ToString();
                this.txtBoxDeuda.Text = colono.Saldo.ToString();
                this.txtBoxFechaNacimiento.Text = colono.FechaNacimiento.ToString();
                this.txtBoxGrupo.Text = colono.EdadGrupo.ToString();
                retorno = true;
            }
            return retorno;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.vincular = new VincularDB(this.conexion);

            DialogResult resultado = MessageBox.Show("¿Realmente desea eliminar?", "Borrar alumno", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                if (this.vincular.EliminarColono(this.colono))
                {
                    MessageBox.Show("Se ha eliminado el colono");
                    this.Close();
                }

            }
        }

        private void btnPagarSaldo_Click(object sender, EventArgs e)
        {
            this.vincular = new VincularDB(this.conexion);

            double saldo = this.colono.Saldo;
            this.colono.SinDeudas = true;
            if (this.colono.Saldo > 0)
            {

                DialogResult resultado = MessageBox.Show("¿Desea pagar $" + saldo + "?", "Saldar deuda", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {

                    this.colono.Saldo = 0;
                    if (this.vincular.ModificarColono(this.colono))
                    {
                        this.ActualizarTextBox();
                        MessageBox.Show("El colono ya no tiene deudas!!");
                    }

                    else
                        MessageBox.Show("No se ha podido procesar el pago");


                }
            }
            else
                MessageBox.Show("El colono no tiene deudas. Impecable");


        }

        
    }
}
