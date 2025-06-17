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
    public partial class productoABML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ocultarTodo();
                cargarDDLcat();
                CargarGridProductos();
                btnAgregarProducto.Visible = true;
                btnVolverLista.Visible = false;
            }
        }


        protected void cargarDDLcat()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            List<Categoria> categorias = negocio.listar();
            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
        }



        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtUnidadVenta.Text = "";
            ddlCategoria.SelectedIndex = 0;
            ddlEstado.SelectedIndex = 0;
            ViewState["IdProductoSeleccionado"] = null;
            ViewState["ModoEdicion"] = null;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            ProductoNegocio negocioP = new ProductoNegocio();

            // Obtener el ID del producto a modificar desde ViewState
            int idProducto = ViewState["IdProductoSeleccionado"] != null ? (int)ViewState["IdProductoSeleccionado"] : 0;
            if (idProducto == 0)
            {

                lblMensaje.Text = "No se ha seleccionado un producto para modificar.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return;
            }


            Producto modificado = new Producto
            {
                Id = idProducto,
                Codigo = txtCodigo.Text.Trim(),  //  no se modifica en DB
                Nombre = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Precio = decimal.Parse(txtPrecio.Text.Trim()),
                Stock = int.Parse(txtStock.Text.Trim()),
                UnidadVenta = txtUnidadVenta.Text.Trim(),
                Categoria = new Categoria
                {
                    Id = int.Parse(ddlCategoria.SelectedValue),
                    Descripcion = ddlCategoria.SelectedItem.Text
                },
                Estado = ddlEstado.SelectedValue == "1"
            };

            try
            {
                negocioP.modificarProducto(modificado);

                lblMensaje.Text = "Producto modificado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Visible = true;


                Producto actualizado = negocioP.ObtenerProductoId(idProducto);
                gvProductos.DataSource = new List<Producto> { actualizado };
                gvProductos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al modificar el producto: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
        }



        private bool ValidarCampos()
        {
            decimal precio;
            int stock;

            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrWhiteSpace(txtUnidadVenta.Text))
            {
                lblMensaje.Text = "Por favor complete todos los campos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                lblMensaje.Text = "Ingrese un precio válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (!int.TryParse(txtStock.Text, out stock))
            {
                lblMensaje.Text = "Ingrese un stock válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            lblMensaje.Text = "";
            return true;
        }


        protected void ocultarTodo()
        {
            lblCodigo.Visible = false;
            txtCodigo.Visible = false;

            lblNombre.Visible = false;
            txtNombre.Visible = false;
            lblDescripcion.Visible = false;
            txtDescripcion.Visible = false;
            lblPrecio.Visible = false;
            txtPrecio.Visible = false;
            lblStock.Visible = false;
            txtStock.Visible = false;
            lblUnidadVenta.Visible = false;
            txtUnidadVenta.Visible = false;
            lblCategoria.Visible = false;
            ddlCategoria.Visible = false;
            lblEstado.Visible = false;
            ddlEstado.Visible = false;
            btnGuardar.Visible = false;

        }

        protected void mostrarTodo()
        {
            lblCodigo.Visible = true;
            txtCodigo.Visible = true;

            lblNombre.Visible = true;
            txtNombre.Visible = true;
            lblDescripcion.Visible = true;
            txtDescripcion.Visible = true;
            lblPrecio.Visible = true;
            txtPrecio.Visible = true;
            lblStock.Visible = true;
            txtStock.Visible = true;
            lblUnidadVenta.Visible = true;
            txtUnidadVenta.Visible = true;
            lblCategoria.Visible = true;
            lblEstado.Visible = true;
            ddlCategoria.Visible = true;
            ddlEstado.Visible = true;
        }

        protected void inhabilitarCambios()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            txtUnidadVenta.Enabled = false;
            ddlCategoria.Enabled = false;
            ddlEstado.Enabled = false;
            btnGuardar.Visible = false;

        }

        protected void habilitarCambios()
        {
            txtCodigo.Enabled = false; // El código no se puede modificar
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtUnidadVenta.Enabled = true;
            ddlCategoria.Enabled = true;
            ddlEstado.Enabled = true;
            btnGuardar.Visible = true;
            btnAgregarProducto.Visible = true;
        }

        private void CargarGridProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            gvProductos.DataSource = negocio.listar(true);
            gvProductos.DataBind();

            btnVolverLista.Visible = false;
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "SeleccionarProducto")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idProducto = Convert.ToInt32(gvProductos.DataKeys[index].Value);

                try
                {
                    Producto producto = new ProductoNegocio().ObtenerProductoId(idProducto);

                    if (producto == null)
                    {
                        lblMensaje.Text = "No se encontró el producto seleccionado.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    // Cargo datos en el formulario
                    txtCodigo.Text = producto.Codigo;
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    txtPrecio.Text = producto.Precio.ToString("0.00");
                    txtStock.Text = producto.Stock.ToString();
                    txtUnidadVenta.Text = producto.UnidadVenta;
                    ddlCategoria.SelectedValue = producto.Categoria.Id.ToString();
                    ddlEstado.SelectedValue = producto.Estado ? "1" : "0";

                    mostrarTodo();
                    habilitarCambios();

                    // Código no editable
                    txtCodigo.Enabled = false;

                    // Mostrar solo el producto seleccionado en el GridView
                    gvProductos.DataSource = new List<Producto> { producto };
                    gvProductos.DataBind();

                    btnVolverLista.Visible = true;

                    // Guardar modo edición para modificar
                    ViewState["ModoEdicion"] = "Modificar";
                    ViewState["IdProductoSeleccionado"] = producto.Id;

                    lblMensaje.Text = "";
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al cargar producto: " + ex.Message;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }


        protected void btnBuscarClave_Click(object sender, EventArgs e)
        {
            ocultarTodo();
            LimpiarFormulario();
            ViewState["IdProductoSeleccionado"] = null;

            string texto = txtBusquedaClave.Text.Trim();

            ProductoNegocio negocio = new ProductoNegocio();

            if (string.IsNullOrEmpty(texto))
            {
                gvProductos.DataSource = negocio.listar(true);
            }
            else
            {
                gvProductos.DataSource = negocio.buscarRapido(texto, true);
                btnVolverLista.Visible = true;
            }

            gvProductos.DataBind();
        }

        protected void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            ocultarTodo();
            LimpiarFormulario();
            ViewState["IdProductoSeleccionado"] = null;

            string codigo = txtBusquedaCodigo.Text.Trim();
            ProductoNegocio negocio = new ProductoNegocio();

            if (string.IsNullOrEmpty(codigo))
            {
                gvProductos.DataSource = negocio.listar(true);
            }
            else
            {
                // buscarXcodigo devuelve un solo producto, así que para el GridView necesitamos una lista
                Producto prod = negocio.buscarXcodigo(codigo);

                if (prod == null || prod.Id == 0)
                {
                    gvProductos.DataSource = new List<Producto>(); // lista vacía, nada para mostrar
                }
                else
                {
                    gvProductos.DataSource = new List<Producto> { prod };
                    btnVolverLista.Visible = true;
                }
            }

            gvProductos.DataBind();


        }
        protected void btnVolverLista_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            LimpiarFormulario();
            ocultarTodo();
            btnVolverLista.Visible = false;

            CargarGridProductos();

            ViewState["ModoEdicion"] = null;
            ViewState["IdProductoSeleccionado"] = null;
        }
    }
}