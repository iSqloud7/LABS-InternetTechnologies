<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UspeshnoGlasanje.aspx.cs" Inherits="Lab01.UspeshnoGlasanje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mt-5 text-center" style="color: darkgreen; font-size: 30px; border: 5px solid pink">
        <div class="row mt-5 text-center" style="color: mediumpurple; font-style: italic">
            Ви благодариме за учеството во акцијата за избор на најинтересен предмет на ФИНКИ. 
            Резултатите од гласањето ќе ги добиете по електронска пошта, на Е-MAIL:
        </div>
        <asp:Label ID="WantedEmail" runat="server"></asp:Label>
    </div>

</asp:Content>
