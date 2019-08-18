<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearSolicitud.aspx.cs" Inherits="PL.CrearSolicitud" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">


    <link rel="stylesheet" href="Modal/Modal.css" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="four" class="wrapper style1 special fade-up">
        <div class="container" style="min-height: 600px;">
            <header class="major">
                <h2>Registro de Requisitos
                </h2>
            </header>

            <form runat="server">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updIngreso" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <div class="rechnungsdaten">
                            <div class="form__group">
                                <label for="">Descripción Requisito:</label>
                                <input type="text" id="txtDescripcion" maxlength="25" runat="server" />
                            </div>

                        
                        </div>



                        <div class="rechnungsdaten">

                        

                        </div>

                        <div>

                            <div class="form__group">
                                <label for="">Nombre Requisito:</label>
                                <input type="text" id="txtPeso" maxlength="7" runat="server" />
                                    </div>

                        <div>
                           


                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="updpnlBusqueda" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Button Text="Registrar Requisito" OnClick="btnRegistrar_Click" OnClientClick="return validacionGuardar();" ID="btnRegistrar" runat="server" />
                        <input type="text" id="txtMensaje" runat="server" style="height: 35px; border: 0; text-align: center;" readonly="true" />
                    </ContentTemplate>
                </asp:UpdatePanel>

            </form>


        </div>


    </section>
    <script src="Modal/ModalJS.js"></script>
    <script src="js/Pedidos/PedidosJS.js"></script>
</asp:Content>
