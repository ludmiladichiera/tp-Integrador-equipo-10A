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
    public partial class MiPerfil : System.Web.UI.Page
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

                lblDNI.Text = usuario.Dni;
                lblNombre.Text = usuario.Nombre;
                lblApellido.Text = usuario.Apellido;
                lblEmail.Text = usuario.Mail;
                lblTelefono.Text = usuario.Telefono;
                lblCP.Text = usuario.CodigoPostal.ToString();
                lblCiudad.Text = usuario.Ciudad;
                lblDireccion.Text = usuario.Direccion;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // Mostrar panel y precargar datos
            pnlModificarDatos.Visible = true;
            lblErrorModificar.Visible = false;

            txtDireccion.Text = usuario.Direccion;
            txtCiudad.Text = usuario.Ciudad;
            txtCP.Text = usuario.CodigoPostal.ToString();
            txtTelefono.Text = usuario.Telefono;
        }

        protected void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // Guardar datos editados
            usuario.Direccion = txtDireccion.Text.Trim();
            usuario.Ciudad = txtCiudad.Text.Trim();
            usuario.Telefono = txtTelefono.Text.Trim();

            if (int.TryParse(txtCP.Text.Trim(), out int cp))
                usuario.CodigoPostal = cp;
            else
                usuario.CodigoPostal = 0;

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.ModificarUsuario(usuario);
                Session["usuario"] = usuario;

                pnlModificarDatos.Visible = false;

                // Refrescar los labels
                lblDireccion.Text = usuario.Direccion;
                lblCiudad.Text = usuario.Ciudad;
                lblCP.Text = usuario.CodigoPostal.ToString();
                lblTelefono.Text = usuario.Telefono;
            }
            catch (Exception ex)
            {
                lblErrorModificar.Text = "Error al modificar: " + ex.Message;
                lblErrorModificar.Visible = true;
            }
        }

        protected void btnCancelarModificar_Click(object sender, EventArgs e)
        {
            pnlModificarDatos.Visible = false;
            lblErrorModificar.Visible = false;
        }
        protected void btnMostrarCambiarContrasenia_Click(object sender, EventArgs e)
        {
            pnlCambiarContrasenia.Visible = true;
            lblErrorContrasenia.Visible = false;
        }

        protected void btnCancelarCambioContrasenia_Click(object sender, EventArgs e)
        {
            pnlCambiarContrasenia.Visible = false;
            lblErrorContrasenia.Visible = false;
            LimpiarCamposContrasenia();
        }

        protected void btnCambiarContrasenia_Click(object sender, EventArgs e)
        {
            lblErrorContrasenia.Visible = false;

            string actual = txtContraseniaActual.Text.Trim();
            string nueva = txtNuevaContrasenia.Text.Trim();
            string confirmar = txtConfirmarContrasenia.Text.Trim();

            if (string.IsNullOrEmpty(actual) || string.IsNullOrEmpty(nueva) || string.IsNullOrEmpty(confirmar))
            {
                lblErrorContrasenia.Text = "Todos los campos son obligatorios.";
                lblErrorContrasenia.Visible = true;
                return;
            }

            if (nueva != confirmar)
            {
                lblErrorContrasenia.Text = "La nueva contraseña y la confirmación no coinciden.";
                lblErrorContrasenia.Visible = true;
                return;
            }

            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                bool cambioOk = negocio.ModificarContrasenia(usuario.Id, actual, nueva);

                if (cambioOk)
                {
                    pnlCambiarContrasenia.Visible = false;
                    LimpiarCamposContrasenia();

                    // Opcional: mostrar mensaje de éxito
                    lblErrorContrasenia.ForeColor = System.Drawing.Color.Green;
                    lblErrorContrasenia.Text = "Contraseña cambiada correctamente.";
                    lblErrorContrasenia.Visible = true;
                }
                else
                {
                    lblErrorContrasenia.ForeColor = System.Drawing.Color.Red;
                    lblErrorContrasenia.Text = "La contraseña actual es incorrecta.";
                    lblErrorContrasenia.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblErrorContrasenia.ForeColor = System.Drawing.Color.Red;
                lblErrorContrasenia.Text = "Error al cambiar la contraseña: " + ex.Message;
                lblErrorContrasenia.Visible = true;
            }
        }

        private void LimpiarCamposContrasenia()
        {
            txtContraseniaActual.Text = "";
            txtNuevaContrasenia.Text = "";
            txtConfirmarContrasenia.Text = "";
        }

        protected void btnCancelarBaja_Click(object sender, EventArgs e)
        {
            pnlConfirmarBaja.Style["display"] = "none";
            // Limpia errores o estados
            lblErrorBaja.Visible = false;
            chkConfirmacionBaja.Checked = false;
        }

        protected void btnAceptarBaja_Click(object sender, EventArgs e)
        {
            if (!chkConfirmacionBaja.Checked)
            {
                lblErrorBaja.Text = "Debés confirmar que entendés las consecuencias.";
                lblErrorBaja.Visible = true;
                pnlConfirmarBaja.Visible = true;
                return;
            }

            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario != null)
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    negocio.DarDeBajaUsuario(usuario.Id);

                    // Limpiar sesión
                    Session.Clear();

                    // Redirigir al inicio
                    Response.Redirect("Default.aspx");
                }
            }
            catch (Exception ex)
            {
                lblErrorBaja.Text = "Ocurrió un error al intentar darte de baja.";
                lblErrorBaja.Visible = true;
                pnlConfirmarBaja.Visible = true;
            }
        }
    }
}