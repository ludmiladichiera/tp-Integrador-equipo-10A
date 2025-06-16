<%@ Page Title="AgregarProductoAdmin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProductoAdmin.aspx.cs" Inherits="TpIntegrador_equipo_10A.AgregarProductoAdmin" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
    </head>
    <div>
        <h1>
            <i class="bi bi-plus-circle"></i>Alta de Producto
        </h1>
    </div>
    <div class="mb3">
        <div>
            <asp:Label ID="lblCodigo" runat="server" CssClass="form-label" AssociatedControlID="txtCodigo" Text="Codigo" />
        
        </div>
        <asp:TextBox ID="txtCodigo" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Ingrese el Codigo" OnTextChanged="txtCodigo_TextChanged" />
        <div>
            <asp:Label ID="lblCodigoError" runat="server" CssClass="text-danger" Text="" />
        </div>
        <div>
            <asp:Label ID="lblNombre" runat="server" CssClass="form-label" AssociatedControlID="txtNombre" Text="Nombre" />
        
        </div>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el Nombre" />
        <div>
            <asp:Label ID="lblNombreError" runat="server" CssClass="text-danger" Text="" />
        
        </div>
        <div>
            <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label" AssociatedControlID="txtDescripcion" Text="Descripción" />
        
        </div>
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Ingrese la Descripción"/>
        <div>
            <asp:Label ID="lblDescripcionError" runat="server" CssClass="text-danger" Text="" />
        
        </div>
        <div>
            <asp:Label ID="lblPrecio" runat="server" CssClass="form-label" AssociatedControlID="txtPrecio" Text="Precio" />
        
        </div>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Ingrese el Precio" />
        <div>
            <asp:Label ID="lblPrecioError" runat="server" CssClass="text-danger" Text="" />
        </div>
        <div>
            <asp:Label ID="lblStock" runat="server" CssClass="form-label" AssociatedControlID="txtStock" Text="Stock" />
        </div>
        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="Ingrese el Stock" />
        <div>
            <asp:Label ID="lblStockError" runat="server" CssClass="text-danger" Text="" />
        </div>
        <div>
            <asp:Label ID="lblUnidadVenta" runat="server" CssClass="form-label" AssociatedControlID="txtUnidadVenta" Text="Ingrese la unidad de venta" />
        </div>
        <asp:TextBox ID="txtUnidadVenta" runat="server" CssClass="form-control" placeholder="Ingrese la unidad de venta" />
        <div>
            <asp:Label ID="lblUnidadVentaError" runat="server" CssClass="text-danger" Text="" />
        </div>
        <div>
            <asp:label ID="lblCategoria" runat="server" CssClass="form-label" AssociatedControlID="ddlCategoria" Text="Categoria" />
        </div>
        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
        </asp:DropDownList>
        <div>
            <asp:Label ID="lblCategoriaError" runat="server" CssClass="text-danger" Text="" />
        </div>
        <div>
            <asp:Label ID="lblEstado" runat="server" CssClass="form-label" AssociatedControlID="ddlEstado" Text="Estado" />
        </div>
        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
            <asp:ListItem Text="Seleccione un estado" />
            <asp:ListItem Text="Inactivo" Value=0 />
            <asp:ListItem Text="Activo" Value=1 />
        </asp:DropDownList>
        <div>
            <asp:Label ID="lblEstadoError" runat="server" CssClass="text-danger" Text="" />
        </div>
        <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success mb-3" Text="Agregar Producto" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAceptar_Click" Visible="false" />
        <div>
            <asp:Label ID="lblExito" runat="server" CssClass="text-success" Text="" />
        </div> 
    </div>
</asp:Content>

