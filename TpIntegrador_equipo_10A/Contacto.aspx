<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TpIntegrador_equipo_10A.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row justify-content-center">
        <div class="col-md-8">
            <h2 class="mb-4 fw-bold text-center">¿En qué podemos ayudarte?</h2>

            <div class="card p-4 shadow-sm">
                <div class="row">
                    <!-- Columna izquierda: datos -->
                    <div class="col-md-6">
                        <!-- TEMA -->
                        <div class="mb-3">
                            <asp:Label ID="lblTema" runat="server" AssociatedControlID="ddlTema" Text="Tema" CssClass="form-label text-uppercase small fw-bold" />
                            <asp:DropDownList ID="ddlTema" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Seleccionar..." Value="" />
                                <asp:ListItem Text="Consulta general" Value="1" />
                                <asp:ListItem Text="Problema con un pedido" Value="2" />
                                <asp:ListItem Text="Sugerencia" Value="3" />
                            </asp:DropDownList>
                        </div>

                        <!-- NOMBRE -->
                        <div class="mb-3">
                            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" Text="Nombre" CssClass="form-label text-uppercase small fw-bold" />
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Tu nombre" />
                        </div>

                        <!-- APELLIDO -->
                        <div class="mb-3">
                            <asp:Label ID="lblApellido" runat="server" AssociatedControlID="txtApellido" Text="Apellido" CssClass="form-label text-uppercase small fw-bold" />
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Placeholder="Tu apellido" />
                        </div>

                        <!-- EMAIL -->
                        <div class="mb-3">
                            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Text="Email" CssClass="form-label text-uppercase small fw-bold" />
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Email address" />
                        </div>
                    </div>

                    <!-- Columna derecha: mensaje -->
                    <div class="col-md-6">
                        <!-- COMENTARIOS -->
                        <div class="mb-3">
                            <asp:Label ID="lblComentarios" runat="server" AssociatedControlID="txtComentarios" Text="Mensaje" CssClass="form-label text-uppercase small fw-bold" />
                            <asp:TextBox ID="txtComentarios" runat="server" TextMode="MultiLine" Rows="10" CssClass="form-control h-100" Placeholder="Tu mensaje..." />
                        </div>
                        <!-- BOTÓN -->
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-dark w-100 fw-bold mt-3" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
