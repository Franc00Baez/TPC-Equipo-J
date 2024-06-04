using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace Consultorio_Medico
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page is Perfil)
            {
                if(!Seguridad.ValidarUsuario(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}