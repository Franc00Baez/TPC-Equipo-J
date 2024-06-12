<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreacionUsuario.aspx.cs" Inherits="Consultorio_Medico.CreacionUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-container {
            max-width: 800px;
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

        .form-label {
            font-weight: bold;
        }

        .form-text {
            font-size: 0.9rem;
            color: #666;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
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
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="form-container">
        <div class="form-title">Crear Usuario</div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddlUserRole" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUserRole_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre"></asp:TextBox>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Placeholder="Apellido"></asp:TextBox>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Correo Electrónico"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Contraseña"></asp:TextBox>
                <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" Placeholder="Fecha de Nacimiento (dd/mm/yyyy)"></asp:TextBox>
                <div class="d-block">
                <asp:CheckBoxList runat="server" ID="cblEspecialidades" CssClass="form-check"></asp:CheckBoxList>
                </div>
                <label for="fuImg" class="form-label">Cargar Imagen</label>
                <asp:FileUpload ID="fuImg" runat="server" CssClass="form-control" />

            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="btn-container">
            <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn-custom" OnClick="btnCrear_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn-custom" OnClick="btnVolver_Click" />

        </div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
