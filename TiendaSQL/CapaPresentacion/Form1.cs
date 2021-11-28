using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;

namespace CapaPresentacion
{

    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = "";
        private bool editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dgvProductos.DataSource = objeto.MostrarProductos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editar == false) 
            { 
                try
                {

                    objetoCN.InsertarProducto(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Insecion correcta");
                    MostrarProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo insertar debido a " + ex);
                }
            }
            if(editar == true)
            {
                try
                {
                    objetoCN.EditarProducto(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Ediccion correcta");
                    MostrarProductos();
                    Limpieza();
                    editar = false;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show($"No se pudo editar debido a " + ex);
                }
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                txtMarca.Text = dgvProductos.CurrentRow.Cells["Marca"].Value.ToString();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dgvProductos.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecciones una fila a editar");
            }
        }

        private void Limpieza()
        {
            txtNombre.Clear();
            txtMarca.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvProductos.SelectedRows.Count > 0)
            {
                idProducto= dgvProductos.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProducto(idProducto);
                MessageBox.Show("El producto fue eliminado");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Selecciones una fila");
            }

        }
    }
}