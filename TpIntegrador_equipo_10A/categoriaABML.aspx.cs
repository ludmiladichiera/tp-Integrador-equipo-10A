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
    public partial class categoriaABML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //para que solo tenga acceso el admin
            /*if (Session["IdTipoUsuario"] == null || (int)Session["IdTipoUsuario"] != 2)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            */


            if (!IsPostBack)
            {
                CargarCategorias();
                pnlCategoria.Visible = false;
            }
        }

        private void CargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            gvCategorias.DataSource = negocio.listar();
            gvCategorias.DataBind();
        }

        protected void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            pnlCategoria.Visible = true;
            btnGuardar.Text = "Agregar";
        }

        protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarCategoria")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCategorias.Rows[index];
                int id = Convert.ToInt32(gvCategorias.DataKeys[index].Value);

                CategoriaNegocio negocio = new CategoriaNegocio();
                Categoria seleccionada = negocio.listar().Find(c => c.Id == id);

                if (seleccionada != null)
                {
                    lblIdCategoria.Text = seleccionada.Id.ToString();
                    txtDescripcionCat.Text = seleccionada.Descripcion;

                    btnGuardar.Text = "Modificar";
                    pnlCategoria.Visible = true;

                    lblExito.Visible = false;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            CategoriaNegocio negocio = new CategoriaNegocio();
            string descripcionIngresada = txtDescripcionCat.Text.Trim();

            if (string.IsNullOrEmpty(descripcionIngresada))
            {
                lblExito.Visible = true;
                lblExito.CssClass = "form-text text-danger";
                lblExito.Text = "La descripción no puede estar vacía.";
                return;
            }

            Categoria existente = negocio.categoriaXdescripcion(descripcionIngresada);

            // Si la categoría ya existe
            if (string.IsNullOrEmpty(lblIdCategoria.Text))
            {
                if (existente != null && existente.Id != 0)
                {
                    lblExito.Visible = true;
                    lblExito.CssClass = "form-text text-danger";
                    lblExito.Text = "Ya existe una categoría con esa descripción.";
                    return;
                }

                Categoria nueva = new Categoria { Descripcion = descripcionIngresada };
                negocio.agregar(nueva);

                lblExito.Visible = true;
                lblExito.CssClass = "form-text text-success";
                lblExito.Text = "Categoría agregada correctamente.";
            }
            else // Modificación
            {
                int idActual = int.Parse(lblIdCategoria.Text);

                // Si existe otra categoría con la misma descripción y distinto ID
                if (existente != null && existente.Id != 0 && existente.Id != idActual)
                {
                    lblExito.Visible = true;
                    lblExito.CssClass = "form-text text-danger";
                    lblExito.Text = "Ya existe otra categoría con esa descripción.";
                    return;
                }

                Categoria categoria = new Categoria
                {
                    Id = idActual,
                    Descripcion = descripcionIngresada
                };
                negocio.modificarCategoria(categoria);

                lblExito.Visible = true;
                lblExito.CssClass = "form-text text-success";
                lblExito.Text = "Categoría modificada correctamente.";
            }

            pnlCategoria.Visible = false;
            CargarCategorias();
            limpiarFormulario();
        }


        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblIdCategoria.Text))
            {
                int id = int.Parse(lblIdCategoria.Text);
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.DesactivarCategoria(id);

                lblExito.Visible = true;
                lblExito.CssClass = "form-text text-success";
                lblExito.Text = "Categoría desactivada correctamente.";

                pnlCategoria.Visible = false;
                CargarCategorias();
                limpiarFormulario();
            }
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblIdCategoria.Text))
            {
                int id = int.Parse(lblIdCategoria.Text);
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.ReactivarCategoria(id);

                lblExito.Visible = true;
                lblExito.CssClass = "form-text text-success";
                lblExito.Text = "Categoría activada correctamente.";

                pnlCategoria.Visible = false;
                CargarCategorias();
                limpiarFormulario();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlCategoria.Visible = false;
            lblExito.Visible = false;
            limpiarFormulario();
        }

        private void limpiarFormulario()
        {
            lblIdCategoria.Text = string.Empty;
            txtDescripcionCat.Text = string.Empty;
            lblExito.Visible = false;
            lblExito.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string descripcion = txtBuscarDescripcion.Text.Trim().ToLower();
            CategoriaNegocio negocio = new CategoriaNegocio();

            var listaCompleta = negocio.listar();

            if (string.IsNullOrEmpty(descripcion))
            {
                gvCategorias.DataSource = listaCompleta;
            }
            else
            {
                var filtrada = listaCompleta.Where(c => c.Descripcion.ToLower().Contains(descripcion)).ToList();
                gvCategorias.DataSource = filtrada;
            }

            gvCategorias.DataBind();
        }
    }
}