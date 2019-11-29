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

namespace FrmPpal
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }
        /// <summary>
        /// Modificacion título
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Correo UTN por BarriosCrespo.Matias.2A";
            
        }
        /// <summary>
        /// Agrega nuevo paquete al correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxTrackingId.Text);
            nuevoPaquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);

            try
            {
                correo += nuevoPaquete;
            }
            catch(TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.ActualizarEstados();
            //finally
            //{
            //    this.ActualizarEstados();
            //}
        }

        /// <summary>
        /// Informa estado paquete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Actualiza los estados de los paquetes segun paquete.estado
        /// </summary>
        private void ActualizarEstados()
        {           
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach(Paquete item in correo.Paquetes)
            {
                if(item.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(item);
                }
                else if(item.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(item);
                }
                else if(item.Estado == Paquete.EEstado.Entregado)
                {
                    lstEstadoEntregado.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Muestra la informacion del paquete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Evalua que el elemento no sea null y muestra los datos del
        /// elemento. Utiliza metoos de extension para guardar los datos.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(elemento!=null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    GuardaString.Guardar(rtbMostrar.Text, "salida.txt");
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void mostrarToolStripMenuItem_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }


        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void cmnuMostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
