using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Stock
{
    /// <summary>
    /// Clase genérica.    
    /// Ha sido utilizado como clase contenedora de dos tipos diferentes de productos a vender: “Gorritas”
    //y “Antiparras”. Se implementa en el namespace STOCK en la clase ControlStock.Esta clase
    //contiene una List<T> que puede ser cargada por cualquiera de los productos vendidos.
     
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ControlStock<T>
    {
        private int capacidad;
        private List<T> lista;

       
        /// <summary>
        /// Constructor por defecto. Inicializa la capacidad en 5.
        /// </summary>
        public ControlStock()
        {
            this.capacidad = 5;
            this.lista = new List<T>();
        }

        public List<T> Listado
        {
            get { return this.lista; }
        }

        public int CantidadEnStock
        {
            get { return this.lista.Count; }            
        }

      


        /// <summary>
        /// Agrega productos a la lista mientras el stock lo permita.
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static ControlStock<T> operator +(ControlStock<T> cs, T p)
        {
            if(cs.lista.Count == 0)
            {
                cs.lista = new List<T>();
            }

            if (cs.lista.Count < cs.capacidad)
            {
                cs.lista.Add(p);
            }
            else
            {
                throw new StockMaximoException("No hay mas espacio en los estantes. Venda algo!!");
            }
            return cs;
        }
        /// <summary>
        /// Sobrecarga - entre una lista existente en ControlDeStock y un atributo T. Elimina el atributo
        /// de la lista.
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static ControlStock<T> operator -(ControlStock<T> cs, T p)
        {
            if (cs.lista.Count > 0)
            {
                cs.lista.Remove(p);
            }
            return cs;
        }
        /// <summary>
        /// Sobrecarga == entre una lista y una T.
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator == (ControlStock<T> cs, T p)
        {
            bool retorno = false;
            foreach(T aux in cs.lista)
            {
                if(aux.Equals(p))
                {
                    retorno = true;
                    break;

                }
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga distinto entre la lista y un atributo genérico.
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator !=(ControlStock<T> cs, T p)
        {
            return !(cs == p);
        }

        /// <summary>
        /// Expone los datos de la clase.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Cantidad en stock: {0}\n", this.CantidadEnStock);
            sb.AppendFormat("Listado de {0}: \n", typeof(T).Name);

            foreach (T aux in this.lista)
            {
                sb.AppendFormat(aux.ToString());
            }
            sb.AppendLine("");
            return sb.ToString();
        }


    }
}
