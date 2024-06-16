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
        private Dictionary<string, Horario> horarios;
        private void BindGridView()
        {
            dgvHorarios.DataSource = horarios.Values.ToList();
            dgvHorarios.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                horarios = new Dictionary<string, Horario>();
                Session["Horarios"] = horarios;
                BindGridView();

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
                txtbEspecialidad.Visible = false;
                btnAgregar.Visible = false;
                lbEspecialidades.Visible = false;
                lblHorarios.Visible = false;
                txtHoraInicio.Visible = false;
                txtHoraFinal.Visible = false;
                BtnHorario.Visible = false;
                ddlDia.Visible = false;
                dgvHorarios.Visible = false;
            }else
            {
                horarios = (Dictionary<string, Horario>)Session["Horarios"];
            }

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            MedicoNegocio negocio_medico = new MedicoNegocio();
            UsuarioNegocio negocio_usuario = new UsuarioNegocio();
            negocio.Login negocio_login= new negocio.Login();
            RecNegocio negocio_recepcionista = new RecNegocio();
            Usuario user = new Usuario();
            Mail mensajeria = new Mail();
            Especialidad especialidad = new Especialidad();

            try
            {
                switch(int.Parse(ddlUserRole.SelectedValue))
                {
                    case 0:
                        lblErrorCreacion.Text = "Error: debe seleccionar un rol.";
                        break;
                    case 1:
                        user.email = txtEmail.Text;
                        user.password_hash = txtPassword.Text;
                        user.rol_type = UserRole.Admin;
                        user.activo = true;
                        if(negocio_login.Registrar(user))
                        {
                            Response.Redirect("AdmUsuarios.aspx", false);
                            mensajeria.armarCorreo(user.email, "Bienvenido", "Gracias por registrarte");
                        }else
                        {
                            lblErrorCreacion.Text = "Error: El Email Ingresado pertenece a una cuenta creada.";
                        }
                        break;
                    case 2:
                        user.email = txtEmail.Text;
                        user.password_hash = txtPassword.Text;
                        user.rol_type = UserRole.Especialista;
                        user.id = negocio_usuario.insertarNuevo(user);
                        if (user.id > 0)
                        {
                            Medico medico = new Medico(user);
                            medico.nombre = txtNombre.Text;
                            medico.apellido = txtApellido.Text;
                            medico.nacimiento = DateTime.Parse(txtFechaNac.Text);    
                            foreach(ListItem item in cblEspecialidades.Items)
                            {
                                if(item.Selected)
                                {
                                    especialidad.id =int.Parse(item.Value);
                                    especialidad.nombre = item.Text;
                                    medico.especialidades.Add(especialidad);
                                    System.Diagnostics.Debug.WriteLine(especialidad.id + " " + especialidad.nombre);
                                }
                            }

                            medico.Turnos = horarios;
                            System.Diagnostics.Debug.WriteLine(horarios.ToString());
                            int id = negocio_medico.insertarNuevo(medico);
                            System.Diagnostics.Debug.WriteLine("ID DE MEDICO: " + id);
                            negocio_medico.InsertarEspecialidades(medico, id);
                            negocio_medico.InsertarTurnos(medico, id);
                            Response.Redirect("AdmUsuarios.aspx", false);
                        }
                        else
                        {
                            lblErrorCreacion.Text = "Error: El Email Ingresado pertenece a una cuenta creada.";
                        }
                        break;
                    case 3:
                        user.email = txtEmail.Text;
                        user.password_hash = txtPassword.Text;
                        user.rol_type = UserRole.Recepcionista;
                        user.id = negocio_usuario.insertarNuevo(user);
                        if(user.id > 0)
                        {
                            Recepcionista recepcionista = new Recepcionista(user);
                            negocio_recepcionista.registrarRecepcionista(recepcionista);
                            Response.Redirect("AdmUsuarios.aspx", false);
                        }

                        break;

                }

            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdmUsuarios.aspx");
        }

        protected void ddlUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlUserRole.SelectedIndex)
            {
                case 1:
                    horarios.Clear();
                    Session["Horarios"] = horarios;
                    BindGridView();
                    txtNombre.Visible = false;
                    txtApellido.Visible = false;
                    txtFechaNac.Visible = false;
                    cblEspecialidades.Visible = false;
                    txtbEspecialidad.Visible = false;
                    btnAgregar.Visible = false;
                    lbEspecialidades.Visible = false;
                    lblHorarios.Visible = false;
                    txtHoraInicio.Visible = false;
                    txtHoraFinal.Visible = false;
                    BtnHorario.Visible = false;
                    ddlDia.Visible = false;
                    lblErrorCreacion.Visible = false;
                    lblErrorEspecialidad.Visible = false;
                    lblErrorHorarios.Visible = false;
                    dgvHorarios.Visible = false;
                    break;
                case 2:
                    horarios.Clear();
                    Session["Horarios"] = horarios;
                    BindGridView();
                    txtNombre.Visible = true;
                    txtApellido.Visible = true;
                    txtFechaNac.Visible = true;
                    cblEspecialidades.Visible = true;
                    txtbEspecialidad.Visible = true;
                    btnAgregar.Visible = true;
                    lbEspecialidades.Visible = true;
                    lblHorarios.Visible = false;
                    txtHoraInicio.Visible = true;
                    txtHoraFinal.Visible = true;
                    BtnHorario.Visible = true;
                    ddlDia.Visible = true;
                    lblErrorCreacion.Visible = false;
                    lblErrorEspecialidad.Visible = false;
                    lblErrorHorarios.Visible = false;
                    dgvHorarios.Visible = true;
                    break;
                case 3:
                    horarios.Clear();
                    Session["Horarios"] = horarios;
                    BindGridView();
                    txtNombre.Visible = true;
                    txtApellido.Visible = true;
                    txtFechaNac.Visible = true;
                    cblEspecialidades.Visible = false;
                    txtbEspecialidad.Visible = false;
                    btnAgregar.Visible = false;
                    lbEspecialidades.Visible = false;
                    lblHorarios.Visible = false;
                    txtHoraInicio.Visible = false;
                    txtHoraFinal.Visible = false;
                    BtnHorario.Visible = false;
                    ddlDia.Visible = false;
                    lblErrorCreacion.Visible = false;
                    lblErrorEspecialidad.Visible = false;
                    lblErrorHorarios.Visible = false;
                    dgvHorarios.Visible = false;
                    break;
                case 0:
                    horarios.Clear();
                    Session["Horarios"] = horarios;
                    BindGridView();
                    txtNombre.Visible = false;
                    txtApellido.Visible = false;
                    txtFechaNac.Visible = false;
                    cblEspecialidades.Visible = false;
                    txtbEspecialidad.Visible = false;
                    btnAgregar.Visible = false;
                    lbEspecialidades.Visible = false;
                    lblHorarios.Visible = false;
                    txtHoraInicio.Visible = false;
                    txtHoraFinal.Visible = false;
                    BtnHorario.Visible = false;
                    ddlDia.Visible = false;
                    lblErrorCreacion.Visible = false;
                    lblErrorEspecialidad.Visible = false;
                    lblErrorHorarios.Visible = false;
                    dgvHorarios.Visible = false;
                    break;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            EspNegocio negocio = new EspNegocio();

            try
            {
                string especialidad = txtbEspecialidad.Text;
                if (!(string.IsNullOrEmpty(especialidad)))
                {
                    if (negocio.AgregarEspecialidad(especialidad))
                    {
                        txtbEspecialidad.Text = "";
                        cblEspecialidades.DataSource = negocio.listar();
                        cblEspecialidades.DataTextField = "nombre";
                        cblEspecialidades.DataValueField = "id";
                        cblEspecialidades.DataBind();
                        lblErrorEspecialidad.Text = "";
                    }
                    else
                    {
                        txtbEspecialidad.Text = "";
                        lblErrorEspecialidad.Text = "Error: La especialidad ya existe";
                    }
                }else
                {
                    txtbEspecialidad.Text = "";
                    lblErrorEspecialidad.Text = "Error: no se puede ingresar una especialidad en blanco";
                }
            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }
        }

        protected void BtnHorario_Click(object sender, EventArgs e)
        {
            string dia = ddlDia.SelectedValue;
            TimeSpan horaInicio;
            TimeSpan horaFinal;

            // Validar formato de hora
            if (!TimeSpan.TryParse(txtHoraInicio.Text, out horaInicio))
            {
                lblErrorHorarios.Text = "Formato de hora de inicio inválido. Use HH:mm.";
                lblErrorHorarios.Visible = true;
                return;
            }

            if (!TimeSpan.TryParse(txtHoraFinal.Text, out horaFinal))
            {
                lblErrorHorarios.Text = "Formato de hora final inválido. Use HH:mm.";
                lblErrorHorarios.Visible = true;
                return;
            }

            // Validar que la hora de inicio sea anterior a la hora final
            if (horaInicio >= horaFinal)
            {
                lblErrorHorarios.Text = "La hora de inicio debe ser anterior a la hora final.";
                lblErrorHorarios.Visible = true;
                return;
            }

            // Agregar o actualizar el horario en el diccionario
            if (horarios.ContainsKey(dia))
            {
                // Actualizar el horario existente
                horarios[dia].HoraInicio = horaInicio;
                horarios[dia].HoraFinal = horaFinal;
            }
            else
            {
                // Agregar un nuevo horario
                horarios[dia] = new Horario
                {
                    Dia = dia,
                    HoraInicio = horaInicio,
                    HoraFinal = horaFinal
                };
            }

            Session["Horarios"] = horarios;
            BindGridView();
            // Limpiar campos y ocultar mensaje de error
            txtHoraInicio.Text = "";
            txtHoraFinal.Text = "";
            lblErrorHorarios.Visible = false;
        }
    }
}