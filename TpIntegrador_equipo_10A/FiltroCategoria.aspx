<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FiltroCategoria.aspx.cs" Inherits="TpIntegrador_equipo_10A.FiltroCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblTitulo" runat="server" CssClass="titulo-pagina" />

   <div class="contenedor-productos">
    <div class="row">
        <asp:Repeater ID="repProductos" runat="server">
            <ItemTemplate>
                <div class="col-md-4 mb-4"> <!-- 3 columnas por fila -->
                    <div class="producto card h-100">
                        <img src='<%# ObtenerUrlImagen(Container.DataItem) %>' alt='<%# Eval("Nombre") %>' class="card-img-top img-fluid" style="max-height:200px; object-fit:cover;" />
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><strong>Categoría:</strong> <%# Eval("Categoria.Descripcion") %></p>
                            <p class="card-text"><strong>Precio:</strong> $ <%# Eval("Precio") %></p>
                            <a href='<%# Eval("Id", "ProductDetail.aspx?id={0}") %>' class="btn btn-primary mt-auto">Ver más</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>


</asp:Content>
