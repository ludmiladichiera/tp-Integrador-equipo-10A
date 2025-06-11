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
    public partial class AltaModificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                noVisibleTodo();
                //Response.Write("<script>alert('La página hizo un postback');</script>");
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
                    lblDescripcionCat.Visible = true;
                    txtDescripcionCat.Visible = true;


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

            lblDescripcionCat.Visible = false;
            txtDescripcionCat.Visible = false;
            txtDescripcionCat.Text = null;

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

            lblImagenURL.Visible = false;
            txtImagenURL.Visible = false;
            txtImagenURL.Text = null;

            lblExistente.Visible=false;
            btnGuardar.Visible = false;
            lblExito.Visible = false;
        }

        protected void txtDescripcionCat_TextChanged(object sender, EventArgs ee)
        {
            
            switch (ddlSeleccion.SelectedValue)
            {
                case "1":
                    try
                    {
                        CategoriaNegocio negoCategoria = new CategoriaNegocio();
                        Categoria categoria = new Categoria();
                        string desc=txtDescripcionCat.Text;
                        categoria=negoCategoria.categoriaXdescripcion(desc);
                        
                        if (categoria == null ||categoria.Id==0)
                        {
                            lblExistente.Visible = false;
                            lblDescripcionCat.Visible = true;
                            txtDescripcionCat.Text = "Ingrese nueva Categoria";
                            txtDescripcionCat.Visible = true;
                            btnGuardar.Text = "Agregar";
                            btnGuardar.Visible = true;

                        }
                        else
                        {
                            Response.Write("<script>alert('encontro');</script>");
                            lblExistente.Visible = true;
                            lblExistente.Text = "categoria existente";
                            ddlCategoria.DataTextField = categoria.Descripcion;
                            ddlCategoria.DataValueField = categoria.Id.ToString();
                            lblDescripcionCat.Visible = true;
                            txtDescripcionCat.Text = categoria.Descripcion;
                            txtDescripcionCat.Visible = true;
                            btnGuardar.Text = "Modificar";
                            btnGuardar.Visible = true;

                        }
                    }
                    catch (Exception ex)
                    {
                        lblExito.Text = ex.Message;
                        lblExito.Visible = true;
                        Response.Write("<script>alert('errrrooror');</script>");
                    }
                    break;

            }
        }
        protected void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            switch (ddlSeleccion.SelectedValue)
            {
                
                case "2"://producto
                    try
                    {
                        ProductoNegocio negocio = new ProductoNegocio();
                        Producto prod = new Producto();
                        prod.Categoria=new Categoria();

                        prod=negocio.buscarXcodigo(txtCodigo.Text);

                        if (prod == null || prod.Id==0)
                        {
                            Response.Write("<script>alert('producto NOOOO encontrado');</script>");

                            lblNombre.Visible = true;
                            txtNombre.Text = null;
                            txtNombre.Visible = true;

                            lblDescripcion.Visible = true;
                            txtDescripcion.Text = null;
                            txtDescripcion.Visible = true;

                            lblPrecio.Visible = true;
                            txtPrecio.Text = null;
                            txtPrecio.Visible = true;

                            lblStock.Visible = true;
                            txtStock.Text = null;
                            txtStock.Visible = true;

                            lblUnidadVenta.Visible = true;
                            txtUnidadVenta.Text = null;
                            txtUnidadVenta.Visible = true;

                            ddlCategoria.Visible = true;
                            cargarDDLcat();
                            

                            btnGuardar.Text = "Agregar";
                            btnGuardar.Visible = true;


                            

                        }
                        else {
                            Response.Write("<script>alert('producto encontrado');</script>");

                            lblExistente.Visible = true;
                            lblExistente.Text = "Producto existente";

                            lblNombre.Visible = true;
                            txtNombre.Text = prod.Nombre;
                            txtNombre.Visible = true;

                            lblDescripcion.Visible = true;
                            txtDescripcion.Text = prod.Descripcion;
                            txtDescripcion.Visible = true;

                            lblPrecio.Visible = true;
                            txtPrecio.Text = prod.Precio.ToString();
                            txtPrecio.Visible = true;

                            lblStock.Visible = true;
                            txtStock.Text = prod.Stock.ToString();
                            txtStock.Visible = true;

                            lblUnidadVenta.Visible = true;
                            txtUnidadVenta.Text = prod.UnidadVenta;
                            txtUnidadVenta.Visible = true;

                            ddlCategoria.Visible = true;
                            cargarDDLcat();
                            ddlCategoria.SelectedValue = prod.Categoria.Id.ToString();

                            btnGuardar.Text = "Modificar";
                            btnGuardar.Visible = true;
                        }
                    }
                    catch(Exception ex)
                    {
                        lblExito.Text = ex.Message;
                        lblExito.Visible = true;
                        Response.Write("<script>alert('errrrooror');</script>");
                    }
                   
                    break;
                case "3"://imagen
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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

        protected void cargarDDLcat()
        {
            
            CategoriaNegocio negocio = new CategoriaNegocio();
            List<Categoria> categorias = negocio.listar();
            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (ddlSeleccion.SelectedValue)
            {
                case "1":
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    Categoria nuevaCategoria = new Categoria();
                    nuevaCategoria.Descripcion = txtDescripcionCat.Text;
                    List<Categoria> categorias = negocio.listar();
                   
                    if (btnGuardar.Text == "Agregar")
                    {
                        foreach (Categoria c in categorias)
                        {
                            if (c.Descripcion == nuevaCategoria.Descripcion)
                            {
                                lblExito.Visible = true;
                                lblExito.Text = "Categoria ya existe";
                                return;
                            }
                        }
                        negocio.agregar(nuevaCategoria);
                        lblExito.Visible = true;
                        lblExito.Text = "Exito al agregar";

                    }
                    else if (btnGuardar.Text == "Modificar")
                    {
                        nuevaCategoria.Id = int.Parse(ddlCategoria.DataValueField);
                        nuevaCategoria.Descripcion= txtDescripcionCat.Text;
                        negocio.Modificar(nuevaCategoria);
                       
                        lblExito.Visible = true;
                        lblExito.Text = "Exito al modificar";
                    }
                    break;
                case "2":
                    decimal precio;
                    int stock;
                    ProductoNegocio negocioP = new ProductoNegocio();
                    Producto nuevoProducto = new Producto();
                    nuevoProducto.Categoria = new Categoria();

                    nuevoProducto.Codigo = txtCodigo.Text;
                    nuevoProducto.Descripcion = txtDescripcion.Text;
                    nuevoProducto.Nombre = txtNombre.Text;

                    
                    if (decimal.TryParse(txtPrecio.Text, out precio))
                    {
                        nuevoProducto.Precio = precio;
                    }
                    else
                    {
                        lblExito.Text = "Ingrese un valor numérico válido";
                        lblExito.Visible = true;
                        return;
                    }

                    
                    if (int.TryParse(txtStock.Text, out stock))
                    {
                        nuevoProducto.Stock = stock;
                    }
                    else
                    {
                        lblExito.Text = "Ingrese un valor numérico válido";
                        lblExito.Visible = true;
                        return;
                    }

                    nuevoProducto.UnidadVenta = txtUnidadVenta.Text;

                    nuevoProducto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);  // ✅ Obtiene el ID correctamente
                    nuevoProducto.Categoria.Descripcion = ddlCategoria.SelectedItem.Text; // ✅ Obtiene la descripción seleccionada

                    List<Producto> productos = negocioP.listar();
                    if (btnGuardar.Text == "Agregar")
                    {
                        foreach(Producto p in productos)
                        {
                            if(txtCodigo.Text == p.Codigo) {
                                lblExito.Visible = true;
                                lblExito.Text = "El producto ya existe";
                                return;
                            }
                            
                        }
                        int id=negocioP.agregarProductoYDevolverId(nuevoProducto);
                        lblExito.Visible = true;
                        lblExito.Text = "Exito al agregar";

                    }else if(btnGuardar.Text == "Modificar")
                    {
                        nuevoProducto.Codigo= txtCodigo.Text;
                        nuevoProducto.Descripcion= txtDescripcion.Text;
                        nuevoProducto.Nombre= txtNombre.Text;

                        
                        if (decimal.TryParse(txtPrecio.Text, out precio))
                        {
                            nuevoProducto.Precio = precio;
                        }
                        else
                        {
                            lblExito.Text = "Ingrese un valor numérico válido"; 
                            lblExito.Visible = true;
                            return;
                        }

                        
                        if(int.TryParse(txtStock.Text, out stock))
                        {
                            nuevoProducto.Stock= stock;
                        }
                        else
                        {
                            lblExito.Text = "Ingrese un valor numérico válido";
                            lblExito.Visible = true;
                            return;
                        }
                        
                        nuevoProducto.UnidadVenta=txtUnidadVenta.Text;

                        nuevoProducto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                        nuevoProducto.Categoria.Descripcion = ddlCategoria.DataTextField;
                        negocioP.modificarProducto(nuevoProducto);
                        lblExito.Visible = true;
                        lblExito.Text = "Exito al modificar";

                    }

                        break;
                case "3":
                break;
            }
        }
    }
}
