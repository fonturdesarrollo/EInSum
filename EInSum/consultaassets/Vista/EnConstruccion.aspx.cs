using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli.Vista
{
    public partial class EnConstruccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString.Keys.Count > 0)
                {
                    messageBox.ShowMessage("Hola " + Request.QueryString["Cedula"] + " " + Request.QueryString["Nombre"] + " " + Request.QueryString["ID"]);
                }
            }
        }
    }
}