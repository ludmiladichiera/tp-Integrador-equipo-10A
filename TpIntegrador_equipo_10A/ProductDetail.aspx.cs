﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TpIntegrador_equipo_10A
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idQuery = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idQuery))
                {
                    int idProducto = int.Parse(idQuery);

                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    Producto producto = productoNegocio.ObtenerProductoId(idProducto); // ← este es tu método

                    if (producto != null)
                    {
                        // Obtener imágenes (si usás ImagenNegocio)
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        producto.Imagenes = imagenNegocio.listar(idProducto); // ← solo si tenés ese método

                        // Mostrar en la UI
                        lblNombre.Text = producto.Nombre;
                        lblDescripcion.Text = producto.Descripcion;
                        lblPrecio.Text = producto.Precio.ToString();
                        lblCategoria.Text = producto.Categoria.Descripcion;
                        lblStock.Text = producto.Stock.ToString();
                        lblUnidadVenta.Text = producto.UnidadVenta;

                        // Bind de imágenes para el carrusel
                        rptImagenes.DataSource = producto.Imagenes;
                        rptImagenes.DataBind();

                        rptIndicadores.DataSource = producto.Imagenes;
                        rptIndicadores.DataBind();
                    }
                    else
                    {
                        lblError.Text = "Producto no encontrado.";
                    }
                }
            }

        }
        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de login
                if (Session["Usuario"] == null)
                {
                    // Redirige al login con returnUrl opcional
                    Response.Redirect("Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
                    return;
                }

                // Validar ID de producto
                int idProducto = int.Parse(Request.QueryString["id"]);
                int cantidad = 1;

                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Ingrese una cantidad válida.";
                        return;
                    }
                }

                // Recuperar usuario logueado
                Usuario usuario = (Usuario)Session["Usuario"];

                // Verificar si ya tiene carrito en sesión
                if (Session["IdCarrito"] == null)
                {
                    CarritoNegocio carritoNegocio = new CarritoNegocio();
                    int nuevoIdCarrito = carritoNegocio.CrearCarrito(usuario.Id); // ← IMPORTANTE: pasar el id del usuario
                    Session["IdCarrito"] = nuevoIdCarrito;
                }

                int idCarrito = (int)Session["IdCarrito"];

                // Agregar o actualizar item
                CarritoItemNegocio itemNegocio = new CarritoItemNegocio();
                bool ok = itemNegocio.AgregarOActualizarItem(idCarrito, idProducto, cantidad);

                if (!ok)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "No hay stock suficiente para este producto.";
                    return;
                }

         ((SiteMaster)this.Master).ActualizarCantidadCarrito();

                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Producto agregado al carrito correctamente.";
            }
            catch (Exception ex)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Error al agregar producto al carrito: " + ex.Message +
                                (ex.InnerException != null ? " Detalle: " + ex.InnerException.Message : "");
            }
        }

        protected void btnComprarAhora_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de login
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
                    return;
                }

                // Validación de existencia de carrito e items
                if (Session["IdCarrito"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sinCarrito", "alert('No hay un carrito activo.');", true);
                    return;
                }

                int idCarrito = (int)Session["IdCarrito"];
                CarritoItemNegocio itemNegocio = new CarritoItemNegocio();
                var items = itemNegocio.ObtenerItems(idCarrito);

                if (items == null || items.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "carritoVacio", "alert('Tu carrito está vacío. Agregá productos antes de continuar.');", true);
                    return;
                }

                // Redirigir a la página del carrito
                Response.Redirect("Carrito.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", $"alert('Error: {ex.Message}');", true);
            }
        }
    }
}

