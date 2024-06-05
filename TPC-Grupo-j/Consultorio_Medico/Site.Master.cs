using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Consultorio_Medico
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Page is Perfil)
            {
                if(!Seguridad.ValidarUsuario(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx");

                }
            }

            if (Seguridad.ValidarUsuario(Session["usuario"]))
            {
                imgAvatar.ImageUrl = "~/Images/img_perfil/" + ((Usuario)Session["usuario"]).img_url;

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