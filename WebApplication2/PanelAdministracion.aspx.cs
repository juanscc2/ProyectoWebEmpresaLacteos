using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.DAL;
using WebApplication2.Models;

namespace WebApplication2
{
    public partial class PanelAdministracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvUsuarios.DataSource = new UsuariosDAL().ObtenerListaProductos();
            gvUsuarios.DataBind();
        }

        protected void AgregarBtn_Click(object sender, ImageClickEventArgs e)
        {
            panelAgregarUser.Visible = true;
            panelUsuarios.Visible = false;
            labelTitulo.Text = "Agregar usuario";
            
        }

        protected void ImageButtonCancelar_Click(object sender, ImageClickEventArgs e)
        {
            panelAgregarUser.Visible = false;
            panelUsuarios.Visible = true;
        }

        protected void ImageButtonGuardar_Click(object sender, ImageClickEventArgs e)
        {
            int.TryParse(TextBoxId.Text,out int id);
            UsuariosEmpresa usuario = new UsuariosEmpresa()
            {
                PrimerApellido = TextBoxApellido.Text,
                PrimerNombre = TextBoxUsuario.Text,
                CorreoElectronico = TextBoxCorreo.Text,
                Username = TextBoxuser.Text,
                Password = TextBoxPassword.Text,
                NombreEmpresa = TextBoxEmpresa.Text,
                IdUsuario = id
                
            };
            if (id!=0) {
                new UsuariosDAL().ActualizarUsuarios(usuario);

            }
            else
            {
                new UsuariosDAL().insertarUsuarios(usuario);

            }
            gvUsuarios.DataSource = new UsuariosDAL().ObtenerListaProductos();
            gvUsuarios.DataBind(); 
            panelAgregarUser.Visible = false;
            panelUsuarios.Visible = true;

        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                filaID.Visible = true;
                panelAgregarUser.Visible = true;
                panelUsuarios.Visible = false;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvUsuarios.Rows[index];
                

                TextBoxId.Text=Server.HtmlDecode(row.Cells[1].Text.Trim());
                TextBoxUsuario.Text = Server.HtmlDecode(row.Cells[2].Text.Trim());
                TextBoxApellido.Text = Server.HtmlDecode(row.Cells[3].Text.Trim());
                TextBoxuser.Text = Server.HtmlDecode(row.Cells[4].Text.Trim());
                TextBoxPassword.Text = Server.HtmlDecode(row.Cells[5].Text.Trim());
                TextBoxCorreo.Text = Server.HtmlDecode(row.Cells[6].Text.Trim());
                TextBoxEmpresa.Text = Server.HtmlDecode(row.Cells[7].Text.Trim());
                labelTitulo.Text = "Editar usuario";
            }
        }
    }
}