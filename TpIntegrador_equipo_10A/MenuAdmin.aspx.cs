using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpIntegrador_equipo_10A
{
    public partial class MenuAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            
            // Siempre se intenta recrear el control si hay uno guardado
            /*if (ViewState["ControlActual"] != null)
            {
                string controlPath = ViewState["ControlActual"].ToString();
                CargarControl(controlPath);
            }
            else if (!IsPostBack)
            {
                // Primera carga por defecto
                ViewState["ControlActual"] = "MenuAdminPedidos.ascx";
                CargarControl("MenuAdminPedidos.ascx");
            }*/
        }

       
        protected void btnPerfiles_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPerfil.aspx");
        }

        private void CargarControl(string controlPath)
        {
            phContenido.Controls.Clear();
            Control ctrl = LoadControl("~/" + controlPath);
            phContenido.Controls.Add(ctrl);
        }
    }
}