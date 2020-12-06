using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Npgsql;


namespace winformsCrud_proyecto
{
    public partial class formdatosPersonales : Form
    {
        public formdatosPersonales()
        {
            InitializeComponent();
        }
        public void MostrarDAtosEnTabla()
        {
            try
            {
                dataGridView1.DataSource = MetodosBase.MostrarDAtosPersonales().Tables[0];
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al mostrar la base de datos" + e.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id_datos_personales = Convert.ToInt32(txtid.Text);
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            int telefono = Convert.ToInt32(txtTelefono.Text);
            string sexo = txtSexo.Text;
            int edad = Convert.ToInt32(numericUpDownEdad.Text);
            string Email = txtEmail.Text;
            if (nombre == "" || direccion == "" || sexo == "" || Email == "" || edad == 0 || telefono == 0)
            {
                MessageBox.Show(" Falta ingresar un dato ");
            }
            else
            {
                MetodosBase.AgregarDatosPersonales(id_datos_personales, nombre, direccion, telefono, sexo, edad, Email);
                MostrarDAtosEnTabla();
            }

        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            int id_datos_personales = Convert.ToInt32(txtid.Text);
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            int telefono = Convert.ToInt32(txtTelefono.Text);
            string sexo = txtSexo.Text;
            int edad = Convert.ToInt32(numericUpDownEdad.Text);
            string Email = txtEmail.Text;
            if (nombre == "" || direccion == "" || sexo == "" || Email == "" || edad == 0 || telefono == 0)
            {
                MessageBox.Show(" Falta ingresar un dato ");
            }
            else
            {
                MetodosBase.ActualizarDatosPersonales(id_datos_personales, nombre, direccion, telefono, sexo, edad, Email);
                MostrarDAtosEnTabla();
            }

        }
        private void FilaSeleccionada(int rowIndex)
        {
            txtDireccion.Text = dataGridView1.Rows[rowIndex].Cells["direccion"].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[rowIndex].Cells["email"].Value.ToString();
            txtid.Text = dataGridView1.Rows[rowIndex].Cells["id_datos_personales"].Value.ToString();
            txtNombre.Text = dataGridView1.Rows[rowIndex].Cells["nombre"].Value.ToString();
            txtSexo.Text = dataGridView1.Rows[rowIndex].Cells["sexo"].Value.ToString();
            txtTelefono.Text = dataGridView1.Rows[rowIndex].Cells["telefono"].Value.ToString();
        }
        private void formdatosPersonales_Load_1(object sender, EventArgs e)
        {
            MostrarDAtosEnTabla();
            //MostrarDatosComboBoxCategorias();
            //MostrarDatosComboBoxclasificacion();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                FilaSeleccionada(((DataGridView)sender).CurrentCell.RowIndex);
            }
            catch { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id_datos_personales = Convert.ToInt32(txtid.Text);
            MetodosBase.EliminarDatosPersonales(id_datos_personales);
            MostrarDAtosEnTabla();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltimer.Text = DateTime.Now.ToString();
        }

        private void lbltimer_Click(object sender, EventArgs e)
        {

        }

    private void button1_Click(object sender, EventArgs e)
    {

    }
  }
}
