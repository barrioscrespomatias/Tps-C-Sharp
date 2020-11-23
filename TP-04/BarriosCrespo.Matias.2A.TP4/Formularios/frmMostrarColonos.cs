using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Entidades;
using Stock;

namespace Formularios
{
    public partial class frmMostrarColonos : Form
    {
        /// <summary>
        /// Atributos de conexion DB
        /// </summary>
        private SqlConnection cn;
        public SqlDataAdapter da;
        public DataTable dt;

        Colonia catalinas;
        /// <summary>
        /// constructor por defecto.
        /// Configura el dataGridView
        /// </summary>
        public frmMostrarColonos()
        {
            InitializeComponent();

            this.ConfigurarDataTable();
            this.ConfigurarDataAdapter(cn);

            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.AllowUserToAddRows = false;

        }
        /// <summary>
        /// Constructor con un parámetro. Recibe una colonia.
        /// </summary>
        /// <param name="c1"></param>
        public frmMostrarColonos(Colonia c1) : this()
        {
            this.catalinas = c1;
        }
        /// <summary>
        /// Configura dataTalbe.
        /// </summary>
        private void ConfigurarDataTable()
        {

            this.dt = new DataTable("Colonos");

            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns.Add("nombre", typeof(string));
            this.dt.Columns.Add("apellido", typeof(string));
            this.dt.Columns.Add("dni", typeof(int));
            this.dt.Columns.Add("fechaNacimiento", typeof(DateTime));
            this.dt.Columns.Add("periodo", typeof(string));
            this.dt.Columns.Add("saldo", typeof(double));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;
            this.dt.Columns["id"].AutoIncrementStep = 1;
        }
        /// <summary>
        /// Configura dataAdapter
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        private bool ConfigurarDataAdapter(SqlConnection cn)
        {
            bool rta = false;

            try
            {
                cn = new SqlConnection(Properties.Settings.Default.conexionDB);

                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT id, nombre, apellido, dni, fechaNacimiento, periodo, saldo FROM colonos_table", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO colonos_table (nombre, apellido, dni, fechaNacimiento, periodo,saldo) VALUES (@nombre, @apellido, @dni, @fechaNacimiento, @periodo, @saldo)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE colonos_table SET nombre=@nombre, apellido=@apellido, dni=@dni, fechaNacimiento=@fechaNacimiento, periodo=@periodo, saldo=@saldo WHERE id=@id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM colonos_table WHERE id=@id", cn);

                this.da.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.da.InsertCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
                this.da.InsertCommand.Parameters.Add("@dni", SqlDbType.Int, 10, "dni");
                this.da.InsertCommand.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime, 10, "fechaNacimiento");
                this.da.InsertCommand.Parameters.Add("@periodo", SqlDbType.VarChar, 50, "periodo");
                this.da.InsertCommand.Parameters.Add("@saldo", SqlDbType.Float, 10, "saldo");

                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");
                this.da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.da.UpdateCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
                this.da.UpdateCommand.Parameters.Add("@dni", SqlDbType.Int, 10, "dni");
                this.da.UpdateCommand.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime, 10, "fechaNacimiento");
                this.da.UpdateCommand.Parameters.Add("@periodo", SqlDbType.VarChar, 50, "periodo");
                this.da.UpdateCommand.Parameters.Add("@saldo", SqlDbType.Float, 10, "saldo");


                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                rta = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return rta;
        }

        /// <summary>
        /// Ejecuta método fill y carga el datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnObtenerAlumnos_Click(object sender, EventArgs e)
        {
            this.da.Fill(this.dt);
            this.dataGridView1.DataSource = this.dt;
        }
        /// <summary>
        /// Actualiza la base de datos con un nuevo colono.
        /// </summary>
        /// <param name="c1"></param>
        /// <returns></returns>
        public bool CargarColono(Colono c1)
        {



            DataRow fila = this.dt.NewRow();
            fila["nombre"] = c1.Nombre;
            fila["apellido"] = c1.Apellido;
            fila["dni"] = c1.Dni;
            fila["fechaNacimiento"] = c1.FechaNacimiento;
            fila["periodo"] = c1.CargarPeriodo;
            fila["saldo"] = c1.Deuda;

            this.dt.Rows.Add(fila);

            //Actualizar base de datos luego de cargar un colono
            this.da.Update(this.dt);

            return true;

        }
        /// <summary>
        /// Elimina un colono del datagrid y de la colonia. Borrado lógico. 
        /// Para borrarlo definitvamente habrá que guardar los cambios.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarColono_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Realmente desea eliminar?", "Borrar alumno", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                int seleccion = -1;
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    seleccion = this.dataGridView1.CurrentRow.Index;

                    //cargar variables
                    DataRow fila = this.dt.Rows[seleccion];
                    Colono c = this.catalinas.ObtenerDatosDatRow(fila);

                    //Elimina el colono de la colonia.
                    this.catalinas -= c;
                    this.dataGridView1.Rows.Remove(this.dataGridView1.Rows[seleccion]);
                    this.btnGuardar.BackColor = Color.Yellow;
                }
                else
                {
                    MessageBox.Show("Primero debe seleccionar una fila");
                }
            }

        }
        /// <summary>
        /// Modifica los datos del colono.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Realmente desea modificar?", "Modificar alumno", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                int seleccion = -1;
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    seleccion = this.dataGridView1.CurrentRow.Index;

                    //cargar variables
                    DataRow fila = this.dt.Rows[seleccion];

                    Colono c = this.catalinas.ObtenerDatosDatRow(fila);

                    frmModificarColono modificar = new frmModificarColono(c);
                    modificar.StartPosition = FormStartPosition.CenterScreen;
                    if (modificar.ShowDialog() == DialogResult.OK)
                    {
                        //Cargar el data row modificado.
                        this.dt.Rows[seleccion]["apellido"] = modificar.Apellido;
                        this.dt.Rows[seleccion]["nombre"] = modificar.Nombre;
                        this.dt.Rows[seleccion]["dni"] = modificar.Dni;
                        this.dt.Rows[seleccion]["fechaNacimiento"] = modificar.FechaNacimiento;
                        this.dt.Rows[seleccion]["periodo"] = modificar.Periodo;
                        MessageBox.Show("Se ha modificado correctamente!");
                    }
                    else
                        MessageBox.Show("Se ha cancelado la modificación.");
                }
                else
                {
                    MessageBox.Show("Primero debe seleccionar una fila");
                }
            }

        }
        /// <summary>
        /// Click boton guardar. Sincroniza con la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.da.Update(this.dt);
            this.btnGuardar.BackColor = default(Color);
        }
        /// <summary>
        /// Boton que permite pagar la cuota. Llama al método pagarCuota. Baja el saldo del colono a cero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPagarCuota_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea saldar el saldo deudor?", "Pagar cuota", MessageBoxButtons.YesNo);


            if (resultado == DialogResult.Yes)
            {
                int seleccion = -1;
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    seleccion = this.dataGridView1.CurrentRow.Index;

                    //cargar variables
                    DataRow fila = this.dt.Rows[seleccion];
                    Colono c = this.catalinas.ObtenerDatosDatRow(fila);

                    if (c.Deuda > 0)
                    {
                        //metodo extension.
                        this.catalinas.SaldoActual += c.PagarCuota(c, this.catalinas);
                        MessageBox.Show("El nuevo saldo deudor es $0");
                        this.dt.Rows[seleccion]["saldo"] = c.Deuda;
                    }
                    else
                    {
                        MessageBox.Show("El colono no tiene deudas para pagar");
                    }

                }

            }
        }

        /// <summary>
        /// Boton comprar. Agrega a los productos del colono, el producto seleccionado desde el datagridview.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (this.catalinas.ProductosEnVenta.Listado.Count > 0)
            {
                int seleccion = -1;
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    seleccion = this.dataGridView1.CurrentRow.Index;

                    //cargar variables
                    DataRow fila = this.dt.Rows[seleccion];

                    Colono c = this.catalinas.ObtenerDatosDatRow(fila);
                    Producto p = new Producto();
                    frmVenta venta = new frmVenta(c, this.catalinas, p);


                    venta.StartPosition = FormStartPosition.CenterScreen;
                    if (venta.ShowDialog() == DialogResult.OK)
                    {
                        this.dt.Rows[seleccion]["saldo"] = c.Deuda;
                        MessageBox.Show("Venta realizada con exito!");
                    }
                    ///Mostrar al colono con su nuevo producto.
                    MessageBox.Show(c.ToString());

                }
            }
            else
            {
                this.btnComprar.BackColor = Color.IndianRed;

            }

        }



    }
}
