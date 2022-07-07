using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2
{
    public partial class Catalogo : System.Web.UI.Page
    {
        const string LISTADO_CARRITO_COMPRA = "ListadoDeProductosCarritoCompra";

        public List<Producto> ListaCarritoCompra
        {
            get
            {
                // check if not exist to make new (normally before the post back)
                // and at the same time check that you did not use the same viewstate for other object
                if (!(ViewState[LISTADO_CARRITO_COMPRA] is List<Producto>))
                {
                    // need to fix the memory and added to viewstate
                    ViewState[LISTADO_CARRITO_COMPRA] = new List<Producto>();
                }

                return (List<Producto>)ViewState[LISTADO_CARRITO_COMPRA];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                gvProductos.DataSource = new ProductosDAL().ObtenerListaProductos();
                gvProductos.DataBind();
            }
            

        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarProducto")
            {
                //Obtiene el indice de la fila donde se hace clic en el boton seleccionar
                int index = Convert.ToInt32(e.CommandArgument);
                //Obtiene el valor del id que se especifica en la propiedad datakeynames del gridview
                int.TryParse(gvProductos.DataKeys[index]["ProductoID"].ToString(), out int idProducto);

                //Valida si ya lo agrego al listado de carrito de compra
                if (ListaCarritoCompra.Any(x => x.ProductoID == idProducto))
                {
                    Response.Write($"<script>alert('Usted ya adiciono el producto {lblNombreProducto.Text} al carrito')</script>");
                    return;
                }

                //Obtiene el detalle del producto de la base de datos y asigna al panel del detalle cada valor
                Producto productoSeleccionado = new ProductosDAL().ObtenerProductoPorId(idProducto);
                lblNombreProducto.Text = productoSeleccionado.NombreProducto;
                lblStock.Text = productoSeleccionado.StockProducto.ToString();
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])productoSeleccionado.ImagenProducto);
                imagenProducto.ImageUrl = imageUrl;
                lblIdProducto.Text = idProducto.ToString();
                lblPrecio.Text = productoSeleccionado.PrecioProducto.ToString();
                txtCantidad.Focus();
                pnDetalleProducto.Visible = true;

            }
        }

        protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Producto dr = (Producto)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr.ImagenProducto);
                (e.Row.FindControl("ImagenProducto") as Image).ImageUrl = imageUrl;
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                Response.Write($"<script>alert('Por favor ingrese la cantidad del producto')</script>");
                return;
            }

            int.TryParse(txtCantidad.Text, out int cantidadIngresada);

            if (cantidadIngresada <= 0)
            {
                Response.Write($"<script>alert('Debe ingresar un cantidad valida para el producto {lblNombreProducto.Text}. Recuerde que no puede agregar el valor 0 como cantidad')</script>");
                return;
            }


            if (cantidadIngresada > Convert.ToInt32(lblStock.Text))
            {
                Response.Write($"<script>alert('Solo puede agregar hasta {lblStock.Text} unidades del producto {lblNombreProducto.Text}.')</script>");
                return;
            }

            ListaCarritoCompra.Add(new Producto()
            {
                ProductoID = Convert.ToInt32(lblIdProducto.Text),
                CantidadSeleccionada = Convert.ToInt32(lblIdProducto.Text),
                NombreProducto = lblNombreProducto.Text,
                PrecioProducto = Convert.ToInt32(lblPrecio.Text)
            });

            pnDetalleProducto.Visible = false;            
            gvCarritoCompra.DataSource = ListaCarritoCompra;
            gvCarritoCompra.DataBind();
            pnItemsCarritoCompra.Visible = true;
            Response.Write($"<script>alert('Se adiciono el producto {lblNombreProducto.Text}. al carrito de compra')</script>");


        }

        private byte[] GenerarArchivoPlano()
        {

            byte[] archivo = null;
            using (var ms = new MemoryStream())
            {
                using (TextWriter tw = new StreamWriter(ms))

                {
                    tw.WriteLine("Producto|Precio|CantidadOrdenada");
                    foreach (var producto in ListaCarritoCompra)
                    {
                        tw.WriteLine($"{producto.NombreProducto}|{producto.PrecioProducto}|{producto.CantidadSeleccionada}");
                    }
                    tw.Flush();
                    ms.Position = 0;
                    archivo = ms.ToArray();
                }

            }

            return archivo;

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {


            string fileName = "Comprobante.txt";            
            Response.Clear();
            MemoryStream ms = new MemoryStream(GenerarArchivoPlano());
            Response.ContentType = "application/txt";
            Response.Headers.Add("content-disposition", "attachment;filename=" + fileName);
            Response.Buffer = true;
            ms.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }

        protected void ButtonMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }
    }

}