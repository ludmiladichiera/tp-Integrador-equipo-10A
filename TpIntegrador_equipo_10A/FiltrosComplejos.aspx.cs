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
    public partial class FiltrosComplejos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    ddlCampo.Items.Add("Nombre");
                    ddlCampo.Items.Add("Descripcion");
                    ddlCampo.Items.Add("Categoria");
                    ddlCampo.Items.Add("Precio");

                    cargarCriterios(); // inicial
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCriterios(); // se actualiza según el campo
        }

        private void cargarCriterios()
        {
            ddlCriterio.Items.Clear();
            string campoSeleccionado = ddlCampo.SelectedValue;

            if (campoSeleccionado == "Precio")
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                //validar que este completos los campos

            string campo = ddlCampo.SelectedValue;
            string filtro = txtFiltro.Text;
            string criterio = ddlCriterio.SelectedValue;
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> listaFiltrada = negocio.filtrar(campo, criterio, filtro);


                rptResultados.DataSource = listaFiltrada;
                rptResultados.DataBind();
            }
            catch (Exception)
            {

                throw;
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