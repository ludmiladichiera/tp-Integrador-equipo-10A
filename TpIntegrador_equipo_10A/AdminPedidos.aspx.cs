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
    public partial class AdminPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ver si hay sesión y si es admin, queda comentado ahora q hacemos pruebas
            /*if (Session["IdTipoUsuario"] == null || (int)Session["IdTipoUsuario"] != 2)
            {
                Response.Redirect("~/Default.aspx"); 
                return;
            }*/
            if (!IsPostBack)
            {
                ocultarTodo();
                cargarDDLestadoPago();
                cargarDDLestadoPedido();
                cargarGridPedidos();
            }
        }
        protected void ocultarTodo()
        {
            lblMensaje.Visible = false;
            lblEstadoPago.Visible = false;
            ddlEstadoPago.Visible = false;
            lblEstadoPedido.Visible = false;
            ddlEstadoPedido.Visible = false;
            btnVolverLista.Visible = false;
            btnGuardar.Visible = false;
        }
        protected void ocultarbusqueda()
        {
            ddlEstadoPagoBusqueda.Visible = false;
            ddlEstadoPedidoBusqueda.Visible = false;
            txtDni.Visible = false;
            btnBuscarPedido.Visible = false;
        }
        protected void mostrarTodo()
        {
            lblMensaje.Visible = true;
            lblEstadoPago.Visible = true;
            ddlEstadoPago.Visible = true;
            lblEstadoPedido.Visible = true;
            ddlEstadoPedido.Visible = true;
            btnVolverLista.Visible = true;
            btnGuardar.Visible = true;
        }
        protected void cargarGridPedidos()
        {
            PedidoNegocio negocio = new PedidoNegocio();
            List<Pedido> listaPedidos = negocio.Listar();
            dgvPedidos.DataSource = listaPedidos;
            dgvPedidos.DataBind();
        }
        protected void cargarDDLestadoPago()
        {
            ddlEstadoPagoBusqueda.DataSource = Enum.GetValues(typeof(EstadoPago));
            ddlEstadoPagoBusqueda.DataBind();
            ddlEstadoPago.DataSource = Enum.GetValues(typeof(EstadoPago));
            ddlEstadoPago.DataBind();
        }
        protected void cargarDDLestadoPedido()
        {
            ddlEstadoPedidoBusqueda.DataSource = Enum.GetValues(typeof(EstadoPedido));
            ddlEstadoPedidoBusqueda.DataBind();
            ddlEstadoPedido.DataSource = Enum.GetValues(typeof(EstadoPedido));
            ddlEstadoPedido.DataBind();
        }
        protected void dgvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarPedido")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idPedido = Convert.ToInt32(dgvPedidos.DataKeys[index].Value);
                try
                {
                    Pedido pedido1 = new Pedido();
                    PedidoNegocio negocio1 = new PedidoNegocio();
                    pedido1 = negocio1.ObtenerPedidoPorId(idPedido);
                    if (pedido1 == null)
                    {
                        lblMensaje.Text = "No se encontró el pedido seleccionado.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    ddlEstadoPago.SelectedValue = pedido1.EstadoPago.ToString();
                    ddlEstadoPedido.SelectedValue = pedido1.EstadoPedido.ToString();
                    mostrarTodo();
                    dgvPedidos.DataSource = new List<Pedido> { pedido1 };
                    dgvPedidos.DataBind();

                    ViewState["ModoEdicion"] = "Modificar";
                    ViewState["IdPedidoSeleccionado"] = pedido1.Id;

                    lblMensaje.Text = "";
                }
                catch (Exception ex)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Error al cargar producto: " + ex.Message;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void btnVolverLista_Click(object sender, EventArgs e)
        {
            ddlFiltro.SelectedValue = "";
            ocultarbusqueda();
            ocultarTodo();
            cargarGridPedidos();
            lblMensaje.Text = "";
            ViewState["ModoEdicion"] = null;
            ViewState["IdPedidoSeleccionado"] = null;
            ddlFiltro.Visible = true;
            lblFiltroBusqueda.Visible = true;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoNegocio negocio = new PedidoNegocio();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Pedido pedido = new Pedido();
                int idPedido = ViewState["IdPedidoSeleccionado"] != null ? Convert.ToInt32(ViewState["IdPedidoSeleccionado"]) : 0;
                if (idPedido == 0)
                {
                    lblMensaje.Text = "Debe seleccionar un pedido para modificar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                pedido.Id = idPedido;
                pedido.EstadoPago = (EstadoPago)Enum.Parse(typeof(EstadoPago), ddlEstadoPago.SelectedValue);
                pedido.EstadoPedido = (EstadoPedido)Enum.Parse(typeof(EstadoPedido), ddlEstadoPedido.SelectedValue);
                negocio.modificarEstadoPago(pedido);
                negocio.modificarEstadoPedido(pedido);
                lblMensaje.Text = "Pedido actualizado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;

                Pedido actualizado = new Pedido();
                actualizado = negocio.ObtenerPedidoPorId(idPedido);
                dgvPedidos.DataSource = new List<Pedido> { actualizado };
                dgvPedidos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar el pedido: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
            mostrarTodo();
            ocultarbusqueda();
        }

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlFiltro.SelectedValue)
            {
                case "":
                    lblMensaje.Visible = false;
                    ocultarbusqueda();
                    cargarGridPedidos();
                    if (lblMensaje.ForeColor == System.Drawing.Color.Red)
                    {
                        lblMensaje.Visible = false;
                    }

                    break;
                case "DNI":
                    txtDni.Visible = true;
                    btnBuscarPedido.Visible = true;
                    ddlEstadoPagoBusqueda.Visible = false;
                    ddlEstadoPedidoBusqueda.Visible = false;
                    if (lblMensaje.ForeColor == System.Drawing.Color.Red)
                    {
                        lblMensaje.Visible = false;
                    }
                    break;
                case "EstadoPago":
                    txtDni.Visible = false;
                    ddlEstadoPedidoBusqueda.Visible = false;
                    ddlEstadoPagoBusqueda.Visible = true;
                    btnBuscarPedido.Visible = true;
                    if (lblMensaje.ForeColor == System.Drawing.Color.Red)
                    {
                        lblMensaje.Visible = false;
                    }
                    break;
                case "EstadoPedido":
                    txtDni.Visible = false;
                    ddlEstadoPagoBusqueda.Visible = false;
                    ddlEstadoPedidoBusqueda.Visible = true;
                    btnBuscarPedido.Visible = true;
                    if (lblMensaje.ForeColor == System.Drawing.Color.Red)
                    {
                        lblMensaje.Visible = false;
                    }
                    break;
                default:
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Filtro no reconocido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    ocultarbusqueda();
                    break;
            }
        }
        protected void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            switch (ddlFiltro.SelectedValue)
            {
                case "DNI":
                    try
                    {
                        List<Pedido> pedidos = new List<Pedido>();
                        PedidoNegocio negocioPedido = new PedidoNegocio();
                        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                        List<Usuario> usuarios = usuarioNegocio.BuscarPorDniOMail(txtDni.Text.Trim());
                        if (usuarios.Count == 0)
                        {
                            lblMensaje.Visible = true;
                            lblMensaje.Text = "No se encontraron pedidos con el DNI ingresado.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            dgvPedidos.DataSource = null;
                            dgvPedidos.DataBind();
                            return;
                        }
                        else
                        {
                            if (lblMensaje.ForeColor == System.Drawing.Color.Red)
                            {
                                lblMensaje.Visible = false;
                            }
                            foreach (Usuario usuario in usuarios)
                            {
                                if (usuario != null && usuario.Id > 0)
                                {
                                    pedidos = negocioPedido.ListarPorUsuario(usuario.Id);
                                }
                            }
                            dgvPedidos.DataSource = pedidos;
                            dgvPedidos.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "Error al buscar pedidos: " + ex.Message;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }

                    break;
                case "EstadoPago":
                    try
                    {
                        List<Pedido> pedidos = new List<Pedido>();
                        PedidoNegocio negocioPedido = new PedidoNegocio();
                        int estadoPago = (int)Enum.Parse(typeof(EstadoPago), ddlEstadoPagoBusqueda.SelectedValue);
                        pedidos = negocioPedido.obtenerPedidoPorEstadoPago(estadoPago);
                        if (pedidos.Count == 0)
                        {
                            lblMensaje.Visible = true;
                            lblMensaje.Text = "No se encontraron pedidos con el estado de pago seleccionado.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            dgvPedidos.DataSource = null;
                            dgvPedidos.DataBind();
                            return;
                        }
                        else
                        {
                            if (lblMensaje.ForeColor == System.Drawing.Color.Red)
                            {
                                lblMensaje.Visible = false;
                            }
                            dgvPedidos.DataSource = pedidos;
                            dgvPedidos.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "Error al buscar pedidos: " + ex.Message;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                    break;
                case "EstadoPedido":
                    try
                    {
                        List<Pedido> pedidos = new List<Pedido>();
                        PedidoNegocio negocioPedido = new PedidoNegocio();
                        int estado = (int)Enum.Parse(typeof(EstadoPedido), ddlEstadoPedidoBusqueda.SelectedValue);
                        pedidos = negocioPedido.obtenerPedidoPorEstadoPedido(estado);
                        if (pedidos.Count == 0)
                        {
                            lblMensaje.Visible = true;
                            lblMensaje.Text = "No se encontraron pedidos con el estado seleccionado.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            dgvPedidos.DataSource = null;
                            dgvPedidos.DataBind();
                            return;
                        }
                        else
                        {
                            if (lblMensaje.ForeColor == System.Drawing.Color.Red)
                            {
                                lblMensaje.Visible = false;
                            }
                            dgvPedidos.DataSource = pedidos;
                            dgvPedidos.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "Error al buscar pedidos: " + ex.Message;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                    break;
                default:
                    lblMensaje.Text = "Debe seleccionar un filtro válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    break;
            }
        }
    }
}