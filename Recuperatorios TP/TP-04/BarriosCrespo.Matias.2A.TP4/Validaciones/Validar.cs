using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace Validaciones
{
    public static class Validar
    {
        /// <summary>
        /// Valida que los caracteres ingresados sean solo numeros.
        /// </summary>
        /// <param name="cadenaNumerica"></param>
        /// <returns></returns>
        public static int ValidarSoloNumeros(string cadenaNumerica)
        {

            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(cadenaNumerica) && int.TryParse(cadenaNumerica, out int numero))
                return numero;

            else
                throw new ValidacionIncorrectaException("Uno o más campos ha sido incorrecto!");

        }
        /// <summary>
        /// Valida que los caracteres ingresados sean solo letras.
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static string ValidarSoloLetras(string cadena)
        {
            string retorno = null;
            Regex regex = new Regex("^[a-z |A-Z ]+$");
            if (regex.IsMatch(cadena))
                retorno = cadena;

            else
                throw new ValidacionIncorrectaException("Uno o más campos ha sido incorrecto!");

            return retorno;
        }
        /// <summary>
        /// Valida que los caracteres ingresados sean una fecha.
        /// </summary>
        /// <param name="cadenaFecha"></param>
        /// <returns></returns>
        public static DateTime ValidarFecha(string cadenaFecha)
        {

            DateTime aux = new DateTime();
            bool esFecha = DateTime.TryParse(cadenaFecha, out aux);


            if (aux.Year > 2017 || aux.Year < 2007)
            {
                throw new NacimientoInvalidoException("La fecha de nacimiento debe estar entre 2007 y 2017");

            }


            return aux;
        }


    }
}
