<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpIntegrador_equipo_10A.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Iniciar sesión</h2>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="txtEmail" Text="Email:" CssClass="control-label" />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <asp:Label runat="server" AssociatedControlID="txtPassword" Text="Contraseña:" CssClass="control-label" />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
    </div>

    <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
    <a href="Registrarse.aspx" class="btn btn-primary">Registrarse</a>
    <div class="mt-3">
    <small>
        Si alguna vez estuviste registrado, perdiste tu contraseña o acceso a tu mail, 
        <a href="Contacto.aspx">contactanos</a>.
    </small>
</div>


    <asp:Label ID="Label1" runat="server" Visible="false" CssClass="text-success"></asp:Label>

</asp:Content>