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
                // Obtener o crear el carrito
                if (Session["IdCarrito"] == null)
                {
                    idCarrito = carritoNegocio.CrearCarrito();
                    Session["IdCarrito"] = idCarrito;
                }
                else
                {
                    idCarrito = (int)Session["IdCarrito"];
                }

                CargarCarrito();
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
        }

        protected void ModificarCantidad(object source, RepeaterCommandEventArgs e)
        {
            int idProducto = int.Parse(e.CommandArgument.ToString());
            idCarrito = (int)Session["IdCarrito"];

            switch (e.CommandName)
            {
                case "Aumentar":
                    itemNegocio.ModificarCantidad(idCarrito, idProducto, 1); // suma 1
                    break;
                case "Disminuir":
                    itemNegocio.ModificarCantidad(idCarrito, idProducto, -1); // resta 1
                    break;
            }

            CargarCarrito();
        }
    }
}