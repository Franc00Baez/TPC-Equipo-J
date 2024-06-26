﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreacionMedico.aspx.cs" Inherits="Consultorio_Medico.CreacionMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 600px;
            margin: 0 auto;
            margin-top:10px;
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
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

        .btn-submit {
            display: inline-block;
            margin-top: 20px;
            font-size: 1.2rem;
            padding: 10px 20px;
            background-color: #a9d0b8;
            color: white;
            border: none;
            border-radius: 5px;
            transition: background-color 0.3s ease, box-shadow 0.3s ease;
            text-align: center;
            text-decoration: none;
        }

            .btn-submit:hover {
                background-color: #88b090;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            }

        .btn-back {
            display: inline-block;
            margin-top: 20px;
            font-size: 1.2rem;
            padding: 10px 20px;
            background-color: #ccc;
            color: white;
            border: none;
            border-radius: 5px;
            transition: background-color 0.3s ease, box-shadow 0.3s ease;
            text-align: center;
            text-decoration: none;
        }

            .btn-back:hover {
                background-color: #aaa;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            }

        .error-message {
            color: red;
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="form-container">
        <div class="form-title">Crear Médico</div>
        <div class="form-title">FALTA SETEAR USUARIO ID</div>
        <div class="form-group">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtNacimiento" class="form-label">Fecha de Nacimiento</label>
            <asp:TextBox ID="txtNacimiento" runat="server" CssClass="form-control" TextMode="Date" />
        </div>
        <div class="form-group">
            <label for="chkListEspecialidades" class="form-label">Especialidades</label>
            <asp:CheckBoxList ID="chkListEspecialidades" runat="server" CssClass="form-control" />
        </div>
        <asp:Label ID="lblError" runat="server" CssClass="error-message" />
        <div style="text-align: center;">
            <asp:Button ID="btnCrear" runat="server" Text="Guardar" CssClass="btn-submit" OnClick="btnGuardar_Click"/>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-submit" OnClick="btnEliminar_Click"/>
            <a href="AdmMedicos.aspx" class="btn-back">Volver</a>
        </div>
    </div>
</asp:Content>
