using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;


namespace Entidades
{
    public class Colonia : IComprar
    {
        protected double saldoActual;
        protected string nombre;
        protected List<Grupo> listadoDeGrupos;
        protected ControlStock<Producto> stockProductos;
        protected string pagos;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Colonia()
        {
            this.listadoDeGrupos = new List<Grupo>();
            this.stockProductos = new ControlStock<Producto>();
        }

        /// <summary>
        /// Constructor 3 parámetros
        /// </summary>
        /// <param name="nombre"></param>
        public Colonia(string nombre) : this()
        {
            this.nombre = nombre;
        }

        #region Propiedades


        public ControlStock<Producto> StockProductos
        {
            get { return this.stockProductos; }
            set { this.stockProductos = value; }
        }

        public List<Grupo> ListaDeGrupos
        {
            get { return this.listadoDeGrupos; }
            set { this.listadoDeGrupos = value; }
        }

        public double SaldoActual
        {
            get { return this.saldoActual; }
            set { this.saldoActual = value; }
        }

        public string Pagos
        {
            get { return this.pagos; }
            set { this.pagos = value; }
        }


        public ControlStock<Producto> ProductosEnVenta
        {
            get { return this.stockProductos; }
            set { this.stockProductos = value; }
        }
        #endregion

        #region sobrecargas == + -
        /// <summary>
        /// Sobrecarga  == entre Colonia y alumno(colono). 
        /// </summary>
        /// <param name="ca"></param>
        /// <param name="co"></param>
        /// <returns>Si el colono está en la colonia, devuelve true.</returns>
        public static bool operator ==(Colonia ca, Colono co)
        {
            bool retorno = false;
            foreach (Grupo aux in ca.listadoDeGrupos)
            {
                if (aux == co)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga  != entre Colonia y alumno(colono). 
        /// </summary>
        /// <param name="ca"></param>
        /// <param name="co"></param>
        /// <returns>Si el colono no está en la colonia, devuelve true.</returns>
        public static bool operator !=(Colonia ca, Colono co)
        {
            return !(ca == co);
        }

        /// <summary>
        /// Igualdad entre Colonia y grupo. Inspecciona si el grupo se encuentra en la colonia (segun color)
        /// </summary>
        /// <param name="co"></param>
        /// <param name="g1"></param>
        /// <returns>Retorna true si el grupo ya se encuentra en la colonia.</returns>
        public static bool operator ==(Colonia co, Grupo g1)
        {
            bool retorno = false;
            foreach (Grupo aux in co.listadoDeGrupos)
            {
                if (aux == g1)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Distinto entre Colonia y grupo. Inspecciona si el grupo no se encuentra en la colonia (segun color)
        /// </summary>
        /// <param name="co"></param>
        /// <param name="g1"></param>
        /// <returns>Retorna true si el grupo no se encuentra en la colonia.</returns>
        public static bool operator !=(Colonia co, Grupo g1)
        {
            return !(co == g1);
        }
        /// <summary>
        /// Sobrecarga + entre Colonia y grupo. Agrega el grupo a la colonia
        /// </summary>
        /// <param name="co"></param>
        /// <param name="g1"></param>
        /// <returns>Si pudo agregar retorna la colonia con el nuevo grupo.</returns>
        public static Colonia operator +(Colonia co, Grupo g1)
        {
            int contadorGrupos = 0;

            foreach (Grupo aux in co.listadoDeGrupos)
            {
                if (aux == g1)
                {
                    contadorGrupos++;
                }
            }

            if (contadorGrupos == 0)
                co.listadoDeGrupos.Add(g1);

            return co;

        }
        /// <summary>
        /// Sobrecarga - entre Colonia y grupo. Elimina el grupo de la colonia
        /// </summary>
        /// <param name="co"></param>
        /// <param name="g1"></param>
        /// <returns>Si pudo eliminar retorna la colonia sin el grupo.</returns>
        public static Colonia operator -(Colonia co, Grupo g1)
        {
            foreach (Grupo aux in co.listadoDeGrupos)
            {
                if (aux == g1)
                {
                    co.listadoDeGrupos.Remove(g1);
                    break;
                }
            }
            return co;
        }
        /// <summary>
        /// Agrega colonos a la colonia.
        /// </summary>
        /// <param name="colonia"></param>
        /// <param name="co"></param>
        /// <returns></returns>
        //La colonia debe ser la encargada de agregar chicos y asignarle un grupo.
        public static Colonia operator +(Colonia colonia, Colono co)
        {
            Random numeroColor = new Random();
            int indice = 0;
            if (colonia != co)
            {
                //Si no hay grupos, se crea uno y agrega al colono.       
                if (colonia.listadoDeGrupos.Count == 0)
                {
                    Grupo nuevoGrupo = new Grupo(10, Colonia.GeneradorColores(), co.EdadGrupo);
                    nuevoGrupo += co;
                    colonia.listadoDeGrupos.Add(nuevoGrupo);
                }
                else
                {
                    foreach (Grupo aux in colonia.listadoDeGrupos)
                    {
                        //Si el grupo existente y es de la edad del colono lo agrega
                        //si la capacidad del grupo no ha sido pasada.
                        if (Colonia.RecorrerGruposEdad(colonia, co.EdadGrupo, out indice))
                        {
                            if (aux.ListadoColonos.Count < aux.Capacidad)
                            {
                                colonia.listadoDeGrupos[indice].ListadoColonos.Add(co);
                                //aux.ListadoColonos.Add(co);
                                break;
                            }

                        }
                        else
                        {
                            //Si no existe la edad del grupo, sea crea y agrega al colono.
                            Random otroRandom = new Random();
                            Grupo otroGrupo = new Grupo(10, Colonia.GeneradorColores(), co.EdadGrupo);
                            otroGrupo += co;
                            colonia.listadoDeGrupos.Add(otroGrupo);
                            break;
                        }

                    }
                }
            }

            return colonia;

        }
        /// <summary>
        /// Elimina un colono de la colonia.
        /// </summary>
        /// <param name="colonia"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Colonia operator -(Colonia colonia, Colono c)
        {
            foreach (Grupo aux in colonia.ListaDeGrupos)
            {
                foreach (Colono colono in aux.ListadoColonos)
                {
                    if (colonia == c)
                    {
                        aux.ListadoColonos.Remove(c);

                        break;

                    }

                }
            }

            return colonia;
        }
        /// <summary>
        /// Sobrecarga igualdad entre colonia y dni. Si alguno de los colonos tiene el dni
        /// pasado por parámetro, retorna true.
        /// </summary>
        /// <param name="colonia"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static bool operator ==(Colonia colonia, int dni)
        {
            bool retorno = false;
            foreach (Grupo grupo in colonia.ListaDeGrupos)
            {
                foreach (Colono colono in grupo.ListadoColonos)
                {
                    if (colono.Dni == dni)
                    {
                        retorno = true;
                        break;
                    }
                }
            }
            return retorno;
        }
        /// <summary>
        /// Sobrecarga != entre colonia y dni.
        /// </summary>
        /// <param name="colonia"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        public static bool operator !=(Colonia colonia, int dni)
        {
            return !(colonia == dni);
        }

        #endregion

        #region metodos adicionales

        /// <summary>
        /// Recorre los grupos de la colonia buscando la edad pasada por parámetro.        
        /// </summary>
        /// <param name="ca"></param>
        /// <param name="edadDelGrupo"></param>
        /// <param name="indice"></param>
        /// <returns>Devuelve true si existe algun grupo de la colonia coincide con la edad del parámetro </returns>
        private static bool RecorrerGruposEdad(Colonia ca, EEdad edadDelGrupo, out int indice)
        {
            bool retorno = false;
            indice = default;
            int contador = 0;
            foreach (Grupo aux in ca.listadoDeGrupos)
            {
                if (aux.EdadDelGrupo == edadDelGrupo)
                {
                    retorno = true;
                    break;
                }
                else
                    contador++;
            }

            indice = contador;
            return retorno;
        }
        /// <summary>
        /// Genera colores alteatorios
        /// </summary>
        /// <returns></returns>
        private static ConsoleColor GeneradorColores()
        {
            Random rd = new Random();
            return (ConsoleColor)rd.Next(0, 12);
        }
        /// <summary>
        /// Efectua una venta. Modifica el stock del producto, el saldo a favor de la colonia,
        /// el saldo deudor al colono y agrega el producto a su lista de comprados.
        /// </summary>
        /// <param name="colonia"></param>
        /// <param name="p1"></param>
        /// <param name="c1"></param>
        /// <param name="cantidad"></param>
        public void RealizaVenta(Colonia colonia, Producto producto, Colono colono, int cantidadComprada)
        {
            if (colonia.stockProductos == producto)
            {
                //colono.Saldo += producto.Precio * cantidadComprada;
                colono.SaldoProductos += producto.Precio * cantidadComprada;
                for (int i = 0; i < cantidadComprada; i++)
                {
                    colono.ListaProductosComprados.Add(producto);
                }
                //bajar stock
                this.stockProductos.BajarCantidad(stockProductos, producto, cantidadComprada);
            }
            else
            {
                Console.WriteLine("No se pudo realizar venta");
            }
        }

        /// <summary>
        /// Aumenta el stock según la cantidad pasada por parámetro.
        /// </summary>
        /// <param name="colonia"></param>
        /// <param name="p1"></param>
        /// <param name="cantidad"></param>
        public void AumentarStock(Colonia colonia, Producto p1)
        {
            try
            {
                colonia.stockProductos += p1;
            }
            catch (StockMaximoException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Busca si un entero coincide con el DNI de un colono.
        /// </summary>
        /// <param name="catalinas"></param>
        /// <param name="dni"></param>
        /// <returns></returns>
        public Colono ObtenerDatos(Colonia catalinas, int dni)
        {
            Colono auxiliar = new Colono();

            foreach (Grupo grupo in catalinas.listadoDeGrupos)
            {
                foreach (Colono colono in grupo.ListadoColonos)
                {
                    if (colono.Dni == dni)
                    {
                        auxiliar = colono;
                        break;
                    }

                }
            }
            return auxiliar;
        }

        /// <summary>
        /// Guarda en un archivo de texto el importe que el colono ha saldado.
        /// </summary>
        /// <param name="catalinas"></param>
        /// <returns></returns>
        public static bool GuardarImporte(Colonia catalinas)
        {
            bool retorno = false;
            string rutaDeGuardado = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "saldo-colonia.txt";
            Encoding miCodificacion = Encoding.UTF8;
            try
            {
                using (StreamWriter sw = new StreamWriter(rutaDeGuardado, true, miCodificacion))
                {
                    sw.WriteLine(catalinas.SaldoActual);
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retorno;
        }
        /// <summary>
        /// Guarda el pago realizado con su descripción.
        /// </summary>
        /// <param name="colono"></param>
        /// <returns></returns>
        public static bool GuardarPagos(Colono colono)
        {

            bool retorno = false;
            string rutaDeGuardado = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "pagos-colonia.txt";
            Encoding miCodificacion = Encoding.UTF8;
            try
            {
                using (StreamWriter sw = new StreamWriter(rutaDeGuardado, true, miCodificacion))
                {
                    if (colono.SaldoCuota > 0)
                        sw.WriteLine(DateTime.Now.ToShortDateString() + " " + colono.Nombre + " " + colono.Apellido + " DNI: " + colono.Dni + " abonó su cuota: $" + colono.SaldoCuota + ".-");
                    if (colono.SaldoProductos > 0)
                        sw.WriteLine(DateTime.Now.ToShortDateString() + " " + colono.Nombre + " " + colono.Apellido + " DNI: " + colono.Dni + " abonó productos: $" + colono.SaldoProductos + ".-");
                    retorno = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return retorno;
        }
        /// <summary>
        /// Obtiene el saldo a favor de la colonia desde un archivo que ha sido generado.
        /// </summary>
        /// <returns></returns>
        public static double ObtenerSaldo()
        {
            double importe = 0;
            try
            {
                string rutaDeLectura = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "saldo-colonia.txt";
                StreamReader sw = new StreamReader(rutaDeLectura);
                while (sw.EndOfStream == false)
                {
                    importe = double.Parse(sw.ReadLine());
                }
                sw.Close();
            }
            catch (Exception)
            {

            }
            return importe;

        }
        /// <summary>
        /// Obtiene la descripción de los pagos realizados.
        /// </summary>
        /// <returns></returns>
        public static string ObtenerPagos()
        {
            string cuotasPagas = "";
            try
            {
                string rutaDeLectura = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "pagos-colonia.txt";
                StreamReader sw = new StreamReader(rutaDeLectura);
                cuotasPagas = sw.ReadToEnd();
                sw.Close();
            }
            catch (Exception)
            {

            }

            return cuotasPagas;

        }

        /// <summary>
        /// Método manejador del evento.
        /// Analiza e informa la cantidad de productos en stock.
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public string AnalizaStock(Producto producto)
        {
            StringBuilder sb = new StringBuilder();
            if (producto.Cantidad > 0 && producto.Cantidad != 1)
                sb.AppendFormat("Quedan {0} {1} color {2}", producto.Cantidad, producto.GetType().Name, (EColores)producto.Color);
            if (producto.Cantidad == 1)
                sb.AppendFormat("Queda un {0} {1}", producto.GetType().Name, (EColores)producto.Color);
            else if (producto.Cantidad == 0)
                sb.AppendFormat("No hay más {0} {1} de ${2}", producto.GetType().Name, (EColores)producto.Color, producto.precio);
            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// Muestra la colonia con toda su informacion.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Colonia: {0} 1.0\n", this.nombre);
            sb.AppendFormat("Saldo actual: ${0}\n", this.saldoActual);

            foreach (Grupo aux in this.listadoDeGrupos)
            {
                sb.AppendFormat(aux.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Ruta de serializado y deserializado.
        /// </summary>
        public string Path
        {
            get
            {
                string rutaDeGuardado = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "Catalinas.xml";
                return rutaDeGuardado;
            }

        }

        /// <summary>
        /// Serializado XML
        /// </summary>
        /// <returns></returns>
        public bool Serializar()
        {
            bool retorno = false;
            Encoding miCodificacion = Encoding.UTF8;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(this.Path, miCodificacion))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Colonia));
                    ser.Serialize(writer, this);
                    retorno = true;
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return retorno;
        }

        public Colonia Deserealizar(out Colonia catalinas)
        {
            Encoding miCodificacion = Encoding.UTF8;
            catalinas = null;
            try
            {
                using (XmlTextReader lector = new XmlTextReader(this.Path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Colonia));
                    catalinas = ((Colonia)ser.Deserialize(lector));
                    lector.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return catalinas;
        }


    }
}
