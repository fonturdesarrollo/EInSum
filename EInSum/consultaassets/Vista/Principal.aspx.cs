using Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session,999) == false)
            {
                if (this.Session["UserID"] == null)
                {
                    Server.Transfer("Logout.aspx");
                }
                Response.Redirect("/Index.aspx");
            }
        }
    }
}