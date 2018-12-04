using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class TipoSoporte : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

        }
        private void ProcesoTipoSoporte()
        {
            int codigoTipoSoporte;
            try
            {
                CTipoSoporte objetoTipoSoporte = new CTipoSoporte();
                objetoTipoSoporte.TipoSoporteID = Convert.ToInt32(hdnTipoSoporteID.Value);
                objetoTipoSoporte.NombreTipoSoporte = txtNombreTipoSoporte.Text.ToUpper().Trim();

                codigoTipoSoporte = TipoSoporte.InsertarTipoSoporte(objetoTipoSoporte);
                if (codigoTipoSoporte > 0)
                {
                    messageBox.ShowMessage("Registro actualizado.");
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo tipo de soporte físico: " + txtNombreTipoSoporte.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoTipoSoporte();
        }
    }
}