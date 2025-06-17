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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ImagenNegocio negocio = new ImagenNegocio();
                List<string> imagenes = negocio.obtenerImagenesAleatorias(3);

                litIndicadores.Text = "";  // Limpio por si acaso

                for (int i = 0; i < imagenes.Count; i++)
                {
                    // Agregar indicadores <button>
                    string activeClass = i == 0 ? "class='active'" : "";
                    string ariaCurrent = i == 0 ? "aria-current='true'" : "";
                    litIndicadores.Text += $"<button type='button' data-bs-target='#carouselExampleIndicators' data-bs-slide-to='{i}' {activeClass} {ariaCurrent} aria-label='Slide {i + 1}'></button>";

                    // Crear item de carrusel
                    string divClass = i == 0 ? "carousel-item active" : "carousel-item";
                    string html = $@"
                <div class='{divClass}'>
                    <img src='{imagenes[i]}' class='d-block w-100 imgCarrusel' alt='Imagen {i + 1}' />
                </div>";

                    carouselInner.Controls.Add(new LiteralControl(html));
                }

                // LISTADO PRODUCTOS - primeros 6 productos
                ProductoNegocio negocioProducto = new ProductoNegocio();
                List<Producto> listaProductos = negocioProducto.listar(false);
                List<Producto> primerosSeis = listaProductos.Take(6).ToList();

                repProductos.DataSource = primerosSeis;
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
                if (url.StartsWith("/"))
                    url = url.Substring(1);
                return ResolveUrl("~/" + url);
            }
            else
            {
                return "https://via.placeholder.com/200x150?text=Sin+Imagen";
            }
        }
    }
}