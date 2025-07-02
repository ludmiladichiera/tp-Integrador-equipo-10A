<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagoPendiente.aspx.cs" Inherits="TpIntegrador_equipo_10A.PagoPendiente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:Label ID="lblTitulo" runat="server" CssClass="display-6 fw-bold text-warning" Text="Pago Pendiente" />
                <div class="mt-3">
                    <asp:Label ID="lblTexto" runat="server" CssClass="text-muted" 
                        Text="Tu pago está siendo procesado. Te notificaremos por email cuando se confirme." />
                </div>
                <div class="mt-4">
                    <a href="Default.aspx" class="btn btn-primary me-2">Volver al inicio</a>
                    <a href="Contacto.aspx" class="btn btn-outline-secondary">Contactanos</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>