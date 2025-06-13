<%@ Page Title="categoriaABML" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="categoriaABML.aspx.cs" Inherits="TpIntegrador_equipo_10A.categoriaABML" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet">

    </head>
    <div>
        <h1>
            <i class="bi bi-plus-circle"></i>Alta o Modificación de Categorías
        </h1>
    </div>
      
            <div class="mb3">
                 <asp:Label ID="lblDescripcionCat" runat="server" CssClass="form-label" AssociatedControlID="txtDescripcionCat" Text="Categoria" />
                 <asp:TextBox ID="txtDescripcionCat" AutoPostBack="true" runat="server" CssClass="form-control" placeholder="Ingrese la categoria"  OnTextChanged="txtDescripcionCat_TextChanged"/>
            </div>     
       <div>
           <asp:Label ID="lblExistente" runat="server" CssClass="form-label" Text="Categoria existente" Visible="false" />"
        </div>
    <div> <asp:Label ID="lblExito" runat="server" CssClass="form-label" Text="Exito al agregar" Visible="false"></asp:Label> </div>

    <div>
        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" Visible="false" />
    </div>
    <div>
        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" Visible="false" />
    </div>
    

       
   

</asp:Content>
