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
                // usamos el método Loguear para obtener el usuario completo si el mail y pass coinciden
                Usuario usuario = usuarioNegocio.Loguear(email, contraseña);

                if (usuario == null)
                {
                    lblMensaje.Text = "Email o contraseña incorrectos, o el usuario no está registrado. Por favor, regístrese.";
                    lblMensaje.Visible = true;
                    return;
                }

                // usuario válido: guardamos en sesión
                Session["usuario"] = usuario;

                lblMensaje.Text = "Se ha logueado correctamente.";
                lblMensaje.CssClass = "text-success";
                lblMensaje.Visible = true;
                // redirigimos a la página ...
                //Response.Redirect(".aspx", false);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error al iniciar sesión: " + ex.Message;
                lblMensaje.Visible = true;
            }
        }
    }
}