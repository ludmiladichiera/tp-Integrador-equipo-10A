<%@ Page Title="Listado de Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoProducto.aspx.cs" Inherits="TpIntegrador_equipo_10A.ListadoProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .contenedor-productos {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            justify-content: space-between;
        }

        .producto {
            border: 1px solid #ccc;
            padding: 10px;
            width: calc(25% - 20px); /* 4 por fila */
            box-sizing: border-box;
            text-align: center;
            background-color: #f9f9f9;
            border-radius: 8px;
            transition: transform 0.2s;
        }

        .producto:hover {
            transform: scale(1.03);
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        .producto img {
            width: 100%;
            height: 150px;
            object-fit: contain;
            margin-bottom: 10px;
        }

        @media (max-width: 992px) {
            .producto { width: calc(50% - 20px); }
        }

        @media (max-width: 600px) {
            .producto { width: 100%; }
        }
    </style>

    <div class="contenedor-productos">
        <asp:Repeater ID="repProductos" runat="server">
            <ItemTemplate>
                <div class="producto">
                    <h3><%# Eval("Nombre") %></h3>
                    <img src='<%# ObtenerUrlImagen(Container.DataItem) %>' alt='<%# Eval("Nombre") %>' />
                    <p><strong>Categoría:</strong> <%# Eval("Categoria.Descripcion") %></p>
                    <p><strong>Precio:</strong> $ <%# Eval("Precio") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>