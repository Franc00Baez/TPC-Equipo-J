<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Consultorio_Medico.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .fondo {
            background-image: url("..//resources//imagen.jpg");
            background-size: cover;
            background-position: center;
            background-attachment: fixed;
            background-repeat: no-repeat;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            z-index: -1;
        }

        .content-container {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 20px;
            z-index: 1;
        }

        .left-column, .right-column {
            padding: 20px;
            margin-top: 100px;
            margin-left: 20px;
            margin-right: 20px;
            margin-bottom: 100px;
            background-color: rgba(255, 255, 255, 0.8);
            box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
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
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fondo">

        <div class="content-container">
            <div class="left-column">
                <h2>Descripción de la Clínica</h2>
                <p>Bienvenidos a la Clínica Salud y Vida, un centro de salud dedicado a proporcionar atención médica de alta calidad a nuestra comunidad. Nuestra clínica fue fundada en el año 2000 con el objetivo de ofrecer servicios médicos integrales y personalizados para cada paciente.</p>
                <p>Contamos con un equipo de profesionales altamente calificados en diversas especialidades médicas, incluyendo medicina general, pediatría, ginecología, cardiología, dermatología, y muchas más. Nuestra misión es garantizar el bienestar de nuestros pacientes a través de un enfoque integral y humano.</p>
                <p>En la Clínica Salud y Vida, disponemos de tecnología de punta y modernas instalaciones para asegurar diagnósticos precisos y tratamientos eficaces. Ofrecemos una amplia gama de servicios que incluyen consultas médicas, exámenes de laboratorio, estudios de imagen, y programas de prevención y cuidado de la salud.</p>
                <p>Nos enorgullece brindar una atención centrada en el paciente, asegurando que cada visita sea una experiencia positiva y reconfortante. Nuestro compromiso es mantenernos a la vanguardia en la atención médica, adaptándonos continuamente a los avances científicos y tecnológicos para ofrecer el mejor cuidado posible.</p>
                <p>Gracias por confiar en nosotros. Si tiene alguna pregunta o necesita más información, no dude en ponerse en contacto con nuestro equipo. Estamos aquí para ayudarle a alcanzar una vida más saludable y feliz.</p>
            </div>
            <div class="right-column">
                <div class="mb-2">
                    <label for="txtEmail" class="form-label">Usuario</label>
                    <asp:TextBox runat="server" type="email" CssClass="form-control" ID="txtEmail" aria-describedby="emailHelp" />
                    <div id="emailHelp" class="form-text">Recuerda que el usuario es el correo electrónico.</div>
                </div>
                <div class="mb-2">
                    <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" type="password" CssClass="form-control" ID="txtPass" aria-describedby="PasswordHelp" />
                </div>
                <div class="mb-4">
                    <asp:Button Text="Ingresar" CssClass="btn-custom" ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" />
                    <asp:Button ID="btnRegistrar" CssClass="btn-custom" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />
                    <asp:Label Text="" runat="server" ID="lblID" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
