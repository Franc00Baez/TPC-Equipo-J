using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultorio_Medico
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["usuario"];

            if (Session["usuario"] != null)
            {
                txtbEmail.Text = user.email;
                txtbFecha.Text = user.fecha_creacion.ToString();
                txtbRol.Text = user.rol_type.ToString();
            }
        }
    }
}