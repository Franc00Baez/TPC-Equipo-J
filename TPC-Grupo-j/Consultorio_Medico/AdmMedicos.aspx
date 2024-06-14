<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmMedicos.aspx.cs" Inherits="Consultorio_Medico.AdmMedicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table-container {
            max-width: 100%;
            margin: 0 auto;
            margin-top: 50px;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 10px;
            background-color: #f9f9f9;
            overflow-x: auto;
        }

        .table-title {
            text-align: center;
            margin-bottom: 20px;
            font-size: 1.5rem;
            color: #333;
        }

        .table a {
            color: #007bff;
            text-decoration: none;
        }

            .table a:hover {
                text-decoration: underline;
            }

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-title">Listado de médicos</div>
    <asp:GridView ID="dgv" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" DataKeyNames="id" OnSelectedIndexChanged="dgv_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="apellido" HeaderText="Apellido" />
            <asp:TemplateField HeaderText="Fecha de Nacimiento">
                <ItemTemplate>
                    <%# Eval("nacimiento", "{0:dd/MM/yyyy}") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="true" HeaderText="Editar" />
        </Columns>
    </asp:GridView>
    <div style="text-align: center;">
        <div>
            <a href="CreacionMedico.aspx" class="btn-create">Crear Médico</a>
            <a href="Default.aspx" class="btn-create">Volver</a>
        </div>
    </div>

</asp:Content>
