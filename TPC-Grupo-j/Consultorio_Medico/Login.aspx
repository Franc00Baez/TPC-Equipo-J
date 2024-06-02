<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Consultorio_Medico.Default" %>

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
            margin-top:100px;
            margin-left: 20px;
            margin-right: 20px;
            margin-bottom: 100px;
            background-color: rgba(255, 255, 255, 0.8); 
            box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1); 
            border-radius: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="fondo">

        <div class="content-container">
            <div class="left-column">
                <h2>Descripción</h2>
                <p>Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original. Fue popularizado en los 60s con la creación de las hojas "Letraset", las cuales contenian pasajes de Lorem Ipsum, y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum.</p>
                <p>Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original. Fue popularizado en los 60s con la creación de las hojas "Letraset", las cuales contenian pasajes de Lorem Ipsum, y más recientemente con software de autoedición, como por ejemplo Aldus PageMaker, el cual incluye versiones de Lorem Ipsum.</p>
            </div>
            <div class="right-column">
                <div class="mb-2">
                    <label for="txtEmail" class="form-label">Usuario</label>
                    <asp:TextBox runat="server" type="email" CssClass="form-control" ID="txtEmail" aria-describedby="emailHelp"  />
                    <div id="emailHelp" class="form-text">Recuerda que el usuario es el correo electrónico.</div>
                </div>
                <div class="mb-2">
                    <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                    <asp:TextBox runat="server" type="password" CssClass="form-control" ID="txtPass" aria-describedby="PasswordHelp"  />
                </div>
                <div class="mb-2 form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1">
                    <label class="form-check-label" for="exampleCheck1">Mantener la sesión</label>
                </div>
                <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="btnIngresar"  runat="server" OnClick="btnIngresar_Click" />
                <asp:Label Text="" runat="server" id="lblID" />
            </div>
        </div>
    </div>
</asp:Content>
