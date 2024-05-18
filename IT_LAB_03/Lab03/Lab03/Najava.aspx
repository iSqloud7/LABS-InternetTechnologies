<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Najava.aspx.cs" Inherits="Lab03.Najava" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="col-md-12 text-center mt-3">
        <h5>
            НАЈАВА!
        </h5>
    </div>

    <div>

        <div class="col-md-12 text-center mt-3">
            Име </asp:Label><asp:TextBox ID="_name" runat="server"></asp:TextBox><asp:Label ID="labelName" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-md-12 text-center mt-3" style="margin: auto">
            Лозинка </asp:Label><asp:TextBox ID="_password" runat="server"></asp:TextBox><asp:Label ID="labelPassword" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-md-12 text-center mt-3">
            е-адреса </asp:Label><asp:TextBox ID="_adress" runat="server"></asp:TextBox><asp:Label ID="labelAddress" runat="server" Text=""></asp:Label>
        </div>

        <div class="col-md-12 text-center mt-3">
            <asp:Button ID="_logIn" runat="server" Text="Најавете се" OnClick="OnClick" />
        </div>

    </div>

</asp:Content>
