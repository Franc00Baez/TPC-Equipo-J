<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Consultorio_Medico.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .profile-container {
            margin-top: 40px;
        }

        .profile-header {
            margin-bottom: 30px;
            text-align: center;
            font-size: 2.5rem;
            font-family: 'Arial', sans-serif;
            font-weight: bold;
            color: #000000;
            position: relative;
        }

            .profile-header::after {
                content: '';
                display: block;
                width: 60px;
                height: 4px;
                background: #a9d0b8;
                margin: 0 auto;
                margin-top: 10px;
            }

        .profile-label {
            font-weight: bold;
        }

        .profile-image {
            max-width: 200px;
            border-radius: 50%;
            display: block;
            margin-left: auto;
            margin-right: auto;
            margin-bottom: 20px;
        }

        .btn-custom {
            font-size: 1.2rem;
            padding: 10px 20px;
            background-color: #a9d0b8;
            color: white;
            border: none;
            border-radius: 5px;
            transition: background-color 0.3s ease, box-shadow 0.3s ease;
        }

            .btn-custom:hover {
                background-color: #88b090;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            }

        .btn-container {
            margin-top: 30px;
            margin-bottom:30px;
            text-align: center;
        }

        .form-group {
            margin-bottom: 20px;
        }

        .profile-section {
            margin-bottom: 40px;
        }

        .separator {
            margin: 20px 0;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container profile-container">
        <h1 class="profile-header">Perfil</h1>
        <div class="row">
            <div class="col-md-5 profile-section">
                <div class="form-group">
                    <asp:Label ID="lblEmail" CssClass="form-label profile-label" runat="server">Email</asp:Label>
                    <asp:TextBox ID="txtbEmail" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblFecha" CssClass="form-label profile-label" runat="server">Fecha de creación de la cuenta</asp:Label>
                    <asp:TextBox ID="txtbFecha" CssClass="form-control" TextMode="DateTime" runat="server" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblRol" CssClass="form-label profile-label" runat="server">Rol de usuario</asp:Label>
                    <asp:TextBox ID="txtbRol" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-2 separator"></div>
            <div class="col-md-5 text-center profile-section">
                <div class="form-group">
                    <asp:Label ID="lblImagen" CssClass="form-label profile-label" runat="server">Imagen de perfil</asp:Label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imgPerfil" runat="server" CssClass="profile-image img-fluid mb-3" ImageUrl="../resources/perfil.jpg" />
            </div>
        </div>
        <div class="row btn-container">
            <div class="col-md-12">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn-custom" Text="Guardar cambios" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnSalir" runat="server" CssClass="btn-custom" Text="Salir" OnClick="btnSalir_Click" />
            </div>
        </div>
    </div>
</asp:Content>
