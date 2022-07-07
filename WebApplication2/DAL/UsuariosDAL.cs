using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class UsuariosDAL
    {
        public List<UsuariosEmpresa> ObtenerListaProductos()
        {
            List<UsuariosEmpresa> usuariosRegistrados = new List<UsuariosEmpresa>();
            using (SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["usuariosLacteosAntipConnectionString"].ConnectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand("USP_ListarUsuarios", conexion))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    using (IDataReader dr = command.ExecuteReader())
                    {

                        while (dr.Read())
                        {


                            usuariosRegistrados.Add(new UsuariosEmpresa()
                            {
                                IdUsuario = Convert.ToInt32(dr["idUsuario"].ToString()),
                                PrimerApellido = (dr["primerApellido"].ToString()),
                                PrimerNombre = (dr["primerNombre"].ToString()),
                                CorreoElectronico = (dr["correoElectronico"].ToString())
                                ,
                                NombreEmpresa = (dr["nombreEmpresa"].ToString()),
                                Username = (dr["username"].ToString()),
                                Password = (dr["password"].ToString()),





                            });

                        }



                    }

                    if (conexion.State == ConnectionState.Open)
                        conexion.Close();


                }

                return usuariosRegistrados;


            }
        }
        public void insertarUsuarios(UsuariosEmpresa usuario)
        {
            using (SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["usuariosLacteosAntipConnectionString"].ConnectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand("UPS_InsertarUsuarios", conexion))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@primerNombre", SqlDbType.VarChar).Value = usuario.PrimerNombre;
                    command.Parameters.Add("@primerApellido", SqlDbType.VarChar).Value = usuario.PrimerApellido;
                    command.Parameters.Add("@username", SqlDbType.VarChar).Value = usuario.Username;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = usuario.Password;
                    command.Parameters.Add("@correoelectronico", SqlDbType.VarChar).Value = usuario.CorreoElectronico;
                    command.Parameters.Add("@nombreEmpresa", SqlDbType.VarChar).Value = usuario.NombreEmpresa;
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarUsuarios(UsuariosEmpresa usuario)
        {
            using (SqlConnection conexion = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["usuariosLacteosAntipConnectionString"].ConnectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand("UPS_ActualizarUsuarios", conexion))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@primerNombre", SqlDbType.VarChar).Value = usuario.PrimerNombre;
                    command.Parameters.Add("@primerApellido", SqlDbType.VarChar).Value = usuario.PrimerApellido;
                    command.Parameters.Add("@username", SqlDbType.VarChar).Value = usuario.Username;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = usuario.Password;
                    command.Parameters.Add("@correoelectronico", SqlDbType.VarChar).Value = usuario.CorreoElectronico;
                    command.Parameters.Add("@nombreEmpresa", SqlDbType.VarChar).Value = usuario.NombreEmpresa;
                    command.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuario.IdUsuario;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        
        }
    }

