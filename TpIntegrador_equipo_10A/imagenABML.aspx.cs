using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TpIntegrador_equipo_10A
{
    public partial class imagenABML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                txtUrl.Visible = false;
                lblUrl.Visible = false;
                lblExistente.Visible = false;


            }

            else
            {
                if (Session["imagenes"] != null)
                {
                    var imagenes = (List<Imagen>)Session["imagenes"];
                    crearTarjetasImagenes(imagenes);
                    contenedorImagenes.Visible = true;
                }
            }

        }


        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto producto = negocio.buscarXcodigo(txtCodigo.Text);
            if (producto == null)
            {
                cargarPantalla(0);
            }
            else
            {
                cargarPantalla(producto.Id);
            }
                


        }
        protected void cargarPantalla(int id)
        {
            if (id == 0)
            {
                Session.Remove("imagenes");
                contenedorImagenes.Controls.Clear();

                lblExistente.Visible = true;
                lblExistente.Text = "El producto no existe";
                lblUrl.Visible = false;
                txtUrl.Visible = false;
                btnAgregar.Visible = false;
                lblAgregadoExito.Visible = false;

            }
            else
            {

                List<Imagen> listaImagenes = obtenerImagenes(id);
                if (listaImagenes.Count == 0)
                {
                    contenedorImagenes.Visible = false;
                    lblAgregadoExito.Visible = false;
                    lblExistente.Text = "El producto no tiene imágenes";
                    lblUrl.Visible = true;
                    txtUrl.Visible = true;
                    btnAgregar.Visible = true;
                    btnAgregar.CommandArgument = id.ToString();
                }
                else
                {
                    lblExistente.Visible = false;
                    lblAgregadoExito.Visible = false;
                    Session["imagenes"] = listaImagenes;
                    crearTarjetasImagenes(listaImagenes);
                    lblUrl.Visible = true;
                    txtUrl.Visible = true;
                    btnAgregar.Visible = true;
                    btnAgregar.CommandArgument = id.ToString();
                }

            }
        }
        protected List<Imagen> obtenerImagenes(int prodID)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> listaImagenes = new List<Imagen>();
            try
            {
                listaImagenes = imagenNegocio.listar(prodID);
            }
            catch (Exception ex)
            {
                lblExistente.Text = "Error al cargar las imágenes: " + ex.Message;
            }
            return listaImagenes;
        }

        protected void crearTarjetasImagenes(List<Imagen> imagenes)
        {
            contenedorImagenes.Controls.Clear();

            int index = 0;
            foreach (var img in imagenes)
            {


                
                Panel card = new Panel();
                card.CssClass = "card m-2 d-inline-block";
                card.Style["width"] = "18rem";

                
                Image vista = new Image
                {
                    ImageUrl = img.Url,
                    CssClass = "card-img-top",
                    AlternateText = "Imagen " + index
                };

                
                Panel cardBody = new Panel();
                cardBody.CssClass = "card-body";

                Literal titulo = new Literal();
                titulo.Text = $"<h5 class='card-title'>Imagen {index + 1}</h5>";

               
                TextBox txt = new TextBox
                {
                    ID = img.Id.ToString(),
                    Text = img.Url,
                    CssClass = "form-control mb-2"
                };

                Button btnModificar = new Button
                {
                    Text = "Modificar",
                    CssClass = "btn btn-primary"
                };
                btnModificar.Command += btnModificar_Command;
                btnModificar.CommandArgument = img.Id.ToString();

                Button btnEliminar = new Button
                {
                    Text = "Eliminar",
                    CssClass = "btn btn-danger"
                };
                btnEliminar.Command += btnEliminar_Command;
                btnEliminar.CommandArgument = img.Id.ToString();

                btnModificar.CommandName = "Modificar";
                btnEliminar.CommandName = "Eliminar";

                // Agregar controles al cuerpo y luego a la tarjeta
                cardBody.Controls.Add(titulo);
                cardBody.Controls.Add(txt);

                cardBody.Controls.Add(btnModificar);

                cardBody.Controls.Add(btnEliminar);
                // Agrupar botones en un panel para alinearlos
                Panel grupoBotones = new Panel();
                grupoBotones.CssClass = "d-flex justify-content-between mt-2";


                cardBody.Controls.Add(grupoBotones);


                card.Controls.Add(vista);
                card.Controls.Add(cardBody);

                contenedorImagenes.Controls.Add(card);
                index++;
            }
        }

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            int idImagen = int.Parse(e.CommandArgument.ToString());
            lblExistente.Visible = false;

            TextBox txtUrl = (TextBox)contenedorImagenes.FindControl(idImagen.ToString());

            if (txtUrl != null)
            {
                string nuevaUrl = txtUrl.Text;

                ImagenNegocio negocioImg = new ImagenNegocio();
                negocioImg.modificarImagenPorID(idImagen, nuevaUrl);
                lblAgregadoExito.Text = "Imagen modificada correctamente";
                lblAgregadoExito.Visible = true;

                lblUrl.Visible = false;
                txtUrl.Visible = false;
                btnAgregar.Visible = false;
                int idProducto = negocioImg.obtenerIDproduto(idImagen); 
                Session["imagenes"] = negocioImg.listar(idProducto);

                contenedorImagenes.Visible = false;


            }

        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            int idImagen = int.Parse(e.CommandArgument.ToString());
            lblExistente.Visible = false;

            TextBox txtUrl = (TextBox)contenedorImagenes.FindControl(idImagen.ToString());

            if (txtUrl != null)
            {
                string nuevaUrl = txtUrl.Text;


                ImagenNegocio negocioImg = new ImagenNegocio();
                negocioImg.eliminarImagen(idImagen);

                lblAgregadoExito.Text = "Imagen eliminada";
                lblAgregadoExito.Visible = true;
                lblUrl.Visible = false;
                txtUrl.Visible = false;
                btnAgregar.Visible = false;

                int idProducto = negocioImg.obtenerIDproduto(idImagen); 
                Session["imagenes"] = negocioImg.listar(idProducto);
                contenedorImagenes.Visible = false;
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Imagen imagen = new Imagen();
            imagen.IdProducto = int.Parse(btnAgregar.CommandArgument);
            imagen.Url = txtUrl.Text;
            ImagenNegocio negocioImg = new ImagenNegocio();
            try
            {

                negocioImg.Agregar(imagen);
                lblAgregadoExito.Text = "Imagen agregada correctamente";
                lblAgregadoExito.Visible = true;

                txtUrl.Text = string.Empty;
                lblUrl.Visible = false;
                txtUrl.Visible = false;
                btnAgregar.Visible = false;
                int idProducto = negocioImg.obtenerIDproduto(imagen.Id); 
                Session["imagenes"] = negocioImg.listar(idProducto);
                contenedorImagenes.Visible = false;


            }
            catch (Exception ex)
            {
                lblAgregadoExito.Text = "Error al agregar la imagen: " + ex.Message;
                lblAgregadoExito.Visible = true;
            }

        }
    }

}

