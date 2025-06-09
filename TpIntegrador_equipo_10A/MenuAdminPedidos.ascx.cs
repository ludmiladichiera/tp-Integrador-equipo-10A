using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TpIntegrador_equipo_10A
{
    public partial class MenuAdminPedidos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PedidoNegocio negocio = new PedidoNegocio();
            List<Pedido> lista = negocio.Listar();
            if (!IsPostBack)
            {
                repPedidos.DataSource = lista;
                repPedidos.DataBind();
            }
            else
            {
                repPedidos.DataSource = lista;
                repPedidos.DataBind();

            }
        }
    }
}
