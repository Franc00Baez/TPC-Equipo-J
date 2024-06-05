<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Consultorio_Medico.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #imgPerfil{
            height:100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label ID="lblEmail" CssClass="form-label" runat="server" >Email</asp:Label>
                <asp:TextBox ID="txtbEmail" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblFecha" Class="form-label" runat="server">Fecha de creación de la cuenta</asp:Label>
                <asp:TextBox ID="txtbFecha" CssClass="form-control" TextMode="DateTime" runat="server" Enabled="false"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblRol" Class="form-label" runat="server">Rol de usuario</asp:Label>
                <asp:TextBox ID="txtbRol" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
            </div>
             </div>
            <div class="col-md-4">
                <div class="mb-3">
                    <asp:Label ID="lblImagen" runat="server">Imagen de perfil</asp:Label>
                    <input type="file" id="txtImagen" runat="server" Class="form-control"/>
                </div>
                <asp:Image ID="imgPerfil" runat="server" CssClass="img-fluid mb-3" ImageUrl="..//resources//perfil.jpg"/>
            </div>    
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click"/>
        </div>
    </div>
</asp:Content>
