<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrdenPedido.aspx.cs" Inherits="TpIntegrador_equipo_10A.OrdenPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Finalizar Pedido</h2>

    <!-- Productos del Pedido -->
    <asp:Repeater ID="rptProductosPedido" runat="server">
        <HeaderTemplate>
            <table class="table mt-4">
                <thead>
                    <tr>
                        <th>Producto</th>
                        <th>Precio</th>
                        <th>Cantidad</th>
                        <th>Subtotal</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("Producto.Nombre") %></td>
                <td>$<%# Eval("Producto.Precio", "{0:N2}") %></td>
                <td><%# Eval("Cantidad") %></td>
                <td>$<%# Eval("Subtotal", "{0:N2}") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <!-- Selección de entrega y pago -->
    <div class="form-group mt-4">
        <asp:Label ID="lblMetodoEntrega" runat="server" Text="Método de entrega"></asp:Label>
        <asp:DropDownList ID="ddlMetodoEntrega" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblFechaEntrega" runat="server" Text="Fecha de entrega"></asp:Label>
        <asp:TextBox ID="txtFechaEntrega" runat="server" CssClass="form-control" TextMode="Date" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblMetodoPago" runat="server" Text="Método de pago"></asp:Label>
        <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="form-control" />
    </div>

    <asp:Button ID="btnFinalizarPedido" runat="server" Text="Finalizar Compra" CssClass="btn btn-primary" OnClick="btnFinalizarPedido_Click" />

    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 text-danger" />
</asp:Content>