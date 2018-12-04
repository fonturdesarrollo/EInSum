using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class TipoReferencia : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        private void ProcesoTipoReferencia()
        {
            int codigoTipoReferencia;
            try
            {
                CTipoReferencia objetoTipoReferencia = new CTipoReferencia();
                objetoTipoReferencia.TipoReferenciaSolicitudID = Convert.ToInt32(hdnTipoReferenciaID.Value);
                objetoTipoReferencia.NombreTipoReferenciaSolicitud = txtNombreReferencia.Text.ToUpper().Trim();

                codigoTipoReferencia = TipoReferencia.InsertarTipoReferencia(objetoTipoReferencia);
                if (codigoTipoReferencia > 0)
                {
                    messageBox.ShowMessage("Registro actualizado.");
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo tipo de referencia solicitud: " + txtNombreReferencia.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoTipoReferencia();
        }
    }
}