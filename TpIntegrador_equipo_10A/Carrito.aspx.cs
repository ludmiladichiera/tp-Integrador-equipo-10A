using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TpIntegrador_equipo_10A
{
    public partial class Carrito : System.Web.UI.Page
    {
        List<CarritoItem> carrito = new List<CarritoItem>
        {
            new CarritoItem
            {
                Producto = new Producto { Id = 1, Nombre = "Lemon Pie", Precio = 1200 },
                Cantidad = 1
            },
            new CarritoItem {
                Producto = new Producto { Id = 2, Nombre = "Muffin", Precio = 50 },
                Cantidad = 1
            },
            new CarritoItem {
                Producto = new Producto { Id = 3, Nombre = "Pastelito", Precio = 80 },
                Cantidad = 1
            }
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }
        private void CargarCarrito()
        {
            rptCarrito.DataSource = carrito;
            rptCarrito.DataBind();
            lblTotal.Text = carrito.Sum(item => item.Subtotal).ToString("C");
        }
        protected void ModificarCantidad(object sender, RepeaterCommandEventArgs e)
        {
            int idProducto = Convert.ToInt32(e.CommandArgument);
            var carritoItem = carrito.FirstOrDefault(p => p.Producto.Id == idProducto);

            if (carritoItem != null)
            {
                if (e.CommandName == "Aumentar")
                {
                    carritoItem.incrementarCantidad();
                }
                else if (e.CommandName == "Disminuir" && carritoItem.Cantidad > 1)
                {
                    carritoItem.decrementarCantidad();
                }
            }

            CargarCarrito();
        }

    }
}