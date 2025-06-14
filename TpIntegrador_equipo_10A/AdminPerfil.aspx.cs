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
    public partial class AdminPerfil : System.Web.UI.Page
    {
        
            protected void Page_Load(object sender, EventArgs e)
            {
            //ver si hay sesión y si es admin, queda comentado ahora q hacemos pruebas
            /*if (Session["IdTipoUsuario"] == null || (int)Session["IdTipoUsuario"] != 2)
            {
                Response.Redirect("~/Default.aspx"); 
                return;
            }*/

            if (!IsPostBack)
            {
                CargarUsuarios();
            }

        }

            private void CargarUsuarios(string filtro = "")
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                List<Usuario> lista = negocio.BuscarPorDniOMail(filtro);

                gvUsuarios.DataSource = lista;
                gvUsuarios.DataKeyNames = new string[] { "Id" }; // Importante: clave primaria
                gvUsuarios.DataBind();

                pnlUsuarioSeleccionado.Visible = false;
            }

            protected void btnBuscar_Click(object sender, EventArgs e)
            {
                string filtro = txtFiltro.Text.Trim();
                CargarUsuarios(filtro);
            }

            protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "VerUsuario")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    int idUsuario = Convert.ToInt32(gvUsuarios.DataKeys[index].Value);

                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario seleccionado = negocio.BuscarPorId(idUsuario); // Este método deberías tenerlo

                    if (seleccionado != null)
                    {
                        ViewState["UsuarioSeleccionadoId"] = seleccionado.Id;
                        lblUsuarioSeleccionado.Text = $"Usuario: {seleccionado.Nombre} {seleccionado.Apellido} - DNI: {seleccionado.Dni}";
                        btnReactivarUsuario.Visible = !seleccionado.Estado;

                        pnlUsuarioSeleccionado.Visible = true;
                    }
                }
            }

            protected void btnReactivarUsuario_Click(object sender, EventArgs e)
            {
                int id = (int)ViewState["UsuarioSeleccionadoId"];
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.ReactivarUsuario(id);

                CargarUsuarios();
            }

            protected void btnModificarMail_Click(object sender, EventArgs e)
            {
                lblUsuarioSeleccionado.Text += "<br />Funcionalidad para modificar el Mail aún no implementada.";
            }

            protected void btnModificarPass_Click(object sender, EventArgs e)
            {
                lblUsuarioSeleccionado.Text += "<br />Funcionalidad para modificar la Contraseña aún no implementada.";
            }
        }
    }
