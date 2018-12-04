using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguridad
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["login"] != null)
                {
                    Response.Cookies["login"].Value = "";
                    Response.Cookies["password"].Value = "";

                    Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
                }
                Session.Clear();
                Session.Abandon();
                Response.Redirect("../Index.aspx");
    }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message);
            }
        }
    }
}