<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Najava.aspx.cs" Inherits="Lab01.Najava" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mt-5" style="color: steelblue; font-style: italic; text-decoration: underline">
        <h1>Најава</h1>
    </div>

    <div class="col-md-5 mt-2">
        Име<asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <asp:Label ID="labelName" runat="server" Text=""></asp:Label>
    </div>

    <div class="col-md-5 mt-2">
        Лозинка<asp:TextBox ID="Password" runat="server"></asp:TextBox>
        <asp:Label ID="labelPassword" runat="server" Text=""></asp:Label>
    </div>

    <div class="col-md-5 mt-2">
        е-адреса<asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox>
        <asp:Label ID="labelAddress" runat="server" Text=""></asp:Label>

    </div>
    <div class="col md-5 mt-2">
        <asp:Button ID="LogInButton" runat="server" Text="Најавете се" OnClick="OnClick" />
    </div>


</asp:Content>
