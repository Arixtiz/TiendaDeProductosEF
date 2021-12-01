using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaDePresentacion
{

    // NOTA: al ser la capa de presentacion, no se hacen ningun tipo de conversion en las entradas
    // para no interferir con el funcionamiento de las demas capas.

    public partial class Form1 : Form
    {
        // Instancion de objetos necesarios para el funcionamiento
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Se verifica que se este posicionaddo en una fila para sacar el ID de la misma y
            // proceder con la eliminacion 

            if (dgvProductos.SelectedRows.Count > 0)
            {
                idProducto = dgvProductos.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProducto(idProducto);
                MessageBox.Show("El producto fue eliminado");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Selecciones una fila");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Se valida que se encuentre sobre una fila para sacar su Id y
            // se procede a mostrar la informacion actual para actualizarla

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            // Si el editar == false, se procede con la inserciion de un nuevo elemento a la BD
            // Si es true, se procede con la edicion de elemento de la BD

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
            if (editar == true)
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

        private void Limpieza()
        {
            txtNombre.Clear();
            txtMarca.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

        }

        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dgvProductos.DataSource = objeto.MostrarProductos();
        }
    }

}
