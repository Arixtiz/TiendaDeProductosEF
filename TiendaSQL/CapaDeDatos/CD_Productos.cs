using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos.Models;

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
            //using(TiendaEntities2 tienda = new TiendaEntities2())
            //{
            //    tienda.InsetarProductos(nombre, descripcion, marca, precio, stock); 
            //    tienda.SaveChanges();
            //}

            //Producto producto = new Producto();
            //TiendaEntities entities = new TiendaEntities();

            //producto.Nombre = nombre;
            //producto.Descripcion = descripcion;
            //producto.Marca = marca;
            //producto.Precio = precio;
            //producto.Stock = stock;

            //entities.Producto.Add(producto);
            //entities.SaveChanges();


            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = $"exec InsetarProductos '{nombre}','{descripcion}','{marca}',{precio},{stock}";
            cmd.ExecuteNonQuery();
        }

        public void Editar (string nombre, string descripcion, string marca, double precio, int stock, int id)
        {
            //TiendaEntities tienda = new TiendaEntities();
              //  tienda.EditarProductos(nombre, descripcion, marca, precio, stock, id);
                //tienda.SaveChanges();
            
            cmd.Connection = conexion.AbrirConexion();
            cmd.CommandText = $"exec EditarProductos '{nombre}','{descripcion}','{marca}',{precio},{stock},{id}";
            cmd.ExecuteNonQuery();
        }

        public void Eliminar (int id)
        {
            //TiendaEntities tienda = new TiendaEntities();

            //    tienda.EliminarProductos(id);
            //tienda.SaveChanges();

            //cmd.Connection = conexion.AbrirConexion();
            //cmd.CommandText = $"exec EliminarProductos {id}";
            //cmd.ExecuteNonQuery();
        }
    }
}
