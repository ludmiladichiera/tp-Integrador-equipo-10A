<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComoComprar.aspx.cs" Inherits="TpIntegrador_equipo_10A.ComoComprar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>¿Cómo comprar?</h1>
    <p>
        Para realizar una compra en nuestra tienda online, seguí estos pasos:
    </p>
    <ol>
        <li>Buscá el producto que te interesa. Podés usar el <strong>buscador</strong> del menú de navegación si sabés qué estás buscando, o navegar por nuestras distintas <strong>categorías</strong> desde el menú.</li>
        <li>Seleccioná el producto que querés y elegí la <strong>cantidad</strong> deseada.</li>
        <li>Agregá los productos a tu <strong>carrito</strong>.</li>
        <li>Una vez que tengas todo listo en el carrito, hacé clic en el botón <strong>Comprar</strong>.</li>
        <li>Vas a recibir un <strong>correo de confirmación</strong> una vez que el pedido haya sido recibido.</li>
        <li>También te vamos a contactar por <strong>correo electrónico</strong> cuando tu pedido esté listo.</li>
    </ol>
    <p>Si tenés alguna duda durante el proceso, no dudes en escribirnos. </p>

     <asp:LinkButton href="/ListadoProducto.aspx" runat="server" Text="Ver productos" CssClass="btn btn-success" />
     <asp:LinkButton href="/Contacto.aspx" runat="server" Text="Contactanos" CssClass="btn btn-success" />
    

</asp:Content>
