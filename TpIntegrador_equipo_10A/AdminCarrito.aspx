<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminCarrito.aspx.cs" Inherits="TpIntegrador_equipo_10A.AdminCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
     <div class="mb-3">
    <a href="MenuAdmin.aspx" class="btn btn-outline-danger">
        <i class="bi bi-arrow-left-circle me-1"></i> Volver al menú admin
    </a>
</div>

    <h2>Carritos con más de 4 días</h2>

    <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold d-block mb-3"></asp:Label>

    <asp:Button ID="btnEliminarCarritosViejos" runat="server" Text="Eliminar carritos viejos"
        CssClass="btn btn-danger mb-4" OnClick="btnEliminarCarritosViejos_Click" />

    <asp:GridView ID="gvCarritos" runat="server" AutoGenerateColumns="false" 
        DataKeyNames="Id" CssClass="table table-striped mb-4"
        OnSelectedIndexChanged="gvCarritos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID Carrito" />
            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creación" 
                DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Usuario.Nombre" HeaderText="Nombre Usuario" />
            <asp:BoundField DataField="Usuario.Apellido" HeaderText="Apellido Usuario" />
            <asp:CommandField ShowSelectButton="True" SelectText="Ver ítems" />
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlItems" runat="server" Visible="false">
        <h4>Items del carrito seleccionado</h4>

        <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="Producto.Nombre" HeaderText="Producto" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="Producto.Precio" HeaderText="Precio" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>