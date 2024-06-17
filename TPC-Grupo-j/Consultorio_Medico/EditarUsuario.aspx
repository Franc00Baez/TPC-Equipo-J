<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="Consultorio_Medico.EditarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 600px;
            margin: 0 auto;
            margin-top: 50px;
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

        .btn-submit {
            background-color: #a9d0b8;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 10px 20px;
            cursor: pointer;
            transition: background-color 0.3s ease, box-shadow 0.3s ease;
        }

        .btn-submit:hover {
            background-color: #88b090;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }

        .btn-back {
            background-color: #ffb6b6;
            color: white;
            border: none;
            border-radius: 5px;
            padding: 10px 20px;
            cursor: pointer;
            transition: background-color 0.3s ease, box-shadow 0.3s ease;
        }

        .btn-back:hover {
            background-color: #ff9a9a;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="form-container">
        <div class="form-title">Editar Usuario</div>
        <div class="form-group">
            <label for="txtID">ID</label>
        </div>
        <div class="form-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtPassword">Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
        </div>
        <div class="form-group">
            <label for="ddlRol">Rol</label>
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccionar Rol" Value="" />
                <asp:ListItem Text="Admin" Value="Admin" />
                <asp:ListItem Text="User" Value="User" />
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="txtImgUrl">URL de la Imagen</label>
            <asp:TextBox ID="txtImgUrl" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="chkActivo">Activo</label>
            <asp:CheckBox ID="chkActivo" runat="server" CssClass="form-check-input" />
        </div>
        <div class="form-group text-center">
            <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn-submit"  />
            <asp:Button ID="btnBack" runat="server" Text="Volver" CssClass="btn-back" PostBackUrl="AdmUsuarios.aspx" />
        </div>
    </div>
</asp:Content>
