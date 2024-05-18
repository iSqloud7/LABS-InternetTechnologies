<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UspeshnoGlasanje.aspx.cs" Inherits="Lab03.UspeshnoGlasanje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12 text-center mt-3">
        <h5>
            УСПЕШНО ГЛАСАЊЕ!
        </h5>
    </div>

    <div class="col-md-12 text-center mt-3">
        Ви благодариме за учеството во акцијата за избор на најинтересен предмет на ФИНКИ. Резултатите од гласањето ќе ги добиете по електронска пошта, на Е-MAIL:
        <asp:Label ID="wantedEmail" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
