<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TpIntegrador_equipo_10A.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="mb-4">Mi Perfil</h2>

    <div class="row">
  <!-- Datos personales -->
  <div class="col-md-6">
    <div class="card mb-4">
      <div class="card-header fw-bold">Datos personales</div>
      <div class="card-body">
        <p><strong>DNI:</strong> <asp:Label ID="lblDNI" runat="server" /></p>
        <p><strong>Nombre:</strong> <asp:Label ID="lblNombre" runat="server" /></p>
        <p><strong>Apellido:</strong> <asp:Label ID="lblApellido" runat="server" /></p>
        <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" /></p>
        <p><strong>Teléfono:</strong> <asp:Label ID="lblTelefono" runat="server" /></p>
        <p><strong>Código Postal:</strong> <asp:Label ID="lblCP" runat="server" /></p>
        <p><strong>Ciudad:</strong> <asp:Label ID="lblCiudad" runat="server" /></p>
        <p><strong>Dirección:</strong> <asp:Label ID="lblDireccion" runat="server" /></p>

        <asp:Button ID="btnModificar" runat="server" Text="Modificar Datos" CssClass="btn btn-outline-primary w-auto" />
      </div>
    </div>
  </div>

  <!-- Acciones -->
  <div class="col-md-6 d-flex flex-column align-items-center">
    <div class="w-75">  <!-- Contenedor para limitar ancho de botones -->
      <asp:LinkButton ID="btnVerCarrito" runat="server" CssClass="btn btn-secondary w-100 mb-2">
        <i class="bi bi-cart-fill me-2"></i>Ver Carrito
      </asp:LinkButton>
      <asp:LinkButton ID="btnHistorialPedidos" runat="server" CssClass="btn btn-secondary w-100 mb-2">
        <i class="bi bi-clock-history me-2"></i>Historial de Pedidos
      </asp:LinkButton>
      <asp:LinkButton ID="btnEstadoPedido" runat="server" CssClass="btn btn-secondary w-100 mb-2">
        <i class="bi bi-hourglass-split me-2"></i>Estado del Pedido
      </asp:LinkButton>
      <asp:LinkButton ID="btnEstadoEnvio" runat="server" CssClass="btn btn-success w-100 mb-2">
        <i class="bi bi-truck me-2"></i>Estado del Envío
      </asp:LinkButton>
      <asp:LinkButton ID="btnDarseBaja" runat="server" CssClass="btn btn-danger w-100">
        <i class="bi bi-person-x-fill me-2"></i>Darse de Baja
      </asp:LinkButton>
    </div>
  </div>
</div>

</asp:Content>
