using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class TipoOrganizacion : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

        }
        private void ProcesoTipoOrganizacion()
        {
            int codigoTipoOrganizacion;
            try
            {
                CTipoOrganizacion objetoTipoOrganizacion = new CTipoOrganizacion();
                objetoTipoOrganizacion.TipoOrganizacionID = Convert.ToInt32(hdnTipoOrganizacionID.Value);
                objetoTipoOrganizacion.NombreTipoOrganizacion = txtNombreTipoOrganizacion.Text.ToUpper().Trim();

                codigoTipoOrganizacion = TipoOrganizacion.InsertarTipoOrganizacion(objetoTipoOrganizacion);
                if (codigoTipoOrganizacion > 0)
                {
                    messageBox.ShowMessage("Registro actualizado.");
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo tipo de organización: " + txtNombreTipoOrganizacion.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoTipoOrganizacion();
        }
    }
}