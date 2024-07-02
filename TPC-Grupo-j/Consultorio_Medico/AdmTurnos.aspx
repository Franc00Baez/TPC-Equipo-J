<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmTurnos.aspx.cs" Inherits="Consultorio_Medico.AdmTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style>
        .card-container {
            max-width: 80%;
            margin: 0 auto;
            margin-top: 50px;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 10px;
            background-color: #f9f9f9;
        }

        .col {
            flex: 1 1 calc(50% - 40px);
            max-width: calc(50% - 40px);
        }

        .card {
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            margin: 0 auto;
            margin-bottom:50px;
        }

        .card-body {
            padding: 20px;
        }

        .card-title {
            font-size: 1.5rem;
            font-weight: bold;
            margin-bottom: 15px;
            color: #333;
        }

        .card-estado, .card-fecha, .card-hora, .card-paciente, .card-doctor, .card-obs {
            margin: 5px 0;
        }

        .card-label {
            font-weight: bold;
            color: #555;
        }

        .card a {
            display: inline-block;
            margin-right: 10px;
            color: #007bff;
            text-decoration: none;
            transition: color 0.3s ease;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="row row-cols-1 row-cols-md-2 g-4">
            <asp:Repeater ID="rep1" runat="server" OnItemDataBound="rep1_ItemDataBound">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title">TURNO</h5>
                                <div class="card-estado">
                                    <span class="card-label">Estado:</span> <%# Eval("estado_id") %>
                                </div>
                                <div class="card-fecha">
                                    <span class="card-label">Fecha:</span> <%# Eval("fecha") %>
                                </div>
                                <div class="card-hora">
                                    <span class="card-label">Hora:</span> <%# Eval("hora") %>
                                </div>
                                <div class="card-paciente">
                                    <span class="card-label">Paciente:</span> <%# Eval("paciente_id") %>
                                </div>
                                <div class="card-doctor">
                                    <span class="card-label">Doctor:</span> <%# Eval("doctor_id") %>
                                </div>
                                <div class="card-obs">
                                    <span class="card-label">Observaciones:</span> <%# Eval("observaciones") %>
                                </div>
                                <div class="card-actions">
                                    <a href="#">Editar</a>
                                    <a href="#">Cancelar</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>