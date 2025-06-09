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
    public partial class MenuAdminPerfiles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuario> lista = negocio.Listar();
            if (!IsPostBack)
            {
                repPerfiles.DataSource = lista;
                repPerfiles.DataBind();
            }
            else
            {
                repPerfiles.DataSource = lista;
                repPerfiles.DataBind();

            }
        }
    }
}