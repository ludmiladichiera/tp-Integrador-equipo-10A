<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagoFallido.aspx.cs" Inherits="TpIntegrador_equipo_10A.PagoFallido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblTitulo" runat="server" CssClass="display-6 fw-bold text-center mb-4 text-danger" Text="Pago Rechazado" />
                <asp:Label ID="lblTexto1" runat="server" Text="Hubo un problema al procesar el pago. Intente nuevamente." />
                <asp:Label ID="lblTexto2" runat="server" Text="Puede volver al carrito o contactarse con nosotros si el problema persiste." />
                <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 text-danger" />
                <br />
                <a href="Carrito.aspx" class="btn btn-warning">Volver al carrito</a>
                <a href="Contacto.aspx" class="btn btn-secondary">Contactanos</a>
            </div>
        </div>
    </div>
</asp:Content>