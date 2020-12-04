using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using Entidades;
using Excepciones;

namespace BaseDatos
{
    public class VincularDB
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        public VincularDB(SqlConnection cn)
        {
            this.conexion = cn;
        }

        /// <summary>
        /// Prueba la conexion con la base de datos.
        /// </summary>
        /// <returns>Retorna true en caso de ser exitosa. sino false</returns>
        public bool ProbarConexion()
        {
            bool retorno = true;
            try
            {
                this.conexion.Open();
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                if (this.conexion.State == System.Data.ConnectionState.Open)
                    this.conexion.Close();
            }
            return retorno;

        }

        /// <summary>
        /// Carga los grupos a la colonia desde la base de datos.
        /// </summary>
        /// <returns></returns>
        public Colonia ObtenerColonos(Colonia catalinas)
        {


            string sql = "SELECT * FROM colonos";

            this.comando = new SqlCommand();
            this.conexion = new SqlConnection(Properties.Settings.Default.conexionDB);

            try
            {
                this.comando.Connection = conexion;
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.CommandText = sql;

                conexion.Open();
                lector = comando.ExecuteReader();


                Colono c;
                int id;
                string nombre;
                string apellido;
                int dni;
                DateTime fechaNacimiento;
                string periodo;
                double saldoCuota;
                double saldoProductos;

                while (lector.Read())
                {
                    id = lector.GetInt32(0);
                    nombre = lector.GetString(1);
                    apellido = lector.GetString(2);
                    dni = lector.GetInt32(3);
                    fechaNacimiento = lector.GetDateTime(4);
                    periodo = lector.GetString(5);
                    saldoCuota = lector.GetDouble(6);
                    saldoProductos = lector.GetDouble(7);

                    c = new Colono(nombre, apellido, fechaNacimiento, dni, (EPeriodoInscripcion)Enum.Parse(typeof(EPeriodoInscripcion), periodo), saldoCuota, saldoProductos, id);
                    if (catalinas != c)
                        catalinas += c;
                }

            }
            catch (Exception)
            {
                throw new ErrorDeConexionException("Error en la conexion a la base de datos");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return catalinas;
        }
        /// <summary>
        /// Agrega un colono a la base de datos.
        /// </summary>
        /// <param name="colono"></param>
        /// <returns></returns>
        public bool AgregarColono(Colono colono)
        {
            bool retorno = false;
            string sql = "INSERT INTO colonos(nombre, apellido, dni, fechaNacimiento, periodo, saldoCuota,saldoProductos) ";
            sql += "VALUES (@nombre,@apellido,@dni,@fechaNacimiento,@periodo,@saldoCuota,@saldoProductos)";
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Connection = conexion;

                this.comando.Parameters.AddWithValue("@nombre", colono.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", colono.Apellido);
                this.comando.Parameters.AddWithValue("@dni", colono.Dni);
                this.comando.Parameters.AddWithValue("@fechaNacimiento", colono.FechaNacimiento);
                this.comando.Parameters.AddWithValue("@periodo", colono.Periodo);
                this.comando.Parameters.AddWithValue("@saldoCuota", colono.SaldoCuota);
                this.comando.Parameters.AddWithValue("@saldoProductos", colono.SaldoProductos);


                this.comando.CommandText = sql;
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                retorno = false;
                throw e;

            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return retorno;
        }
        /// <summary>
        /// Modifica un colono de la base de datos.
        /// </summary>
        /// <param name="colono"></param>
        /// <returns></returns>
        public bool ModificarColono(Colono colono)
        {
            bool retorno = false;
            string sql = "UPDATE colonos SET nombre=@nombre, apellido=@apellido," +
                " dni=@dni, fechaNacimiento=@fechaNacimiento, periodo=@periodo, saldoCuota=@saldoCuota, saldoProductos=@saldoProductos WHERE id=@id";


            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Connection = conexion;

                this.comando.Parameters.AddWithValue("@id", colono.Id);
                this.comando.Parameters.AddWithValue("@nombre", colono.Nombre);
                this.comando.Parameters.AddWithValue("@apellido", colono.Apellido);
                this.comando.Parameters.AddWithValue("@dni", colono.Dni);
                this.comando.Parameters.AddWithValue("@fechaNacimiento", colono.FechaNacimiento);
                this.comando.Parameters.AddWithValue("@periodo", colono.Periodo);
                this.comando.Parameters.AddWithValue("@saldoCuota", colono.SaldoCuota);
                this.comando.Parameters.AddWithValue("@saldoProductos", colono.SaldoProductos);


                this.comando.CommandText = sql;
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    retorno = true;
                    Console.WriteLine("Se ha actualizado la base de datos");
                }
            }
            catch (Exception e)
            {
                retorno = false;
                throw e;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }

            return retorno;
        }
        /// <summary>
        /// Elimina un colono de la base de datos según su DNI.
        /// </summary>
        /// <param name="colono"></param>
        /// <returns></returns>
        public bool EliminarColono(Colono colono)
        {
            bool retorno = false;
            string sql = "DELETE FROM colonos WHERE dni=@dni";
            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = System.Data.CommandType.Text;
                this.comando.Connection = conexion;

                this.comando.Parameters.AddWithValue("@dni", colono.Dni);

                this.comando.CommandText = sql;
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    retorno = true;
                    Console.WriteLine("Se ha eliminado de la base de datos");
                }
            }
            catch (Exception e)
            {
                retorno = false;
                throw e;

            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            return retorno;
        }


    }
}
