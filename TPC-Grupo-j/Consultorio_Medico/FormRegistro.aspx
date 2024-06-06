<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormRegistro.aspx.cs" Inherits="Consultorio_Medico.FormRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 500px;
            margin: 0 auto;
            margin-top:130px;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 10px;
            background-color: #f9f9f9;
        }

        .form-title {
            text-align: center;
            margin-bottom: 20px;
            font-size: 1.5rem;
            color: #333;
            font-weight: bold;
        }

        .form-label {
            font-weight: bold;
        }

        .form-text {
            font-size: 0.9rem;
            color: #666;
        }

        .btn-custom {
            font-size: 1.2rem;
            padding: 10px 20px;
            background-color: #a9d0b8;
            color: white;
            border: none;
            border-radius: 5px;
            transition: background-color 0.3s ease, box-shadow 0.3s ease;
            margin-top: 10px;
        }

        .btn-custom:hover {
            background-color: #88b090;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }

        .btn-container {
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <div class="form-container">
        <div class="form-title">Registro</div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate><asp:Label Text="" ID="lblValidacion" CssClass="p" runat="server" /></ContentTemplate>
        </asp:UpdatePanel>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Correo Electrónico</label>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" aria-describedby="emailHelp" />
            <div id="emailHelp" class="form-text">Nunca compartiremos tu correo con nadie más.</div>
        </div>
        <div class="mb-3">
            <label for="txtPassword" class="form-label">Contraseña</label>
            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
        </div>
        <div class="btn-container">
            <asp:Button Text="Registrarse" ID="btnRegistrar" CssClass="btn-custom" OnClick="btnRegistrar_Click" runat="server" />
            <asp:Button ID="btnRegresar" CssClass="btn-custom" runat="server" Text="Volver" OnClick="btnRegresar_Click"/>
        </div>
    </div>
</asp:Content>
