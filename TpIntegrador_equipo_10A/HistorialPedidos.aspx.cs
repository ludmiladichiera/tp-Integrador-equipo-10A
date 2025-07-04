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
    public partial class HistorialPedidos : System.Web.UI.Page
    {
        PedidoNegocio pedidoNegocio = new PedidoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = Session["usuario"] as Usuario;

                if (usuario == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                int idUsuario = usuario.Id;
                lblUsuario.Text = $"Pedidos de Usuario: {idUsuario}";

                CargarPedidos(idUsuario);
                gvDetalleItems.Visible = false;
                btnVolver.Visible = false;
            }
        }

        private void CargarPedidos(int idUsuario)
        {
            List<Pedido> pedidos = pedidoNegocio.ListarPorUsuario(idUsuario);

            // Mostrar enums como texto legible
            var pedidosMostrar = pedidos.Select(p => new
            {
                p.Id,
                FechaPedido = p.FechaPedido.ToString("dd/MM/yyyy"),
                MetodoEntregaNombre = p.MetodoEntrega.ToString(),
                MetodoPagoNombre = p.MetodoPago.ToString(),
                EstadoPagoNombre = p.EstadoPago.ToString(),
                EstadoPedidoNombre = p.EstadoPedido.ToString(),
                p.PrecioTotal
            }).ToList();

            gvPedidos.DataSource = pedidosMostrar;
            gvPedidos.DataBind();
        }

        protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPedidoSeleccionado = (int)gvPedidos.SelectedDataKey.Value;
            ViewState["IdPedidoSeleccionado"] = idPedidoSeleccionado;

            Pedido pedidoSeleccionado = pedidoNegocio.ObtenerPedidoPorId(idPedidoSeleccionado);

            if (pedidoSeleccionado != null)
            {
                var pedidoMostrar = new[]
{
    new {
        pedidoSeleccionado.Id,
        FechaPedido = pedidoSeleccionado.FechaPedido.ToString("dd/MM/yyyy"),
        MetodoEntregaNombre = pedidoSeleccionado.MetodoEntrega.ToString(),
        MetodoPagoNombre = pedidoSeleccionado.MetodoPago.ToString(),
        EstadoPagoNombre = pedidoSeleccionado.EstadoPago.ToString(),
        EstadoPedidoNombre = pedidoSeleccionado.EstadoPedido.ToString(),
        pedidoSeleccionado.PrecioTotal
    }
};


                gvPedidos.DataSource = pedidoMostrar;
                gvPedidos.DataBind();

                var detalleItems = pedidoSeleccionado.Items.Select(i => new
                {
                    ProductoNombre = i.Producto.Nombre,
                    i.Cantidad,
                    Precio = i.Precio,
                    Subtotal = i.Cantidad * i.Precio
                }).ToList();

                gvDetalleItems.DataSource = detalleItems;
                gvDetalleItems.DataBind();
                gvDetalleItems.Visible = true;
                btnVolver.Visible = true;

                // Mostrar u ocultar botón cancelar según estado
                if (pedidoSeleccionado.EstadoPedido == EstadoPedido.Pendiente || pedidoSeleccionado.EstadoPedido == EstadoPedido.Recepcionado)
                {
                    btnCancelarPedido.Visible = true;
                    lblMensaje.Visible = false;
                }
                else
                {
                    btnCancelarPedido.Visible = false;
                    lblMensaje.Text = "Este pedido no puede ser cancelado.";
                    lblMensaje.CssClass = "text-warning fw-bold";
                    lblMensaje.Visible = true;
                }
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuario"] as Usuario;

            if (usuario != null)
            {
                CargarPedidos(usuario.Id);
                gvDetalleItems.Visible = false;
                btnVolver.Visible = false;
                btnCancelarPedido.Visible = false;
                lblMensaje.Visible = false;
                //lblMensaje.Text = "";
            }
        }

        protected void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            if (ViewState["IdPedidoSeleccionado"] != null)
            {
                int idPedido = (int)ViewState["IdPedidoSeleccionado"];

                try
                {
                    Pedido pedido = pedidoNegocio.ObtenerPedidoPorId(idPedido);

                    if (pedido.EstadoPedido == EstadoPedido.Pendiente || pedido.EstadoPedido == EstadoPedido.Recepcionado)
                    {
                        pedidoNegocio.CancelarPedido(idPedido);

                        Usuario usuario = Session["usuario"] as Usuario;
                        if (usuario != null)
                        {
                            CargarPedidos(usuario.Id);
                            gvDetalleItems.Visible = false;
                            btnVolver.Visible = false;
                            btnCancelarPedido.Visible = false;

                            
                        }
                    }
                    else
                    {
                        // Mensaje de error si no es cancelable
                        
                    }
                }
                catch (Exception ex)
                {
                    // Manejar error
                }
            }
        }
    }
}