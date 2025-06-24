<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialPedidos.aspx.cs" Inherits="TpIntegrador_equipo_10A.HistorialPedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblUsuario" runat="server" CssClass="mb-3 fw-bold"></asp:Label>

    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
        OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged" DataKeyNames="Id" AllowPaging="true" PageSize="10">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID Pedido" />
            <asp:BoundField DataField="FechaPedido" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="MetodoEntregaNombre" HeaderText="Método Entrega" />
            <asp:BoundField DataField="MetodoPagoNombre" HeaderText="Método Pago" />
            <asp:BoundField DataField="EstadoPagoNombre" HeaderText="Estado Pago" />
            <asp:BoundField DataField="EstadoPedidoNombre" HeaderText="Estado Pedido" />
            <asp:BoundField DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:C}" />
            <asp:CommandField ShowSelectButton="True" SelectText="Ver Detalle" />
        </Columns>
    </asp:GridView>

   <!-- Botones debajo de la grilla principal -->
    <div class="d-flex gap-2 mt-3">
        <asp:Button ID="btnVolver" runat="server" Text="Volver al listado"
            CssClass="btn btn-primary" OnClick="btnVolver_Click" Visible="false" />

        <asp:Button ID="btnCancelarPedido" runat="server" Text="Cancelar Pedido"
            CssClass="btn btn-danger" OnClick="btnCancelarPedido_Click" Visible="false" />
    </div>

    <!-- Mensaje opcional de confirmación o error -->
    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold mt-2" Visible="false"></asp:Label>


    <asp:GridView ID="gvDetalleItems" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered mt-4" Visible="false">
        <Columns>
            <asp:BoundField DataField="ProductoNombre" HeaderText="Producto" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="Precio" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>

</asp:Content>