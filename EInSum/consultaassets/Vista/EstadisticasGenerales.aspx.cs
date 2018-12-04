using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    [System.Runtime.InteropServices.Guid("41556A1F-56A6-41B7-9509-F6F5153F4487")]
    public partial class EstadisticasGenerales : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtFechaRegistro.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                CargarPorEstado();
                CargarPorTipoSolicitud();
                CargarPorTipoRemitido();
                CargarTotales();
            }
        }
        private void CargarTotales()
        {
            try
            {
                SqlDataReader dr = Estadisticas.ObtenerTotalSolicitudes(txtFechaRegistro.Text);
                
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        lblTitulo.Text = "Total solicitudes registradas en la fecha seleccionada: ["  + dr["Total"] +"]";
                    }
                }

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message);
            }
        }
        private void CargarPorEstado()
        {
            try
            {
                string fechaSolicitud = "";

                fechaSolicitud = txtFechaRegistro.Text;
                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorEstado(fechaSolicitud);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }  
        }
        private void CargarPorTipoSolicitud()
        {
            try
            {
                string fechaSolicitud = "";

                fechaSolicitud = txtFechaRegistro.Text;
                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorTipoSolicitud(fechaSolicitud);
                this.gridDetalle2.DataSource = ds.Tables[0];
                this.gridDetalle2.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void CargarPorTipoRemitido()
        {
            try
            {
                string fechaSolicitud = "";

                fechaSolicitud = txtFechaRegistro.Text;
                DataSet ds = Estadisticas.ObtenerDetalleEstadisticaPorTipoRemitido(fechaSolicitud);
                this.gridDetalle3.DataSource = ds.Tables[0];
                this.gridDetalle3.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarPorEstado();
            CargarPorTipoSolicitud();
            CargarPorTipoRemitido();
            CargarTotales();
        }
    }
}