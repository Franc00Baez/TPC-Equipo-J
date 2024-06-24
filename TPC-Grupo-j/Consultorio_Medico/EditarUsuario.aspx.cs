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
        private UsuarioNegocio negocio_usuario = new UsuarioNegocio();
        private RecNegocio negocio_recepcionista = new RecNegocio();
        MedicoNegocio negocio_medico = new MedicoNegocio();
        protected Usuario user { get; set; }
        private Medico medico { get; set; }
        private Recepcionista recepcionista { get; set; }
        private string imgPath { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if(Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    user = negocio_usuario.BuscarUsuarioPorId(id);
                    imgPath = Server.MapPath("~/Images/img_perfil/" + user.img_url);
                    Session.Add("user", negocio_usuario.BuscarUsuarioPorId(id));
                    Session.Add("imgPath", imgPath);

                    switch (user.rol_type)
                    {
                        case UserRole.Admin:
                            CargarAdmin(user);
                            break;
                        case UserRole.Recepcionista:
                            CargarRecepcionista(user);
                            break;
                        case UserRole.Especialista:
                            CargarMedico(user);
    
                            break;
                    }

                }
            }
            else
            {
                if(Session["user"] != null)
                {
                    user = (Usuario)Session["user"];

                }

            }
        }
        private void CargarEspecialidades()
        {
            EspNegocio negocio = new EspNegocio();
            List<Especialidad> lista = negocio.listar();
            List<Especialidad> especialidadesFiltradas = lista
               .Where(e => !medico.especialidades.Any(me => me.id == e.id))
               .ToList();
            ddlEspecialidades.DataSource = especialidadesFiltradas;
            ddlEspecialidades.DataValueField = "id";
            ddlEspecialidades.DataTextField = "nombre";
            ddlEspecialidades.DataBind();
        }
        private void BindTurnosGrid()
        {
            medico = (Medico)Session["medico"];
            gvTurnos.DataSource = medico.Turnos.Values;
            gvTurnos.DataBind();
        }
        private void CargarAdmin(Usuario user)
        {
            txtbEmail.Text = user.email;
            txtbPassword.Text = user.password_hash;
            txtbRol.Text = user.rol_type.ToString();
            if (!string.IsNullOrEmpty(user.img_url) && System.IO.File.Exists(Session["imgPath"].ToString()))
            {
                ImagPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;
            }
            txtbFechaCreacion.Text = user.fecha_creacion.ToString();
        }
        private void CargarRecepcionista(Usuario user)
        {
            recepcionista = negocio_recepcionista.buscarRecepcionista(user);

            txtbEmail.Text = recepcionista.email;
            txtbPassword.Text = recepcionista.password_hash;
            txtbFechaCreacion.Text = recepcionista.fecha_creacion.ToString();
            txtbRol.Text = recepcionista.rol_type.ToString();
            if (!string.IsNullOrEmpty(user.img_url) && System.IO.File.Exists(Session["imgPath"].ToString()))
            {
                ImagPerfil.ImageUrl = "~/Images/img_perfil/" + recepcionista.img_url;
            }
            txtbNombre.Text = recepcionista.nombre;
            txtbApellido.Text = recepcionista.apellido;
            txtbNacimiento.Text = recepcionista.nacimiento.ToString("dd/MM/yyyy");
        }

        private void CargarMedico(Usuario user)
        {
            if (Session["medico"] == null)
            {
                medico = new Medico(user);
                medico = negocio_medico.buscarMedico(medico.id);
                medico.especialidades = negocio_medico.getEspecialidadesPorMedico(medico.id_medico);
                medico.Turnos = negocio_medico.getHorariosPorDoctor(medico.id_medico);
                Session.Add("medico", medico);
            } 

            txtbEmail.Text = user.email;
            txtbPassword.Text = user.password_hash;
            txtbFechaCreacion.Text = user.fecha_creacion.ToString();
            txtbRol.Text = user.rol_type.ToString();
            if (!string.IsNullOrEmpty(user.img_url) && System.IO.File.Exists(Session["imgPath"].ToString()))
            {
                ImagPerfil.ImageUrl = "~/Images/img_perfil/" + user.img_url;
            }
            txtbNombre.Text = medico.nombre;
            txtbApellido.Text = medico.apellido;
            txtbNacimiento.Text = medico.nacimiento.ToString("dd/MM/yyyy");
            rptEspecialidades.DataSource = medico.especialidades;
            rptEspecialidades.DataBind();
            BindTurnosGrid();
            CargarEspecialidades();
        }

        protected void gvTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTurnos.EditIndex = e.NewEditIndex;
            BindTurnosGrid();
        }

        protected void gvTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvTurnos.Rows[e.RowIndex];
            string dia = gvTurnos.DataKeys[e.RowIndex].Value.ToString();
            string horaInicioStr = ((TextBox)row.FindControl("txtHoraInicio")).Text;
            string horaFinalStr = ((TextBox)row.FindControl("txtHoraFin")).Text;
            medico = (Medico)Session["medico"];

            if (TimeSpan.TryParse(horaInicioStr, out TimeSpan horaInicio) && TimeSpan.TryParse(horaFinalStr, out TimeSpan horaFinal))
            {
                // Actualiza los datos en el objeto Medico
                if (medico.Turnos.ContainsKey(dia))
                {
                    medico.Turnos[dia].HoraInicio = horaInicio;
                    medico.Turnos[dia].HoraFinal = horaFinal;
                }
            }
            Session["medico"] = medico;
            gvTurnos.EditIndex = -1;
            BindTurnosGrid();
        }

        protected void gvTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTurnos.EditIndex = -1;
            BindTurnosGrid();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            EspNegocio negocio = new EspNegocio();
            int especialidadId = int.Parse(ddlEspecialidades.SelectedValue);
            Especialidad especialidad = negocio.ObtenerEspecialidadPorId(especialidadId);

            if (especialidad != null)
            {
                medico = (Medico)Session["medico"];
                if (!medico.especialidades.Any(me => me.id == especialidadId))
                {
                    medico.especialidades.Add(especialidad);
                    Session["medico"] = medico;
                    rptEspecialidades.DataSource = medico.especialidades;
                    rptEspecialidades.DataBind();
                    CargarEspecialidades(); // Actualizar el dropdown de especialidades
                }
            }
        }

        protected void rptEspecialidades_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            EspNegocio negocio = new EspNegocio();
            if (e.CommandName == "Eliminar")
            {
                int especialidadId = int.Parse(e.CommandArgument.ToString());
                medico = (Medico)Session["medico"];
                Especialidad especialidad = medico.especialidades.FirstOrDefault(me => me.id == especialidadId);

                if (especialidad != null)
                {
                    // Eliminar la especialidad del médico
                    medico.especialidades.Remove(especialidad);


                    // Actualizar la sesión y los controles en la página
                    Session["medico"] = medico;
                    rptEspecialidades.DataSource = medico.especialidades;
                    rptEspecialidades.DataBind();
                    CargarEspecialidades(); // Actualizar el dropdown de especialidades
                }
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if(Session["user"] != null)
            {
                user = (Usuario)Session["user"];

                switch(user.rol_type)
                {
                    case UserRole.Admin:
                        break;
                    case UserRole.Recepcionista:
                        break;
                    case UserRole.Especialista:
                        break;
                }
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Session.Remove("medico");
            Response.Redirect("AdmUsuarios.aspx", false);
        }

        protected void deactivateButton_Click(object sender, EventArgs e)
        {
            user = Session["user"] != null ? (Usuario)Session["user"] : null;

            if(user.activo)
            {
                user.activo = false;
                negocio_usuario.actualizar(user);
                deactivateButton.Text = "Unban";
                Session["user"] = user;

            }else
            {
                user.activo = false;
                negocio_usuario.actualizar(user);
                deactivateButton.Text = "Ban";
                Session["user"] = user;
            }
        }

        private void SaveAdmin()
        {
            HashService service = new HashService();
            user = (Usuario)Session["user"];
            try
            {
                if(string.Compare(user.password_hash, txtbPassword.Text) != 0 && txtbPassword.Text != "")
                {
                    user.password_hash = service.HashPassword(txtbPassword.Text);
                }
                if(profileImageUpload.HasFile)
                {
                    string ruta = Server.MapPath("~/Images/img_perfil/");
                    string fileName = "imgPerfil-" + user.id + ".jpg";
                    string filePath = Path.Combine(ruta, fileName);

                    profileImageUpload.SaveAs(filePath);

                    user.img_url = fileName;
                }

               
            }catch (Exception ex)
            {

            }
        }
    }
}