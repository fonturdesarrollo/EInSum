using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class TipoSolicitud : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
        }
        private void ProcesoTipoSolicitud()
        {
            int codigoTipoSolicitud;
            try
            {
                CTipoSolicitud objetoTipoSolicitud = new CTipoSolicitud();
                objetoTipoSolicitud.TipoSolicitudID = Convert.ToInt32(hdnTipoSolicitudID.Value);
                objetoTipoSolicitud.NombreTipoSolicitud = txtNombreTipoSolicitud.Text.Trim();
                objetoTipoSolicitud.DescripcionTipoSolicitud = txtDescripcionTipoSolicitud.Text.Trim();

                codigoTipoSolicitud = TipoSolicitud.InsertarTipoSolicitud(objetoTipoSolicitud);
                if (codigoTipoSolicitud > 0)
                {
                    messageBox.ShowMessage("Registro actualizado.");
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo tipo de solicitud: " + txtNombreTipoSolicitud.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoTipoSolicitud();
        }
    }
}