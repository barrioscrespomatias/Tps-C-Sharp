using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BarriosCrespo.Matias_TPS
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza los calculos en base a los numeros y operador ingresados por el usuario.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>El valor de la operacion. Sino puede realizarla -1.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = -1;
        
            if (operador.Length == 1)
            {
                string operadorValidado = Calculadora.ValidarOperador(operador[0]);
                switch (operadorValidado)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;

                    case "-":
                        resultado = num1 - num2;
                        break;

                    case "*":
                        resultado = num1 * num2;
                        break;

                    case "/":
                        resultado = num1 / num2;
                        break;
                }
            }
            else
                resultado = num1+num2;

            return resultado;
        }

        /// <summary>
        /// Valida el operador ingreado por el usuario.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(char operador)
        {
            string retorno = "+";
            switch (operador)
            {
                case '-':
                    retorno = "-";
                    break;

                case '/':
                    retorno = "/";
                    break;

                case '*':
                    retorno = "*";
                    break;

                default:
                    retorno = "+";
                    break;                                  
            }
            return retorno;
        }
    }
}
