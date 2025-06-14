<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPerfil.aspx.cs" Inherits="TpIntegrador_equipo_10A.AdminPerfil" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblFiltro" runat="server" Text="Buscar por DNI o Mail:" AssociatedControlID="txtFiltro" />
    <asp:TextBox ID="txtFiltro" runat="server" Width="200px" />
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    
    <br /><br />
    
    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" GridLines="Both" 
    BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC" CellPadding="5" 
    CssClass="table table-striped table-bordered" EmptyDataText="No se encontraron usuarios"
    DataKeyNames="Id" OnRowCommand="gvUsuarios_RowCommand">
    
    <Columns>
        <asp:BoundField DataField="Dni" HeaderText="DNI" />
        <asp:BoundField DataField="Mail" HeaderText="Email" />
        <asp:BoundField DataField="Pass" HeaderText="Contraseña" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
        <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
        <asp:BoundField DataField="CodigoPostal" HeaderText="Código Postal" />
        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
        <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
                <%# (bool)Eval("Estado") ? "Activo" : "Inactivo" %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="TipoUsuario.Descripcion" HeaderText="Tipo Usuario" />

        <asp:ButtonField Text="Ver/Editar" CommandName="VerUsuario" ButtonType="Button" />
    </Columns>
</asp:GridView>

    <br />
<asp:Panel ID="pnlUsuarioSeleccionado" runat="server" Visible="false" CssClass="card p-3 mt-3" BorderStyle="Solid" BorderWidth="1" BorderColor="#ccc" BackColor="#f9f9f9">
    <asp:Label ID="lblUsuarioSeleccionado" runat="server" Font-Bold="true" />
    <br /><br />
    <asp:Button ID="btnModificarMail" runat="server" Text="Modificar Mail" OnClick="btnModificarMail_Click" CssClass="btn btn-primary me-2" />
    <asp:Button ID="btnModificarPass" runat="server" Text="Modificar Contraseña" OnClick="btnModificarPass_Click" CssClass="btn btn-warning me-2" />
    <asp:Button ID="btnReactivarUsuario" runat="server" Text="Reactivar Usuario" OnClick="btnReactivarUsuario_Click" CssClass="btn btn-success" />
</asp:Panel>

    <style>
        /* Estilo para la tabla (puede estar en tu archivo CSS principal también) */
        .table {
            border-collapse: collapse;
            width: 100%;
            font-family: Arial, sans-serif;
            font-size: 14px;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        .table th {
            background-color: #f2f2f2;
            text-align: left;
        }

        .table-striped tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .table-bordered {
            border: 1px solid #ccc;
        }
    </style>
</asp:Content>
