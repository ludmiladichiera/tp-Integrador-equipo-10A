<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagoExitoso.aspx.cs" Inherits="TpIntegrador_equipo_10A.PagoExitoso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div accesskey="p" class="container">
    <div class="row">
        <div class="col-md-12">
            <div>
                <asp:Label ID="lblTitulo" runat="server" CssClass="display-6 fw-bold text-center mb-4 text-info" Text="Pago Exitoso" Visible="true" />
            </div>
            <div>
                 <asp:Label ID="lblTexto1" runat="server" Text="Su pago se ha procesado exitosamente. Gracias por su compra." Visible="true" />
            </div>
            <div>
                <asp:Label ID="lblTexto2" runat="server" Text="Si tiene alguna pregunta, no dude en contactarnos." Visible="true" />
            </div>
            <div>
                <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 text-success" />
            </div>                
            <a href="Default.aspx" class="btn btn-primary">Volver al inicio</a>
            <a href="Contacto.aspx" class="btn btn-primary">Contactanos</a>
        </div>
    </div>
</asp:Content>
