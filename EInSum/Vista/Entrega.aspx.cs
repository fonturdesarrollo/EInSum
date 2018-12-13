using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eisum
{
    public partial class Entrega : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }
        private void CargarDetalleEntregaInsumosPlaca()
        {
            try
            {
                DataSet ds = EntregaInsumoDetalleJornada.ObtenerDetalleEntregaJornada(0, txtPlaca.Text.ToUpper(),0);
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void ProcesoActualizar()
        {
            try
            {
                if(EsTodoCorrecto())
                {
                    EntregaInsumoDetalleJornada.ActualizarPlacaRecepcionInsumo(txtPlaca.Text.ToUpper(), Convert.ToInt32(Session["UserId"]));
                    messageBox.ShowMessage("Registro actualizado");
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Aasigó insumo a la placa: " + txtPlaca.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                    NuevoRegistro();
                }

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
           
        }
        private bool EsTodoCorrecto()
        {
            bool resultado = true;    
            if(hdnBeneficiarioID.Value =="0")
            {
                resultado = false;
                messageBox.ShowMessage("Debe seleccionar la placa de la lista");
            }
            return resultado;
            
        }
        private void NuevoRegistro()
        {
            hdnBeneficiarioID.Value = "0";
            txtPlaca.Text = string.Empty;
            txtCedulaBeneficiario.Text = string.Empty;
            txtRifOrganizacion.Text = string.Empty;
            txtSerialCarroceria.Text = string.Empty;
            txtPuestos.Text = string.Empty;
            txtAñoVehiculo.Text = string.Empty;
            txtTipoVehiculo.Text = string.Empty;
            gridDetalle.DataSource = null;
            gridDetalle.DataBind();
        }
        protected void ButtonTest_Click(object sender, EventArgs e)
        {
            CargarDetalleEntregaInsumosPlaca();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoActualizar();
        }

        protected void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }
    }
}