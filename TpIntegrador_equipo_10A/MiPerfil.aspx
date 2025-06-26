<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TpIntegrador_equipo_10A.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="mb-4">Mi Perfil</h2>

    <div class="row">
        <!-- Columna izquierda: Datos personales + Cambiar Contraseña -->
        <div class="col-md-6">
            <div class="card mb-4">
                <div class="card-header fw-bold">Datos personales</div>
                <div class="card-body">
                    <p><strong>DNI:</strong>
                        <asp:Label ID="lblDNI" runat="server" /></p>
                    <p><strong>Nombre:</strong>
                        <asp:Label ID="lblNombre" runat="server" /></p>
                    <p><strong>Apellido:</strong>
                        <asp:Label ID="lblApellido" runat="server" /></p>
                    <p><strong>Email:</strong>
                        <asp:Label ID="lblEmail" runat="server" /></p>
                    <p><strong>Teléfono:</strong>
                        <asp:Label ID="lblTelefono" runat="server" /></p>
                    <p><strong>Código Postal:</strong>
                        <asp:Label ID="lblCP" runat="server" /></p>
                    <p><strong>Ciudad:</strong>
                        <asp:Label ID="lblCiudad" runat="server" /></p>
                    <p><strong>Dirección:</strong>
                        <asp:Label ID="lblDireccion" runat="server" /></p>
                </div>
            </div>

            <!-- Panel cambiar contraseña abajo, igual estilo que modificar datos -->
            <asp:Panel ID="pnlCambiarContrasenia" runat="server" Visible="false" CssClass="card p-4 mt-4 mx-auto" Style="max-width: 600px;">
                <h5><i class="bi bi-key-fill me-2"></i>Cambiar Contraseña</h5>

                <asp:Label ID="lblErrorContrasenia" runat="server" ForeColor="red" Visible="false"></asp:Label>

                <div class="mb-3">
                    <asp:Label runat="server" Text="Contraseña Actual" AssociatedControlID="txtContraseniaActual" />
                    <asp:TextBox ID="txtContraseniaActual" runat="server" TextMode="Password" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label runat="server" Text="Nueva Contraseña" AssociatedControlID="txtNuevaContrasenia" />
                    <asp:TextBox ID="txtNuevaContrasenia" runat="server" TextMode="Password" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <asp:Label runat="server" Text="Confirmar Nueva Contraseña" AssociatedControlID="txtConfirmarContrasenia" />
                    <asp:TextBox ID="txtConfirmarContrasenia" runat="server" TextMode="Password" CssClass="form-control" />
                </div>

                <div class="d-flex justify-content-end">
                    <asp:Button ID="btnCambiarContrasenia" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary me-2" OnClick="btnCambiarContrasenia_Click" />
                    <asp:Button ID="btnCancelarCambioContrasenia" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelarCambioContrasenia_Click" />
                </div>
            </asp:Panel>
        </div>

        <!-- Columna derecha: Botones de acción -->
        <div class="col-md-6 d-flex flex-column align-items-center">
            <div class="w-75">
                <!-- Botones comunes -->
                <a href="HistorialPedidos.aspx" class="btn btn-secondary w-100 mb-3">
                    <i class="bi bi-clock-history me-2"></i>Historial de Pedidos
                </a>

                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnModificar_Click"
                    CssClass="btn btn-secondary w-100 mb-3">
                    <i class="bi bi-pencil-square me-2"></i>Modificar Datos
                </asp:LinkButton>

                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btnMostrarCambiarContrasenia_Click"
                    CssClass="btn btn-outline-danger w-100 mb-3">
                    <i class="bi bi-key-fill me-2"></i>Cambiar Contraseña
                </asp:LinkButton>

                <!-- Separador -->
                <hr class="my-4 text-muted" />

                <!-- Botón de baja y panel -->
                <asp:LinkButton ID="btnDarseBaja" runat="server" CssClass="btn btn-danger w-100 mb-3"
                    OnClientClick="mostrarConfirmacion(); return false;">
                    <i class="bi bi-person-x-fill me-2"></i>Darse de Baja
                </asp:LinkButton>

                <asp:Panel ID="pnlConfirmarBaja" runat="server" CssClass="card p-3 mt-4 border-danger" Style="display: none;">
                    <h5 class="text-danger">¿Estás segura de que querés darte de baja?</h5>
                    <p class="text-muted">Esta acción desactivará tu cuenta. No podrás volver a iniciar sesión.</p>

                    <div class="form-check mb-3">
    <input type="checkbox" id="chkConfirmacionBaja" runat="server" class="form-check-input" />
    <asp:Label ID="lblChkConfirmacion" runat="server" AssociatedControlID="chkConfirmacionBaja" CssClass="form-check-label text-danger ms-2"
        Text="Entiendo que perderé el acceso a mi cuenta permanentemente." />
</div>

                    <asp:Label ID="lblErrorBaja" runat="server" CssClass="text-danger mb-2 d-block" Visible="false" />

                    <div class="d-flex justify-content-end">
                        <asp:Button ID="btnAceptarBaja" runat="server" Text="Aceptar"
                            CssClass="btn btn-danger me-2" OnClick="btnAceptarBaja_Click" />
                        <asp:Button ID="btnCancelarBaja" runat="server" Text="Cancelar"
                            CssClass="btn btn-secondary" OnClick="btnCancelarBaja_Click" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>

    <!-- Panel para modificar datos personales -->
    <asp:Panel ID="pnlModificarDatos" runat="server" Visible="false" CssClass="card p-4 mt-4" Style="max-width: 600px;">
        <h5>Modificar Datos Personales</h5>
        <asp:Label ID="lblErrorModificar" runat="server" ForeColor="Red" Visible="false" />

        <div class="mb-3">
            <asp:Label Text="Dirección" runat="server" AssociatedControlID="txtDireccion" />
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <asp:Label Text="Ciudad" runat="server" AssociatedControlID="txtCiudad" />
            <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <asp:Label Text="Código Postal" runat="server" AssociatedControlID="txtCP" />
            <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <asp:Label Text="Teléfono" runat="server" AssociatedControlID="txtTelefono" />
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
        </div>

        <div class="d-flex justify-content-end gap-2 mt-3">
            <asp:Button ID="btnGuardarDatos" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary flex-fill" OnClick="btnGuardarDatos_Click" />
            <asp:Button ID="btnCancelarModificar" runat="server" Text="Cancelar" CssClass="btn btn-secondary flex-fill" OnClick="btnCancelarModificar_Click" />
        </div>
    </asp:Panel>

    <!-- Script para mostrar el panel -->
    <script type="text/javascript">
        function mostrarConfirmacion() {
            document.getElementById('<%= pnlConfirmarBaja.ClientID %>').style.display = 'block';

        }
    </script>

</asp:Content>