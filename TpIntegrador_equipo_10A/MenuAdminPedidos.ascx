<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuAdminPedidos.ascx.cs" Inherits="TpIntegrador_equipo_10A.MenuAdminPedidos" %>

<style>
    .card {
        background-color: #ECEFF1;
    }
</style>

<div class="container">
    <h2 class="text-center titulo pt-2 ">Pedidos</h2>
    <div class="row mt-4">
        <asp:Repeater ID="repPedidos" runat="server">
            <ItemTemplate>
                <div class="col-md-4 mb-4">
                    <div class="card border-0 shadow h-100">
                        <div class="card-body">
                            <h5 class="card-title">Pedido N° <%# Eval("Id") %></h5>
                            <p class="card-text mb-1"><strong>ID Usuario:</strong> <%# Eval("Usuario") %></p>
                            <p class="card-text mb-1"><strong>Fecha Pedido:</strong> <%# Eval("FechaPedido", "{0:dd/MM/yyyy}") %></p>
                            <p class="card-text mb-1"><strong>Método Entrega:</strong> <%# Eval("MetodoEntrega") %></p>
                            <p class="card-text mb-1"><strong>Fecha Entrega:</strong> <%# Eval("FechaEntrega", "{0:dd/MM/yyyy}") %></p>
                            <p class="card-text"><strong>Precio Total:</strong> $ <%# Eval("PrecioTotal") %></p>

                            <div class="mb-2">
                                <asp:Label ID="LblEstado" runat="server" CssClass="badge bg-secondary">
                                </asp:Label>
                            </div>

                            <div class="mb-2">
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select form-select-sm">
                                    <asp:ListItem Text="Pendiente" Value="Pendiente" />
                                    <asp:ListItem Text="Enviado" Value="Enviado" />
                                    <asp:ListItem Text="Entregado" Value="Entregado" />
                                </asp:DropDownList>
                            </div>

                            <div class="d-flex justify-content-between">
                                <asp:Button ID="btnCambiarEstado" runat="server" CssClass="btn btn-outline-primary btn-sm" Text="Cambiar estado" />
                                <a href="#" class="btn btn-outline-danger btn-sm">Ver más</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

