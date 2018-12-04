using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class SeguimientoSeleccion : Seguridad.SeguridadAuditoria
    {
        private static int tipoRemitidoID = 0;
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                tipoRemitidoID = 0;
                EstablecerTitulo();
                LimpiarSession();
            }
        }
        private void EstablecerTitulo()
        {
            string codigoObjeto = Request.QueryString["CodigoObjeto"];
            switch (codigoObjeto)
            {
                case "1023":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Cobranzas";
                    tipoRemitidoID = 2;
                    break;
                case "1026":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Financiamiento";
                    tipoRemitidoID = 3;
                    break;
                case "1027":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Movilidad Estudiantil";
                    tipoRemitidoID = 4;
                    break;
                case "1028":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Asesoria Legal";
                    tipoRemitidoID = 5;
                    break;
                case "1029":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Tecnica Automotriz";
                    tipoRemitidoID = 6;
                    break;
                case "1030":
                    lblTitulo.Text = "Consulta de Seguimiento Especialista de Control y Seguimiento OAC";
                    tipoRemitidoID = 7;
                    break;
                default:
                    break;
            }
        }
        private void ProcesoSeleccion()
        {
            string codigoObjeto = Request.QueryString["CodigoObjeto"];
            switch (codigoObjeto)
            {
                case "1023":
                    Session["NombreGerenciaSeguimiento"] = "Cobranzas";
                    break;
                case "1026":
                    Session["NombreGerenciaSeguimiento"] = "Financiamiento";
                    break;
                case "1027":
                    Session["NombreGerenciaSeguimiento"] = "Movilidad";
                    break;
                case "1028":
                    Session["NombreGerenciaSeguimiento"] = "Legal";
                    break;
                case "1029":
                    Session["NombreGerenciaSeguimiento"] = "TecnicaAutomotriz";
                    break;
                case "1030":
                    Session["NombreGerenciaSeguimiento"] = "OAC";
                    break;
            }
            Response.Redirect("SeguimientoOAC.aspx");
        }
        private void CargarConsulta()
        {
            try
            {
                int codigoSolicitud = 0;
                if(txtSolicitud.Text.Trim() != "")
                {
                    codigoSolicitud = Convert.ToInt32(txtSolicitud.Text.Trim());
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó para realizar seguimiento solicitud: " + txtSolicitud.Text, System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
                else
                {
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó todas las solicitudes para realizar seguimiento", System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                }
                DataSet ds = Seguimiento.ObtenerSolicitudEnSeguimiento(codigoSolicitud, tipoRemitidoID);
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
                Session["SolicitudIDParaSeguimiento"] = Convert.ToInt32(e.CommandArgument.ToString());
                Session["SolicitudParaSeguimientoID"] = Convert.ToInt32(e.CommandArgument.ToString());
                AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Seleccionó para realizar seguimiento la solicitud: " + e.CommandArgument.ToString(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                if (e.CommandName == "ConsultarSeguimiento")
                {
                    ProcesoSeleccion();
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void LimpiarSession()
        {
            Session.Remove("SolicitudParaSeguimientoID");
            Session.Remove("SolicitudIDParaSeguimiento");
            Session.Remove("NombreGerenciaSeguimiento");
        }
    }
}