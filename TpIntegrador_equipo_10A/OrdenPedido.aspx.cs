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
    public partial class OrdenPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDowns();

                // Validar que exista carrito en sesión
                if (Session["IdCarrito"] == null)
                {
                    Response.Redirect("Carrito.aspx");
                    return;
                }

                int idCarrito = (int)Session["IdCarrito"];

                CarritoItemNegocio carritoItemNegocio = new CarritoItemNegocio();
                var productosEnCarrito = carritoItemNegocio.ObtenerItems(idCarrito);

                if (productosEnCarrito == null || productosEnCarrito.Count == 0)
                {
                    Response.Redirect("Carrito.aspx");
                    return;
                }

                rptProductosPedido.DataSource = productosEnCarrito;
                rptProductosPedido.DataBind();
            }
        }

        private void CargarDropDowns()
        {
            ddlMetodoEntrega.DataSource = new[]
            {
            new { Text = "Retiro", Value = ((int)MetodoEntrega.Retiro).ToString() },
            new { Text = "Envío", Value = ((int)MetodoEntrega.Envio).ToString() }
        };
            ddlMetodoEntrega.DataTextField = "Text";
            ddlMetodoEntrega.DataValueField = "Value";
            ddlMetodoEntrega.DataBind();

            ddlMetodoPago.DataSource = new[]
            {
            new { Text = "MercadoPago", Value = ((int)MetodoPago.MercadoPago).ToString() },
            new { Text = "Transferencia", Value = ((int)MetodoPago.Transferencia).ToString() },
            new { Text = "Efectivo", Value = ((int)MetodoPago.Efectivo).ToString() }
        };
            ddlMetodoPago.DataTextField = "Text";
            ddlMetodoPago.DataValueField = "Value";
            ddlMetodoPago.DataBind();
        }


        protected void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            lblMensaje.CssClass = "";

            // Validar fecha entrega
            if (!DateTime.TryParse(txtFechaEntrega.Text, out DateTime fechaEntrega))
            {
                lblMensaje.Text = "Por favor ingrese una fecha de entrega válida.";
                lblMensaje.CssClass = "text-danger";
                return;
            }

            // Obtener usuario de sesión
            var usuario = (Usuario)Session["usuario"];
            if (usuario == null)
            {
                lblMensaje.Text = "Debe iniciar sesión para realizar el pedido.";
                lblMensaje.CssClass = "text-danger";
                return;
            }

            // Obtener id carrito de sesión
            int idCarrito = (int)(Session["IdCarrito"] ?? 0);
            if (idCarrito == 0)
            {
                lblMensaje.Text = "No se encontró un carrito válido.";
                lblMensaje.CssClass = "text-danger";
                return;
            }

            // Obtener items del carrito
            CarritoItemNegocio carritoItemNegocio = new CarritoItemNegocio();
            var itemsCarrito = carritoItemNegocio.ObtenerItems(idCarrito);

            if (itemsCarrito == null || itemsCarrito.Count == 0)
            {
                lblMensaje.Text = "No hay productos en el carrito para realizar el pedido.";
                lblMensaje.CssClass = "text-danger";
                return;
            }

            // Calcular precio total
            decimal precioTotal = itemsCarrito.Sum(ci => ci.Producto.Precio * ci.Cantidad);

            // Convertir CarritoItem a PedidoItem
            var itemsPedido = itemsCarrito.Select(ci => new PedidoItem
            {
                Producto = ci.Producto,
                Cantidad = ci.Cantidad,
                Precio = ci.Producto.Precio
            }).ToList();

            ProductoNegocio productoNegocio = new ProductoNegocio();

            foreach (var item in itemsPedido)
            {
                Producto actualizado = productoNegocio.ObtenerProductoId(item.Producto.Id);
                item.Producto = actualizado;
            }
            // Crear el pedido
            Pedido nuevoPedido = new Pedido
            {
                Usuario = usuario,
                FechaPedido = DateTime.Now,
                FechaEntrega = fechaEntrega,
                MetodoEntrega = (MetodoEntrega)int.Parse(ddlMetodoEntrega.SelectedValue),
                MetodoPago = (MetodoPago)int.Parse(ddlMetodoPago.SelectedValue),
                EstadoPago = EstadoPago.Pendiente,
                EstadoPedido = EstadoPedido.Pendiente,
                PrecioTotal = precioTotal,
                Items = itemsPedido
            };

            PedidoNegocio pedidoNegocio = new PedidoNegocio();

            
            try
            {
                int idPedido = pedidoNegocio.CrearPedido(nuevoPedido);
                               
                // eliminar el carrito y sus items de la bd 
                carritoItemNegocio.EliminarItems(idCarrito);
                CarritoNegocio carritoNegocio = new CarritoNegocio();
                carritoNegocio.EliminarCarrito(idCarrito);
                Session["IdCarrito"] = null;

                lblMensaje.Text = $"Pedido creado con éxito. Número de pedido: {idPedido}";
                lblMensaje.CssClass = "text-success";
                Session["IdPedido"] = idPedido;

                // Si el método de pago es MercadoPago → Redirige al checkout
                if (nuevoPedido.MetodoPago == MetodoPago.MercadoPago)
                {
                    nuevoPedido.Id = idPedido; // importante: por si se usa como external_reference después
                    string urlPago = MercadoPagoHelper.CrearPreferencia(nuevoPedido);
                    Response.Redirect(urlPago);
                    return;
                }



            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al crear el pedido: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
            }
        }
    }
}