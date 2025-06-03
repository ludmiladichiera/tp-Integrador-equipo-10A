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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMensaje.Visible = false;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(textEmail.Text) ||
                string.IsNullOrWhiteSpace(textPassword.Text) ||
                string.IsNullOrWhiteSpace(textNombre.Text) ||
                string.IsNullOrWhiteSpace(textApellido.Text))
            {
                lblMensaje.Text = "Debe completar todos los campos obligatorios.";
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
                return;
            }

            if (!chkbAcepto.Checked)
            {
                lblMensaje.Text = "Debe aceptar los términos y condiciones.";
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
                return;
            }

            if (textPassword.Text != textConfirmPassword.Text)
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
                return;
            }

            Usuario usuario = new Usuario
            {
                Mail = textEmail.Text.Trim(),
                Pass = textPassword.Text.Trim(),
                Nombre = textNombre.Text.Trim(),
                Apellido = textApellido.Text.Trim(),
                Direccion = textDireccion.Text.Trim(),
                Telefono = textTelefono.Text.Trim(),
                Ciudad = textCiudad.Text.Trim(),
                CodigoPostal = int.TryParse(textCodigoPostal.Text.Trim(), out int cp) ? cp : 0,
                Dni = textDni.Text.Trim(),
                TipoUsuario = new TipoUsuario { Id = 1 } // Asignás el tipo 'cliente' fijo
            };

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                // Validar que mail y dni no existan
                if (usuarioNegocio.EmailExiste(usuario.Mail))
                {
                    lblMensaje.Text = "El email ya está registrado.";
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Visible = true;
                    return;
                }

                if (usuarioNegocio.DniExiste(usuario.Dni))
                {
                    lblMensaje.Text = "El DNI ya está registrado.";
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Visible = true;
                    return;
                }

                // Crear usuario
                usuarioNegocio.RegistrarCliente(usuario);

                lblMensaje.Text = "Registro completado con éxito.";
                lblMensaje.CssClass = "text-success";
                lblMensaje.Visible = true;

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al registrar usuario: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
            }
        }

        private void LimpiarFormulario()
        {
            textNombre.Text = "";
            textApellido.Text = "";
            textEmail.Text = "";
            textDireccion.Text = "";
            textTelefono.Text = "";
            textCiudad.Text = "";
            textCodigoPostal.Text = "";
            textDni.Text = "";
            textPassword.Text = "";
            textConfirmPassword.Text = "";
            chkbAcepto.Checked = false;
        }
        protected void cvAcepto_ServerValidate(object source, ServerValidateEventArgs args)
        {

            args.IsValid = chkbAcepto.Checked;
        }
    }
}