using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace winformsCrud_proyecto
{
    public partial class frmDatosPeli : Form
    {
        public frmDatosPeli()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }

        private void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            MostrarDAtosEnTabla();
        }
       public void MostrarDAtosEnTabla()
        {
            try
            {
                dataGridView1.DataSource = MetodosBase.Mostrar().Tables[0];
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al mostrar la base de datos" + e.Message);
            }
        }
        public void Limpiar()
        {

            txtdatospelicula.Text = "";
            txtformato.Text = "";
            txtNombrePelicula.Text = "";
            cmbxCategorias.Text = "seleccionar";
            cmbxClasificasion.Text = "seleccionar";

        }

        private void btnNUevo_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

           
            int categoria = Convert.ToInt32(cmbxCategorias.SelectedValue);
            string NombrePeli = txtNombrePelicula.Text;
            string FormatoPeli = txtformato.Text;
            int Clasificion = Convert.ToInt32(cmbxClasificasion.SelectedValue);
            MetodosBase.Agregar( categoria, NombrePeli, FormatoPeli, Clasificion);
            MostrarDAtosEnTabla();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {


            int idDatosP = Convert.ToInt32(txtdatospelicula.Text);
            int idCategorias = Convert.ToInt32(cmbxCategorias.SelectedValue);
            string NombrePeli = txtNombrePelicula.Text;
            string FormatoPeli = txtformato.Text;
            int  Clasificion = Convert.ToInt32(cmbxClasificasion.SelectedValue);
            MetodosBase.Actualizar( idDatosP, idCategorias, NombrePeli, FormatoPeli, Clasificion);
            MostrarDAtosEnTabla();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idDatosP = Convert.ToInt32(txtdatospelicula.Text);     
            MetodosBase.Eliminar(idDatosP);
            MostrarDAtosEnTabla();
        }

        private void btndesconectar_Click(object sender, EventArgs e)
        {
            Conexion.Desconectar();

        }

        private void MostrarDatosComboBoxCategorias()
        {
            try
            {
                DataTable dataTableCategorias = MetodosBase.MostrarCategorias().Tables[0];
                cmbxCategorias.DataSource = dataTableCategorias;
                cmbxCategorias.ValueMember="id_categorias";
                cmbxCategorias.DisplayMember="nombre";
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al mostrar la base de datos" + e.Message);
            }
        }
        private void MostrarDatosComboBoxclasificacion()
        {
            try
            {
                DataTable dataTableClasificacion = MetodosBase.MostrarClasificacion().Tables[0];
                cmbxClasificasion.DataSource = dataTableClasificacion;
                cmbxClasificasion.ValueMember = "id_clasificacion";
                cmbxClasificasion.DisplayMember = "nombre_clasificacion";
            }
            catch (Exception e)
            {

                MessageBox.Show("Error al mostrar la base de datos" + e.Message);
            }
        }

      

        private void FilaSeleccionada(int rowIndex)
        {
            txtdatospelicula.Text = dataGridView1.Rows[rowIndex].Cells["id_datos_pelicula"].Value.ToString();
            txtNombrePelicula.Text = dataGridView1.Rows[rowIndex].Cells["nombre_pelicula"].Value.ToString();
             cmbxCategorias.Text = dataGridView1.Rows[rowIndex].Cells["categoria"].Value.ToString();
             txtformato.Text = dataGridView1.Rows[rowIndex].Cells["formato_tipo"].Value.ToString();
             cmbxClasificasion.Text = dataGridView1.Rows[rowIndex].Cells["clasificacion"].Value.ToString();
            //DataTable dataTabledatospelicula = MetodosBase.Mostrardatos_pelicula().Tables[0];
            //string query = "SELECT * FROM datos_pelicula WHERE id = id_datos_pelicula";

                       //txtVName.Text = dataGridView1.Rows[rowIndex].Cells["name"].Value.ToString();

            //DataGridViewRow fila = dataGridView1.CurrentRow;


            //txtNombrePelicula.Text = Convert.ToString(fila.Cells[2].Value);
            //

        }
        private void Form3_Load(object sender, EventArgs e)
        {
        
            MostrarDAtosEnTabla();
            MostrarDatosComboBoxCategorias();
            MostrarDatosComboBoxclasificacion();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                FilaSeleccionada(((DataGridView)sender).CurrentCell.RowIndex);
            }
            catch { }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            string categoriaNueva;

            categoriaNueva = Interaction.InputBox("Nueva Categoria", "Ingresa el nombre de la nueva categoria");

            MetodosBase.AgregarCategoria(categoriaNueva);
            MostrarDatosComboBoxCategorias();           
        }

        private void btnClasificacion_Click(object sender, EventArgs e)
        {
            string clasificacionNueva;

            clasificacionNueva = Interaction.InputBox("Nueva Clasificacion", "Ingresa el nombre de la nueva clasificacion");

            MetodosBase.AgregarClasificacion(clasificacionNueva);
            MostrarDatosComboBoxCategorias();
        }
    }
}
