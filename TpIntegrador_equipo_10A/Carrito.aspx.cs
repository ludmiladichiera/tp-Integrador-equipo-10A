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
    public partial class Carrito : System.Web.UI.Page
    {

        private CarritoItemNegocio itemNegocio = new CarritoItemNegocio();
        private CarritoNegocio carritoNegocio = new CarritoNegocio();
        private int idCarrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Solo cargar el carrito si ya existe uno en sesión
                if (Session["IdCarrito"] != null)
                {
                    idCarrito = (int)Session["IdCarrito"];
                    CargarCarrito();
                }
                else
                {
                    // Si no hay carrito creado, mostrar carrito vacío
                    lblTotal.Text = "0.00";
                    rptCarrito.DataSource = null;
                    rptCarrito.DataBind();
                    // Opcional: mostrar un mensaje
                    pnlCarritoVacio.Visible = true;
                }
            }
        }
        private void CargarCarrito()
        {
            List<CarritoItem> items = itemNegocio.ObtenerItems(idCarrito);

            // Agregamos la propiedad Subtotal para mostrar en el Repeater
            var datos = items.Select(x => new
            {
                Producto = x.Producto,
                Cantidad = x.Cantidad,
                Subtotal = x.Producto.Precio * x.Cantidad
            }).ToList();

            rptCarrito.DataSource = datos;
            rptCarrito.DataBind();

            decimal total = datos.Sum(x => x.Subtotal);
            lblTotal.Text = total.ToString("0.00");

            // Mostrar o ocultar mensaje carrito vacío
            pnlCarritoVacio.Visible = datos.Count == 0;
        }

        protected void ModificarCantidad(object source, RepeaterCommandEventArgs e)
        {
            int idProducto = int.Parse(e.CommandArgument.ToString());
            idCarrito = (int)Session["IdCarrito"];

            bool ok = true;

            switch (e.CommandName)
            {
                case "Aumentar":
                    // Valida stock antes de agregar
                    ok = itemNegocio.AgregarOActualizarItem(idCarrito, idProducto, 1);
                    break;

                case "Disminuir":
                    // Disminuir no necesita validación de stock
                    itemNegocio.ModificarCantidad(idCarrito, idProducto, -1);
                    break;

                case "Eliminar":
                    itemNegocio.EliminarItem(idCarrito, idProducto);
                    break;
            }

            if (!ok)
            {
                // Mostramos alerta si no hay stock suficiente
                ScriptManager.RegisterStartupScript(this, GetType(), "stockInsuficiente", "alert('No hay stock suficiente para este producto.');", true);
            }

            CargarCarrito();
        }
        protected void btnIniciarCompra_Click(object sender, EventArgs e)
        {

            try
            {
                if (Session["IdCarrito"] != null)
                {
                    int idCarrito = (int)Session["IdCarrito"];
                    CarritoItemNegocio itemNegocio = new CarritoItemNegocio();

                    var items = itemNegocio.ObtenerItems(idCarrito);

                    if (items != null && items.Count > 0)
                    {
                        // Avanzar a la página de orden de pedido
                        Response.Redirect("OrdenPedido.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "carritoVacio", "alert('Tu carrito está vacío. Agrega productos antes de iniciar la compra.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sinCarrito", "alert('No hay un carrito activo.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", $"alert('Error: {ex.Message}');", true);
            }
        }
    }
}
