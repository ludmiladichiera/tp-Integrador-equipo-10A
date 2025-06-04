using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TpIntegrador_equipo_10A
{
    public partial class AltaModificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                noVisibleTodo();
            }

        }
        protected void ddlSelecion_SelectedIndexChanged(object sender, EventArgs e)
        {


            switch (ddlSeleccion.SelectedValue)
            {
                case "0":

                    noVisibleTodo();
                    break;
                case "1"://categoria
                    noVisibleTodo();
                    lblCodigo.Visible = true;
                    txtCodigo.Visible = true;


                    break;
                case "2"://producto
                    noVisibleTodo();
                    lblCodigo.Visible = true;
                    txtCodigo.Visible = true;


                    break;
                case "3"://imagen
                    noVisibleTodo();
                    lblCodigo.Visible = true;
                    txtCodigo.Visible = true;

                    break;
                default:
                    noVisibleTodo();
                    break;
            }

        }
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void noVisibleTodo()
        {
            lblCodigo.Visible = false;
            txtCodigo.Visible = false;
            txtCodigo.Text = null;

            lblExistente.Visible = false;

            lblNombre.Visible = false;
            txtNombre.Visible = false;
            txtNombre.Text = null;

            lblDescripcion.Visible = false;
            txtDescripcion.Visible = false;
            txtDescripcion.Text = null;

            lblPrecio.Visible = false;
            txtPrecio.Visible = false;
            txtPrecio.Text = null;

            lblStock.Visible = false;
            txtStock.Visible = false;
            txtStock = null;

            lblUnidadVenta.Visible = false;
            txtUnidadVenta.Visible = false;
            txtUnidadVenta.Text = null;

            ddlCategoria.Visible = false;
            ddlCategoria.SelectedIndex = 0;

            lblImagenURL.Visible = false;
            txtImagenURL.Visible = false;
            txtImagenURL.Text = null;
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            switch (ddlSeleccion.SelectedValue)
            {
                case "1"://categoria
                    if (txtCodigo.Text == "a")
                    {
                        lblExistente.Visible = true;
                        lblExistente.Text = "Categoria existente";
                        ddlCategoria.SelectedIndex = 1;
                        lblDescripcion.Visible = true;
                        txtDescripcion.Text = ddlCategoria.SelectedItem.Text;
                        txtDescripcion.Visible = true;



                    }
                    else
                    {
                        txtDescripcion.Visible = true;
                        txtDescripcion.Visible = true;
                    }
                    break;
                case "2"://producto
                    if (txtCodigo.Text == "a")
                    {
                        lblExistente.Visible = true;
                        lblExistente.Text = "Producto existente";
                        lblNombre.Visible = true;
                        txtNombre.Text = "cargado";
                        txtNombre.Visible = true;
                        lblDescripcion.Visible = true;
                        txtDescripcion.Text = "cargado";
                        txtDescripcion.Visible = true;
                        lblPrecio.Visible = true;
                        txtPrecio.Text = "99";
                        txtPrecio.Visible = true;
                        lblStock.Visible = true;
                        txtStock.Text = "4";
                        txtStock.Visible = true;
                        lblUnidadVenta.Visible = true;
                        txtUnidadVenta.Text = "12";
                        txtUnidadVenta.Visible = true;
                        ddlCategoria.SelectedIndex = 1;
                        ddlCategoria.Visible = true;
                    }
                    else
                    {
                        lblNombre.Visible = true;
                        txtNombre.Visible = true;
                        lblDescripcion.Visible = true;
                        txtDescripcion.Visible = true;
                        lblPrecio.Visible = true;
                        txtPrecio.Visible = true;
                        lblStock.Visible = true;
                        txtStock.Visible = true;
                        lblUnidadVenta.Visible = true;
                        txtStock.Visible = true;
                        lblUnidadVenta.Visible = true;
                        txtUnidadVenta.Visible = true;
                        ddlCategoria.Visible = true;
                    }

                    break;
                case "3"://imagen
                    if (txtCodigo.Text == "a")
                    {
                        lblExistente.Visible = true;
                        lblExistente.Text = "Imagen existente";
                        lblImagenURL.Visible = true;
                        txtImagenURL.Text = "url";
                        txtImagenURL.Visible = true;
                    }
                    else
                    {
                        lblImagenURL.Visible = true;
                        txtImagenURL.Visible = true;
                    }

                    break;
            }


        }
    }
}
