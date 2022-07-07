using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        private SqlConnection conexion;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            conexion = new SqlConnection("server=localhost ; database=usuariosLacteosAntip ; integrated security = true");
            conexion.Open();
            //string cadena = "Select * from usuarios Where id_usuario = '" + textBoxUsuario.Text.Trim() + "' and password = '" + textBoxContraseña.Text.Trim() + "'";
            string cadena2 = "Select * from usuariosEmpresa where userName='" + txtUsuario.Text.Trim() + "'and password='" + txtPassword.Text.Trim() + "'";
            SqlCommand comando = new SqlCommand(cadena2, conexion);
            SqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                Response.Redirect("Catalogo.aspx");

            }
            else if (txtUsuario.Text.Equals("admin") && txtPassword.Text.Equals("admin"))
            {
                Response.Redirect("PanelAdministracion.aspx");

            }
            else

                

            conexion.Close();
        }

        protected void linkOlvideContraseña_Click(object sender, EventArgs e)
        {
            Response.Write($"<script>alert('Por favor contactese con soporte tecnico para recuperar su contraseña.')</script>");

        }
    }
    }
