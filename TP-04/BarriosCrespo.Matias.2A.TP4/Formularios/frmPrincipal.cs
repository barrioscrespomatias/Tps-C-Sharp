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
using System.Data.Sql;
using System.Data.SqlClient;
using Stock;
using System.Threading;

namespace Formularios
{
    public partial class frmPrincipal : Form
    {
        frmMostrarColonos mostrarColonos;
        frmMostrarGrupo mostrarGrupo;
        Thread hiloInicial;

        //atributo principal de la colonia.
        public Colonia catalinas = new Colonia("Catalinas");

        /// <summary>
        /// Constructor sin parámetros. Inicializa hilo de color del formulario principal
        /// </summary>
        public frmPrincipal()
        {
            InitializeComponent();
            hiloInicial = new Thread(new ThreadStart(this.Comenzando));
            hiloInicial.Start();
        }
        /// <summary>
        /// Carga los grupos en la colonia, inicializa los productos en venta, carga los profesores
        /// y productos hardcodeados. Muestra medante messageBox los docentes actuales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.catalinas = this.CargarGrupos();
            this.catalinas.ProductosEnVenta = new ControlStock<Producto>();
            this.HardcodeoProfesoresProductos();

            foreach (Profesor aux in this.catalinas.ListaDeProfesores)
            {
                MessageBox.Show(aux.ToString());
            }
        }
        /// <summary>
        /// Boton que levanta el formulario frmMostrarColonos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarAlumnos_Click(object sender, EventArgs e)
        {
            mostrarColonos = new frmMostrarColonos(this.catalinas);
            mostrarColonos.StartPosition = FormStartPosition.CenterScreen;
            mostrarColonos.Show();

        }
        /// <summary>
        /// Boton que levanta el formulario frmMostrarGrupos (filtrados por edad...)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarGrupos_Click(object sender, EventArgs e)
        {
            this.mostrarGrupo = new frmMostrarGrupo(this.catalinas);
            this.mostrarGrupo.StartPosition = FormStartPosition.CenterScreen;
            this.mostrarGrupo.Show();
        }
        /// <summary>
        /// Boton que levanta el formulario del alta del alumno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaAlumno_Click(object sender, EventArgs e)
        {
            frmAltaColono altaColono = new frmAltaColono(this.catalinas);
            altaColono.StartPosition = FormStartPosition.CenterScreen;

            if (altaColono.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Se ha cargado el alumno!");
            }
        }

        /// <summary>
        /// Boton que levanta el formulario alta del profesor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAltaProfesor_Click(object sender, EventArgs e)
        {
            frmAltaProfesor frmProfesor = new frmAltaProfesor();
            frmProfesor.StartPosition = FormStartPosition.CenterScreen;


            if (frmProfesor.ShowDialog() == DialogResult.OK)
            {
                this.catalinas.ListaDeProfesores.Add(frmProfesor.profesor);
                MessageBox.Show("Se ha cargado el profesor!");
            }
        }
        /// <summary>
        /// Boton que muestra los datos de la colonia. Cantidad de dinero saliente por profesores,
        /// cantidad de dinero entrante por cuotas y venta de productos, cantidad de saldo actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntControlador_Click(object sender, EventArgs e)
        {
            double gastos = 0;
            double saldo = 0;

            foreach (Profesor profe in this.catalinas.ListaDeProfesores)
            {
                gastos += profe.Salario;
            }
            this.catalinas.Gastos = gastos;

            saldo = this.catalinas.SaldoActual - gastos;


            MessageBox.Show("La entrada por las cuotas es: $ " + catalinas.SaldoActual.ToString());
            MessageBox.Show("Gastos por profesores: $ " + catalinas.Gastos.ToString());
            MessageBox.Show("El saldo a favor es: $ " + saldo);

        }
        /// <summary>
        /// metodo que agrega profesores hardcodeados a la colonia.
        /// </summary>
        /// <param name="p1"></param>
        public void AgregarProfesorLista(Profesor p1)
        {
            this.catalinas.ListaDeProfesores.Add(p1);
        }

