using dominio;
using negocio;
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
                if (!string.IsNullOrEmpty(user.img_url))
                {
                    imgPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                string ruta = Server.MapPath("./Images/img_perfil/");
                Usuario user = (Usuario)Session["usuario"];
                string rutacompleta = ruta + "imgPerfil-" + user.id + ".jpg";
                string rutasemicompleta = "imgPerfil-" + user.id + ".jpg";
                txtImagen.PostedFile.SaveAs(rutacompleta);
                user.img_url = rutasemicompleta;
                usuarioNegocio.actualizar(user);
                Master.FindControl("imgAvatar");
                user.img_url = "~/Images/img_perfil/" + rutasemicompleta;
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}