using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TpIntegrador_equipo_10A
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string contraseña = txtPassword.Text;

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                Usuario usuario = usuarioNegocio.Loguear(email, contraseña);

                if (usuario == null)
                {
                    lblMensaje.Text = "Email o contraseña incorrectos.";
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Visible = true;
                    return;
                }

                // guardamos usuario y tipo en sesión
                Session["usuario"] = usuario;
                Session["IdTipoUsuario"] = usuario.TipoUsuario.Id;

                // Mensaje y redirigir a otra página
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al iniciar sesión: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
            }
        }
    }
}