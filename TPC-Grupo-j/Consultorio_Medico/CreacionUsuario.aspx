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

        .checkbox-list {
            display: flex;
            flex-wrap: wrap;
        }

            .checkbox-list .form-check {
                width: calc(33.333% - 10px);
                margin-right: 10px;
                margin-bottom: 10px;
            }

        .horario-container {
            margin-bottom: 20px;
        }

        .error-message {
            color: red;
            margin-top: 10px;
        }
        /* Estilos para el GridView */
        .grid-view {
            width: 100%;
            border-collapse: collapse;
        }

        .grid-view th, .grid-view td {
            padding: 10px;
            text-align: left;
            border: 1px solid #ccc;
        }

        .grid-view th {
            background-color: #f2f2f2;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .grid-view tr:hover {
            background-color: #eaeaea;
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
                <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" Placeholder="Fecha de Nacimiento (dd/mm/yyyy)" TextMode="Date"></asp:TextBox>
                <div class="especialidad-container">
                    <asp:Label Text="Especialidades" CssClass="form-label" ID="lbEspecialidades" runat="server" />
                    <div>
                        <asp:TextBox runat="server" ID="txtbEspecialidad" CssClass="form-control-sm" Placeholder="Nueva Especialidad" />
                        <asp:Label ID="lblErrorEspecialidad" runat="server" CssClass="error-message" />
                        <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
                    </div>
                    <asp:CheckBoxList runat="server" ID="cblEspecialidades" CssClass="checkbox-list form-check" RepeatColumns="3" RepeatDirection="Horizontal"></asp:CheckBoxList>
                </div>
                <asp:Label Text="Horarios" ID="lblHorarios" CssClass="form-label" runat="server" />
                <div class="horario-container">
                    <asp:DropDownList runat="server" ID="ddlDia" CssClass="form-control">
                        <asp:ListItem Text="Lunes" Value="Lunes" />
                        <asp:ListItem Text="Martes" Value="Martes" />
                        <asp:ListItem Text="Miércoles" Value="Miércoles" />
                        <asp:ListItem Text="Jueves" Value="Jueves" />
                        <asp:ListItem Text="Viernes" Value="Viernes" />
                        <asp:ListItem Text="Sábado" Value="Sábado" />
                        <asp:ListItem Text="Domingo" Value="Domingo" />
                    </asp:DropDownList>
                    <asp:TextBox runat="server" ID="txtHoraInicio" CssClass="form-control" TextMode="Time" Placeholder="Hora de Inicio (HH:mm)" />
                    <asp:TextBox runat="server" ID="txtHoraFinal" CssClass="form-control" TextMode="Time" Placeholder="Hora de Final(HH:mm)" />
                    <asp:Label Text="" runat="server" ID="lblErrorHorarios" CssClass="error-message" Visible="false" />
                    <asp:Button Text="Agregar/Actualizar Horarios" runat="server" CssClass="btn-custom" ID="BtnHorario" OnClick="BtnHorario_Click" />
                </div>
                <asp:GridView runat="server" ID="dgvHorarios" AutoGenerateColumns="false" CssClass="grid-view ">
                    <Columns>
                        <asp:BoundField DataField="Dia" HeaderText="Día" />
                        <asp:BoundField DataField="HoraInicio" HeaderText="Hora De Inicio" />
                        <asp:BoundField DataField="HoraFinal" HeaderText="Hora Final" />
                    </Columns>
                </asp:GridView>
        <div class="btn-container">
            <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn-custom" OnClick="btnCrear_Click" />
            <asp:Label ID="lblErrorCreacion" runat="server" Text="" CssClass="error-message"></asp:Label>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn-custom" OnClick="btnVolver_Click" />
        </div>
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
