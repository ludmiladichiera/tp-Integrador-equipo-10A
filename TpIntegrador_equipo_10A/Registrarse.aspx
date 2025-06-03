<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TpIntegrador_equipo_10A.Registrarse" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Dancing+Script:wght@400..700&family=Fredoka:wght@400;600&display=swap');
        h1, h2, .titulo {
            font-family: "Dancing Script", cursive;
        }
        body, p, a, h3, span {
            font-family: "Fredoka", sans-serif;
        }
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container mt-4">
                <h2 class="mb-4">Registrarse</h2>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="textEmail" class="form-label">Email <span class="text-danger">*</span></label>
                        <asp:TextBox ID="textEmail" CssClass="form-control" runat="server" TextMode="Email" />
                        <asp:RequiredFieldValidator ControlToValidate="textEmail" ErrorMessage="El email es obligatorio." CssClass="text-danger small" runat="server" Display="Dynamic" />
                        <asp:RegularExpressionValidator ControlToValidate="textEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Email inválido." CssClass="text-danger small" runat="server" Display="Dynamic" />
                    </div>

                    <div class="col-md-6">
                        <label for="textDni" class="form-label">DNI <span class="text-danger">*</span></label>
                        <asp:TextBox ID="textDni" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="textDni" ErrorMessage="El DNI es obligatorio." CssClass="text-danger small" runat="server" Display="Dynamic" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="textNombre" class="form-label">Nombre <span class="text-danger">*</span></label>
                        <asp:TextBox ID="textNombre" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="textNombre" ErrorMessage="El nombre es obligatorio." CssClass="text-danger small" runat="server" Display="Dynamic" />
                    </div>

                    <div class="col-md-6">
                        <label for="textApellido" class="form-label">Apellido <span class="text-danger">*</span></label>
                        <asp:TextBox ID="textApellido" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ControlToValidate="textApellido" ErrorMessage="El apellido es obligatorio." CssClass="text-danger small" runat="server" Display="Dynamic" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="textPassword" class="form-label">Contraseña <span class="text-danger">*</span></label>
                        <asp:TextBox ID="textPassword" CssClass="form-control" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ControlToValidate="textPassword" ErrorMessage="La contraseña es obligatoria." CssClass="text-danger small" runat="server" Display="Dynamic" />
                    </div>
                    <div class="col-md-6">
                        <label for="textConfirmPassword" class="form-label">Confirmar Contraseña <span class="text-danger">*</span></label>
                        <asp:TextBox ID="textConfirmPassword" CssClass="form-control" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ControlToValidate="textConfirmPassword" ErrorMessage="Debe confirmar la contraseña." CssClass="text-danger small" runat="server" Display="Dynamic" />
                        <asp:CompareValidator ControlToValidate="textConfirmPassword" ControlToCompare="textPassword" ErrorMessage="Las contraseñas no coinciden." CssClass="text-danger small" runat="server" Display="Dynamic" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="textDireccion" class="form-label">Dirección</label>
                        <asp:TextBox ID="textDireccion" CssClass="form-control" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <label for="textTelefono" class="form-label">Teléfono</label>
                        <asp:TextBox ID="textTelefono" CssClass="form-control" runat="server" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="textCiudad" class="form-label">Ciudad</label>
                        <asp:TextBox ID="textCiudad" CssClass="form-control" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <label for="textCodigoPostal" class="form-label">Código Postal</label>
                        <asp:TextBox ID="textCodigoPostal" CssClass="form-control" runat="server" />
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-12">
                        <asp:CheckBox ID="chkbAcepto" runat="server" Text="Acepto términos y condiciones" CssClass="form-check-input me-2" />
                        <asp:CustomValidator ID="cvAcepto" runat="server" OnServerValidate="cvAcepto_ServerValidate" ErrorMessage="Debes aceptar los términos y condiciones." CssClass="text-danger small d-block mt-1" Display="Dynamic" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12 text-end">
                        <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                    </div>
                </div>

                <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3" Visible="false" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
