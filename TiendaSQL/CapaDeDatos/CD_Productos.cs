using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos
{
    public class CD_Productos
    {
        private ConexionSQL conexion = new ConexionSQL();

        SqlDataReader leer;
        DataTable dtProductos=new DataTable();
        SqlCommand cmd = new SqlCommand();


        public DataTable Mostrar()
        { 
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = "MostrarProductos";
            leer = cmd.ExecuteReader();
            dtProductos.Load(leer);
            conexion.CerrarConexion();
            return dtProductos;
        }

        public void Insertar(string nombre, string descripcion, string marca, double precio, int stock)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = $"exec InsetarProductos '{nombre}','{descripcion}','{marca}',{precio},{stock}";
            cmd.ExecuteNonQuery();
        }

        public void Editar (string nombre, string descripcion, string marca, double precio, int stock, int id)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = $"exec EditarProductos '{nombre}','{descripcion}','{marca}',{precio},{stock},{id}";
            cmd.ExecuteNonQuery();
        }

        public void Eliminar (int id)
        {
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = $"exec EliminarProductos {id}";
            cmd.ExecuteNonQuery();
        }
    }
}
