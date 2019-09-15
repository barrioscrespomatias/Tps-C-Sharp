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

namespace MiCalculadora
{
   

    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Limpia los textBox. Metodo privado
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";

        }

        /// <summary>
        /// Limpia los textBox. Llama al metodo privado Limpiar().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }


        /// <summary>
        /// Boton Cerrar click. Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Boton Convertir a Binario. Instancia un numero y lo utiliza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero ingresado;
            ingresado = new Numero();

            
           txtNumero2.Text= ingresado.DecimalBinario(this.txtNumero1.Text);
            
            
        }


        /// <summary>
        /// Boton Convertir a Decimal. Instancia un numero y llama al metodo "BinarioDecimal".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            Numero ingresado;
            ingresado = new Numero();

            txtNumero2.Text = ingresado.BinarioDecimal(this.txtNumero1.Text).ToString();

            if(txtNumero2.Text == "-1")
            {
                txtNumero2.Text = "Valor invalido";
            }


        }


        /// <summary>
        /// Boton operar. Instancia dos numeros y opera con el motodo Calculadora.Operar(). Muestra el resultado por label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador;
            string resultado;

            if(this.cmbOperador.SelectedItem == null)
            {
                operador = "+";
            }
            else
            {
                operador = this.cmbOperador.SelectedItem.ToString();
            }

            Numero num1 = new Numero(this.txtNumero1.Text);
            Numero num2 = new Numero(this.txtNumero2.Text);

            resultado = Calculadora.Operar(num1, num2, operador).ToString();

            this.lblResultado.Text = resultado;
            
        }
    }
}
