using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TpIntegrador_equipo_10A
{
    public partial class AdminCarrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarritos();
            }
        }

        private void CargarCarritos()
        {
            CarritoNegocio negocio = new CarritoNegocio();
            var carritosViejos = negocio.ListarCarritosMayoresA4Dias();

            gvCarritos.DataSource = carritosViejos;
            gvCarritos.DataBind();

            // Mostrar/ocultar el botón según si hay carritos o no
            btnEliminarCarritosViejos.Visible = carritosViejos.Count > 0;
        }

        protected void gvCarritos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCarrito = Convert.ToInt32(gvCarritos.SelectedDataKey.Value);

            CarritoItemNegocio negocio = new CarritoItemNegocio();
            var items = negocio.ObtenerItems(idCarrito);

            gvItems.DataSource = items;
            gvItems.DataBind();
            pnlItems.Visible = true;

            lblMensaje.Text = $"Mostrando {items.Count} ítems del carrito {idCarrito}.";
            lblMensaje.CssClass = "text-info";
        }
        protected void btnEliminarCarritosViejos_Click(object sender, EventArgs e)
        {
            try
            {
                CarritoNegocio negocio = new CarritoNegocio();
                negocio.EliminarCarritosViejos();

                lblMensaje.Text = "Se eliminaron correctamente los carritos con más de 4 días.";
                lblMensaje.CssClass = "text-success";

                CargarCarritos(); // refresca el grid después de eliminarlos

                // Limpiar la grilla de items porque el carrito seleccionado ya no existe
                gvItems.DataSource = null;
                gvItems.DataBind();

                pnlItems.Visible = false;

                btnEliminarCarritosViejos.Visible = false;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar carritos viejos: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
            }
        }
    }
}