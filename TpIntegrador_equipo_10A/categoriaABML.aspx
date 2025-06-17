<%@ Page Title="categoriaABML" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="categoriaABML.aspx.cs" Inherits="TpIntegrador_equipo_10A.categoriaABML" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">
        <style>
            .btn{
                margin:2px;
            }
        </style>
    </head>

    <div class="container mt-3">
        <h1><i class="bi bi-tags-fill"></i> Gestión de Categorías</h1>
        <a href="MenuAdmin.aspx" class="btn btn-outline-danger mb-2" style="margin-top: 10px; display: inline-block;">Volver al menu admin</a> <br />
        <asp:Button ID="btnNuevaCategoria" runat="server" CssClass="btn btn-success mb-3" Text="Nueva Categoría" OnClick="btnNuevaCategoria_Click" />
        <asp:TextBox ID="txtBuscarDescripcion" runat="server" CssClass="form-control me-2" Placeholder="Buscar por descripción..." Width="250px" AutoPostBack="false" />

    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary m-2 " Text="Buscar" OnClick="btnBuscar_Click" />
        <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="false" GridLines="Both"
            CssClass="table table-striped table-bordered" DataKeyNames="Id" 
            OnRowCommand="gvCategorias_RowCommand" EmptyDataText="No hay categorías registradas.">

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <%# (bool)Eval("Estado") ? "Activo" : "Inactivo" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField Text="Ver/Editar" CommandName="SeleccionarCategoria" ButtonType="Button" />
            </Columns>
        </asp:GridView>

        <asp:Panel ID="pnlCategoria" runat="server" Visible="false" CssClass="card p-3 mt-4" BorderStyle="Solid" BorderWidth="1" BorderColor="#ccc" BackColor="#f9f9f9">
            <asp:Label ID="lblIdCategoria" runat="server" Visible="false" />

            <div class="mb-3">
                <asp:Label ID="lblDescripcionCat" runat="server" CssClass="form-label" AssociatedControlID="txtDescripcionCat" Text="Descripción de Categoría" />
                <asp:TextBox ID="txtDescripcionCat" runat="server" CssClass="form-control" placeholder="Ingrese la categoría" />
            </div>

            <asp:Label ID="lblExistente" runat="server" CssClass="form-text text-danger" Text="Categoría existente" Visible="false" />
            <asp:Label ID="lblExito" runat="server" CssClass="form-text text-success" Text="Categoría guardada exitosamente" Visible="false" />

            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary me-2" Text="Guardar cambios" OnClick="btnGuardar_Click" />
           <asp:Button ID="btnDesactivar" runat="server" CssClass="btn btn-warning me-2" Text="Desactivar" OnClick="btnDesactivar_Click" />
<asp:Button ID="btnActivar" runat="server" CssClass="btn btn-success me-2" Text="Activar" OnClick="btnActivar_Click" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelar_Click" />
        </asp:Panel>
    </div>
</asp:Content>