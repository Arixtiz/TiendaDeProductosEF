using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    // Capa encargada de las diferentes conversiones de entradas


    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable MostrarProductos()
        {
            DataTable dt = new DataTable();
            dt = objetoCD.Mostrar();
            return dt;
        }

        public void InsertarProducto(string nombre, string descripcion, string marca, string precio, string stock)
        {
            objetoCD.Insertar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        public void EditarProducto(string nombre, string descripcion, string marca, string precio, string stock,string id)
        {
            objetoCD.Editar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        public void EliminarProducto(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
