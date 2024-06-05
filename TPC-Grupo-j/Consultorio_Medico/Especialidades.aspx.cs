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
    public partial class Especialidades : System.Web.UI.Page
    {
        public List<Especialidad> ListaEspecialidad { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NuevaLista"] == null)
                {
                    EspNegocio negocio = new EspNegocio();
                    Session.Add("NuevaLista", negocio.listar());
                    ListaEspecialidad = negocio.listar();
                }
                Rep1.DataSource = Session["NuevaLista"];
                Rep1.DataBind();
            }

        }

        protected void Rep1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}