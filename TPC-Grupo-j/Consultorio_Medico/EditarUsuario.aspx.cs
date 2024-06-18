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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        protected Usuario user { get; set; }
        protected string imagePath { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocio_usuario = new UsuarioNegocio();
            
            if(!IsPostBack)
            {
                if(Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    user = negocio_usuario.BuscarUsuarioPorId(id);
                    imagePath = Server.MapPath("~/Images/img_perfil/" + user.img_url);

                    switch (user.rol_type)
                    {
                        case UserRole.Admin:
                            txtbEmail.Text = user.email;
                            txtbPassword.Text = user.password_hash;
                            txtbRol.Text = user.rol_type.ToString();
                            if (!string.IsNullOrEmpty(user.img_url) && System.IO.File.Exists(imagePath))
                            {
                                ImagPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;
                            }
                            txtbFechaCreacion.Text = user.fecha_creacion.ToString();
                            break;
                        case UserRole.Recepcionista:

                            break;
                        case UserRole.Especialista:
                            break;
                    }
                    
                }
            }
        }
    }
}