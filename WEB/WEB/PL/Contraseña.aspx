﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contraseña.aspx.cs" Inherits="PL.Contraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="Modal/Modal.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

       <script>

    </script>

    <section id="four"  class="wrapper style1 special fade-up"  >
        <div class="container">
            <header class="major">
                <h2>Recuperar contraseña</h2>
            </header>

            <form runat="server">

                <div class="Contenido1">
                   <asp:Label Text="Correo:" ID="lblPrimerApellido" runat="server" />
                <input type="text" id="txtcorreo" name="txtusuario" runat="server" placeholder="Usuario" maxlength="50" required="required" />
                <br />
                         <div class="col-lg-8">
                        <asp:Button ID="btnRecuperarContrasenia" runat="server" Text="Recuperar Contraseña" Width="250px" class="submit" OnClick="btnRecuperarContrasenia_Click" />
                    </div>
                </div>

                <asp:Label Text="" ID="lblMensaje" runat="server" Font-Size="XX-Large" />
            </form>

        </div>
    </section>


</asp:Content>
