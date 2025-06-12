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
    public partial class AdminEnvio : System.Web.UI.Page
    {
        /*public List<Envio> ListaEnvios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarEnvios();
        }
        protected void cargarEnvios()
        {
            ListaEnvios = new List<Envio>();
            Envio envio = new Envio();
            envio.Id = 123;
            envio.Pedido = new Pedido { FechaEntrega = DateTime.Now.AddDays(3), FechaPedido = DateTime.Now, MetodoEntrega = "Envio", EstadoPedido = EstadoPedido.ListoParaEnviar, PrecioTotal = 9000m };
            envio.Pedido.Usuario = new Usuario { Nombre = "pepe", Apellido = "perez", Dni = "12345678", Direccion = "calle falsa 123", Ciudad = "caba", CodigoPostal = 1234, Telefono = "123456789", Mail = "pepe@ejemplo.com" };
            envio.Pedido.Items = new List<PedidoItem>();
            envio.Pedido.Items.Add(new PedidoItem { Producto = new Producto { Codigo = "tart001", Nombre = "Producto1", Precio = 50.00m }, Cantidad = 1 });
            envio.Pedido.Items.Add(new PedidoItem { Producto = new Producto { Codigo = "chegusan001", Nombre = "Producto2", Precio = 50.00m }, Cantidad = 1 });

            envio.Direccion = envio.Pedido.Usuario.Direccion;
            envio.Ciudad = envio.Pedido.Usuario.Ciudad;
            envio.CodigoPostal = envio.Pedido.Usuario.CodigoPostal;
            envio.EstadoEnvio = "En camino";
            envio.CodigoSeguimiento = "A123";
            envio.FechaEntrega = DateTime.Now;
            ddlEstadoEnvio.SelectedValue = envio.EstadoEnvio;


            if (envio.EstadoEnvio == "En camino")
            {

                txtCodigoSeguimiento.Text = envio.CodigoSeguimiento;
                txtFechaEntrega.Text = envio.FechaEntrega.ToString("yyyy-MM-dd");
                txtFechaEntrega.Enabled = false;
                txtCodigoSeguimiento.Enabled = false;
                btnModificar.Visible = false;
                ddlEstadoEnvio.Enabled = false;
            }


            if (envio.Pedido.EstadoPedido == EstadoPedido.ListoParaEnviar)
            {
                ListaEnvios.Add(envio);
            }

        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            cargarEnvios();
        }*/
    }
}