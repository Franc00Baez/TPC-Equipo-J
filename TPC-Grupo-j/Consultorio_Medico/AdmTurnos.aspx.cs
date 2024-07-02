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
    public partial class AdmTurnos : System.Web.UI.Page
    {
        public List<Turno> ListaTurnos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NuevaLista"] == null)
                {
                    TurnoNegocio negocio = new TurnoNegocio();
                    Session.Add("NuevaLista", negocio.listar());
                    ListaTurnos = negocio.listar();
                }
                rep1.DataSource = Session["NuevaLista"];
                rep1.DataBind();
            }
        }

        protected void rep1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}