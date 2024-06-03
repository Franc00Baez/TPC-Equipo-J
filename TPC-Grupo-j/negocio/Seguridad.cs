using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace negocio
{
    public class Seguridad
    {
        public void ManejarExcepcion(Exception ex, HttpContext contexto)
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
