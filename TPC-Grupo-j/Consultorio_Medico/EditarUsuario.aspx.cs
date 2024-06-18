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
                            RecNegocio negocio_recepcionista = new RecNegocio();
                            Recepcionista recepcionista = new Recepcionista(user);

                            txtbEmail.Text = recepcionista.email;
                            txtbPassword.Text = recepcionista.password_hash;
                            txtbFechaCreacion.Text = recepcionista.fecha_creacion.ToString();
                            txtbRol.Text = recepcionista.rol_type.ToString();
                            if (!string.IsNullOrEmpty(user.img_url) && System.IO.File.Exists(imagePath))
                            {
                                ImagPerfil.ImageUrl = "~/Images/img_perfil/" + recepcionista.img_url;
                            }
                            txtbNombre.Text = recepcionista.nombre;
                            txtbApellido.Text = recepcionista.apellido;
                            txtbNacimiento.Text = recepcionista.nacimiento.ToString("dd/MM/yyyy");

                            break;
                        case UserRole.Especialista:
                            MedicoNegocio negocio_medico = new MedicoNegocio();
                            Medico medico = new Medico(user);

                            medico = negocio_medico.buscarMedico(medico.id);
                            medico.especialidades = negocio_medico.getEspecialidadesPorMedico(medico.id_medico);
                            medico.Turnos = negocio_medico.getHorariosPorDoctor(medico.id_medico);

                            txtbEmail.Text = medico.email;
                            txtbPassword.Text = medico.password_hash;
                            txtbFechaCreacion.Text = medico.fecha_creacion.ToString();
                            txtbRol.Text = medico.rol_type.ToString();
                            if (!string.IsNullOrEmpty(user.img_url) && System.IO.File.Exists(imagePath))
                            {
                                ImagPerfil.ImageUrl = "~/Images/img_perfil/" + medico.img_url;
                            }
                            txtbNombre.Text = medico.nombre;
                            txtbApellido.Text = medico.apellido;
                            txtbNacimiento.Text = medico.nacimiento.ToString("dd/MM/yyyy");
                            rptEspecialidades.DataSource = medico.especialidades;
                            rptEspecialidades.DataBind();

                            break;
                    }
                    
                }
            }
        }
    }
}