<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Consultorio_Medico.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .fondo {
            background-image: url("..//resources//imagen.jpg"); /* Imagen de fondo */
            background-size: cover; /* Ajusta el tamaño de la imagen para cubrir el contenedor */
            background-position: center; /* Centra la imagen */
            background-attachment: fixed; /* Hace que la imagen de fondo se mantenga fija */
            background-repeat: no-repeat; /* Evita que la imagen se repita */
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            z-index: -1; /* Coloca el fondo detrás del contenido */ /* Aplica el desenfoque */
        }

        .content-container {
            margin-top: 100px;
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 20px;
            z-index: 1; /* Asegura que el contenido esté encima del fondo */
        }

        .left-column, .right-column {
            padding: 20px;
            margin-left: 20px;
            margin-right: 20px;
            margin-bottom: 50px;
            background-color: rgba(255, 255, 255, 0.8); /* Fondo blanco semitransparente */
            box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1); /* Sombra */
            border-radius: 10px; /* Bordes redondeados */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fondo">
        <h1>Bienvenido</h1>
        <div class="content-container">
            <div class="left-column">
                <h2>Descripción</h2>
                <p>Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original. Fue popularizado en los 60s con la creación de las hojas "Letraset", las cuales contenian pasajes de Lorem Ipsum, y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum.</p>
                <p>Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original. Fue popularizado en los 60s con la creación de las hojas "Letraset", las cuales contenian pasajes de Lorem Ipsum, y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum.</p>
            </div>
            <div class="right-column">
                <div class="mb-2">
                    <label for="exampleInputEmail1" class="form-label">Email address</label>
                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
                    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
                </div>
                <div class="mb-2">
                    <label for="exampleInputPassword1" class="form-label">Password</label>
                    <input type="password" class="form-control" id="exampleInputPassword1">
                </div>
                <div class="mb-2 form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1">
                    <label class="form-check-label" for="exampleCheck1">Check me out</label>
                </div>
                <button type="submit" class="btn btn-primary">Submit</button>
            </div>
        </div>
    </div>
</asp:Content>
