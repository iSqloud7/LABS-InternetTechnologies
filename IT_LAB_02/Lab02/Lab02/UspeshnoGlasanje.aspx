<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UspeshnoGlasanje.aspx.cs" Inherits="Lab02.UspeshnoGlasanje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mt-5 text-center" style="color: lime; font-size: 45px; border: 10px double darkgreen; background-color: black; height: 350px; font-style: italic">

        <div class="row-10-lg text-center mt-5">
            Ви благодариме за учеството во акцијата за избор на најинтересен предмет на ФИНКИ.
            Резултатите од гласањето ќе гидобиете по електронска пошта, на:
        </div>

        <asp:Label ID="_wantedEmail" runat="server" Text=""></asp:Label>

    </div>

</asp:Content>
