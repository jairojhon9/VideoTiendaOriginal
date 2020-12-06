using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace winformsCrud_proyecto
{
    public partial class Form1 : Form
    {
        public NpgsqlConnection conexion = new NpgsqlConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.ConnectionString =
                              "User ID=" + txtUser.Text +
                                 ";Password=" + txtPassword.Text +
                                 ";Host=" + txtHost.Text +
                                 ";Port=" + txtpuerto.Text +
                                 ";Database=" + txtBaseDatos.Text +
                                 ";Pooling=true;";
            try
            {
                conexion.Open();
                MessageBox.Show("base conectada");

            }
            catch (Exception ex )
            {
                MessageBox.Show("base de datos No conectada" + ex.Message);

            }
        }

        private void btndesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if(conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                    MessageBox.Show("conexion Cerrada");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("no es poisible desconectar por : " + ex.Message);
            }
        }
    }
}
