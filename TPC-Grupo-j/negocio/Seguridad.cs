using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using dominio;
using helpers;

namespace negocio
{
    public static class Seguridad
    {
        public static bool ValidarUsuario(object user)
        {
            Usuario logueado = user != null ? (Usuario)user : null;
            if (logueado != null && logueado.id > 0)
                return true;
            else
                return false;

        }

        public static void ManejarExcepcion(Exception ex, HttpContext contexto)
        {
            //logException(ex);

            List<string> errores = new List<string>
            {
                "Ha ocurrido un error. Por favor, contacte al administrador!",
                "Tipo de Excepción: " + ex.GetType().Name,
                "Mensaje: " + ex.Message
                 
            };

            // Almacenamos los mensajes de error en la sesión
            contexto.Session["Errores"] = errores;

            //Redirigimos a la página de error
            contexto.Response.Redirect("~/Error.aspx");
        }
    }
}
