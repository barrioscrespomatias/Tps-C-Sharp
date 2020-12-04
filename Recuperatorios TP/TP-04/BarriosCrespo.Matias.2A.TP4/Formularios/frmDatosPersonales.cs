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

        private frmPrincipal padre = new frmPrincipal();
        public event DelegadoActualizaColonia EventoActualizacion;

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
            if (!this.ActualizarTextBox(this.colono))
            {
                MessageBox.Show("El dni ingresado no coincide con ninguno de los colonos");
            }
            this.Text = "Datos del colono";
            this.EventoActualizacion = new DelegadoActualizaColonia(padre.ActualizarColonia);

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
                this.ActualizarTextBox(this.colono);
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
            Colono auxiliar = new Colono();
            this.vincular = new VincularDB(this.conexion);
            //Actualiza la instancia de colonia con ultimos datos de la base de datos.
            this.catalinas = this.EventoActualizacion();

            frmModificarColono modificar = new frmModificarColono(this.colono);
            modificar.StartPosition = FormStartPosition.CenterScreen;
            if (modificar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    auxiliar.Id = this.colono.Id;
                    auxiliar.Nombre = Validaciones.Validar.ValidarSoloLetras(modificar.txtBoxNombre.Text);
                    auxiliar.Apellido = Validaciones.Validar.ValidarSoloLetras(modificar.txtBoxApellido.Text);
                    auxiliar.Dni = Validaciones.Validar.ValidarSoloNumeros(modificar.txtBoxDni.Text);
                    auxiliar.CargarMes = (EMesIncripcion)modificar.cmbMes.SelectedIndex;
                    auxiliar.Periodo = (EPeriodoInscripcion)modificar.cmbPeriodo.SelectedIndex;
                    auxiliar.FechaNacimiento = Validaciones.Validar.ValidarFecha(modificar.txtBoxFechaNacimiento.Text);
                    auxiliar.Edad = (int)DateTime.Today.Year - auxiliar.FechaNacimiento.Year;
                    auxiliar.EdadGrupo = auxiliar.AsignarGrupo(auxiliar.Edad);
                    auxiliar.SaldoProductos = this.colono.SaldoProductos;
                    if (this.colono.SaldoCuota != 0)
                        auxiliar.SaldoCuota = Colono.CalcularDeuda(auxiliar.Periodo);

                    if (Colono.EsValido(auxiliar))
                    {
                        //Eliminar al colono anterior.
                        //this.catalinas -= this.colono;

                        //Agregar al colono modificado                     
                        //this.catalinas += auxiliar;
                        if (this.vincular.ProbarConexion())
                        {
                            if (this.vincular.ModificarColono(auxiliar))
                            {
                                this.ActualizarTextBox(auxiliar);
                                MessageBox.Show("Se ha modificado el colono!");
                            }
                        }
                        else
                            MessageBox.Show("No se ha podido conectar con la base de datos!");
                    }
                }
                catch (ValidacionIncorrectaException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (NacimientoInvalidoException exe)
                {
                    MessageBox.Show(exe.Message);
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
            double saldo = this.colono.SaldoCuota + this.colono.SaldoProductos;
            this.colono.SinDeudas = true;
            if (saldo > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Desea pagar $" + saldo + "?", "Saldar deuda", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    if (this.vincular.ProbarConexion())
                    {
                        this.colono.PagarDeudas(this.colono, this.catalinas);
                        if (this.vincular.ModificarColono(this.colono))
                        {
                            this.ActualizarTextBox(this.colono);
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
        private bool ActualizarTextBox(Colono colono)
        {
            bool retorno = false;
            if (colono.Dni > 0)
            {
                this.txtBoxNombre.Text = colono.Nombre;
                this.txtBoxApellido.Text = colono.Apellido;
                this.txtBoxDni.Text = colono.Dni.ToString();
                this.txtBoxEdad.Text = colono.Edad.ToString();
                this.txtBoxDeuda.Text = (colono.SaldoCuota + colono.SaldoProductos).ToString();
                this.txtBoxFechaNacimiento.Text = colono.FechaNacimiento.ToShortDateString();
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

        public Colonia ActualizarColonia()
        {
            this.vincular = new VincularDB(this.conexion);
            Colonia auxiliar = new Colonia();

            if (this.vincular.ProbarConexion())
            {
                auxiliar = this.vincular.ObtenerColonos(this.catalinas);
            }
            else
                MessageBox.Show("No se ha podido conectar a la base de datos");

            return auxiliar;
        }
    }
}
