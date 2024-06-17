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
    public partial class AdmUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            dgv1.DataSource = usuarioNegocio.listar();
            dgv1.DataBind();

        }

        protected void dgv1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                // Obtener el CommandArgument y separarlo en ID y Rol
                string[] argumentos = e.CommandArgument.ToString().Split(';');
                string id = argumentos[0];
                string rol = argumentos[1];

                // Redirigir a la página de edición con los parámetros ID y Rol
                Response.Redirect($"EditarUsuario.aspx?id={id}&rol={rol}");
            }
        }
    }
}