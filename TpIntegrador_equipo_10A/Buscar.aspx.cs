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
    public partial class Buscar : System.Web.UI.Page
    {
        private void CargarProductos(string texto)
        {
            ProductoNegocio negocio = new ProductoNegocio(); 
            List<Producto> productos = negocio.buscarRapido(texto, false);

            if (productos != null && productos.Count > 0)
            {
                rptProductos.DataSource = productos;
                rptProductos.DataBind();
                pnlSinResultados.Visible = false;
            }
            else
            {
                rptProductos.DataSource = null;
                rptProductos.DataBind();
                pnlSinResultados.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string texto = Request.QueryString["q"];
                if (!string.IsNullOrEmpty(texto))
                {

                    CargarProductos(texto);
                }
                else
                {
                    pnlSinResultados.Visible = true;
                }
            }
        }


    }
}