        /// <summary>
        /// Carga los grupos a la colonia desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public Colonia CargarGrupos()
        {
            SqlConnection conexion;
            SqlCommand comando;
            SqlDataReader lector;

            string sql = "SELECT * FROM colonos_table";

            comando = new SqlCommand();
            conexion = new SqlConnection(Properties.Settings.Default.conexionDB);

            try
            {
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;

                conexion.Open();
                lector = comando.ExecuteReader();


                Colono c;
                string nombre;
                string apellido;
                int dni;
                DateTime fechaNacimiento;
                string periodo;


                while (lector.Read())
                {
                    nombre = lector.GetString(1);
                    apellido = lector.GetString(2);
                    dni = lector.GetInt32(3);
                    fechaNacimiento = lector.GetDateTime(4);
                    periodo = lector.GetString(5);

                    //MODFICIAR PERIODO
                    c = new Colono(nombre, apellido, fechaNacimiento, dni, EPeriodoInscripcion.Mes);
                    if (catalinas != c)
                        catalinas += c;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return catalinas;
        }

        /// <summary>
        /// Hardocodeo de profesores y productos.
        /// </summary>
        private void HardcodeoProfesoresProductos()
        {
            Profesor p1 = new Profesor("Charly", "Baus", new DateTime(1970, 05, 15), 121212, 5000f);
            Profesor p2 = new Profesor("Octa", "Bio", new DateTime(1975, 10, 15), 131313, 5000f);
            Profesor p3 = new Profesor("German", "Cito", new DateTime(1995, 06, 25), 141414, 5000f);
            Profesor p4 = new Profesor("Maxi", "Neymmar", new DateTime(1977, 08, 02), 151515, 5000f);

            this.catalinas.ListaDeProfesores.Add(p1);
            this.catalinas.ListaDeProfesores.Add(p2);
            this.catalinas.ListaDeProfesores.Add(p3);
            this.catalinas.ListaDeProfesores.Add(p4);

            Gorrito g1 = new Gorrito(ConsoleColor.Yellow, 200f);
            Gorrito g2 = new Gorrito(ConsoleColor.Green, 200f);

            Antiparra a1 = new Antiparra(EMarca.Pirulito, ConsoleColor.Red, 500f);
            Antiparra a2 = new Antiparra(EMarca.Adidas, ConsoleColor.Green, 500f);
            Antiparra a3 = new Antiparra(EMarca.Adidas, ConsoleColor.White, 500f);

            this.catalinas.ProductosEnVenta += g1;
            this.catalinas.ProductosEnVenta += g2;
            this.catalinas.ProductosEnVenta += a1;
            this.catalinas.ProductosEnVenta += a2;
            this.catalinas.ProductosEnVenta += a3;


        }
        /// <summary>
        /// Metodo manejador del evento de hilos. Lindos los colores (?
        /// </summary>
        private void Comenzando()
        {
            Thread.Sleep(1000);
            this.BackColor = Color.Beige;

            for (int i = 0; i < 2; i++)
            {
                this.btnAltaAlumno.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnAltaAlumno.BackColor = (Color)default;
                Thread.Sleep(100);
                this.btnMostrarAlumnos.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnMostrarAlumnos.BackColor = (Color)default;
                Thread.Sleep(100);

                this.btnMostrarGrupos.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnMostrarGrupos.BackColor = (Color)default;
                Thread.Sleep(100);

                this.btnAltaProfesor.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.btnAltaProfesor.BackColor = (Color)default;
                Thread.Sleep(100);

                this.bntControlador.BackColor = Color.BurlyWood;
                Thread.Sleep(1000);
                this.bntControlador.BackColor = (Color)default;
                Thread.Sleep(100);
            }
            this.BackColor = (Color)default;
            hiloInicial.Abort();



        }


    }
}
