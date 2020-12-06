using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winformsCrud_proyecto
{
    class Conexion
    {
        private static NpgsqlConnection conexion = new NpgsqlConnection("Server=localhost;Port=5434; User Id=postgres; Password=PostekDB;Database=tienda_alquiler");
        public static NpgsqlConnection Conectar()
        {
            try
            {
                conexion.Open();
               // MessageBox.Show("conectada");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            
            }
            return conexion;
        }
        public static void Desconectar()
        {
            try
            {
                if( conexion.State== System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("Coneccion cerrada");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(" No sucedio la conexion" + e.Message);
            }
        }
    }
}
