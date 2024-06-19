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
    public partial class CreacionPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {
                    int id;
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        List<Paciente> temporales = Session["listaPacientes"] as List<Paciente>;

                        if (temporales != null)
                        {
                            Paciente seleccionado = temporales.Find(x => x.id == id);

                            if (seleccionado != null)
                            {
                                txtNombre.Text = seleccionado.nombre;
                                txtApellido.Text = seleccionado.apellido;
                                txtEmail.Text = seleccionado.email;
                                txtTelefono.Text = seleccionado.telefono;
                                txtNacimiento.Text = seleccionado.nacimiento.ToString("yyyy-MM-dd");
                                txtDni.Text = seleccionado.dni;
                                chbox.Checked = seleccionado.activo;

                                btnCrear.Text = "Editar";
                            }
                            else
                            {
                                lblError.Text = "Paciente no encontrado.";
                            }
                        }
                        else
                        {
                            lblError.Text = "No se encontró la lista de pacientes en la sesión.";
                        }
                    }
                    else
                    {
                        lblError.Text = "ID de paciente no válido.";
                    }
                }
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string email = txtEmail.Text;
                string telefono = txtTelefono.Text;
                DateTime nacimiento;
                if (!DateTime.TryParse(txtNacimiento.Text, out nacimiento))
                {
                    lblError.Text = "La fecha de nacimiento no es válida.";
                    return;
                }
                string dni = txtDni.Text;
                bool estado = chbox.Checked;

                Paciente nuevoPaciente = new Paciente
                {
                    nombre = nombre,
                    apellido = apellido,
                    email = email,
                    telefono = telefono,
                    nacimiento = nacimiento,
                    dni = dni,
                    activo = estado
                };

                if (Request.QueryString["id"] != null)
                {
                    int id;
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        nuevoPaciente.id = id; 
                        pacienteNegocio.actualizar(nuevoPaciente);
                    }
                    else
                    {
                        lblError.Text = "ID de paciente no válido.";
                        return;
                    }
                }
                else
                {
                    pacienteNegocio.insertarNuevo(nuevoPaciente);
                }

                Session["listaPacientes"] = null;

                Response.Redirect("AdmPacientes.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error inesperado: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    int id;
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        PacienteNegocio pacienteNegocio = new PacienteNegocio();
                        pacienteNegocio.eliminar(id);

                        List<Paciente> temporales = Session["listaPacientes"] as List<Paciente>;
                        if (temporales != null)
                        {
                            Paciente pacienteAEliminar = temporales.Find(x => x.id == id);
                            if (pacienteAEliminar != null)
                            {
                                temporales.Remove(pacienteAEliminar);
                                Session["listaPacientes"] = temporales;
                            }
                        }

                        Response.Redirect("AdmPacientes.aspx");
                    }
                    else
                    {
                        lblError.Text = "ID de paciente no válido.";
                    }
                }
                else
                {
                    lblError.Text = "No se proporcionó un ID de paciente.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error inesperado: " + ex.Message;
            }
        }
    }
}