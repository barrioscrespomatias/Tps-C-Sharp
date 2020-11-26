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
  

        static Validar()
        {

        }

        public static int ValidarSoloNumeros(string cadenaNumerica)
        {

            Regex regex = new Regex("^[0-9]+$");
            if (regex.IsMatch(cadenaNumerica) && int.TryParse(cadenaNumerica, out int numero))
                return numero;

            else
                throw new ValidacionIncorrectaException("Uno o más campos ha sido incorrecto!");

        }

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

        public static DateTime ValidarFecha(string cadenaFecha)
        {
            DateTime aux = new DateTime();            
            bool esFecha = DateTime.TryParse(cadenaFecha, out aux);
            return aux;
        }


    }
}
