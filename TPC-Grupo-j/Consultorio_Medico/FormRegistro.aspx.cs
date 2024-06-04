using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Consultorio_Medico
{
    public partial class FormRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario(1);
            negocio.Login service = new negocio.Login();
            Seguridad seguridad = new Seguridad();
            bool seRegistro;

            try
            {
                user.email = txtEmail.Text;
                user.password_hash = txtPassword.Text;
                seRegistro=service.Registrar(user);
                Session.Add("Registrado", seRegistro);
                Response.Redirect("Login.aspx", false);

            }catch (Exception ex)
            {
                seguridad.ManejarExcepcion(ex, HttpContext.Current);
                
            }
        }
    }
}