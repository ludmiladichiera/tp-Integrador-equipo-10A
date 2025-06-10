<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuAdminPerfiles.ascx.cs" Inherits="TpIntegrador_equipo_10A.MenuAdminPerfiles" %>
<style>
    .card {
        background-color: #ECEFF1;
    }
</style>
<div class="container">
    <div class="row pt-3">
        <asp:Repeater ID="repPerfiles" runat="server">
            <ItemTemplate>
                <div class="col-md-4 mb-4">
                    <div class="card border-0 shadow h-100">
                        <div class="card-body">
                            <h5 class="card-title mb-2"><%# Eval("Nombre") %> <%# Eval("Apellido") %></h5>
                            <p class="card-text mb-1"><strong>ID Usuario:</strong> <%# Eval("Id") %></p>
                            <p class="card-text mb-1"><strong>DNI:</strong> <%# Eval("Dni") %></p>
                            <p class="card-text mb-1"><strong>Mail:</strong> <%# Eval("Mail") %></p>
                            <p class="card-text mb-1">
                                <asp:Label ID="lblTipoUsuario" runat="server" />
                            </p>
                            <p class="card-text mb-1"><strong>Dirección:</strong> <%# Eval("Direccion") %></p>
                            <p class="card-text mb-1"><strong>Ciudad:</strong> <%# Eval("Ciudad") %></p>
                            <p class="card-text mb-1"><strong>Código Postal:</strong> <%# Eval("CodigoPostal") %></p>
                            <p class="card-text"><strong>Teléfono:</strong> <%# Eval("Telefono") %></p>

                            <div class="d-flex justify-content-end">
                                <a href="#" class="btn btn-outline-danger btn-sm">Ver más</a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
