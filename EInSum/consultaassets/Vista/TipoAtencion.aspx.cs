using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class TipoAtencion : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

        }
        private void ProcesoTipoAtencion()
        {
            int codigoTipoAtencion;
            try
            {
                CTIpoAtencion objetoTipoAtencion = new CTIpoAtencion();
                objetoTipoAtencion.TipoAtencionBrindadaID = Convert.ToInt32(hdnTipoAtencionID.Value);
                objetoTipoAtencion.NombreTipoAtencionBrindada = txtNombreTipoAtencion.Text.ToUpper().Trim();

                codigoTipoAtencion = TipoAtencion.InsertarTipoAtencion(objetoTipoAtencion);
                if (codigoTipoAtencion > 0)
                {
                    messageBox.ShowMessage("Registro actualizado.");
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo tipo de atención: " + txtNombreTipoAtencion.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoTipoAtencion();
        }
    }
}