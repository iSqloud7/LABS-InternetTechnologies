<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Glasaj.aspx.cs" Inherits="Lab01.Glasaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mt-5" style="color: darkred; font-style: italic; text-decoration: underline">
        <h1>Гласај</h1>
    </div>

    <div class="col-md-5">
        <asp:Image ID="Logo" runat="server" ImageUrl="~/finki_logo.png" />
    </div>

    <div class="col-md-5">
        <asp:Label ID="lblProfessors" runat="server" Text=""></asp:Label>
    </div>

    <div class="col-md-5">
        <asp:ListBox ID="lbSubjects" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbSubjects_SelectedIndexChanged" SelectionMode="Multiple">
            <asp:ListItem Value="Проф. д-р Гоце Арменски">Интернет Технологии</asp:ListItem>
            <asp:ListItem Value="Проф. д-р Ивица Димитровски">Дигирално Процесирање на Слика</asp:ListItem>
            <asp:ListItem Value="Проф. д-р Весна Димитрова">Оперативни Системи</asp:ListItem>
            <asp:ListItem Value="Проф. д-р Дејан Ѓорѓевиќ">Софтверско Инженерство</asp:ListItem>
            <asp:ListItem Value="Проф. д-р Горан Велинов">Концепти на Информатичко Општество</asp:ListItem>
        </asp:ListBox>
        <asp:ListBox ID="lbCredits" runat="server" SelectionMode="Multiple">
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>5.5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:ListBox>
    </div>

    <div class="col-md-5">
        <asp:Button ID="VoteButton" runat="server" Text="Гласајте" OnClick="VoteButton_Click" />
    </div>

</asp:Content>
