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

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            try
            {
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string email = txtEmail.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                DateTime nacimiento;
                if (!DateTime.TryParse(txtNacimiento.Text, out nacimiento))
                {
                    lblError.Text = "La fecha de nacimiento no es válida.";
                    return;
                }
                string dni = txtDni.Text.Trim();

                Paciente nuevoPaciente = new Paciente
                {
                    nombre = nombre,
                    apellido = apellido,
                    email = email,
                    telefono = telefono,
                    nacimiento = nacimiento,
                    dni = dni,
                    activo = true 
                };

                pacienteNegocio.insertarNuevo(nuevoPaciente);

                lblError.Text = "Paciente creado exitosamente.";
                lblError.CssClass = "success-message";
                Response.Redirect("AdmPacientes.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error inesperado: " + ex.Message;
                lblError.CssClass = "error-message";
            }
        }
    }
}