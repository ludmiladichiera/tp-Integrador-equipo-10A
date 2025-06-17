<%@ Page Title="productoABML" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="productoABML.aspx.cs" Inherits="TpIntegrador_equipo_10A.productoABML" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
    </head>
    <div>
        <h1>
            <i class="bi bi-plus-circle"></i>Gestión de Productos
        </h1>
        <a href="MenuAdmin.aspx" class="btn btn-outline-danger" style="margin-top: 10px; display: inline-block;">Volver al menu admin</a>
    </div>



    <div class="row mb-3 align-items-end">
        <!-- Agregar Producto -->
        <div class="col-md-3">
            <asp:Button ID="btnAgregarProducto" runat="server"
                Text="Agregar Producto"
                CssClass="btn btn-success w-100"
                PostBackUrl="AgregarProductoAdmin.aspx" />
        </div>

        <!-- Buscar por Código -->
        <div class="col-md-4">
            <asp:Label ID="lblBusquedaCodigo" runat="server" CssClass="form-label" AssociatedControlID="txtBusquedaCodigo" Text="Buscar por Código" />
            <div class="input-group">
                <asp:TextBox ID="txtBusquedaCodigo" runat="server" CssClass="form-control" placeholder="Ingrese el Código" />
                <asp:Button ID="btnBuscarCodigo" runat="server" CssClass="btn btn-outline-primary" Text="Buscar" OnClick="btnBuscarCodigo_Click" />
            </div>
        </div>

        <!-- Buscar por Palabra Clave -->
        <div class="col-md-5">
            <asp:Label ID="lblBusquedaClave" runat="server" CssClass="form-label" AssociatedControlID="txtBusquedaClave" Text="Buscar por Palabra Clave" />
            <div class="input-group">
                <asp:TextBox ID="txtBusquedaClave" runat="server" CssClass="form-control" placeholder="Ingrese palabra clave" />
                <asp:Button ID="btnBuscarClave" runat="server" CssClass="btn btn-outline-secondary" Text="Buscar" OnClick="btnBuscarClave_Click" />
            </div>
        </div>
    </div>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false"></asp:Label>

    <div class="container mt-4">
        <asp:Label ID="lblListado" runat="server" Text="Listado de Productos" CssClass="h4 mb-3 d-block"></asp:Label>


        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" GridLines="Both"
            CssClass="table table-striped table-bordered" DataKeyNames="Id"
            OnRowCommand="gvProductos_RowCommand" EmptyDataText="No hay productos registrados.">

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Codigo" HeaderText="Código" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />

                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <%# (bool)Eval("Estado") ? "Activo" : "Inactivo" %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Acción">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server"
                            Text="Editar"
                            CommandName="SeleccionarProducto"
                            CommandArgument='<%# Container.DataItemIndex %>'
                            UseSubmitBehavior="false"
                            CssClass="btn btn-warning btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnVolverLista" runat="server" Text="Volver a la lista completa"
            OnClick="btnVolverLista_Click" Visible="false" CssClass="btn btn-primary" />



        <!-- formulario -->
        <div class="col-md-3 mb-3">
            <asp:Label ID="lblCodigo" runat="server" CssClass="form-label" Text="Código" AssociatedControlID="txtCodigo" Visible="true" />
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ReadOnly="true" Visible="true" />
        </div>
        <div class="col-md-6 mb-3">
            <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombre" AssociatedControlID="txtNombre" Visible="false" />
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Ingrese el Nombre" Visible="false" />
        </div>
        <div class="col-md-6 mb-3">
            <asp:Label ID="lblDescripcion" runat="server" CssClass="form-label" Text="Descripción" Visible="false" />
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Ingrese la Descripción" Visible="false" />
        </div>
        <div class="col-md-3 mb-3">
            <asp:Label ID="lblPrecio" runat="server" CssClass="form-label" Text="Precio" Visible="false" />
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Placeholder="Ingrese el Precio" Visible="false" />
        </div>
        <div class="col-md-3 mb-3">
            <asp:Label ID="lblStock" runat="server" CssClass="form-label" Text="Stock" Visible="false" />
            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" Placeholder="Ingrese el Stock" Visible="false" />
        </div>
        <div class="col-md-3 mb-3">
            <asp:Label ID="lblUnidadVenta" runat="server" CssClass="form-label" Text="Unidad de Venta" Visible="false" />
            <asp:TextBox ID="txtUnidadVenta" runat="server" CssClass="form-control" Placeholder="Ingrese la Unidad de Venta" Visible="false" />
        </div>
        <div class="col-md-3 mb-3">
            <asp:Label ID="lblCategoria" runat="server" CssClass="form-label" Text="Categoría" Visible="false" />
            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" Visible="false"></asp:DropDownList>
        </div>
        <div class="col-md-3 mb-3">
            <asp:Label ID="lblEstado" runat="server" CssClass="form-label" Text="Estado" Visible="false" />
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select" Visible="false">
                <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div>

        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" Visible="false" />
    </div>




</asp:Content>
