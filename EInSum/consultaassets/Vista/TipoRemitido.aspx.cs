using System;
using System.Web;
namespace Atensoli
{
    public partial class TipoRemitido : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

        }
        private void ProcesoTipoRemitido()
        {
            int codigoTipoRemitido;
            try
            {
                CTipoRemitido objetoTipoRemitido = new CTipoRemitido();
                objetoTipoRemitido.TipoRemitidoID = Convert.ToInt32(hdnTipoRemitidoID.Value);
                objetoTipoRemitido.NombreTipoRemitido = txtNombreTipoRemitido.Text.ToUpper().Trim();

                codigoTipoRemitido = TipoRemitido.InsertarTipoRemitido(objetoTipoRemitido);
                if (codigoTipoRemitido > 0)
                {
                    messageBox.ShowMessage("Registro actualizado.");
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo tipo de remitido: " + txtNombreTipoRemitido.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoTipoRemitido();
        }
    }
}