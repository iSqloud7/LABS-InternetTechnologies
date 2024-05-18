<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Glasaj.aspx.cs" Inherits="Lab03.Glasaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12 text-center mt-3">
        <h5>
            ГЛАСАЈ!
        </h5>
    </div>

    <div>

        <div class="col-md-12 text-center mt-3">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/finki_logo.png" />
        </div>

        <div class="col-md-12 text-center mt-3">
            <asp:Label ID="lblProfessor" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-md-12 text-center mt-3">
            <asp:ListBox ID="lblSubjects" runat="server" OnSelectedIndexChanged="OnSelectedIndexChanged" AutoPostBack="True"></asp:ListBox><asp:ListBox ID="lblCredits" runat="server" Enabled="False"></asp:ListBox>
        </div>

        <div class="col-md-12 text-center mt-3">
            <asp:Button ID="_vote" runat="server" Text="Гласајте" OnClick="OnClick" />
        </div>

    </div>

    <div>

        <div class="col-md-12 text-center mt-3">
            <h5>Предмети:</h5>
            <asp:TextBox ID="_subjects" runat="server"></asp:TextBox>
        </div>

        <div class="col-md-12 text-center mt-3">
            <h5>Кредити:</h5>
            <asp:TextBox ID="_credits" runat="server"></asp:TextBox>
        </div>


        <div class="col-md-12 text-center mt-3">
            <asp:Button ID="_addButton" runat="server" Text="Додади" OnClick="addOnClick" />
        </div>

        <div class="col-md-12 text-center mt-3">
            <asp:Button ID="_deleteButton" runat="server" Text="Избриши" OnClick="deleteOnClick" />
        </div>

    </div>

</asp:Content>
