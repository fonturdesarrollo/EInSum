using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class TipoSolicitante : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

        }
        private void ProcesoTipoSolicitante()
        {
            int codigoTipoSolicitante;
            try
            {
                CTipoSolicitante objetoTipoSolicitante = new CTipoSolicitante();
                objetoTipoSolicitante.TipoSolicitanteID = Convert.ToInt32(hdnTipoSolicitanteID.Value);
                objetoTipoSolicitante.NombreTipoSolicitante = txtNombreTipoSolicitante.Text.ToUpper().Trim();

                codigoTipoSolicitante = TipoSolicitante.InsertarTipoSolicitante(objetoTipoSolicitante);
                if (codigoTipoSolicitante > 0)
                {
                    messageBox.ShowMessage("Registro actualizado.");
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo tipo de solicitante: " + txtNombreTipoSolicitante.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoTipoSolicitante();
        }
    }
}