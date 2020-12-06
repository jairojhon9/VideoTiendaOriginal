using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformsCrud_proyecto
{
    class MetodosBase
    {
        public static DataSet Mostrar()
        {

            NpgsqlConnection conexion = Conexion.Conectar();

            DataSet datos = new DataSet();
            try
            {
                string Sql = "select * from peliculas; ";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(Sql, conexion);
                add.Fill(datos);
                conexion.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("error a interactuar con la base e datos" + ex.Message);
            }

            return datos;
        }
        public static DataSet MostrarDAtosPersonales()
        {

            NpgsqlConnection conexion = Conexion.Conectar();

            DataSet datos = new DataSet();
            try
            {
                string Sql = "SELECT  id_datos_personales , nombre, direccion, telefono, email, sexo, edad FROM public.datos_personales order by id_datos_personales asc ;";


                NpgsqlDataAdapter add = new NpgsqlDataAdapter(Sql, conexion);
                add.Fill(datos); 
                conexion.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("error a interactuar con la base e datos" + ex.Message);
            }

            return datos;
        }

        public static DataSet MostrarCategorias()
        {

            NpgsqlConnection conexion = Conexion.Conectar();

            DataSet datos = new DataSet();
            try
            {
                string Sql = "select * from categorias; ";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(Sql, conexion);
                add.Fill(datos);
                conexion.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("error a interactuar con la base e datos" + ex.Message);
            }

            return datos;
        }
        public static DataSet MostrarClasificacion()
        {

            NpgsqlConnection conexion = Conexion.Conectar();

            DataSet datos = new DataSet();
            try
            {
                string Sql = "select * from clasificacion; ";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(Sql, conexion);
                add.Fill(datos);
                conexion.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("error a interactuar con la base e datos" + ex.Message);
            }

            return datos;
        }
        public static DataSet Mostrardatos_pelicula()
        {

            NpgsqlConnection conexion = Conexion.Conectar();

            DataSet datos = new DataSet();
            try
            {
                string Sql = "select * from datos_pelicula(id_datos_peliculas)VALUES(id_datos_pelicula); ";
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(Sql, conexion);
                add.Fill(datos);
                conexion.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("error a interactuar con la base e datos" + ex.Message);
            }

            return datos;
        }

        public static void Agregar( int Categoria, string NombrePeli, string FormatoPeli, int Clasificion)
        {
            NpgsqlConnection conexion = Conexion.Conectar();
            string sentencia = "INSERT INTO public.datos_pelicula( id_categorias, nombre_pelicula, formato_tipo, id_clasificacion)VALUES( "+Categoria+", '"+NombrePeli+"', '"+FormatoPeli+"', "+Clasificion+");" ;

            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregado");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sucedio un error al ingresar el registro" + e.Message);
            }
        }
        public static void AgregarDatosPersonales(int id_datos_personales, string nombre, string direccion, int telefono, string sexo, int edad, string Email)
        {
            NpgsqlConnection conexion = Conexion.Conectar();
            string sentencia = "INSERT INTO public.datos_personales(id_datos_personales,nombre, direccion, telefono, email, sexo, edad)VALUES("+ id_datos_personales + ",'" + nombre + "', '" + direccion + "', " + telefono + ", '" + sexo + "', '" + edad + "', '" + Email + "'); ";

            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregado");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sucedio un error al ingresar el registro" + e.Message);
            }
        }

        public static void AgregarCategoria(string NombreCategoria)
        {
            NpgsqlConnection conexion = Conexion.Conectar();
            string sentencia = "INSERT INTO public.categorias( nombre) VALUES('" + NombreCategoria + "' ); ";
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregada");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sucedio un error al ingresar el registro" + e.Message);
            }
        }
        public static void AgregarClasificacion(string NombreClasificasion)
        {
            NpgsqlConnection conexion = Conexion.Conectar();
            string sentencia = "INSERT INTO public.clasificacion( nombre_clasificacion) VALUES('" + NombreClasificasion + "' ); ";
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Agregada");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sucedio un error al ingresar el registro" + e.Message);
            }
        }

        public static void Actualizar(  int idDatosP, int idCategorias, string NombrePeli, string FormatoPeli, int Clasificion)
        {
            NpgsqlConnection conexion = Conexion.Conectar();
            string sentencia = "UPDATE public.datos_pelicula SET id_datos_pelicula = "+idDatosP+", id_categorias =" + idCategorias + ", nombre_pelicula ='" + NombrePeli + "', formato_tipo ='" + FormatoPeli + "', id_clasificacion =" + Clasificion + "" +
                " WHERE id_categorias = " +idCategorias + "; ";

            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sucedio un error al actualizar el registro" + e.Message);
            }

        }
        public static void ActualizarDatosPersonales(int id_datos_personales, string nombre, string direccion, int telefono, string sexo, int edad, string Email)
        {
            NpgsqlConnection conexion = Conexion.Conectar();
            string sentencia = "UPDATE public.datos_personales SET id_datos_personales=" + id_datos_personales+", nombre ='"+ nombre +"', direccion ='"+ direccion +"', telefono "+ telefono +", email ='"+ Email +"', sexo ='"+ sexo +"', edad ='"+ edad +"'WHERE id_datos_personales ="+id_datos_personales+";";


            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sucedio un error al actualizar el registro" + e.Message);
            }

        }

        public static void Eliminar(int idDatosP)
        {
            NpgsqlConnection conexion = Conexion.Conectar();
            string sentencia = "DELETE FROM public.datos_pelicula WHERE id_datos_pelicula ="+idDatosP+";";
            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sucedio un error al eliminar el registro" + e.Message);
            }

        }
        public static void EliminarDatosPersonales(int id_datos_personales)
        {
            NpgsqlConnection conexion = Conexion.Conectar();
            string sentencia = "DELETE FROM public.datos_personales WHERE id_datos_personales = "+id_datos_personales+";";

            try
            {
                NpgsqlCommand comando = new NpgsqlCommand(sentencia, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado");
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sucedio un error al eliminar el registro" + e.Message);
            }

        }

    }
}