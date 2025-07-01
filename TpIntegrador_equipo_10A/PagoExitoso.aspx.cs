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
    public partial class PagoExitoso : System.Web.UI.Page
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
                    lblMensaje.Text = "No se encontró un pedido válido.";
                    lblMensaje.CssClass = "text-danger";
                    return;
                }
                else
                {
                    PedidoNegocio pedidoNegocio = new PedidoNegocio();
                    Pedido pedido = pedidoNegocio.ObtenerPedidoPorId(idPedido);
                    pedido.EstadoPago = EstadoPago.Abonado;
                    pedidoNegocio.modificarEstadoPago(pedido);

                }

            }
            else
            {
                // Si la página se está recargando por un postback, podrías manejarlo aquí.
                // Por ejemplo, podrías actualizar información o manejar eventos específicos.
                lblMensaje.Text = "¡Gracias por su paciencia! Su pago ha sido procesado correctamente.";
            }
        }
    }
}