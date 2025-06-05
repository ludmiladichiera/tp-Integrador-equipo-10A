using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TpIntegrador_equipo_10A
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ActualizarCantidadCarrito();
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                Response.Redirect($"Buscar.aspx?q={Server.UrlEncode(textoBusqueda)}");
            }
        }
        private void ActualizarCantidadCarrito()
        {
            int cantidadTotal = 0;

            if (Session["IdCarrito"] != null)
            {
                int idCarrito = (int)Session["IdCarrito"];
                CarritoItemNegocio itemNegocio = new CarritoItemNegocio();
                var items = itemNegocio.ObtenerItems(idCarrito);

                if (items != null)
                {
                    cantidadTotal = items.Sum(x => x.Cantidad);
                }
            }

            // Actualizar el badge con la cantidad total
            badgeCarrito.InnerText = cantidadTotal.ToString();
        }

    }
}
    