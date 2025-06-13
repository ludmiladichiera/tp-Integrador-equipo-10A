<%@ Page Title="productoABML" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productoABML.aspx.cs" Inherits="TpIntegrador_equipo_10A.productoABML" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
    </head>
    <div>
    <h1>
        <i class="bi bi-plus-circle"></i>Alta o Modificación de Productos
    </h1>
</div>

   <div class="mb3">
              <asp:Label ID="lblCodigo" runat="server" CssClass="form-label" AssociatedControlID="txtCodigo" Text="Codigo" />
              <asp:TextBox ID="txtCodigo" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Ingrese el Codigo" OnTextChanged="txtCodigo_TextChanged"/>
        </div>
        <div>
            <asp:Label ID="lblExistente" runat="server" CssClass="form-label" Text="Existente" Visible="false" />
        </div>
<div class="mb3">
          <asp:Label ID="lblNombre" runat="server" CssClass="form-label" AssociatedControlID="txtNombre" Text="Nombre" Visible="false" />
          <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el Nombre" Visible="false"/>
    </div>
        <div class="mb3">
             <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label" AssociatedControlID="txtDescripcion" Text="Descripcion" Visible="false" />
             <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Ingrese la Descripcion" Visible="false" />
        </div>
    <div class="mb3">
          <asp:Label ID="lblPrecio" runat="server" CssClass="form-label" AssociatedControlID="txtPrecio" Text="Precio"  Visible="false"/>
          <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Ingrese el Precio" Visible="false"/>
    </div>
<div class="mb3">
          <asp:Label ID="lblStock" runat="server" CssClass="form-label" AssociatedControlID="txtStock" Text="Stock" Visible="false"/>
          <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="Ingrese el Stock" Visible="false"/>
    </div>
<div class="mb3">
          <asp:Label ID="lblUnidadVenta" runat="server" CssClass="form-label" AssociatedControlID="txtUnidadVenta" Text="Unidad de venta" Visible="false" />
          <asp:TextBox ID="txtUnidadVenta" runat="server" CssClass="form-control" placeholder="Ingrese la Unidad de Venta" Visible="false"/>
    </div>
       <div>
        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"  Visible="false"> </asp:DropDownList>
    </div>
    <div>
        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select" Visible="false">
            <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
            <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
        </asp:DropDownList>  
    </div>

<div>
    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" Visible="false" />
</div>
<div>
    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" Visible="false" />
</div>
<div> <asp:Label ID="lblExito" runat="server" CssClass="form-label" Text="Exito al agregar" Visible="false"></asp:Label> </div>


</asp:Content>
