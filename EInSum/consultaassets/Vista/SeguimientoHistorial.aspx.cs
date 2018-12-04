using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class SeguimientoHistorial : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblTitulo.Text = "Historial del seguimiento solicitud número [" + Convert.ToInt32(Session["SolicitudParaSeguimientoID"].ToString()) +"]";
                CargarSeguimientoHistorial();
                AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó historial de seguimiento a la solicitud: " + Convert.ToInt32(Session["SolicitudParaSeguimientoID"]), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
            }
        }
        private void CargarSeguimientoHistorial()
        {
            try
            {
                DataSet ds = Seguimiento.ObtenerHistorialSeguimientoSolicitud(Convert.ToInt32(Session["SolicitudParaSeguimientoID"].ToString()));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}