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
using Stock;
using Excepciones;

namespace Formularios
{
    public partial class frmAltaGorrito : Form
    {
        public Colonia catalinas;
        public Gorrito ingresante;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public frmAltaGorrito()
        {
            InitializeComponent();
        }
        /// <summary>
        /// COnstructor un parámetro que recibe una colonia.
        /// </summary>
        /// <param name="catalinas"></param>
        public frmAltaGorrito(Colonia catalinas) : this()
        {
            this.catalinas = catalinas;
        }

        /// <summary>
        /// Carga los colores a mostrar en el ComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAltaGorrito_Load(object sender, EventArgs e)
        {
            this.cmbColores.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (EColores color in Enum.GetValues(typeof(EColores)))
            {
                this.cmbColores.Items.Add(color.ToString());
            }
            this.Text = "Alta Gorrito";            
            this.cmbColores.SelectedIndex = 0;
        }
        /// <summary>
        /// Toma los datos del nuevo gorrito por formulario.
        /// Valida que los datos sean correctos.
        /// Llama al método "AumentarStock" de la colonia. Este se encarga de verificar la existencia
        /// y aumentar el stock.
        /// Establece el dialogResult en OK. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntAceptar_Click(object sender, EventArgs e)
        {

            EColores color = (EColores)this.cmbColores.SelectedIndex;

            try
            {
                double precio = Validaciones.Validar.ValidarSoloNumeros(this.textBoxPrecio.Text);
                int cantidad= Validaciones.Validar.ValidarSoloNumeros(this.txtBoxCantidad.Text);
                ingresante = new Gorrito(color, precio,cantidad);
                try
                {
                    this.catalinas.AumentarStock(this.catalinas, ingresante);
                    MessageBox.Show(ingresante.ToString(), "ALTA");
                    this.DialogResult = DialogResult.OK;
                }
                catch(StockMaximoException exep)
                {
                    MessageBox.Show(exep.Message);
                }                
            }
            catch (ValidacionIncorrectaException ex)
            {                
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Establece el dialogResult en Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
