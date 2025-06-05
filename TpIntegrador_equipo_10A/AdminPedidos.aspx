<%@ Page Title="AdminPedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPedidos.aspx.cs" Inherits="TpIntegrador_equipo_10A.AdminPedidos" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
    </head>
    <div>
        <h1>
            <i class="bi bi-cart"></i>Administración de Pedidos
        </h1>
    </div>
    <% 
        foreach(Dominio.Pedido pedido in ListaPedidos)
            {
                %>
           
            <div class="row">
  <div class="col-sm-6 mb-3 mb-sm-0">
    <div class="card">
      <div class="card-body">
        <ul>
    <% foreach (var item in pedido.Items) { %>
           <h5 class="card-title">Codigo: <% Response.Write(item.Producto.Codigo); %> 
          <h5 class="card-title">Productos: <% Response.Write(item.Producto.Nombre); %> | Cantidad: <% Response.Write(item.Cantidad); %></h5>
           
        
    <% } %>
</ul>
          <p class="card-text">Cliente: <%: pedido.Usuario.Nombre %> <%: pedido.Usuario.Apellido %></p>
          <p class="card-text">Email: <%: pedido.Usuario.Mail %></p>
          <p class="card-text">Teléfono: <%: pedido.Usuario.Telefono %></p>
        <p class="card-text">Fecha del pedido: <%: pedido.FechaPedido.ToString("dd/MM/yyyy") %></p>
         <p class="card-text">Fecha de entrega: <%: pedido.FechaEntrega.ToString("dd/MM/yyyy") %></p>
          <p class="card-text">Metodo entrega: <%:  pedido.MetodoEntrega %></p>
          <p class="card-text">Pago: <%:  pedido.Pago %></p>
          <p class="card-text">Precio total: <%:  pedido.PrecioTotal %></p>
          <p class="card-text">Estado: <%:  pedido.EstadoPedido %></p>
          <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
    <asp:ListItem Text="Pendiente" Value="Pendiente" />
    <asp:ListItem Text="En preparación" Value="En preparación" />
    <asp:ListItem Text="Listo" Value="Listo" />
    <asp:ListItem Text="Cancelado" Value="Cancelado" />
</asp:DropDownList>


          <input type="hidden" name="pedidoId" value="<% Response.Write(pedido.Id); %>" />
<asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />



      </div>
    </div>
  </div>
  

     <% }%>

    </div>
</asp:Content>
