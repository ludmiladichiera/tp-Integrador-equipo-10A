<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="TpIntegrador_equipo_10A.Buscar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

         <asp:Panel ID="pnlSinResultados" runat="server" Visible="false" CssClass="alert alert-warning">
            No se encontraron productos que coincidan con su búsqueda.
        </asp:Panel>

      <asp:Repeater ID="rptProductos" runat="server">
    <ItemTemplate>
        <div class="card mb-3" style="max-width: 540px;">
            <div class="row g-0">
                <div class="col-md-4">
                   <img src='<%# ObtenerUrlImagen(Container.DataItem) %>' class="img-fluid rounded-start" alt="Imagen Producto" />
                </div>
                <div class="col-md-8">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%# Eval("Descripcion") %></p>
                        <p class="card-text"><small class="text-muted">Categoría: <%# Eval("Categoria.Descripcion") %></small></p>
                        <p class="card-text"><strong>Precio: $<%# Eval("Precio") %></strong></p>

                        <!-- Acá agregás el botón para ir a ProductDetail -->
                        <a href='ProductDetail.aspx?id=<%# Eval("Id") %>' class="btn btn-primary mt-2">Ver más</a>

                    </div>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
    </div>

    <script src="https://kit.fontawesome.com/a076d05399.js" crossorigin="anonymous"></script>

</asp:Content>