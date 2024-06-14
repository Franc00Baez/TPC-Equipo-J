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
    public partial class CreacionMedico : System.Web.UI.Page
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
                        List <Medico> temporales = Session["listaMedicos"] as List<Medico>;

                        if (temporales != null)
                        {
                            Medico seleccionado = temporales.Find(x => x.id == id);

                            if (seleccionado != null)
                            {
                                txtNombre.Text = seleccionado.nombre;
                                txtApellido.Text = seleccionado.apellido;                              
                                txtNacimiento.Text = seleccionado.nacimiento.ToString("yyyy-MM-dd");

                                btnCrear.Text = "Editar";
                            }
                            else
                            {
                                lblError.Text = "Médico no encontrado.";
                            }
                        }
                        else
                        {
                            lblError.Text = "No se encontró la lista de médicos en la sesión.";
                        }
                    }
                    else
                    {
                        lblError.Text = "ID de médico no válido.";
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            MedNegocio medicoNegocio = new MedNegocio();
            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                DateTime nacimiento;
                if (!DateTime.TryParse(txtNacimiento.Text, out nacimiento))
                {
                    lblError.Text = "La fecha de nacimiento no es válida.";
                    return;
                }

                Medico nuevoMedico = new Medico
                {
                    nombre = nombre,
                    apellido = apellido,
                    nacimiento = nacimiento,
                };

                if (Request.QueryString["id"] != null)
                {
                    int id;
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {
                        nuevoMedico.id = id;
                        medicoNegocio.actualizar(nuevoMedico);
                    }
                    else
                    {
                        lblError.Text = "ID de médico no válido.";
                        return;
                    }
                }
                else
                {
                    medicoNegocio.insertarNuevo(nuevoMedico);
                }

                Session["listaMedicos"] = null;

                Response.Redirect("AdmMedicos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error inesperado: " + ex.Message;
            }
        }
    }
}