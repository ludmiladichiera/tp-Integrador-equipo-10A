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
        bool guardo = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!guardo)
                    ocultarTodo();
                btnEliminar.Text = "Eliminar";
            }

        }
        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {

            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                Producto prod = new Producto();
                prod.Categoria = new Categoria();

                prod = negocio.buscarXcodigo(txtCodigo.Text);

                if (prod == null || prod.Id == 0)
                {
                    mostrarTodo();
                    lblExistente.Text = "Producto inexistente,llene todos los campos para darlo de alta";
                    btnGuardar.Text = "Agregar";
                    btnEliminar.Text = "Cancelar";

                }
                else
                {
                    mostrarTodo();
                    lblExistente.Text = "Producto existente";
                    txtNombre.Text = prod.Nombre;
                    txtDescripcion.Text = prod.Descripcion;
                    txtPrecio.Text = prod.Precio.ToString();
                    txtStock.Text = prod.Stock.ToString();
                    txtUnidadVenta.Text = prod.UnidadVenta;
                    ddlCategoria.SelectedValue = prod.Categoria.Id.ToString();
                    btnGuardar.Text = "Modificar";
                }
            }
            catch (Exception ex)
            {
                lblExito.Text = ex.Message;
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
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            decimal precio;
            int stock;
            ProductoNegocio negocioP = new ProductoNegocio();
            Producto nuevoProducto = new Producto();
            nuevoProducto.Categoria = new Categoria();

            if (txtCodigo.Text == null || txtNombre.Text == null || txtDescripcion.Text == null || txtPrecio.Text == null || txtStock.Text == null || txtUnidadVenta.Text == null)
            {
                lblExito.Text = "Complete todos los campos";
                lblExito.Visible = true;
                return;
            }
            nuevoProducto.Codigo = txtCodigo.Text;
            nuevoProducto.Descripcion = txtDescripcion.Text;
            nuevoProducto.Nombre = txtNombre.Text;


            if (decimal.TryParse(txtPrecio.Text, out precio))
            {
                nuevoProducto.Precio = precio;
            }
            else
            {
                lblExito.Text = "Ingrese un valor numérico válido";
                lblExito.Visible = true;
                return;
            }


            if (int.TryParse(txtStock.Text, out stock))
            {
                nuevoProducto.Stock = stock;
            }
            else
            {
                lblExito.Text = "Ingrese un valor numérico válido";
                lblExito.Visible = true;
                return;
            }

            nuevoProducto.UnidadVenta = txtUnidadVenta.Text;

            nuevoProducto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
            nuevoProducto.Categoria.Descripcion = ddlCategoria.SelectedItem.Text;

            //nuevoProducto.Estado=int.Parse(ddlEstado.SelectedValue); para cuando este el estado en producto
            if (btnGuardar.Text == "Agregar")
            {
                int id = negocioP.agregarProductoYDevolverId(nuevoProducto);
                lblExito.Visible = true;
                lblExito.Text = "Exito al agregar nuevo producto";
                inhabilitarCambios();

            }
            else if (btnGuardar.Text == "Modificar")
            {
                Producto aux = negocioP.buscarXcodigo(txtCodigo.Text);
                if (txtCodigo.Text == null || txtNombre.Text == null || txtDescripcion.Text == null || txtPrecio.Text == null || txtStock.Text == null || txtUnidadVenta.Text == null)
                {
                    lblExito.Text = "Complete todos los campos";
                    lblExito.Visible = true;
                    return;
                }
                habillitarCambios();
                txtCodigo.AutoPostBack = false;
                nuevoProducto.Codigo = txtCodigo.Text;
                nuevoProducto.Descripcion = txtDescripcion.Text;
                nuevoProducto.Nombre = txtNombre.Text;


                if (decimal.TryParse(txtPrecio.Text, out precio))
                {
                    nuevoProducto.Precio = precio;
                }
                else
                {
                    lblExito.Text = "Ingrese un valor numérico válido";
                    lblExito.Visible = true;
                    return;
                }


                if (int.TryParse(txtStock.Text, out stock))
                {
                    nuevoProducto.Stock = stock;
                }
                else
                {
                    lblExito.Text = "Ingrese un valor numérico válido";
                    lblExito.Visible = true;
                    return;
                }

                nuevoProducto.UnidadVenta = txtUnidadVenta.Text;

                nuevoProducto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevoProducto.Categoria.Descripcion = ddlCategoria.DataTextField;
                //nuevoProducto.Estado = int.Parse(ddlEstado.SelectedValue); para cuando este el estado en producto

                if (negocioP.existeCodigoEnOtroProducto(nuevoProducto.Codigo, aux.Id))
                {
                    lblExito.Text = "El código ingresado ya existe para otro producto. Por favor, ingrese un código único.";
                    lblExito.Visible = true;
                    return;
                }
                negocioP.modificarProducto(nuevoProducto);
                lblExito.Visible = true;
                lblExito.Text = "Exito al modificar";
                guardo = true;
                inhabilitarCambios();
                btnEliminar.Visible = true;
                btnEliminar.Text = "Volver";
            }

        }

        protected void ocultarTodo()
        {
            lblExistente.Visible = false;
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
            ddlCategoria.Visible = false;
            ddlEstado.Visible = false;
            btnGuardar.Visible = false;
            btnEliminar.Visible = false;
        }
        protected void mostrarTodo()
        {
            lblExistente.Visible = true;

            lblNombre.Visible = true;
            txtNombre.Visible = true;
            txtNombre.Text = null;

            lblDescripcion.Visible = true;
            txtDescripcion.Visible = true;
            txtDescripcion.Text = null;

            lblPrecio.Visible = true;
            txtPrecio.Visible = true;
            txtPrecio.Text = null;

            lblStock.Visible = true;
            txtStock.Visible = true;
            txtStock.Text = null;

            lblUnidadVenta.Visible = true;
            txtUnidadVenta.Visible = true;
            txtUnidadVenta.Text = null;

            ddlCategoria.Visible = true;
            cargarDDLcat();

            ddlEstado.Visible = true;

            btnGuardar.Visible = true;
            btnEliminar.Visible = true;
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
            btnEliminar.Visible = false;
        }
        protected void habillitarCambios()
        {
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            txtUnidadVenta.Enabled = true;
            ddlCategoria.Enabled = true;
            ddlEstado.Enabled = true;
            btnGuardar.Visible = true;
            btnEliminar.Visible = true;

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            guardo = false;
            txtCodigo.Text = null;
        }
    }
}