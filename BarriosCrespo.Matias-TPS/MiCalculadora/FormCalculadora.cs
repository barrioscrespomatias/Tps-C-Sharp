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

        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero ingresado;
            ingresado = new Numero();

            
           txtNumero2.Text= ingresado.DecimalBinario(this.txtNumero1.Text);
            //this.txtNumero2
            
        }

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

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador;
            operador = this.cmbOperador.SelectedItem.ToString();

            string num1;
            string num2;

            num1 = this.txtNumero1.Text;
            num2 = this.txtNumero2.Text;

            string resultado;



            // NO PUEDO TOMAR EL TXT.Numero1 y numero2.
            resultado = Calculadora.Operar((Numero)num1,(Numero)num2,operador).ToString();
            

            
        }
    }
}
