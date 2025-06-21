using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TpIntegrador_equipo_10A
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = Session["usuario"] as Usuario;

                if (usuario == null)
                {
                    // Redirecciona al login si no hay sesión activa
                    Response.Redirect("Login.aspx");
                    return;
                }

                lblNombre.Text = usuario.Nombre;
                lblApellido.Text = usuario.Apellido;
                lblEmail.Text = usuario.Mail;
            }
        }
    }
}