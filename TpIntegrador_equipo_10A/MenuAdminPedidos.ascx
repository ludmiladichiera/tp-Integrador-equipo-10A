<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuAdminPedidos.ascx.cs" Inherits="TpIntegrador_equipo_10A.MenuAdminPedidos" %>

<style>
    .contenedor-pedidos {
        display: flex;
        flex-direction: column;
        gap: 15px;
        padding: 10px;
    }

    .pedido {
        border: 1px solid #ccc;
        padding: 15px;
        border-radius: 6px;
        background-color: #f5f5f5;
    }

    .pedido h4 {
        margin-top: 0;
    }
</style>

<div class="contenedor-pedidos">
    <asp:Repeater ID="repPedidos" runat="server">
        <ItemTemplate>
            <div class="pedido">
                <h4>Pedido N° <%# Eval("Id") %></h4>
                <p><strong>ID Usuario:</strong> <%# Eval("Usuario") %></p>
                <p><strong>Fecha Pedido:</strong> <%# Eval("FechaPedido", "{0:dd/MM/yyyy}") %></p>
                <p><strong>Método Entrega:</strong> <%# Eval("MetodoEntrega") %></p>
                <p><strong>Fecha Entrega:</strong> <%# Eval("FechaEntrega", "{0:dd/MM/yyyy}") %></p>
                <p><strong>Precio Total:</strong> $ <%# Eval("PrecioTotal") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
