using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class SolicitudResultado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarDatosSolicitante();
                CargarDatosSolicitud();
            }
        }
        private void CargarDatosSolicitante()
        {
            if (Session["SolicitanteID"] != null && Session["SolicitanteID"].ToString() != "")
            {
                SqlDataReader dr = Solicitante.ObtenerDatosSolicitante(Convert.ToInt32(Session["SolicitanteID"]));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblTitulo2.Text = "Tipo de solicitud: [" + Session["NombreTipoSolicitud"] + "]";
                    }
                }
                dr.Close();
            }
            else
            {
                Response.Redirect("SeleccionarTipoSolicitud.aspx");
            }
        }
        private void CargarDatosSolicitud()
        {
            if (Session["SolicitudID"] != null && Session["SolicitudID"].ToString() != "")
            {
                SqlDataReader dr = Solicitud.ObtenerDatosSolicitud(Convert.ToInt32(Session["SolicitudID"]));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblNumeroSOlicitud.Text = dr["SolicitudID"].ToString();
                        lblRemitido.Text = dr["NombreTipoRemitido"].ToString();
                        lblCedulaSolicitante.Text = dr["CedulaSolicitante"].ToString();
                        lblSolicitanteNombre.Text = dr["SolicitanteNombre"].ToString();
                        lblRifOrganizacion.Text = dr["RifOrganizacion"].ToString();
                        lblNombreOrganizacion.Text = dr["NombreOrganizacion"].ToString();
                    }
                }
                dr.Close();
                LimpiarVariablesSession();
            }
            else
            {
                Response.Redirect("SeleccionarTipoSolicitud.aspx");
            }
        }
        private void LimpiarVariablesSession()
        {
            Session.Remove("SolicitudID");
            Session.Remove("TipoSolicitudID");
            Session.Remove("SolicitanteID");
            Session.Remove("OrganizacionID");
            Session.Remove("RifOrganizacion");
            Session.Remove("TipoSolicitudID");
            Session.Remove("NombreTipoSolicitud");
            Session.Remove("TipoSolicitanteID");
            Session.Remove("CedulaSaime");
            Session.Remove("NombreSaime");
            Session.Remove("ApellidoSaime");
            Session.Remove("SerialCarnetPatria");
        }
        protected void btnNueva_Click(object sender, EventArgs e)
        {
            LimpiarVariablesSession();
            Response.Redirect("SeleccionarTipoSolicitud.aspx");
        }
    }
}