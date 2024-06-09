using dominio;
using negocio;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using helpers;

namespace Consultorio_Medico
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected int rol;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Seguridad.ValidarUsuario(Session["usuario"]))
            {
                rol = Session["Rol"] != null ? (int)Session["Rol"] : -1;
                Usuario user = (Usuario)Session["usuario"];
                string imagePath = Server.MapPath("~/Images/img_perfil/" + user.img_url);
                RecNegocio negocio_rec = new RecNegocio();
                switch (rol)
                {
                    case 1:
                        txtbEmail.Text = user.email;
                        txtbFecha.Text = user.fecha_creacion.ToString("dd/MM/yyyy");
                        txtbRol.Text = user.rol_type.ToString();
                        if (!string.IsNullOrEmpty(user.img_url) && File.Exists(imagePath))
                        {
                            imgPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;
                        }
                        break;
                    case 2:
                        Recepcionista recepcionista = negocio_rec.buscarRecepcionista(user);
                        txtbEmail.Text = recepcionista.email;
                        txtbFecha.Text = recepcionista.fecha_creacion.ToString("dd/MM/yyyy");
                        txtbRol.Text = recepcionista.rol_type.ToString();
                        txtNombre.Text = recepcionista.nombre;
                        txtApellido.Text = recepcionista.apellido;
                        txtNacimiento.Text = recepcionista.nacimiento.ToString("dd/MM/yyyy");
                        if (!string.IsNullOrEmpty(recepcionista.img_url) && File.Exists(imagePath))
                        {
                            imgPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;
                        }

                        break;
                    case 3:
                        break;
                    case -1:
                        break;
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