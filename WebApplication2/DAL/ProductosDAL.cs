using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class ProductosDAL
    {
        public List<Producto> ObtenerListaProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["usuariosLacteosAntipConnectionString"].ConnectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand("USP_ListarProductos", conexion))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    using (IDataReader dr = command.ExecuteReader())
                    {

                        while (dr.Read())
                       {
                            productos.Add(new Producto()
                            {
                                ProductoID = Convert.ToInt32(dr["ProductoID"].ToString()),
                                NombreProducto = (dr["nombreProducto"].ToString()),
                                PrecioProducto = Convert.ToInt32(dr["precioProducto"].ToString()),
                                ImagenProducto = (byte[])dr["imagenProducto"],
                                StockProducto = Convert.ToInt32(dr["stockProducto"].ToString()),                                

                            });
                        }
                    }

                    if (conexion.State == ConnectionState.Open)
                        conexion.Close();

                }

                return productos;
            }
        }

        public Producto ObtenerProductoPorId( int idProducto)
        {
            Producto producto = null;

            using (SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["usuariosLacteosAntipConnectionString"].ConnectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand("USP_ListarProducto_PorId", conexion))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;

                    using (IDataReader dr = command.ExecuteReader())
                    {

                        if (dr.Read())
                        {
                            producto = new Producto()
                            {
                                ProductoID = Convert.ToInt32(dr["ProductoID"].ToString()),
                                NombreProducto = (dr["nombreProducto"].ToString()),
                                PrecioProducto = Convert.ToInt32(dr["precioProducto"].ToString()),
                                ImagenProducto = (byte[])dr["imagenProducto"],
                                StockProducto = Convert.ToInt32(dr["stockProducto"].ToString()),

                            };
                        }
                    }

                    if (conexion.State == ConnectionState.Open)
                        conexion.Close();

                }

                return producto;
            }
        }

    }
}