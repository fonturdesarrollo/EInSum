using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class ConsultarSolicitud : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               
            }
        }
        private void CargarConsulta()
        {
            try
            {
                int cedulaConsulta = 0;
                if(txtCedula.Text != "")
                {
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó la solicitud en seguimiento a la cedula numero: " + txtCedula.Text, System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                    cedulaConsulta = Convert.ToInt32(txtCedula.Text.Trim());
                }
                else
                {
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó todas las solicitudes en seguimiento", System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
                DataSet ds = ConsultarSolicitud.ObtenerConsultaSolicitudSeguimientoAbierto(cedulaConsulta);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarConsulta();
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                Solicitud.ActualizarConsultaSolicitud(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session["UserID"]));
                CargarConsulta();
                messageBox.ShowMessage("Consulta actualizada");

            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
    }
}