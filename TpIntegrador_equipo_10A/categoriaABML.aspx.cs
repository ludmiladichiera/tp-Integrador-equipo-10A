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
    public partial class categoriaABML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (btnEliminar.Text == "Volver")
                {
                    noVisibleTodo();
                    btnEliminar.Text = "Eliminar";
                }

            }
        }


        protected void txtDescripcionCat_TextChanged(object sender, EventArgs ee)
        {
            try
            {
                CategoriaNegocio negoCategoria = new CategoriaNegocio();
                Categoria categoria = new Categoria();
                string desc = txtDescripcionCat.Text;
                categoria = negoCategoria.categoriaXdescripcion(desc);

                if (categoria == null || categoria.Id == 0)
                {
                    lblExistente.Visible = true;
                    lblExistente.Text = "Categoria inexistente, llene todos los campos para darla de alta";

                    txtDescripcionCat.Text = "Ingrese nueva Categoria";

                    btnGuardar.Text = "Agregar";
                    btnGuardar.Visible = true;

                }
                else
                {
                    lblExistente.Visible = true;
                    lblExistente.Text = "Categoria existente";
                    txtDescripcionCat.Text = categoria.Descripcion;
                    btnGuardar.Text = "Modificar";
                    btnGuardar.Visible = true;

                }
            }
            catch (Exception ex)
            {
                lblExito.Text = ex.Message;
                lblExito.Visible = true;
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria nuevaCategoria = new Categoria();
            nuevaCategoria.Descripcion = txtDescripcionCat.Text;

            if (btnGuardar.Text == "Agregar")
            {

                negocio.agregar(nuevaCategoria);
                lblExito.Visible = true;
                lblExito.Text = "Exito al agregar";
                txtDescripcionCat.Enabled = false;
                btnEliminar.Enabled = true;
                btnEliminar.Text = "Volver";

            }
            else if (btnGuardar.Text == "Modificar")
            {
                nuevaCategoria.Descripcion = txtDescripcionCat.Text;
                negocio.Modificar(nuevaCategoria);

                lblExito.Visible = true;
                lblExito.Text = "Exito al modificar";
                txtDescripcionCat.Enabled = false;
                btnEliminar.Enabled = true;
                btnEliminar.Text = "Eliminar";
            }


        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            noVisibleTodo();
            txtDescripcionCat.Text = null;
        }
        protected void noVisibleTodo()
        {
            btnGuardar.Visible = false;
            lblExito.Visible = false;
            lblExistente.Visible = false;
        }
    }
}
