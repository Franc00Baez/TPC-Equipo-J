<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="Consultorio_Medico.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            width: 100%;
            max-width: 500px;
            border: 1px solid #ddd;
            border-radius: 10px;
            overflow: hidden;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
            background-color: #fff;
            margin-bottom: 20px;
        }

        .card:hover {
            transform: translateY(-5px);
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
        }

        .card-body {
            padding: 30px;
        }

        .card-titulo {
            font-size: 2rem;
            margin-bottom: 15px;
            color: #333;
        }

        .card-descr {
            font-size: 1.2rem;
            color: #666;
            margin-bottom: 20px;
        }

        .card a {
            color: #007bff;
            text-decoration: none;
            font-weight: bold;
        }

        .card a:hover {
            text-decoration: underline;
        }

        .row-cols-1 > .col,
        .row-cols-md-2 > .col {
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .row {
            margin-top: 20px;
        }

        @media (min-width: 768px) {
            .row-cols-md-2 > .col {
                flex: 0 0 50%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="row row-cols-1 row-cols-md-2 g-4">
            <asp:Repeater ID="Rep1" runat="server" OnItemDataBound="Rep1_ItemDataBound">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-titulo"><%# Eval("nombre") %></h5>
                                <p class="card-descr">...</p>
                                <a href="#">Ver detalles</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>