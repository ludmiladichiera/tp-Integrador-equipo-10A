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
    public partial class AgregarProductoAdmin : System.Web.UI.Page
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
                deshabilitarTodo();
            }
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            bool existe = false;
            existe = negocio.existeCodigo(txtCodigo.Text);
            if (existe)
            {
                lblCodigoError.Text = "El código ingresado ya existe, por favor ingrese otro";
            }
            else
            {
                lblCodigoError.Text = "";
                habilitarTodo();
                cargarCateorias();
            }
        }
        protected void deshabilitarTodo()
        {
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            txtUnidadVenta.Enabled = false;
            ddlCategoria.Enabled = false;
            ddlEstado.Enabled = false;
            btnAgregar.Enabled = false;
            lblNombreError.Text = "";
            lblDescripcionError.Text = "";
            lblPrecioError.Text = "";
            lblStockError.Text = "";
            lblUnidadVentaError.Text = "";
            lblCategoriaError.Text = "";
            lblEstadoError.Text = "";
            lblExito.Text = "";
        }
        protected void habilitarTodo()
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtUnidadVenta.Enabled = true;
            ddlCategoria.Enabled = true;
            ddlEstado.Enabled = true;
            btnAgregar.Enabled = true;
        }

        protected void cargarCateorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                ddlCategoria.DataSource = negocio.listar();
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoría", "0"));

            }
            catch (Exception ex)
            {

                lblCategoriaError.Text = ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto producto = new Producto();
            producto.Categoria = new Categoria();
            int id = 0;
            decimal precio = 0;
            int stock = 0;
            bool estado;
            producto.Codigo = txtCodigo.Text;

            if (txtDescripcion.Text == null)
            {
                lblDescripcionError.Text = "Ingrese una descripcion";
                return;
            }
            else
            {
                producto.Descripcion = txtDescripcion.Text;
                lblDescripcionError.Text = "";

            }
            if (txtNombre.Text == null)
            {
                lblNombreError.Text = "Ingrese un nombre";
                return;
            }
            else
            {
                producto.Nombre = txtNombre.Text;
                lblNombreError.Text = "";
            }
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                lblPrecioError.Text = "Ingrese in precio válido";
                return;
            }
            else
            {
                producto.Precio = precio;
                lblPrecioError.Text = "";
            }
            if (!int.TryParse(txtStock.Text, out stock))
            {
                lblStockError.Text = "Ingrese un stock válido";
                return;
            }
            else
            {
                producto.Stock = stock;
                lblStockError.Text = "";
            }
            if (txtUnidadVenta.Text == null)
            {
                lblUnidadVentaError.Text = "Ingrese una unidad de venta válida";
                return;
            }
            else
            {
                producto.UnidadVenta = txtUnidadVenta.Text;
                lblUnidadVentaError.Text = "";
            }
            if (ddlCategoria.SelectedIndex == 0)
            {
                lblCategoriaError.Text = "Ingrese una categoría válida";
                return;
            }
            else
            {
                producto.Categoria.Id = ddlCategoria.SelectedIndex;
                lblCategoriaError.Text = "";
            }
            producto.Estado=ddlEstado.SelectedValue == "1" ? true : false;
            id = productoNegocio.agregarProductoYDevolverId(producto);
            if (id != 0)
            {
                deshabilitarTodo();
                lblExito.Text = "Producto agregado exitosamente!!!";
                btnAceptar.Visible = true;
                txtCodigo.Enabled = false;
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "Ingrese el Codigo";
            txtNombre.Text = "Ingrese el Nombre";
            txtDescripcion.Text = "Ingrese la Descripción";
            txtPrecio.Text = "Ingrese el Precio";
            txtStock.Text = "Ingrese el Stock";
            ddlCategoria.SelectedValue = "0";
            ddlEstado.SelectedValue = "0";
            btnAceptar.Visible = false;
            lblExito.Text = "";
            txtCodigo.Enabled = true;
        }
    }
}