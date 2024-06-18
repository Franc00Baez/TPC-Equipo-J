<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="Consultorio_Medico.EditarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn-create {
            display: inline-block;
            margin: 20px auto;
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

            .btn-create:hover {
                background-color: #88b090;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            }
            .imgPerfil{
                width: 150px;
                height: 150px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1>Editar Usuario</h1>
        <div class="text-center mb-3">
            <asp:Image ID="ImagPerfil" runat="server" CssClass="img-fluid rounded-circle mb-3 imgPerfil" ImageUrl="../resources/perfil.jpg" />
            <div class="mb-3">
                <label for="profileImageUpload" class="form-label">Subir Foto de Perfil:</label>
                <asp:FileUpload ID="profileImageUpload" runat="server" CssClass="form-control" accept="image/*"></asp:FileUpload>
            </div>
        </div>
        <div class="mb-3">
            <label for="rol" class="form-label">Rol:</label>
            <asp:TextBox runat="server" ID="txtbRol" CssClass="form-control" Enabled="false" />
        </div>
        <div class="mb-3">
            <label for="email" class="form-label">Email:</label>
            <asp:TextBox ID="txtbEmail" runat="server" CssClass="form-control" TextMode="Email" required="required" Enabled="false"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="password" class="form-label">Password:</label>
            <asp:TextBox ID="txtbPassword" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="fecha_creacion" class="form-label">Fecha de Creación:</label>
            <asp:TextBox ID="txtbFechaCreacion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <%if (user.rol_type == helpers.UserRole.Recepcionista || user.rol_type == helpers.UserRole.Especialista )
            {%>
        <div class="mb-3">
            <asp:Label Text="Nombre:" CssClass="form-label" ID="lblNombre" runat="server" />
            <asp:TextBox ID="txtbNombre" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:Label Text="Apellido:" runat="server" CssClass="form-label"  ID="lblApellido" />
            <asp:TextBox ID="txtbApellido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <asp:label text="Fecha de nacimiento:"  runat="server" CssClass="form-label" id="lblNacimiento" />
            <asp:TextBox ID="txtbNacimiento" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
        <%} %>

        <%if (user.rol_type == helpers.UserRole.Especialista)
            {%>
        <div class="container mt-5">
        <asp:Label Text="Especialidades" ID="lblEspecialidades" runat="server" />
        <asp:Repeater ID="rptEspecialidades" runat="server">
            <ItemTemplate>
                <div class="mb-3">
                    <asp:Label ID="lblEspecialidad" runat="server" Text='<%#Eval("nombre") %>'></asp:Label>
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger btn-sm ms-2" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>'/>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="mt-3">
            <asp:Label Text="Agregar Especialidades" ID="lblAgregarEsp" runat="server" />
            <div class="input-group mb-3">
                <asp:DropDownList ID="ddlEspecialidades" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success ms-2" Text="Agregar" />
            </div>
        </div>
    </div>
        <%} %>
        <div class="text-center">
            <asp:Button ID="saveButton" runat="server" CssClass="btn-create" Text="Guardar" />
            <asp:Button ID="backButton" runat="server" CssClass="btn-create" Text="Volver" />
            <asp:Button ID="deactivateButton" runat="server" CssClass="btn-create" Text="Desactivar" />
        </div>
    </div>

</asp:Content>
