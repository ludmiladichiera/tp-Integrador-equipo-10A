<%@ Page Title="AdminPedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPedidos.aspx.cs" Inherits="TpIntegrador_equipo_10A.AdminPedidos" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
    </head>
    <div>
        <h1>
            <i class="bi bi-cart"></i>Administración de Pedidos
        </h1>
          <a href="MenuAdmin.aspx" class="btn btn-outline-danger" style="margin-top: 10px; display: inline-block;">Volver al menu admin</a>
       </div>
    <div class="col-md-4">
    <asp:Label ID="lblFiltroBusqueda" runat="server" CssClass="form-label" AssociatedControlID="ddlFiltro" Text="Filtro de Busqueda por:" />
    <div class="input-group">
        <asp:DropDownList ID="ddlFiltro" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Text="Seleccione un filtro" Value="" />
            <asp:ListItem Text="DNI" Value="DNI" />
            <asp:ListItem Text="Estado del Pedido" Value="EstadoPedido" />
            <asp:ListItem Text="Estado del Pago" Value="EstadoPago" />
        </asp:DropDownList>
        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" placeholder="Ingrese el DNI " Visible="false" />
        <asp:DropDownList ID="ddlEstadoPedidoBusqueda" runat="server" CssClass="form-select" Visible="false" />
        <asp:DropDownList ID="ddlEstadoPagoBusqueda" runat="server" CssClass="form-select" Visible="false" />
        <asp:Button ID="btnBuscarPedido" runat="server" CssClass="btn btn-outline-primary" Text="Buscar" OnClick="btnBuscarPedido_Click" Visible="false" />
    </div>
</div>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    <div class="container mt-4">
    <asp:Label ID="lblListado" runat="server" Text="Lista de Pedidos" CssClass="h4 mb-3 d-block"></asp:Label>


    <asp:GridView ID="dgvPedidos" runat="server" AutoGenerateColumns="false" GridLines="Both"
        CssClass="table table-striped table-bordered" DataKeyNames="Id"
        OnRowCommand="dgvPedidos_RowCommand" EmptyDataText="No hay pedidos pendientes.">

        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Usuario.Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Usuario.Apellido" HeaderText="Apellido" />
            <asp:BoundField DataField="FechaPedido" HeaderText="Fecha Pedido" />
            <asp:BoundField DataField="MetodoEntrega" HeaderText="Metodo Entrega" />
            <asp:BoundField DataField="FechaEntrega" HeaderText="Fecha Entrega" />
            <asp:BoundField DataField="PrecioTotal" HeaderText="Precio Total" DataFormatString="{0:C}" />
            <asp:BoundField DataField="EstadoPago" HeaderText="Estado del Pago" />
            <asp:BoundField DataField="EstadoPedido" HeaderText="Estado del Pedido" />

            

            <asp:TemplateField HeaderText="Acción">
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server"
                        Text="Editar"
                        CommandName="SeleccionarPedido"
                        CommandArgument='<%# Container.DataItemIndex %>'
                        UseSubmitBehavior="false"
                        CssClass="btn btn-warning btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="btnVolverLista" runat="server" Text="Volver a la lista completa"
        OnClick="btnVolverLista_Click" Visible="false" CssClass="btn btn-primary" />



    <!-- formulario -->
    <div class="col-md-3 mb-3">
        <asp:Label ID="lblEstadoPago" runat="server" CssClass="form-label" Text="Estado del Pago" Visible="false" />
        <asp:DropDownList ID="ddlEstadoPago" runat="server" CssClass="form-select" Visible="false">
        </asp:DropDownList>
    </div>
    <div class="col-md-3 mb-3">
         <asp:Label ID="lblEstadoPedido" runat="server" CssClass="form-label" Text="Estado del Pedido" Visible="false" />
        <asp:DropDownList ID="ddlEstadoPedido" runat="server" CssClass="form-select" Visible="false">
    </asp:DropDownList>
</div>
</div>
    <div>
    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" Visible="false" />
</div>
</asp:Content>
