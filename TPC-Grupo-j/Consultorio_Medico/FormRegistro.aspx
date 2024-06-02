<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="FormRegistro.aspx.cs" Inherits="Consultorio_Medico.FormRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="mb-3">
    <label for="txtEmail" class="form-label">Email address</label>
    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" aria-describeby="emailHelp" />
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
  </div>
  <div class="mb-3">
    <label for="txtPassword" class="form-label">Password</label>
    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" type="password" />
  </div>
    <asp:Button Text="Registrarte" ID="btnRegistrar" CssClass="btn btn-dark" OnClick="btnRegistrar_Click" runat="server" />
    <a href="Login.aspx" class="btn btn-dark">Volver al login</a>
</asp:Content>
