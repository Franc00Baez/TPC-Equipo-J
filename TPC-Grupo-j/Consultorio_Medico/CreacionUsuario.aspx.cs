using dominio;
using helpers;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultorio_Medico
{
    public partial class CreacionUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UsuarioNegocio negocio_usuario = new UsuarioNegocio();
                ddlUserRole.DataSource = negocio_usuario.ListarRoles();
                ddlUserRole.DataTextField = "Text";
                ddlUserRole.DataValueField = "Value";
                ddlUserRole.DataBind();

                EspNegocio negocio_esp = new EspNegocio();
                cblEspecialidades.DataSource = negocio_esp.listar();
                cblEspecialidades.DataTextField = "nombre";
                cblEspecialidades.DataValueField = "id";
                cblEspecialidades.DataBind();

                txtNombre.Visible = false;
                txtApellido.Visible = false;
                txtFechaNac.Visible = false;
                cblEspecialidades.Visible = false;
            }

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdmUsuarios.aspx");
        }

        protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(ddlUserRole.SelectedIndex)
            {
                case 1:
                    txtNombre.Visible = false;
                    txtApellido.Visible = false;
                    txtFechaNac.Visible = false;
                    cblEspecialidades.Visible = false;
                    break;
                case 2:
                    txtNombre.Visible = true;
                    txtApellido.Visible = true;
                    txtFechaNac.Visible = true;
                    cblEspecialidades.Visible = true;
                    break;
                case 3:
                    txtNombre.Visible = true;
                    txtApellido.Visible = true;
                    txtFechaNac.Visible = true;
                    cblEspecialidades.Visible = false;
                    break;
                case 0:
                    txtNombre.Visible = false;
                    txtApellido.Visible = false;
                    txtFechaNac.Visible = false;
                    cblEspecialidades.Visible = false;
                    break;
            }
        }
    }
}