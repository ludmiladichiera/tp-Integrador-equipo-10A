<%@ Page Title="imagenABML" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="imagenABML.aspx.cs" Inherits="TpIntegrador_equipo_10A.imagenABML" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />
    </head>

    <div class="container mt-4">
        <div class="row">
            <!-- 🧩 Columna izquierda: formulario original -->
            <div class="col-md-6">
                <div>
                    <h1><i class="bi bi-plus-circle"></i> Alta o Modificación de Imágenes</h1>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblCodigo" runat="server" CssClass="form-label" AssociatedControlID="txtCodigo" Text="Código" />
                    <asp:TextBox ID="txtCodigo" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Ingrese el Código" OnTextChanged="txtCodigo_TextChanged" />
                </div>

                <div>
                    <asp:Label ID="lblExistente" runat="server" CssClass="form-label" Text="Existente" Visible="false" />
                </div>

                <div>
                    <asp:PlaceHolder ID="contenedorImagenes" runat="server"></asp:PlaceHolder>
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblUrl" runat="server" CssClass="form-label" AssociatedControlID="txtUrl" Text="Nueva imagen" Visible="false" />
                    <asp:TextBox ID="txtUrl" runat="server" CssClass="form-control" placeholder="Ingrese la URL" Visible="false"></asp:TextBox>
                </div>

                <div>
                    <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar Imagen" OnClick="btnAgregar_Click" Visible="false" />
                </div>

                <div class="mb-3">
                    <asp:Label ID="lblAgregadoExito" runat="server" CssClass="form-label" Text="¡Imagen agregada con éxito!" Visible="false" />
                </div>
            </div>

            <!-- 🖼️ Columna derecha: subir desde la PC -->
            <div class="col-md-6">
                <h4>📁 Subir imagen desde tu PC</h4>

                <!-- control para cargar archivos -->
                <asp:FileUpload ID="fileImagen" runat="server" CssClass="form-control mb-2" />

                <!-- botón para subir -->
                <asp:Button ID="btnCargarImagen" runat="server" Text="Subir imagen" CssClass="btn btn-success mb-3" OnClick="btnCargarImagen_Click" />

                <!-- vista previa -->
                <asp:Image ID="imgNuevo" runat="server" CssClass="w-100 border rounded shadow" Visible="false" />
            </div>
        </div>
    </div>
</asp:Content>
