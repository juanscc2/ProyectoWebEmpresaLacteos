using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Serializable]

    public class Producto
    {
        public int ProductoID { get; set; }

        public string NombreProducto { get; set; }

        public byte[] ImagenProducto { get; set; }

        public int PrecioProducto { get; set; }
        public int StockProducto { get; set; }
        public int CantidadSeleccionada { get; set; }

    }
}