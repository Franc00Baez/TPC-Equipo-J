using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consultorio_Medico
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Errores"] != null)
            {
                List<string> errores = (List<string>)Session["Errores"];
                litErrores.Text = "<ul>";
                foreach (string error in errores)
                {
                    litErrores.Text += $"<li>{error}</li>";
                }
                litErrores.Text += "</ul>";
            }
        }
    }
}