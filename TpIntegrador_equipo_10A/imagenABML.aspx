<%@ Page Title="imagenABML" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="imagenABML.aspx.cs" Inherits="TpIntegrador_equipo_10A.imagenABML" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">

    </head>

    <div>
        <h1>
            <i class="bi bi-plus-circle"></i>Alta o Modificación de Imagenes
        </h1>
    </div>
    <div class="mb3">
              <asp:Label ID="lblCodigo" runat="server" CssClass="form-label" AssociatedControlID="txtCodigo" Text="Codigo" />
              <asp:TextBox ID="txtCodigo" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Ingrese el Codigo" OnTextChanged="txtCodigo_TextChanged"/>
        </div>
    <div>
        <asp:Label ID="lblExistente" runat="server" CssClass="form-label" Text="Existente" Visible="false" />
   
        </div>
    <div>
        <asp:PlaceHolder ID="contenedorImagenes" runat="server" ></asp:PlaceHolder>
    </div>

    



    </asp:Content>