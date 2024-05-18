<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Glasaj.aspx.cs" Inherits="Lab02.Glasaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mt-5 text-center" style="color: red; font-size: 50px; text-decoration: underline">
        <h1>Гласај!</h1>
    </div>

    <div class="col-10-sm text-center" style="border: 5px double red">

        <div class="col-5-md mt-2 text-center">
            <asp:Image ID="_logo" runat="server" ImageUrl="~/finki_logo.png" />
        </div>

        <div class="col-5-md mt-2 text-center">
            <asp:Label ID="lblProfessor" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-5-md mt-2 text-center">
            <asp:ListBox ID="lblSubjects" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lblSubjects_SelectedIndexChanged"></asp:ListBox>
            <asp:ListBox ID="lblCredits" runat="server"></asp:ListBox>
        </div>

        <div class="col-5-md mt-2 text-center">
            <asp:Button ID="_vote" runat="server" Text="Гласај" OnClick="OnClick" />
        </div>

        <div class="col-5-md mt-2 text-center">
            <hr />
        </div>

        <div class="col-5-md mt-2 text-center">
            <div class="col-5-md mt-2 text-center">
                Предмет:
            </div>
            <asp:TextBox ID="_subjects" runat="server"></asp:TextBox>
        </div>

        <div class="col-5-md mt-2 text-center">
             <div class="col-5-md mt-2 text-center">
                Кредити:
            </div>
            <asp:TextBox ID="_credits" runat="server"></asp:TextBox>
        </div>

        <div class="col-5-md mt-4 text-center">
            <asp:Button ID="_add" runat="server" Text="Додади" OnClick="AddOnClick" />
        </div>

        <div class="col-5-md mt-4 text-center">
            <asp:Button ID="_delete" runat="server" Text="Избриши" OnClick="DeleteOnClick" />
        </div>

    </div>

</asp:Content>
