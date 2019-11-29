using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class Paquete:IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        private string direccionEntrega;
        private EEstado estado;
        private string trackingId;        
        public DelegadoEstado InformaEstado;
        #region enumerado
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion
        
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingId = trackingID;
        }

        #region propiedades

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }

            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingId;
            }

            set
            {
                this.trackingId = value;
            }
        }

        #endregion
        
        #region sobrecarga operadores
        /// <summary>
        /// sobre carga operador "==". Dos paquetes seran iguales si tienen el mismo trackID. 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.trackingId == p2.trackingId)
            {
                retorno = true;
            }
                
            return retorno;
        }
        /// <summary>
        /// Sobrecarga != . Dos paquetes serán distintos si tienen diferente trackID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region sobrecarga metodos
        /// <summary>
        /// Sobrecarga metodo ToString, retornando metodo Paquete.MostrarDatos().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos(this);
            
        }
        #endregion

        #region metodos
        /// <summary>
        /// Muestra el paquete con su informacion.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}",((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }   
        
        /// <summary>
        /// Refleja el cambio de estado del paquete. Si el paquete es entregado, se guarda en base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {               
                while(this.estado != EEstado.Entregado)
                {                
                    Thread.Sleep(4000);
                    if(this.estado == EEstado.Ingresado)
                    {
                        this.estado = EEstado.EnViaje;
                    }
                    else if(this.estado == EEstado.EnViaje)
                    {
                        this.estado = EEstado.Entregado;
                    }
                    this.InformaEstado(this, EventArgs.Empty);
                }           

        try
        {
                PaqueteDAO.Insertar(this);        
        }
            catch(Exception e)
            {
               MessageBox.Show(e.Message);
            }
        }
        #endregion 

    }
}
