<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Najava.aspx.cs" Inherits="Lab02.Najava" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mt-5 text-center" style="color: orange; font-size: 50px">
        <h3>Најава!</h3>
    </div>

    <div class="col-10-sm text-center" style="border: 5px double orange">
        
        <div class="col-5-md mt-2 text-center">
            Име: <asp:TextBox ID="_name" runat="server"></asp:TextBox>
            <asp:Label ID="labelName" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-5-md mt-2 text-center">
            Лозинка: <asp:TextBox ID="_password" runat="server"></asp:TextBox>
            <asp:Label ID="labelPassword" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-10-sm mt-2 text-center">
            е-адреса: <asp:TextBox ID="_address" runat="server"></asp:TextBox>
            <asp:Label ID="labelAddress" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-10-sm mt-2 text-center">
            <asp:Button ID="_logIn" runat="server" Text="Најавете се" OnClick="OnClick" />
        </div>

    </div>

</asp:Content>
