<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TpIntegrador_equipo_10A.Carrito" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
    </head>

    <ol class="list-group">
        <li class="list-group-item d-flex justify-content-between">
            <strong>Producto</strong>
            <strong>Subtotal</strong>
        </li>
<asp:Repeater ID="rptCarrito" runat="server" OnItemCommand="ModificarCantidad">
    <ItemTemplate>
        <li class="list-group-item d-flex justify-content-between align-items-center">
            <div>
                <%# Eval("Producto.Nombre") %> - $<%# Eval("Producto.Precio") %> x
                <asp:Button ID="btnDisminuir" runat="server" Text="-" CommandArgument='<%# Eval("Producto.Id") %>' CommandName="Disminuir" CssClass="btn btn-danger btn-sm" />
                <%# Eval("Cantidad") %>
                <asp:Button ID="btnAumentar" runat="server" Text="+" CommandArgument='<%# Eval("Producto.Id") %>' CommandName="Aumentar" CssClass="btn btn-primary btn-sm" />
                <!-- Botón de eliminar con ícono de tacho -->
                <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Producto.Id") %>' CssClass="btn btn-outline-danger btn-sm ms-2" ToolTip="Eliminar producto">
                    <i class="bi bi-trash"></i>
                </asp:LinkButton>
            </div>
            <div>
                $<%# Eval("Subtotal") %>
            </div>
        </li>
    </ItemTemplate>
</asp:Repeater>

    </ol>

    <asp:Panel ID="pnlCarritoVacio" runat="server" Visible="false" CssClass="alert alert-info mt-3">
    Tu carrito está vacío. Agregá productos para verlos aquí.
</asp:Panel>


    <h3>Total de la compra: $<asp:Label ID="lblTotal" runat="server" /></h3>

    <asp:Button ID="btnIniciarCompra" runat="server" Text="Iniciar compra" CssClass="btn btn-success" OnClick="btnIniciarCompra_Click" />
    

</asp:Content>
