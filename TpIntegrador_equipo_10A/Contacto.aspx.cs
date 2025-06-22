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

                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtEmail.Text = usuario.Mail;
            }
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string mensaje = txtMensaje.Text.Trim();
            string nombreCliente = txtNombre.Text.Trim();
            string apellidoCliente = txtApellido.Text.Trim();
            string mailCliente = txtEmail.Text.Trim();
            string tema = ddlTema.SelectedItem.Text;

            // Ocultar mensajes por defecto
            lblError.Visible = false;
            lblSucess.Visible = false;

            // Validaciones
            if (string.IsNullOrWhiteSpace(nombreCliente) ||
                string.IsNullOrWhiteSpace(apellidoCliente) ||
                string.IsNullOrWhiteSpace(mailCliente) ||
                string.IsNullOrWhiteSpace(mensaje))
            {
                lblError.Text = "Por favor, completá todos los campos obligatorios.";
                lblError.Visible = true;
                return;
            }

            if (ddlTema.SelectedIndex == 0 || string.IsNullOrWhiteSpace(ddlTema.SelectedValue))
            {
                lblError.Text = "Por favor, seleccioná un tema válido.";
                lblError.Visible = true;
                return;
            }

            try
            {
                EmailService emailService = new EmailService();
                emailService.armarCorreo(nombreCliente, apellidoCliente, mailCliente, tema, mensaje);
                emailService.enviarEmail();

                lblSucess.Text = $"{nombreCliente}, tu consulta fue enviada correctamente al equipo de soporte.";
                lblSucess.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al enviar el correo: " + ex.Message;
                lblError.Visible = true;
            }
        }


    }
}