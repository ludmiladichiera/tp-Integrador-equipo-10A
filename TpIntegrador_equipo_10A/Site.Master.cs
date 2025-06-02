using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpIntegrador_equipo_10A
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                Response.Redirect($"Buscar.aspx?q={Server.UrlEncode(textoBusqueda)}");
            }
        }
    }
}