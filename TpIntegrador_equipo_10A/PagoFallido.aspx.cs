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
    public partial class PagoFallido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPedido = (int)(Session["IdPedido"] ?? 0);

                if (idPedido == 0)
                {
                    lblTitulo.Text = "ERROR";
                    lblTexto1.Visible = false;
                    lblTexto2.Visible = false;
                    lblMensaje.Text = "No se encontró un pedido válido para actualizar el pago.";
                    lblMensaje.CssClass = "text-danger";
                    return;
                }

                try
                {
                    PedidoNegocio pedidoNegocio = new PedidoNegocio();
                    Pedido pedido = pedidoNegocio.ObtenerPedidoPorId(idPedido);

                    if (pedido.EstadoPago == EstadoPago.Pendiente)
                    {
                        pedido.EstadoPago = EstadoPago.Rechazado;
                        pedidoNegocio.modificarEstadoPago(pedido);
                        lblMensaje.Text = "El pago ha sido Rechazado.";
                        lblMensaje.CssClass = "text-danger";
                    }
                    else
                    {
                        lblMensaje.Text = "El estado de pago ya fue procesado previamente.";
                        lblMensaje.CssClass = "text-warning";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al actualizar el estado del pago: " + ex.Message;
                    lblMensaje.CssClass = "text-danger";
                }
            }
        }
    }
}