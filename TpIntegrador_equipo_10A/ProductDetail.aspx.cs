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
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idQuery = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idQuery))
                {
                    int idProducto = int.Parse(idQuery);

                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    Producto producto = productoNegocio.ObtenerProductoId(idProducto); // ← este es tu método

                    if (producto != null)
                    {
                        // Obtener imágenes (si usás ImagenNegocio)
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        producto.Imagenes = imagenNegocio.listar(idProducto); // ← solo si tenés ese método

                        // Mostrar en la UI
                        lblNombre.Text = producto.Nombre;
                        lblDescripcion.Text = producto.Descripcion;
                        lblPrecio.Text = producto.Precio.ToString();
                        lblCategoria.Text = producto.Categoria.Descripcion;
                        lblStock.Text = producto.Stock.ToString();
                        lblUnidadVenta.Text = producto.UnidadVenta;

                        // Bind de imágenes para el carrusel
                        rptImagenes.DataSource = producto.Imagenes;
                        rptImagenes.DataBind();

                        rptIndicadores.DataSource = producto.Imagenes;
                        rptIndicadores.DataBind();
                    }
                    else
                    {
                        lblError.Text = "Producto no encontrado.";
                    }
                }
            }

        }
        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = int.Parse(Request.QueryString["id"]);
                int cantidad = 1;

                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Ingrese una cantidad válida.";
                        return;
                    }
                }

                if (Session["IdCarrito"] == null)
                {
                    CarritoNegocio carritoNegocio = new CarritoNegocio();
                    int nuevoIdCarrito = carritoNegocio.CrearCarrito();
                    Session["IdCarrito"] = nuevoIdCarrito;
                }

                int idCarrito = (int)Session["IdCarrito"];
                CarritoItemNegocio itemNegocio = new CarritoItemNegocio();
                itemNegocio.AgregarOActualizarItem(idCarrito, idProducto, cantidad);

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto agregado al carrito correctamente.";
            }
            catch (Exception ex)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al agregar producto al carrito: " + ex.Message +
                                (ex.InnerException != null ? " Detalle: " + ex.InnerException.Message : "");
            }
        }
    }
}
  
