using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using helpers;
using dominio;

namespace Consultorio_Medico
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Seguridad.ValidarUsuario(Session["usuario"]))
            {
                Response.Redirect("Perfil.aspx");
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {  
            negocio.Login log = new negocio.Login();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {

                int id = log.ValidarUsuario(txtEmail.Text, txtPass.Text);
                if (!(id <= 0))
                {
                    Session.Add("ID", id);
                    Response.Redirect("Default.aspx", false);
                }

            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormRegistro.aspx");
        }

    }
}