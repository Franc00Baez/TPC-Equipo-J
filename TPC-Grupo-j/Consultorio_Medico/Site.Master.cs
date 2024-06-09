using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using helpers;

namespace Consultorio_Medico
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page is CreacionUsuario ||  Page is AdmUsuarios)
            {
                if (!Seguridad.ValidarUsuario(Session["usuario"]) ||  (UserRole)Session["Rol"] != UserRole.Admin)
                    Response.Redirect("Default.aspx");
            }

            if (Page is Perfil)
            {
                if (!Seguridad.ValidarUsuario(Session["usuario"]))
                    Response.Redirect("Login.aspx");
            }

            if (Session["usuario"] != null && Seguridad.ValidarUsuario(Session["usuario"]))
            {
                Usuario usuario = (Usuario)Session["usuario"];
                lblNombre.Text = usuario.email;

                if (!string.IsNullOrEmpty(usuario.img_url))
                {
                    imgAvatar.ImageUrl = "~/Images/img_perfil/" + usuario.img_url;
                }
                else
                {
                    imgAvatar.ImageUrl = "..//resources//avatar.png";
                }
            }
            else
            {
                imgAvatar.ImageUrl = "..//resources//avatar.png";
            }

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}