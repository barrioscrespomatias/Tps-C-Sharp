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
using Stock;

namespace Formularios
{
    public partial class frmDatosPersonales : Form
    {
        public Colono colono;
        public Colonia catalinas;
        public SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexionDB);
        public VincularDB vincular;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public frmDatosPersonales()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que recibe un colono y una colonia.
        /// </summary>
        /// <param name="colono"></param>
        /// <param name="catalinas"></param>
        public frmDatosPersonales(Colono colono, Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
            this.colono = colono;
        }
        /// <summary>
        /// Bloquea los textbox.
        /// Solo muestra los datos si el DNI ingresado es mayor que cero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDatosPersonales_Load(object sender, EventArgs e)
        {
            this.BloquearTextBox();
            if (!this.ActualizarTextBox())
            {
                MessageBox.Show("El dni ingresado no coincide con ninguno de los colonos");
            }
            this.Text = "Datos del colono";
        }
        /// <summary>
        /// Genera una nueva instancia de frmVenta en la que se cargarán los datos de una nueva venta
        /// A dicho formulario le pasa por parámetro un colono y la colonia con todos sus datos.
        /// Si la venta se produce, actualiza los textBox con la informacion del colono.(actualiza su deuda)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            frmVenta nuevaVenta = new frmVenta(this.colono, this.catalinas);            
            nuevaVenta.StartPosition = FormStartPosition.CenterScreen;
            if (nuevaVenta.ShowDialog() == DialogResult.OK)
            {
                this.ActualizarTextBox();
            }
        }
        /// <summary>
        /// Genera un nuevo formulario frmModificarColono en el que muestra los datos del colono.
        /// En dicho formulario permite cambiar algunos de los datos del colono.
        /// Valida los datos del formulario frmModificarColono.
        /// Si los datos son correctos vincula con la base de datos cargando los nuevos valores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool modificado = false;
            this.vincular = new VincularDB(this.conexion);
            frmModificarColono modificar = new frmModificarColono(this.colono);           
            modificar.StartPosition = FormStartPosition.CenterScreen;
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
                    if (this.vincular.ProbarConexion())
                    {
                        if (this.vincular.ModificarColono(this.colono))
                        {
                            this.ActualizarTextBox();
                            MessageBox.Show("Se ha modificado el colono!");
                        }
                    }
                    else
                        MessageBox.Show("No se ha podido conectar con la base de datos!");
                }
            }

        }
        /// <summary>
        /// Realiza vínculo con la base de datos y elimina el registro de la misma previa
        /// validacion con pregunta a confirmar.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.vincular = new VincularDB(this.conexion);
            DialogResult resultado = MessageBox.Show("¿Realmente desea eliminar?", "Borrar alumno", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                if (this.vincular.ProbarConexion())
                {
                    //Elimina al colono de la instancia actual.
                    this.catalinas -= this.colono;
                    //Elimiina de la base de datos.
                    if (this.vincular.EliminarColono(this.colono))
                    {
                        MessageBox.Show("Se ha eliminado el colono");
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("No se ha podido conectar a la base de datos");

            }
        }
        /// <summary>       
        /// Pagar saldo aumentará el saldo a favor de la colonia según el saldo deudor que tenga un colono.
        /// El saldo del colono bajará a cero y no tendrá más deudas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    if (this.vincular.ProbarConexion())
                    {
                        this.colono.PagarDeudas(this.colono, this.catalinas);
                        if (this.vincular.ModificarColono(this.colono))
                        {
                            this.ActualizarTextBox();
                            MessageBox.Show("El colono ya no tiene deudas!!");
                        }
                        else
                            MessageBox.Show("No se ha podido procesar el pago");
                    }
                    else
                        MessageBox.Show("No se ha podido conectar a la base de datos");

                }
            }
            else
                MessageBox.Show("El colono no tiene deudas. Impecable");
        }
        /// <summary>
        /// Cierra el formulario de datos personales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Actualiza los textBox validando que el dni ingresado sea mayor que cero.
        /// </summary>
        /// <returns></returns>
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
                this.txtBoxMes.Text = colono.CargarMes.ToString();
                retorno = true;
            }
            return retorno;
        }
        /// <summary>
        /// Bloquea los TextBox para que no reciban datos.
        /// </summary>
        private void BloquearTextBox()
        {
            this.txtBoxApellido.Enabled = false;
            this.txtBoxNombre.Enabled = false;
            this.txtBoxDni.Enabled = false;
            this.txtBoxFechaNacimiento.Enabled = false;
            this.txtBoxEdad.Enabled = false;
            this.txtBoxGrupo.Enabled = false;
            this.txtBoxDeuda.Enabled = false;
            this.txtBoxMes.Enabled = false;
        }
    }
}
