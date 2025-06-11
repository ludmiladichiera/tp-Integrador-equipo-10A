<%@ Page Title="AltaModificacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaModificacion.aspx.cs" Inherits="TpIntegrador_equipo_10A.AltaModificacion" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">

    </head>
    <div>
        <h1>
            <i class="bi bi-plus-circle"></i>Alta o Modificación
        </h1>
    </div>
    <div>
           <asp:DropDownList ID="ddlSeleccion" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlSelecion_SelectedIndexChanged">
            <asp:ListItem Text="Seleccione sobre que operar" Value="0" Selected="True"/>
            <asp:ListItem Text="Categoria" value="1" />
            <asp:ListItem Text="Producto" value="2" />
            <asp:ListItem Text="Imagen" value="3" />
            </asp:DropDownList>
    </div>
    
    <div class="mb3">
                  <asp:Label ID="lblCodigo" runat="server" CssClass="form-label" AssociatedControlID="txtCodigo" Text="Codigo" />
                  <asp:TextBox ID="txtCodigo" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Ingrese el Codigo" OnTextChanged="txtCodigo_TextChanged"/>
            </div>
            <div>
                <asp:Label ID="lblExistente" runat="server" CssClass="form-label" Text="Existente" Visible="false" />
            </div>
    <div class="mb3">
              <asp:Label ID="lblNombre" runat="server" CssClass="form-label" AssociatedControlID="txtNombre" Text="Nombre" />
              <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese el Nombre"/>
        </div>
            <div class="mb3">
                 <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label" AssociatedControlID="txtDescripcion" Text="Descripcion" />
                 <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Ingrese la Descripcion" />
            </div>
            
            <div class="mb3">
                 <asp:Label ID="lblDescripcionCat" runat="server" CssClass="form-label" AssociatedControlID="txtDescripcionCat" Text="Descripcion" />
                 <asp:TextBox ID="txtDescripcionCat" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Ingrese la Descripcion"  OnTextChanged="txtDescripcionCat_TextChanged"/>
            </div>        


    <div class="mb3">
              <asp:Label ID="lblPrecio" runat="server" CssClass="form-label" AssociatedControlID="txtPrecio" Text="Precio" />
              <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" placeholder="Ingrese el Precio"/>
        </div>
    <div class="mb3">
              <asp:Label ID="lblStock" runat="server" CssClass="form-label" AssociatedControlID="txtStock" Text="Stock" />
              <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" placeholder="Ingrese el Stock"/>
        </div>
    <div class="mb3">
              <asp:Label ID="lblUnidadVenta" runat="server" CssClass="form-label" AssociatedControlID="txtUnidadVenta" Text="Unidad de venta" />
              <asp:TextBox ID="txtUnidadVenta" runat="server" CssClass="form-control" placeholder="Ingrese la Unidad de Venta"/>
        </div>

       <div>
            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"> </asp:DropDownList>
        </div>
    <br />
    <div class="mb3">
          <asp:Label ID="lblImagenURL" runat="server" CssClass="form-label" AssociatedControlID="txtImagenURL" Text="URL" />
          <asp:TextBox ID="txtImagenURL" runat="server" CssClass="form-control" placeholder="Ingrese la URL"/>
    </div>
    <div>
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" Visible="false" />
    </div>
    <div> <asp:Label ID="lblExito" runat="server" CssClass="form-label" Text="Exito al agregar" Visible="false"></asp:Label> </div>

       
   

</asp:Content>
