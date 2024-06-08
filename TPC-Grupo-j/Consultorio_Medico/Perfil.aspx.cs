using dominio;
using negocio;
using System;
using System.IO;
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
            Usuario user = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;

            if (Session["usuario"] != null)
            {
                txtbEmail.Text = user.email;
                txtbFecha.Text = user.fecha_creacion.ToString("dd/MM/yyyy");
                txtbRol.Text = user.rol_type.ToString();
                string imagePath = Server.MapPath("~/Images/img_perfil/" + user.img_url);
                if (!string.IsNullOrEmpty(user.img_url) && File.Exists(imagePath))
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
                Usuario user = (Usuario)Session["usuario"];

                if (fileupd.HasFile)
                {
                    string ruta = Server.MapPath("~/Images/img_perfil/");
                    string fileName = "imgPerfil-" + user.id + ".jpg";
                    string filePath = Path.Combine(ruta, fileName);

                    fileupd.SaveAs(filePath);

                    user.img_url = fileName;
                }

                usuarioNegocio.actualizar(user);

                imgPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;

                Image imgAvatar = (Image)Master.FindControl("imgAvatar");
                if (imgAvatar != null)
                {
                    imgAvatar.ImageUrl = "~/Images/img_perfil/" + user.img_url;
                }
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