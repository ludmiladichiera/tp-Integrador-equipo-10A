<%@ Page Title="AdminEnvio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminEnvio.aspx.cs" Inherits="TpIntegrador_equipo_10A.AdminEnvio" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
    </head>
    <div>
        <h1>
            Administración de Envios
        </h1>
    </div>
    <% 
        foreach(Dominio.Envio envio in ListaEnvios)
            {
                %>
           
            <div class="row">
  <div class="col-sm-6 mb-3 mb-sm-0">
    <div class="card">
      <div class="card-body">
        
          <h5 class="card-title">ID del envio: <%: envio.Id %> 
          <h5 class="card-title">Estado del envio: <%: envio.EstadoEnvio %> 
          <p class="card-text">Cliente: <%: envio.Pedido.Usuario.Nombre%> <%: envio.Pedido.Usuario.Apellido %></p>
          <ul>
             <% foreach (var item in envio.Pedido.Items) { %>
                <h5 class="card-text">Productos: <% Response.Write(item.Producto.Nombre); %> | Cantidad: <% Response.Write(item.Cantidad); %></h5>  
             <% } %>
          </ul>
          <p class="card-text">Fecha del pedido: <%:envio.Pedido.FechaPedido.ToString("dd/MM/yyyy") %></p>
         <p class="card-text">Fecha de entrega del pedido: <%: envio.Pedido.FechaEntrega.ToString("dd/MM/yyyy") %></p>
          <p class="card-text">Metodo entrega: <%:  envio.Pedido.MetodoEntrega %></p>
          <div>
              <label>Codigo de seguimiento</label>
          </div>
          <asp:TextBox ID="txtCodigoSeguimiento" runat="server" CssClass="form-control" Text="Coidgo de Seguimiento" placeholder="<%:envio.CodigoSeguimiento %>" Enabled="true"></asp:TextBox>
          <label>Estado del envio</label>
          <asp:DropDownList ID="ddlEstadoEnvio" runat="server" CssClass="form-select" Enabled="true">
    <asp:ListItem Text="Pendiente" Value="Pendiente" />
    <asp:ListItem Text="En camino" Value="En camino" />
    <asp:ListItem Text="Entregado" Value="Entregado" />
    <asp:ListItem Text="A retirar" Value="A retirar" />
    <asp:ListItem Text="Cancelado" Value="Cancelado" />
</asp:DropDownList>

          <label>Fecha de entrega del envio</label>
          <asp:TextBox ID="txtFechaEntrega" runat="server" CssClass="form-control" Text="Fecha de entrega del envio" placeholder="<%:envio.FechaEntrega %>" Enabled="true"></asp:TextBox>
          <input type="hidden" name="envioId" value="<% Response.Write(envio.Id); %>" />
          <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" Visible="true" />
        

      </div>
    </div>
  </div>
  

     <% }%>

    </div>
</asp:Content>
