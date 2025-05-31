<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpIntegrador_equipo_10A._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- FUENTES -->
    <style>
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
                        <img src="https://cdn0.uncomo.com/es/posts/1/4/2/como_hacer_tarta_selva_negra_52241_orig.jpg" class="d-block w-100 imgCarrusel" alt="Torta 1">
                    </div>
                    <div class="carousel-item">
                        <img src="https://www.southernliving.com/thmb/_qXEROnwaluQ3Q3XjPIhpM0yM1U=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/2675801_SaveR_23326-2000-761aee90da684686816cf9e8fafd67d1-7fda54d01a594eaba1a296409addc689.jpg" class="d-block w-100 imgCarrusel" alt="Torta 2">
                    </div>
                    <div class="carousel-item">
                        <img src="https://i.blogs.es/45c847/15-recetas-de-tartas-que-siempre-quisiste-hacer-en-su-version-mas-facil-/1366_2000.jpeg" class="d-block w-100 imgCarrusel" alt="Torta 3">
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
                <%-- bloque por producto --%>
                <div class="col-md-3 mb-4">
                    <div class="card border-0 shadow-sm">
                        <img src="https://sugarspunrun.com/wp-content/uploads/2022/04/Best-Chocolate-Cupcakes-1-of-1.jpg" class="card-img-top" alt="Cupcake">
                        <div class="card-body">
                            <h5 class="card-title titulo">Cupcake Arcoíris</h5>
                            <p class="card-text">$3.500</p>
                            <a href="#" class="btn btn-pink">Ver más</a>
                        </div>
                    </div>
                </div>
                <%-- --%>
                <%-- bloque por producto --%>
                <div class="col-md-3 mb-4">
                    <div class="card border-0 shadow-sm">
                        <img src="https://sugarspunrun.com/wp-content/uploads/2022/04/Best-Chocolate-Cupcakes-1-of-1.jpg" class="card-img-top" alt="Cupcake">
                        <div class="card-body">
                            <h5 class="card-title titulo">Cupcake Arcoíris</h5>
                            <p class="card-text">$3.500</p>
                            <a href="#" class="btn btn-pink">Ver más</a>
                        </div>
                    </div>
                </div>
                <%-- --%>
                <%-- bloque por producto --%>
                <div class="col-md-3 mb-4">
                    <div class="card border-0 shadow-sm">
                        <img src="https://sugarspunrun.com/wp-content/uploads/2022/04/Best-Chocolate-Cupcakes-1-of-1.jpg" class="card-img-top" alt="Cupcake">
                        <div class="card-body">
                            <h5 class="card-title titulo">Cupcake Arcoíris</h5>
                            <p class="card-text">$3.500</p>
                            <a href="#" class="btn btn-pink">Ver más</a>
                        </div>
                    </div>
                </div>
                <%-- --%>
            </div>
        </article>

        <!-- SECCIÓN DE ESPECIALIDAD DE LA CASA -->
        <article class="text-center mt-5">
            <h2 class="titulo">Especialidad de la casa</h2>
            <div class="row mt-4">
                <div class="col-md-4">
                    <img src="https://static.toiimg.com/thumb/75758092.cms?width=1200&height=900" class="img-fluid rounded oferta-img" alt="Oferta 1">
                    <h3 class="titulo mt-3">Truffle Cake</h3>
                    <a href="#" class="btn btn-outline-danger mt-2">Ver mas</a>
                </div>
                <div class="col-md-4">
                    <img src="https://ichef.bbci.co.uk/food/ic/food_16x9_1600/recipes/black_forest_gateau_43895_16x9.jpg" class="img-fluid rounded oferta-img" alt="Oferta 2">
                    <h3 class="titulo mt-3">Black Forest</h3>
                    <a href="#" class="btn btn-outline-danger mt-2">Ver mas</a>
                </div>
                <div class="col-md-4">
                    <img src="https://grainfreetable.com/wp-content/uploads/2021/07/IMG_2450.jpg" class="img-fluid rounded oferta-img" alt="Oferta 3">
                    <h3 class="titulo mt-3">Cream & Cherry</h3>
                    <a href="#" class="btn btn-outline-danger mt-2">Ver mas</a>
                </div>
            </div>
        </article>

        <!-- SECCIÓN DE NUESTROS CHEFS -->
        <article class="text-center mt-5">
            <h2 class="titulo">Nuestros CHEFS</h2>
            <div class="row mt-4">
                <div class="col-md-4">
                    <img src="https://cdn.shopify.com/s/files/1/0292/4874/9667/files/Buddy_Valastro_classic_cannoli_480x480.png?v=1670855631" class="rounded-circle" alt="Chef 1" width="120">
                    <p class="mt-2">Chef Juan</p>
                </div>
                <div class="col-md-4">
                    <img src="https://images.squarespace-cdn.com/content/v1/62b615f596fb2230e6a3a6e3/1698268020790-7USJDK5GB9SMBLWNAVFE/Alpha_3.jpg" class="rounded-circle" alt="Chef 2" width="120">
                    <p class="mt-4">Chef Jaime</p>
                </div>
                <div class="col-md-4">
                    <img src="https://cdn.shopify.com/s/files/1/0292/4874/9667/files/Buddy_Valastro_classic_cannoli_480x480.png?v=1670855631" class="rounded-circle" alt="Chef 3" width="120">
                    <p class="mt-4">Chef Alex</p>
                </div>
            </div>
        </article>

    </main>

</asp:Content>
