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
    public partial class ListadoProducto : System.Web.UI.Page
    {
        protected List<Producto> listaProductos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                listaProductos = negocio.listar();
                Session["listaProductos"] = listaProductos;

                repProductos.DataSource = listaProductos;
                repProductos.DataBind();
            }
        }

        protected string ObtenerUrlImagen(object dataItem)
        {
            var producto = (Producto)dataItem;

            if (producto.Imagenes != null &&
                producto.Imagenes.Count > 0 &&
                !string.IsNullOrEmpty(producto.Imagenes[0].Url))
            {
                string url = producto.Imagenes[0].Url;

                // Si empieza con "/", se la quitamos
                if (url.StartsWith("/"))
                    url = url.Substring(1);

                // Retorna una URL resolviendo desde la raíz del sitio
                return ResolveUrl("~/" + url);
            }
            else
            {
                // Imagen por defecto si no tiene ninguna
                return "https://via.placeholder.com/200x150?text=Sin+Imagen";
            }
        }
    }
}