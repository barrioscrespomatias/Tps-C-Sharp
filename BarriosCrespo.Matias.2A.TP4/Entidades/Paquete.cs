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
        private string direccionEntrega;
        private EEstado estado;
        private string trackingId;

        public delegate void DelegadoEstado(object sender, EventArgs e);

        public DelegadoEstado InformaEstado;
        

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

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
        public static bool operator==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.trackingId == p2.trackingId)
                retorno = true;
            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }


        #endregion

        #region sobrecarga metodos

        public override string ToString()
        {
            return MostrarDatos(this);
            
        }
        #endregion

        #region metodos
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}",((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        /*a. Colocar una demora de 4 segundos.
        b. Pasar al siguiente estado.
        c. Informar el estado a través de InformarEstado. EventArgs no tendrá ningún dato extra.
        d. Repetir las acciones desde el punto A hasta que el estado sea Entregado.
        e. Finalmente guardar los datos del paquete en la base de datos */

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
