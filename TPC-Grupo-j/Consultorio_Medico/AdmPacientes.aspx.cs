using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Consultorio_Medico
{
    public partial class AdmPacientes : System.Web.UI.Page
    {
        public List<Paciente> listaPacientes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPacientes();
            }
        }

        private void cargarPacientes()
        {
            PacienteNegocio negocio = new PacienteNegocio();
            listaPacientes = negocio.listar();
            Session["listaPacientes"] = listaPacientes;

            dgv.DataSource = listaPacientes;
            dgv.DataBind();
        }

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgv.SelectedDataKey.Value.ToString();
            Response.Redirect("CreacionPaciente.aspx?id=" + id);
        }
    }
}