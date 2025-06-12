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
            if (IsPostBack && !string.IsNullOrEmpty(txtCodigo.Text))
            {

                ProductoNegocio negocio = new ProductoNegocio();
                Producto producto = negocio.buscarXcodigo(txtCodigo.Text);

                if (producto != null && producto.Id != 0)
                {
                    List<Imagen> imagenes = obtenerImagenes(producto.Id);
                    crearTarjetasImagenes(imagenes);
                }
            }
        }

        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto producto = negocio.buscarXcodigo(txtCodigo.Text);
            
            if (producto==null || producto.Id==0)
            {
                lblExistente.Visible = true;
               lblExistente.Text = "El producto no existe";
            }
            else 
            {
                List<Imagen> listaImagenes = obtenerImagenes(producto.Id);
                if(listaImagenes.Count == 0)
                {
                    lblExistente.Text = "El producto no tiene imágenes";
                }
                else
                {
                    crearTarjetasImagenes(listaImagenes);
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
                // Manejo de excepciones, por ejemplo, mostrar un mensaje de error
                //lblError.Text = "Error al cargar las imágenes: " + ex.Message;
            }
            return listaImagenes;
        }

        protected void crearTarjetasImagenes(List<Imagen> imagenes)
        {
            contenedorImagenes.Controls.Clear();

            int index = 0;
            foreach (var img in imagenes)
            {
                

                // Contenedor de la card
                Panel card = new Panel();
                card.CssClass = "card m-2 d-inline-block";
                card.Style["width"] = "18rem";

                // Imagen arriba (como card-img-top)
                Image vista = new Image
                {
                    ImageUrl = img.Url,
                    CssClass = "card-img-top",
                    AlternateText = "Imagen " + index
                };

                // Cuerpo de la tarjeta
                Panel cardBody = new Panel();
                cardBody.CssClass = "card-body";

                // Título opcional
                Literal titulo = new Literal();
                titulo.Text = $"<h5 class='card-title'>Imagen {index + 1}</h5>";

                // TextBox editable con la URL
                TextBox txt = new TextBox
                {
                    ID = img.Id.ToString(),
                    Text = img.Url,
                    CssClass = "form-control mb-2"
                };

                // Botón para redireccionar (opcional)
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

            // Buscar el TextBox que tiene ese ID
            TextBox txtUrl = (TextBox)contenedorImagenes.FindControl(idImagen.ToString());

            if (txtUrl != null)
            {
                string nuevaUrl = txtUrl.Text;

                // 🔥 Acá modificás la imagen en la base de datos
                ImagenNegocio negocio = new ImagenNegocio();
                negocio.modificarImagenPorID(idImagen, nuevaUrl); // Supongamos que este método existe

                lblExistente.Text = "Imagen modificada correctamente";
                lblExistente.Visible = true;
            }
        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            int idImagen = int.Parse(e.CommandArgument.ToString());

            // Buscar el TextBox que tiene ese ID
            TextBox txtUrl = (TextBox)contenedorImagenes.FindControl(idImagen.ToString());

            if (txtUrl != null)
            {
                string nuevaUrl = txtUrl.Text;

                // 🔥 Acá modificás la imagen en la base de datos
                ImagenNegocio negocio = new ImagenNegocio();
                negocio.eliminarImagen(idImagen); // Supongamos que este método existe

                lblExistente.Text = "Imagen eliminada";
                lblExistente.Visible = true;
            }
        }


    }

}