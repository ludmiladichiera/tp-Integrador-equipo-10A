<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpIntegrador_equipo_10A._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- FUENTES -->
    <style>
        /*FUENTES*/
        @import url('https://fonts.googleapis.com/css2?family=Dancing+Script:wght@400..700&family=Fredoka:wght@400;600&display=swap');

        h1, h2, .titulo {
            font-family: "Dancing Script", cursive;
        }

        body, p, a, h3, span {
            font-family: "Fredoka", sans-serif;
        }


        /* tamano imagenes del carrusel*/
        .carousel-inner {
            height: 800px;
        }

        .imgCarrusel img {
            height: 100%;
            width: 100%;
            object-fit: cover;
            display: block;
        }
        /*tamano imagenes seccion: mas pedidos*/
        .card-img-top {
            width: 100%;
            height: 250px;
            object-fit: cover;
        }
        /*tama;o imagenes: ofertas ------- HABRIA QUE CENTRAR LA IMAGEN NO ME ACUERDO COMO SE HACE*/
        .oferta-img {
            width: 100%;
            height: 250px;
            object-fit: cover;
        }
    </style>

    <main class="container">

        <!-- 🧁 SECCIÓN CARRUSEL DE TORTAS -->

        <article class="mt-4">

            <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner rounded">
                    <div class="carousel-item active">
                        <asp:Image ID="ImageCarrusel1" runat="server" ImageUrl="https://cdn0.uncomo.com/es/posts/1/4/2/como_hacer_tarta_selva_negra_52241_orig.jpg" CssClass="d-block w-100 imgCarrusel" AlternateText="Torta 1" />
                    </div>
                    <div class="carousel-item">
                        <asp:Image ID="ImageCarrusel2" runat="server" ImageUrl="https://www.southernliving.com/thmb/_qXEROnwaluQ3Q3XjPIhpM0yM1U=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/2675801_SaveR_23326-2000-761aee90da684686816cf9e8fafd67d1-7fda54d01a594eaba1a296409addc689.jpg" CssClass="d-block w-100 imgCarrusel" AlternateText="Torta 2" />
                    </div>
                    <div class="carousel-item">
                        <asp:Image ID="ImageCarrusel3" runat="server" ImageUrl="https://i.blogs.es/45c847/15-recetas-de-tartas-que-siempre-quisiste-hacer-en-su-version-mas-facil-/1366_2000.jpeg" CssClass="d-block w-100 imgCarrusel" AlternateText="Torta 3" />
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                </button>
            </div>
        </article>

        <!-- 🎂 SECCIÓN DE PRODUCTOS DESTACADOS -->
        <article class="text-center mt-5">
            <h2 class="titulo">Productos Destacados</h2>
            <div class="row mt-4">
                <%-- Producto 1 --%>
                <div class="col-md-3 mb-4">
                    <div class="card border-0 shadow-sm">
                        <asp:Image ID="Image4" runat="server" CssClass="card-img-top" AlternateText="image" />
                        <div class="card-body">
                            <asp:Label ID="LblTituloProducto1" runat="server" CssClass="card-title titulo" />
                            <asp:Label ID="LblPrecioProducto1" runat="server" CssClass="card-text d-block mb-2" />
                            <a href="#" class="btn btn-red">Ver más</a>
                        </div>
                    </div>
                </div>
                <%-- --%>
            </div>
        </article>


        <!-- 🍽️ SECCIÓN ESPECIALIDAD DE LA CASA -->
        <article class="text-center mt-5">
            <h2 class="titulo">Especialidad de la casa</h2>
            <div class="row mt-4 justify-content-center">
                <div class="col-md-6">
                    <div class="card border-0 shadow-sm">
                        <asp:Image ID="ImgEspecialidad" runat="server" CssClass="card-img-top" AlternateText="image" />
                        <div class="card-body">
                            <asp:Label ID="LblNombreEspecialidad" runat="server" CssClass="card-title titulo" />
                            <asp:Label ID="LblDescripcionEspecialidad" runat="server" CssClass="card-text d-block mb-2" />
                            <a href="#" class="btn btn-pink">Ver más</a>
                        </div>
                    </div>
                </div>
            </div>
        </article>

        <!-- 🧑‍🍳 SECCIÓN NUESTROS CHEF -->
        <article class="text-center mt-5">
            <h2 class="titulo">Nuestros chefs</h2>
            <div class="row mt-4">
                <%-- Chef 1 --%>
                <div class="col-md-4 mb-4">
                    <div class="card border-0 shadow-sm">
                        <asp:Image ID="ImgChef1" runat="server" CssClass="card-img-top rounded-circle w-50 mx-auto mt-4" AlternateText="Chef 1" />
                        <div class="card-body">
                            <asp:Label ID="LblNombreChef1" runat="server" CssClass="card-title titulo" />
                            <asp:Label ID="LblEspecialidadChef1" runat="server" CssClass="card-text d-block mb-2" />
                        </div>
                    </div>
                </div>

                <%-- Chef 2 --%>
                <div class="col-md-4 mb-4">
                    <div class="card border-0 shadow-sm">
                        <asp:Image ID="ImgChef2" runat="server" CssClass="card-img-top rounded-circle w-50 mx-auto mt-4" AlternateText="Chef 2" />
                        <div class="card-body">
                            <asp:Label ID="LblNombreChef2" runat="server" CssClass="card-title titulo" />
                            <asp:Label ID="LblEspecialidadChef2" runat="server" CssClass="card-text d-block mb-2" />
                        </div>
                    </div>
                </div>

                <%-- Chef 3 --%>
                <div class="col-md-4 mb-4">
                    <div class="card border-0 shadow-sm">
                        <asp:Image ID="ImgChef3" runat="server" CssClass="card-img-top rounded-circle w-50 mx-auto mt-4" AlternateText="Chef 3" />
                        <div class="card-body">
                            <asp:Label ID="LblNombreChef3" runat="server" CssClass="card-title titulo" />
                            <asp:Label ID="LblEspecialidadChef3" runat="server" CssClass="card-text d-block mb-2" />
                        </div>
                    </div>
                </div>
            </div>
        </article>


    </main>

</asp:Content>
