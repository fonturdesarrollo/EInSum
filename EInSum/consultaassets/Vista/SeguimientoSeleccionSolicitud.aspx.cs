using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class SeguimientoSeleccionSolicitud : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                EstablecerTitulo();
            }
        }
        private void EstablecerTitulo()
        {
            string codigoObjeto = Request.QueryString["CodigoObjeto"];
            switch (codigoObjeto)
            {
                case "1023":
                    lblTitulo.Text = "Selección de Solicitud para Seguimiento Especialista de Cobranzas";
                    break;
                case "1026":
                    lblTitulo.Text = "Selección de Solicitud para Seguimiento Especialista de Financiamiento";
                    break;
                case "1027":
                    lblTitulo.Text = "Selección de Solicitud para Seguimiento Especialista de Movilidad Estudiantil";
                    break;
                case "1028":
                    lblTitulo.Text = "Selección de Solicitud para Seguimiento Especialista de Asesoria Legal";
                    break;
                case "1029":
                    lblTitulo.Text = "Selección de Solicitud para Seguimiento Especialista de Tecnica Automotriz";
                    break;
                case "1030":
                    lblTitulo.Text = "Selección de Solicitud para Seguimiento Especialista de Control y Seguimiento OAC";
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
                DataSet ds = ConsultarSolicitud.ObtenerConsultaSolicitud(txtCedula.Text.Trim(), 0);
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
                Session["SolicitudParaSeguimientoID"] = Convert.ToInt32(e.CommandArgument.ToString());
                if (e.CommandName == "RealizarSeguimiento")
                {
                    ProcesoSeleccion();
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}