<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="TpIntegrador_equipo_10A.MenuAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid px-0">
        <!-- Barra de herramientas admin -->
        <nav class="navbar navbar-expand-lg navbar-light bg-light border-bottom shadow-sm px-3">
            <span class="navbar-brand fw-bold">Panel del Administrador</span>
            <div class="collapse navbar-collapse justify-content-end">
                <div class="navbar-nav">
                    <asp:LinkButton ID="btnPedidos" runat="server" CssClass="nav-link btn btn-outline-primary me-2 mb-1" OnClick="btnPedidos_Click">
                        <i class="bi bi-box-seam me-1"></i> Pedidos
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnEnvios" runat="server" CssClass="nav-link btn btn-outline-secondary me-2 mb-1">
                        <i class="bi bi-truck me-1"></i> Envíos
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnPerfiles" runat="server" CssClass="nav-link btn btn-outline-dark me-2 mb-1" OnClick="btnPerfiles_Click">
                        <i class="bi bi-person-lines-fill me-1"></i> Perfiles
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnABMLProducto" runat="server" CssClass="nav-link btn btn-outline-primary me-2 mb-1">
                        <i class="bi bi-receipt-cutoff me-1"></i> ABML Producto
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnABMLCategoria" runat="server" CssClass="nav-link btn btn-outline-primary me-2 mb-1">
                        <i class="bi bi-folder2-open me-1"></i> ABML Categoría
                    </asp:LinkButton>
                    <asp:LinkButton ID="btnABMLImagen" runat="server" CssClass="nav-link btn btn-outline-primary me-2 mb-1">
                        <i class="bi bi-image me-1"></i> ABML Imagen
                    </asp:LinkButton>
                </div>
            </div>
        </nav>

        <!-- place holder. DINAMICOO (en esta seccion se muestran los .ascx)-->
        <h2>place holder dinamico: "este h2 ers temporal"</h2>
        <asp:Panel ID="PanelContenedor" runat="server">
            <asp:PlaceHolder ID="phContenido" runat="server" />
        </asp:Panel>
    </div>



</asp:Content>
