<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PL.Registro1" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="js/Registro/RegistroJS.js"></script>
     <script>

    </script>

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container">
            <header class="major">
                <h2>Cuenta nueva</h2>
            </header>
             
            <form runat="server">

                <div class="table-responsive">
                    <div class="col-lg-1">
                        <asp:Label Text="Cedula:" ID="lblCedula" runat="server" />

                        <input type="text" id="txtCedula" name="txtCedula" runat="server" onkeypress="return ValidarNumeros(event)" style="height: 40px;" maxlength="15" placeholder="Cedula" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Label Text="Nombre:" ID="lblNombre" runat="server" />

                        <input type="text" id="txtNombre" name="txtNombre" runat="server" onkeypress="return ValidarLetras(event)" placeholder="Nombre" style="height: 40px;" maxlength="15" value="" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Label Text="Primer Apellido:" ID="lblPrimerApellido" runat="server" />

                        <input type="text" id="txtPrimerApellido" name="txtPrimerApellido" runat="server" onkeypress="return ValidarLetras(event)" placeholder="Primer Apellido" style="height: 40px;" maxlength="15" value="" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Label Text="Segundo Apellido:" ID="lblSegundoApellido" runat="server" />

                        <input type="text" id="txtSegundoApellido" name="txtSegundoApellido" onkeypress="return ValidarLetras(event)" runat="server" placeholder="Segundo Apellido" style="height: 40px;" maxlength="15" value="" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Label Text="Email:" ID="lblEmail" runat="server" />

                        <input type="text" id="txtEmail" name="txtEmail" runat="server" placeholder="Email" style="height: 40px;" maxlength="50" value="" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Label Text="Telefono :" ID="lblTelefono1" runat="server" />

                        <input type="text" id="txtTelefono1" name="txtTelefono1" runat="server" onkeypress="return ValidarNumeros(event)" placeholder="Teléfono" style="height: 40px;" maxlength="8" value="" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Label Text="Usuario:" ID="lblUsuario" runat="server" />

                        <input type="text" id="txtUsuario" name="txtUsuario" runat="server" onkeypress="return ValidarLetras(event)" placeholder="Usuario" maxlength="15" style="height: 40px;" value="" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Label Text="Contraseña:" ID="lblContrasenia" runat="server" />

                        <input type="password" id="txtContrasenia" name="txtContrasenia" runat="server" placeholder="Contraseña" style="height: 40px;" maxlength="50" value="" />
                    </div>
                </div>
                <br>
                <div class="row">
                    <div class="col-lg-7">
                        <asp:Button ID="btnGuardar" OnClientClick="return GuardarModal();" OnClick="btnGuardar_Click" runat="server" Text="Guardar" Width="150px" class="submit" />
                    </div>
                    <div class="col-lg-8">
                        <input type="button" id="btnCancelar" onclick="location.href = 'Inicio.aspx' " runat="server" value="Cancelar" />
                    </div>

                </div>
                <br>
                <asp:Label Text="" ID="lblMensaje" runat="server" Font-Size="XX-Large" />
            </form>

            </div>
        </section>
    <script src="js/Usuarios/UsuariosJS.js"></script>
</asp:Content>



