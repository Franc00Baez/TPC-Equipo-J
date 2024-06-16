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
    public partial class AdmMedicos : System.Web.UI.Page
    {
        public List<Medico> listaMedicos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarMedicos();
            }
        }
        private void cargarMedicos()
        {
            MedicoNegocio negocio = new MedicoNegocio();
            listaMedicos = negocio.listar();
            Session["listaMedicos"] = listaMedicos;

            dgv.DataSource = listaMedicos;
            dgv.DataBind();
        }

        protected void dgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgv.SelectedDataKey.Value.ToString();
            Response.Redirect("CreacionMedico.aspx?id=" + id);
        }
    }
}