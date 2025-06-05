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
    public partial class AdminPedidos : System.Web.UI.Page
    {
        public List<Pedido> ListaPedidos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPedidos();

            }
        }
        protected void cargarPedidos()
        {
            //se leeria de la base de datos y si no esta listo deberia cagar los pedidos
            Pedido peddido = new Pedido();
            peddido.Usuario = new Usuario { Nombre = "pepe", Apellido = "perez", Dni = "12345678", Direccion = "calle falsa 123", Ciudad = "caba", CodigoPostal = 1234, Telefono = "123456789", Mail = "pepe@ejemplo.com" };
            peddido.Id = 001;
            peddido.FechaPedido = DateTime.Now;
            peddido.MetodoEntrega = "envio";
            peddido.FechaEntrega = DateTime.Now.AddDays(3);
            peddido.PrecioTotal = 100.00m;
            peddido.Estado = "Cancelado";

            peddido.Items = new List<PedidoItem>();

            peddido.Items.Add(new PedidoItem { Producto = new Producto { Codigo = "tart001", Nombre = "Producto1", Precio = 50.00m }, Cantidad = 1 });
            peddido.Items.Add(new PedidoItem { Producto = new Producto { Codigo = "chegusan001", Nombre = "Producto2", Precio = 50.00m }, Cantidad = 1 });
            ListaPedidos = new List<Pedido>();
            ListaPedidos.Add(peddido);
            ddlEstado.SelectedValue = peddido.Estado;////tiene que respetar mayuscula
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            cargarPedidos();
            /* sale error porque intenta leer otra vez pero cambia el valor del estado segun id
          
            string pedidoIdStr = Request.Form["pedidoId"]; // Obtiene el ID desde el campo oculto

            if (!string.IsNullOrEmpty(pedidoIdStr) && int.TryParse(pedidoIdStr, out int pedidoID))
            {
                var pedido = ListaPedidos?.FirstOrDefault(p => p.Id == pedidoID);

                if (pedido != null)
                {
                    DropDownList ddlEstado = (DropDownList)FindControl("ddlEstado");
                    if (ddlEstado != null)
                    {
                        pedido.Estado = ddlEstado.SelectedValue;
                        ActualizarPedidos();
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('Error: No se recibió un ID válido');</script>");
            }*/
        }





        private void ActualizarPedidos()
        {

        }
    }
}