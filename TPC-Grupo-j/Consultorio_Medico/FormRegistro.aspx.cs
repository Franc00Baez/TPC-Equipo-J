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
            if (Seguridad.ValidarUsuario(Session["usuario"]))
            {
                Response.Redirect("Perfil.aspx");
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario(2);
            Mail mail = new Mail();
            negocio.Login service = new negocio.Login();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                user.email = txtEmail.Text;
                user.password_hash = txtPassword.Text;
                if(service.Registrar(user))
                {
                    user.id = service.ValidarUsuario(user.email, user.password_hash);
                    Session.Add("usuario", negocio.BuscarUsuarioPorId(user.id));
                    Session.Add("Rol", user.rol_type);
                    mail.armarCorreo(user.email, "Bienvenid@", "Gracias por registrate");

                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblValidacion.ForeColor = System.Drawing.Color.Red;
                    lblValidacion.Text = "El mail ingresado ya esta asociado a una cuenta.";
                }
                
                
            }catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);

            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}