using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Test_Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            string ingresado = "10";
            int numero = 10;

            Numero a = new Numero();
            Console.WriteLine(a.DecimalBinario(numero));
            Console.ReadKey();

        }
    }
}
