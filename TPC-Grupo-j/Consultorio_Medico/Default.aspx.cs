using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Consultorio_Medico
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ID"] != null )
                    {
                        Usuario logueado;
                        UsuarioNegocio negocio = new UsuarioNegocio();

                        logueado = negocio.BuscarUsuarioPorId((int)Session["ID"]);
                        Session.Add("usuario", logueado);
                        Session.Add("Rol", logueado.rol_type);
                    }
                }

            }
            catch (Exception ex)
            {
                Seguridad.ManejarExcepcion(ex, HttpContext.Current);
            }
            
        }
    }
}