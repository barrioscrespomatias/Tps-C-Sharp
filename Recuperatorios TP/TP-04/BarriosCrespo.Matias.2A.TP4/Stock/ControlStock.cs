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
    public class ControlStock<T> where T : Producto
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

        #region Propiedades 

        public List<T> Listado
        {
            get { return this.lista; }
        }

        public int CantidadEnStock
        {
            get { return this.lista.Count; }
        }

        public int Capacidad
        {
            get { return this.capacidad; }
        }


        #endregion

        #region Sobrecargas 

        /// <summary>
        /// Agrega productos a la lista mientras el stock lo permita.
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static ControlStock<T> operator +(ControlStock<T> cs, T p)
        {
            if (cs.lista.Count == 0)
            {
                cs.lista = new List<T>();
            }

            if (cs.lista.Count < cs.capacidad)
            {
                //Si el producto ya existe, agrego cantidad.
                if (cs == p)
                {
                    //Agregar la cantidad a cs[indice que es igual]
                    int indice = ControlStock<T>.ObtenerIndice(cs, p);
                    cs.lista[indice].Cantidad += p.Cantidad;
                }
                else
                {
                    //sino lo agrego a la lista
                    cs.lista.Add(p);
                }
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
        public static bool operator ==(ControlStock<T> cs, T p)
        {
            bool retorno = false;
            foreach (T aux in cs.lista)
            {
                if (aux.Equals(p))
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

        #endregion

        #region Metodos        

        /// <summary>
        /// Obtiene el índice del elemento pasado como parámetro.
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="p"></param>
        /// <returns></returns>

        private static int ObtenerIndice(ControlStock<T> cs, T p)
        {
            int retorno = -1;
            int indice = 0;
            foreach (T aux in cs.lista)
            {
                if (aux.Equals(p))
                {
                    retorno = indice;
                    break;
                }
                indice++;
            }
            return retorno;
        }
        /// <summary>
        /// Baja la cantidad de productos en stock segun la cantidad de productos que se deseen comprar.
        /// </summary>
        /// <param name="cs"></param>
        /// <param name="p"></param>
        /// <param name="cantidadCompra"></param>
        public void BajarCantidad(ControlStock<T> cs, T p, int cantidadCompra)
        {
            //Si la cantidad de productos en stock es igual o mayor a la cantidad que se 
            //desea comprar, bajo la cantidad de productos en stock teniendo en cuenta la cantidad
            //que el cliente quiere comprar.
            if (cs == p && p.Cantidad >= cantidadCompra)
            {
                p.Cantidad -= cantidadCompra;
                //Si me quedo sin productos, elimino de la lista.
                if (p.Cantidad == 0)
                {
                    cs -= p;
                }
            }
            else
                throw new CantidadInexistenteException("La cantidad de productos en stock es insuficiente");
        }
        #endregion

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
