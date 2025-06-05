<%@ Page Title="Detalle del Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="TpIntegrador_equipo_10A.ProductDetail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
    </head>

    <script>
        function cambiarCantidad(delta) {
            var input = document.getElementById('<%= txtCantidad.ClientID %>');
            var valorActual = parseInt(input.value) || 1;
            var nuevoValor = valorActual + delta;
            if (nuevoValor < 1) nuevoValor = 1;
            input.value = nuevoValor;
        }
    </script>

    <style>
        .carousel-control-next-icon,
        .carousel-control-prev-icon {
            background-color: rgba(0, 0, 0, 0.5);
            border-radius: 50%;
            padding: 10px;
            border: 2px solid white;
        }
    </style>

    <main class="container mt-5">
        <div class="row">

            <!-- Carrusel de imágenes -->
            <div class="col-md-6">
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                    
                    <!-- Indicadores -->
                    <div class="carousel-indicators">
                        <asp:Repeater ID="rptIndicadores" runat="server">
                            <ItemTemplate>
                                <button type="button" data-bs-target="#carouselExampleIndicators"
                                    data-bs-slide-to='<%# Container.ItemIndex %>'
                                    class='<%# Container.ItemIndex == 0 ? "active" : "" %>'
                                    aria-current='<%# Container.ItemIndex == 0 ? "true" : "false" %>'
                                    aria-label='Slide <%# Container.ItemIndex + 1 %>'>
                                </button>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <!-- Imágenes -->
                    <div class="carousel-inner">
                        <asp:Repeater ID="rptImagenes" runat="server">
                            <ItemTemplate>
                                <div class='<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>'>
                                    <img src='<%# Eval("Url") %>' class="d-block w-100 img-fluid" alt="Imagen del producto" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <!-- Controles -->
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    </button>
                </div>
            </div>

            <!-- Detalles del producto -->
            <div class="col-md-6">

                <!-- Categoría -->
                <p class="text-muted small">
                    <asp:Label ID="lblCategoria" runat="server" Text="Categoría / "></asp:Label>
                </p>

                <!-- Nombre -->
                <h2 class="fw-bold">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre del producto"></asp:Label>
                </h2>

                <!-- Precio -->
                <h4 class="text-success fw-semibold mb-3">$<asp:Label ID="lblPrecio" runat="server" Text="0.00"></asp:Label></h4>

                <!-- Descripción -->
                <p class="text-muted mb-2">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción del producto"></asp:Label>
                </p>

                <!-- Stock -->
                <p class="mb-1">Stock disponible: <asp:Label ID="lblStock" runat="server" Text="0"></asp:Label></p>

                <!-- Unidad de venta -->
                <p class="mb-4">Unidad de venta: <asp:Label ID="lblUnidadVenta" runat="server" Text="Unidad"></asp:Label></p>

                <!-- Cantidad con botones -->
                <div class="d-flex align-items-center mb-4">
                    <label for="txtCantidad" class="me-3 fw-semibold">Cantidad:</label>
                    <div class="input-group" style="width: 120px;">
                        <button type="button" class="btn btn-outline-secondary" onclick="cambiarCantidad(-1)">−</button>
                        <asp:TextBox ID="txtCantidad" runat="server" Text="1" CssClass="form-control text-center" />
                        <button type="button" class="btn btn-outline-secondary" onclick="cambiarCantidad(1)">+</button>
                    </div>
                </div>

                <!-- Botones de acción -->
                <div class="d-flex gap-2 mb-2">
                    <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn btn-outline-primary" OnClick="btnAgregarCarrito_Click" Text="Agregar al carrito" />
                    <asp:Button ID="btnComprarAhora" runat="server" Text="Comprar ahora" CssClass="btn btn-primary" />
                </div>

                <!-- Error -->
                <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-semibold"></asp:Label>

            </div>
        </div>
    </main>
</asp:Content>