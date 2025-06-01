<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpIntegrador_equipo_10A._Default" %>

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
            background-color: rgba(0, 0, 0, 0.5); /* Fondo oscuro semitransparente */
            border-radius: 50%; /* Redondeado */
            padding: 10px; /* Espaciado interno */
            border: 2px solid white; /* Borde blanco */

           /* width: 40px;
            height: 40px;*/
        }
    </style>
    <main class="container mt-5">
        <div class="row">
            <!-- Carrusel -->
            <div class="col-md-6">
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel" style="max-width: 100%;">
                    <div class="carousel-inner rounded">
                        <div class="carousel-item active">
                            <asp:Image ID="ImageCarrusel1" runat="server"
                                ImageUrl="https://cdn0.uncomo.com/es/posts/1/4/2/como_hacer_tarta_selva_negra_52241_orig.jpg"
                                CssClass="d-block w-100 img-fluid rounded" AlternateText="Torta 1" />
                        </div>
                        <div class="carousel-item">
                            <asp:Image ID="ImageCarrusel2" runat="server"
                                ImageUrl="https://www.southernliving.com/thmb/_qXEROnwaluQ3Q3XjPIhpM0yM1U=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/2675801_SaveR_23326-2000-761aee90da684686816cf9e8fafd67d1-7fda54d01a594eaba1a296409addc689.jpg"
                                CssClass="d-block w-100 img-fluid rounded" AlternateText="Torta 2" />
                        </div>
                        <div class="carousel-item">
                            <asp:Image ID="ImageCarrusel3" runat="server"
                                ImageUrl="https://i.blogs.es/45c847/15-recetas-de-tartas-que-siempre-quisiste-hacer-en-su-version-mas-facil-/1366_2000.jpeg"
                                CssClass="d-block w-100 img-fluid rounded" AlternateText="Torta 3" />
                        </div>
                    </div>
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
                    <asp:Label ID="lblCategoria" runat="server" Text="categoria /"></asp:Label>
                </p>

                <!-- Nombre producto -->
                <h2 class="fw-bold">
                    <asp:Label ID="lblNombreProducto" runat="server" Text="Nombre producto"></asp:Label>
                </h2>

                <!-- Precio -->
                <h4 class="text-success fw-semibold mb-3">$<asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
                </h4>

                <!-- Descripción -->
                <p class="text-muted mb-4">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion producto"></asp:Label>
                </p>

                <!-- Selector de cantidad con botones -->
                <div class="d-flex align-items-center mb-4">
                    <label for="txtCantidad" class="me-3 fw-semibold">Cantidad:</label>
                    <div class="input-group" style="width: 120px;">
                        <button type="button" class="btn btn-outline-secondary" onclick="cambiarCantidad(-1)">−</button>
                        <asp:TextBox ID="txtCantidad" runat="server" Text="1" CssClass="form-control text-center" />
                        <button type="button" class="btn btn-outline-secondary" onclick="cambiarCantidad(1)">+</button>
                    </div>
                </div>

                <!-- Botones -->
                <div class="d-flex gap-2">
                    <button type="button" class="btn btn-outline-primary">
                        <i class="bi bi-cart3 me-2"></i>Agregar al carrito
                    </button>
                    <asp:Button ID="btnComprarAhora" runat="server" Text="Comprar ahora" CssClass="btn btn-primary" />
                </div>
            </div>
    </main>

</asp:Content>
